import RPi.GPIO as GPIO
import pigpio
from gpiozero import TonalBuzzer
from gpiozero import LED
from gpiozero import AngularServo
from gpiozero.pins.pigpio import PiGPIOFactory

import time
import calendar
from datetime import date, timedelta, datetime

import threading

import cv2
import pytesseract
import socket
import psycopg2

import re
import json
from configparser import ConfigParser
import sys

#Informações do Servidor
global HOST
global PORT
global TOKEN
HOST = "127.0.0.1"
PORT = 5000
TOKEN = "9Z5cn^tY24@T0iLu9teK3yW*"

global DataUltimoMovimento
global PlacaUltimoMovimento
DataUltimoMovimento = datetime.today()
PlacaUltimoMovimento = 'n/a'

#Importação do xml dos treinamentos
identificador_placa_antiga =  cv2.CascadeClassifier("/home/main/AutoPark/placa_cinza.xml")
identificador_placa_mercosul =  cv2.CascadeClassifier(cv2.data.haarcascades +
                                                      "haarcascade_russian_plate_number.xml")

#Definição das portas dos componentes
buzzer = 23 
ledverde = 27
ledvermelho = 22
SensorPresenca = 25
EchoProximidade = 26
TriggerProximidade = 6
ServoMotor = 24

GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)
GPIO.setup(EchoProximidade, GPIO.IN)  # Echo Proximidade
GPIO.setup(TriggerProximidade, GPIO.OUT)  # Trigger Proximidade
GPIO.setup(SensorPresenca, GPIO.IN)  # Sinal Sensor Presença
pigpio_factory = PiGPIOFactory()

AnguloFechado = 180
AnguloAberto = 0
global TempoFecharCancela
TempoFecharCancela = 7
LVerde = LED(ledverde)
LVermelho = LED(ledvermelho)
servo = AngularServo(ServoMotor, min_angle=0, max_angle=180, min_pulse_width=0.0011,
                     max_pulse_width=0.0015, pin_factory=pigpio_factory)
servo.angle = AnguloFechado;

b = TonalBuzzer(buzzer, pin_factory=pigpio_factory)
b.stop()
LVerde.on()
LVermelho.on()
time.sleep(0.4)
LVerde.off()
LVermelho.off()

lock = threading.Lock() #Lock é utilizado nos threads para não haver conflito entre os mesmos

def Finalizar():
    GPIO.cleanup()
    socket.close()
    sys.exit()

def config(filename='/home/main/AutoPark/database.ini', section='postgresql'):
    parser = ConfigParser()
    parser.read(filename)
    db = {}
    if parser.has_section(section):
        params = parser.items(section)
        for param in params:
            db[param[0]] = param[1]
    else:
        raise Exception("Section {0} not found in the {1} file".format(section, filename))
    return db

def PegarConexao():
    try:
        params = config()
        conn = psycopg2.connect(**params)
        return conn
    except Exception as e:
        print('Falha na conexão com o banco de dados %s' %e)
        Finalizar()


def VerificarPresenca():
    # Verificar por 2 segundos se há presença
    t_end = time.time() + 2
    while time.time() < t_end:
        status = GPIO.input(SensorPresenca)
        if (status == 1):
            return True
    # Retorna falso pois não achou presença
    return False

def ObterPlaca(IndexCam):
    video = cv2.VideoCapture(IndexCam)
    if (video.isOpened() == False):
        return None
    try:
        #Detecta a camera por 10 segundos
        t_end = time.time() + 10
        while time.time() < t_end:            
            ret, frame = video.read()
            
            # Converte o video de RGB para escala de cinza, diminuindo o tamanho da matriz
            gray_video = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
            #Remove Ruídos
            gray_video = cv2.bilateralFilter(gray_video, 11, 17, 17) 
            Detectar_PlacaAntiga = identificador_placa_antiga.detectMultiScale(gray_video,
                                                                               scaleFactor=1.2, minNeighbors=5, minSize=(25, 25))
            Detectar_PlacaMercosul = identificador_placa_mercosul.detectMultiScale(gray_video,
                                                                                   scaleFactor=1.2, minNeighbors=5, minSize=(25, 25))
            for (x, y, w, h) in Detectar_PlacaAntiga:
                imgRoi = gray_video[y:y + h, x:x + w] #Pega a parte do frame onde foi encontrada a placa
                (thresh, im_bw) = cv2.threshold(imgRoi, 128, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)
                Placa = pytesseract.image_to_string(im_bw)
                Placa = re.sub('[^A-Za-z0-9]+', '', Placa)# Remove lixos
                # Filtro identificando se o número de letras e numeros batem com o padrão das placas do mercosul ou antigas br.
                numeros = 0
                letras = 0
                for c in Placa:
                    if(c.isnumeric()):
                        numeros = numeros + 1
                    else:
                        letras = letras + 1

                if(len(Placa) == 7 and ((numeros == 4 and letras == 3) or  (numeros == 3 and letras == 4))):
                    video.release()
                    return Placa
            for (x, y, w, h) in Detectar_PlacaMercosul:
                imgRoi = gray_video[y:y + h, x:x + w] #Pega a parte do frame onde foi encontrada a placa
                (thresh, im_bw) = cv2.threshold(imgRoi, 128, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)
                Placa = pytesseract.image_to_string(im_bw)
                Placa = re.sub('[^A-Za-z0-9]+', '', Placa)  # Remove lixos

                # Filtro para ver se o número de letras e numeros batem com o padrão das placas mercosul/antigas
                numeros = 0
                letras = 0
                for c in Placa:
                    if (c.isnumeric()):
                        numeros = numeros + 1
                    else:
                        letras = letras + 1
                if (len(Placa) == 7 and ((numeros == 4 and letras == 3) or (numeros == 3 and letras == 4))):
                    video.release()
                    return Placa
            time.sleep(0.16) # Sleep de 16 ms, mais que 7 fps por segundos somente vai utilizar mais CPU.
            
        video.release()
        return None

    except:
        video.release()
        return None

def AbrirCancela():
    LVerde.on()
    b.play("A5")
    time.sleep(0.1)
    b.stop()
    time.sleep(0.2)
    servo.angle = AnguloAberto;
    LVerde.off()


def FecharCancela():
    presenca = VerificarPresenca()
    while (presenca == True):
        presenca = VerificarPresenca()
    LVermelho.on()
    b.play("C5") 
    time.sleep(0.1)
    b.stop()
    time.sleep(0.2)
    servo.angle = AnguloFechado;
    LVermelho.off()


def PegarDistancia():
    GPIO.output(TriggerProximidade, True)
    time.sleep(0.00001)  # Pulsa durante 10 ms
    GPIO.output(TriggerProximidade, False)

    while GPIO.input(EchoProximidade) == 0:  # Inicia a contagem quando o sinal for emitido
        tempo_inicial = time.time()

    while GPIO.input(EchoProximidade) == 1:  # Tempo final é ao receber o sinal refletido
        tempo_final = time.time()

    tempo_total = tempo_final - tempo_inicial
    times = tempo_total * 1000 / 58

    distancia = (tempo_total * 34000) / 2  #  (Tempo * Velocidade do som - 34000 cm/s) / 2 pois o som vai e voltar.
       
    return distancia  # Retorna a distancia em cm.

def ConsultarPlaca(placa):
    try:
        conn = PegarConexao()
        cur = conn.cursor()        
        first = date.today().replace(day=1)
        last_day = calendar.monthrange(int(first.strftime('%Y')),int(first.strftime('%m')))[1]
        last = date.today().replace(day=int(last_day))       
        sql = ("""SELECT MENSALIDADE.STATUS, VEICULO.IDVEICULO FROM VEICULO INNER JOIN MENSALIDADE
                    ON (MENSALIDADE.IDVEICULO = VEICULO.IDVEICULO)
                    WHERE (MENSALIDADE.VENCIMENTO::date BETWEEN ('%s')::date AND ('%s')::date)
                    AND VEICULO.PLACA = '%s'""" % (first, last, placa.upper()))
               
        cur.execute(sql)
        row = cur.fetchone()
        if row is not None:
            Status = (row[0])
            if(Status == 3):
                return (True, row[1]);
            else:
                return None
        else:
            return None
        conn.close()
        cur.close()
    except Exception as exception:
        print("Não foi possível verificar a placa (OCR). %s", str(exception))
        return False


def CriarEntrada(IDVeiculo):
    try:
        conn = PegarConexao()
        cur = conn.cursor()
        cur2 = conn.cursor()        
        now = datetime.now()
        dt_string = now.strftime("%d/%m/%Y %H:%M:%S")        
        Identificador = "IDENTRADA"        
        # seleciona o próximo id da entrada
        cur.execute("SELECT NEXTVAL('%s')" % Identificador)
        IDEntrada = int(cur.fetchone()[0])
        sql = ("""INSERT INTO ENTRADA(IDENTRADA, IDVEICULO, DATAENTRADA, TEMPO, TIPO)
                    VALUES (%d, %d, '%s', NULL, %d)""" % (IDEntrada, IDVeiculo, now, 1))
        cur2.execute(sql)        
        conn.commit()
        conn.close()
        cur.close()
        cur2.close()
        print("""Entrada Registrada: (IDEntrada : %d, IDVeiculo : %d)
                    %s""" % (IDEntrada, IDVeiculo, (now.strftime("%d/%m/%Y %H:%M:%S"))))
    except Exception as exception:
        print("Não foi possível criar Entrada (OCR). %s", str(exception))
        return False   

def CriarSaida(IDVeiculo):
    try:
        conn = PegarConexao()
        cur = conn.cursor()
        cur2 = conn.cursor()        
        now = datetime.now()
        dt_string = now.strftime("%d/%m/%Y %H:%M:%S")
        Identificador = "IDSAIDA"        
        # seleciona o próximo id da entrada
        cur.execute("SELECT NEXTVAL('%s')" % Identificador)
        IDSaida = int(cur.fetchone()[0])
        sql = ("""INSERT INTO SAIDA(IDSAIDA, IDVEICULO, DATASAIDA, TIPO)
                    VALUES (%d, %d, '%s', %d)""" % (IDSaida, IDVeiculo, now, 1))
        cur2.execute(sql)        
        conn.commit()
        conn.close()
        cur.close()
        cur2.close()
        print("""Saída Registrada: (IDSaida : %d, IDVeiculo : %d)
                %s""" % (IDSaida, IDVeiculo, (now.strftime("%d/%m/%Y %H:%M:%S"))))
    except Exception as exception:
        print("Não foi possível criar a Saída (OCR). %s", str(exception))
        return False

def AbrirCancelaOCR(Tipo):    
    #Tipo 0 = Entrada, 1 = Saida
    if(Tipo == 0):
        Placa = ObterPlaca(0)
    else:
        Placa = ObterPlaca(2)    
  
    if (Placa != None):    
        print(Placa)
        retorno = ConsultarPlaca(Placa)
        if(retorno is not None):
            
            global DataUltimoMovimento
            global PlacaUltimoMovimento
            NextTime = DataUltimoMovimento + timedelta(seconds=45)
            if(NextTime > datetime.today()
               and Placa == PlacaUltimoMovimento):
                print("""Movimento repetido detectado, espere 45 segundos.
                    Placa: %s""" % Placa)
                return None
            DataUltimoMovimento = datetime.today()
            PlacaUltimoMovimento = Placa            
            lock.acquire()
            if(Tipo == 0):
                CriarEntrada(retorno[1])
            else:
                CriarSaida(retorno[1])                
            AbrirCancela()
            time.sleep(TempoFecharCancela)
            FecharCancela()
            lock.release()

def IniciarOCR():
    while True:
        distance = PegarDistancia()
        if (distance < 60):
            AbrirCancelaOCR(0)
        time.sleep(3) # +3 segundos até a próxima verificacao

def IniciarOCRSaida():
    while True:
        AbrirCancelaOCR(1)
        time.sleep(3) # +3 segundos até a próxima verificacao

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

def IniciarServidor():
    try:
        print("host: " + HOST)
        server_address = (HOST, PORT)
        sock.bind(server_address)
        sock.listen(1)
        while True:
            # Wait for a connection
            print("Servidor: Aguardando conexão...")
            connection, client_address = sock.accept()

            try:
                print("Servidor: Conexão recebida : " + str(client_address))
                # Receive the data in small chunks and retransmit it

                data = connection.recv(1000000) #Recebe no máximo 1mb

                if data:
                    try:
                        JSONRecebido = json.loads(data.decode("utf-8"))
                        TokenRecebido = JSONRecebido['Token']

                        if(TOKEN == TokenRecebido):
                            Comando = JSONRecebido['Command']
                            if(Comando == "AbrirCancela"):

                                #Responde o cliente
                                message = str.encode('Comando Executado!')
                                connection.sendall(message)

                                #Simples aviso no servidor
                                print("Comando de abrir cancela executado.")
                                lock.acquire()
                                AbrirCancela()
                                time.sleep(TempoFecharCancela)
                                FecharCancela()
                                lock.release()

                            elif(Comando == "FecharCancela"):

                                # Responde o cliente
                                message = str.encode('Comando Executado!')
                                connection.sendall(message)

                                # Simples aviso no servidor
                                print("Comando de fechar cancela executado.")
                                lock.acquire()
                                FecharCancela()
                                lock.release()
                            else:
                                connection.sendall(str.encode('Nenhum comando identificado.'))
                            print()
                            message = str.encode('Comando recebido com sucesso!')
                        else:
                            print("Erro : Token Inválido.")
                            message = str.encode('Erro : Token Inválido.')

                    except Exception as exception:
                        message = str.encode('Erro : Não foi possível identificar os dados.')
                        connection.sendall(message)
            except Exception as Exp:
                # Clean up the connection
                print("Erro com o cliente: " + str(Exp))
                connection.close()
            finally:
                connection.close()
    except Exception as Excp:
        time.sleep(15) #Caso ocorra algum erro, espera 15 segundos para reiniciar o servidor
        print("Erro no servidor: %s" % str(Excp))
        IniciarServidor()

def DefinirTempoCancela():

    try:
        conn = PegarConexao()
        cur = conn.cursor()
        # execute a statement
        cur.execute(
            """SELECT C.VALOR FROM CONFIGURACAO C WHERE C.CHAVE =
            'CHAVE_CONFIGURACAOSERVIDOR_TEMPO_FECHARCANCELA'""")
        row = cur.fetchone()

        global TempoFecharCancela

        if row is not None:
            Tempo = (row[0].tobytes()).decode("utf-8")
            TempoFecharCancela = int(Tempo)
            print("""Tempo de fechamento da cancela definido:
            %s segundos.""" % TempoFecharCancela)
        else:
            TempoFecharCancela = 7
            print("""Tempo de fechamento da cancela não encontrado,
            definido para 7 segundos.""")

        conn.close()
        cur.close()
    except:
        print("Não foi possível definir o tempo de fechamento da cancela.")

def DefinirToken():
    try:
        conn = PegarConexao()
        cur = conn.cursor()
        # execute a statement
        cur.execute(
            """SELECT C.VALOR FROM CONFIGURACAO C WHERE C.CHAVE =
                'CHAVE_CONFIGURACAOSERVIDOR_TOKEN'""")
        row = cur.fetchone()
        if row is not None:
            TOKENAtual = (row[0].tobytes()).decode("utf-8")
            global TOKEN
            TOKEN = str(TOKENAtual)
            print("Token Definido.")
        else:
            print("Defina o TOKEN antes de iniciar o servidor.")
            Finalizar()

        cur.close()
        conn.close()
    except:
        print("Não foi possível definir o Token.")
        Finalizar()

def DefinirServidor():
    try:
        conn = PegarConexao()
        cur = conn.cursor()
        cur.execute(
            """SELECT C.VALOR FROM CONFIGURACAO C WHERE C.CHAVE
                = 'CHAVE_CONFIGURACAOSERVIDOR_IP'""")
        row = cur.fetchone()
        if row is not None:
            Tempo = (row[0].tobytes()).decode("utf-8")
            global HOST
            HOST = str(Tempo)
        else:
            print("Defina o IP antes de iniciar o servidor.")
            Finalizar()
        curPort = conn.cursor()
        curPort.execute(
            """SELECT C.VALOR FROM CONFIGURACAO C WHERE C.CHAVE =
                'CHAVE_CONFIGURACAOSERVIDOR_PORTA'""")
        row = curPort.fetchone()
        if row is not None:
            Tempo = (row[0].tobytes()).decode("utf-8")
            global PORT
            PORT = int(Tempo)
        else:
            print("Defina a porta antes de inicializar o servidor.")
            Finalizar()

        print("Servidor Configurado: %s" % (HOST + ":" + str(PORT)) )

        cur.close()
        curPort.close()
        conn.close()

    except:
        print("Não foi possível definir o Token.")
        Finalizar()

def main():
   
    DefinirTempoCancela()
    DefinirToken()
    DefinirServidor()
    
    #Incia o servidor TCP e o OCR
    t1 = threading.Thread(target=IniciarServidor)
    t2 = threading.Thread(target=IniciarOCR)
    t3 = threading.Thread(target=IniciarOCRSaida)
    t1.start()
    t2.start()
    t3.start()

    print("AutoPark- Iniciado com sucesso!")    

try:
    main()
except KeyboardInterrupt:
    GPIO.cleanup()
    socket.close()


