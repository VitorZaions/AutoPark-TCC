using AutoController.Funcoes;
using AutoDAO.Custom;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using AutoPark.Forms.Consultas;
using AutoUTIL;
using Guna.UI2.WinForms;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCAFIN_Saida : MetroForm
    {
        public bool Salvou = false;
        private string NOME_TELA = "Cadastro de Saída";
        private Saida _Saida = null;

        private Veiculo VEICULO = null;

        string Host;
        int Port;
        string Token;

        public FCAFIN_Saida(Saida Saida)
        {
            _Saida = Saida;
            InitializeComponent();
            PreencherTela();
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

            if (_Saida.IDSaida != -1)
            {
                VEICULO = FuncoesVeiculo.GetVeiculo(_Saida.IDVeiculo);
                ovTXT_Veiculo.Text = $"{VEICULO.Placa} - {VEICULO.Descricao}";

                ovTXT_Data.Value = _Saida.DataSaida;
            }          
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Salvou = false;
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
        private void metroButton4_Click(object sender, EventArgs e)
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {
                if (!Validar())
                    return;

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                bool IsNew = false;
                TipoOperacao Op = TipoOperacao.UPDATE;
                if (_Saida.IDSaida == -1)
                {
                    _Saida.IDSaida = Sequence.GetNextID("SAIDA", "IDSAIDA");
                    Op = TipoOperacao.INSERT;
                    IsNew = true;
                }

                _Saida.IDVeiculo = VEICULO.IDVeiculo;
                _Saida.DataSaida = ovTXT_Data.Value;
                _Saida.Tipo = 0;

                if (!FuncoesSaida.Salvar(_Saida, Op))
                    throw new Exception("Não foi possível salvar a Saída.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Saída lançada com sucesso!", "green", false, false);
                Salvou = true;

                if (IsNew)
                {                    
                    if (SyncMessager.CreateMessage(0, NOME_TELA, "Deseja abrir a cancela?", "blue", true, false) == DialogResult.OK)
                    {
                        EnviarComando("AbrirCancela");
                    }
                }
            }
            catch (Exception Ex)
            {
                if (InTransaction)
                    PDVControlador.Rollback();
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();

                SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
                Salvou = false;
            }
        }

        

        private bool Validar()
        { 

            if (VEICULO == null)
            {               
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Veículo.", "yellow", false, false);
                ovTXT_Veiculo.Focus();
                return false;
            }

            return true;
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

        private void FCAFIN_ContaReceber_Load(object sender, EventArgs e)
        {

        }          

        private void BTN_BuscarVeiculo_Click(object sender, EventArgs e)
        {
            FCO_Veiculo SeletorVeiculo = new FCO_Veiculo(true);
            SeletorVeiculo.ShowDialog(this);

            if (SeletorVeiculo.DRSelected == null)
                return;

            DataRow DrSelecionada = DrSelecionada = SeletorVeiculo.DRSelected;
            VEICULO = FuncoesVeiculo.GetVeiculo(Convert.ToDecimal(DrSelecionada["IDVEICULO"]));

            if (VEICULO != null)
            {
                ovTXT_Veiculo.Text = $"{VEICULO.Placa} - {VEICULO.Descricao}";
            }
            else
            {
                ovTXT_Veiculo.Text = string.Empty;
            }
        }
    }
}
