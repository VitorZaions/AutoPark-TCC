using AutoController.Funcoes;
using AutoDAO.Custom;
using AutoDAO.Entidades;
using AutoUTIL;
using MetroFramework.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Utils;

namespace AutoPark.Forms.Controle
{
    public partial class FCL_Cancela : MetroForm
    {

        string Host;
        int Port;
        string Token;
        private string NOME_TELA = "Configurações do Servidor";

        public FCL_Cancela()
        {
            InitializeComponent();
        }

        private void PreencherTela()
        {
            //Seta o IP1
            Configuracao config1 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_IP);
            if (config1 != null)
            {
                Host = Encoding.UTF8.GetString(config1.Valor);
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "IP do servidor não configurado, verifique.", "red", true, false);
                Close();
            }

            Configuracao config2 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_TOKEN);
            if (config2 != null)
            {
                Token = Encoding.UTF8.GetString(config2.Valor);
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Token não configurado, verifique.", "red", true, false);
                Close();
            }

            Configuracao config3 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_PORTA);
            if (config3 != null)
            {
                Port = Convert.ToInt32(Encoding.UTF8.GetString(config3.Valor));
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Porta não configurada, verifique.", "red", true, false);
                Close();
            }

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    if (SyncMessager.CreateMessage(0, NOME_TELA, "Deseja sair?", "yellow", true, false) == DialogResult.OK)
                    {
                        Close();
                    }
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
        private void FCONFIG_BackupServidor_Load(object sender, EventArgs e)
        {

            PreencherTela();
        }

        private void NUMERIC_IP1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NUMERIC_IP2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NUMERIC_IP3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NUMERIC_IP4_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
            
        
        private void EnviarComando(string Comando)
        {

            LoadingCall LoadingScreen = new LoadingCall("Enviando..");
            bool IsLoadingScreen = false;

            try
            {

                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                // Comando
                Comando Com = new Comando();
                Com.Command = Comando;
                Com.Token = Token;

                string JSON = JsonConvert.SerializeObject(Com);
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ToSend = asen.GetBytes(JSON);


                IPAddress ipAddress = System.Net.IPAddress.Parse(Host);
                IPEndPoint ipEndPoint = new(ipAddress, Port);

                using Socket client = new(
                ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

                client.NoDelay = true;

                client.Connect(ipEndPoint);

                // Send message.
                client.Send(ToSend, SocketFlags.None);

                // Receive ack.
                var buffer = new byte[1024];
                var received = client.Receive(buffer);
                var response = Encoding.UTF8.GetString(buffer, 0, received);

                string color = "green";

                if (response == "Nenhum comando identificado.")
                    color = "yellow";

                if (response == "Erro: Token Inválido." || response == "Erro : Não foi possível identificar os dados.")
                    color = "red";

                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0, NOME_TELA, response, color, true, false);
                client.Shutdown(SocketShutdown.Both);
            }
            catch (Exception Ex)
            {
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();

                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível enviar o comando, verifique o servidor.", "red", true, false);
            }
        }

        private void BTN_Abrir_Click(object sender, EventArgs e)
        {
            EnviarComando("AbrirCancela");
        }

        private void BTN_Fechar_Click(object sender, EventArgs e)
        {
            EnviarComando("FecharCancela");
        }
    }
}
