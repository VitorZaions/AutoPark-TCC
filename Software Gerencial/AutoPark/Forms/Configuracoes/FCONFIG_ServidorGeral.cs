using AutoController.Funcoes;
using AutoDAO.Custom;
using AutoDAO.Entidades;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Configuracoes
{
    public partial class FCONFIG_ServidorGeral : MetroForm
    {
        private string NOME_TELA = "Configurações do Servidor";
        public FCONFIG_ServidorGeral()
        {
            InitializeComponent();
        }

        private void PreencherTela()
        {
            //Seta o IP1
            Configuracao config1 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_IP);
            if (config1 != null)
            {
                string[] subs = Encoding.UTF8.GetString(config1.Valor).Split('.');
                NUMERIC_IP1.Text = subs[0];
                NUMERIC_IP2.Text = subs[1];
                NUMERIC_IP3.Text = subs[2];
                NUMERIC_IP4.Text = subs[3];
            }
            else
            {
                NUMERIC_IP1.Text = "127";
                NUMERIC_IP2.Text = "0";
                NUMERIC_IP3.Text = "0";
                NUMERIC_IP4.Text = "1";
            }

            Configuracao config2 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_TOKEN);
            if (config2 != null)
            {
                ovTXT_Token.Text = Encoding.UTF8.GetString(config2.Valor);
            }

            Configuracao config3 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_PORTA);
            if (config3 != null)
            {
                NUMERIC_PORTA.Text = Encoding.UTF8.GetString(config3.Valor);
            }
            else
            {
                NUMERIC_PORTA.Text = "5000";
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

        private void BTN_Salvar_Click(object sender, EventArgs e)
        {
            ovTXT_Token.Text = ovTXT_Token.Text.Trim();
            NUMERIC_IP1.Text = NUMERIC_IP1.Text.Trim();
            NUMERIC_IP2.Text = NUMERIC_IP2.Text.Trim();
            NUMERIC_IP3.Text = NUMERIC_IP3.Text.Trim();
            NUMERIC_IP4.Text = NUMERIC_IP4.Text.Trim();

            if (ovTXT_Token.Text == string.Empty)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Insira O Token.", "yellow", false, false);
                return;
            }

            if (NUMERIC_IP1.Text == string.Empty || NUMERIC_IP2.Text == string.Empty || NUMERIC_IP3.Text == string.Empty || NUMERIC_IP4.Text == string.Empty)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Insira o IP completo para salvar.", "yellow", false, false);
                return;
            }

            if (NUMERIC_PORTA.Text == string.Empty)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Insira a Porta.", "yellow", false, false);
                return;
            }

       
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                //Salvar ip do servidor

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_TOKEN, Encoding.Default.GetBytes(ovTXT_Token.Text)))
                        throw new Exception("Não foi possível salvar o Token.");
                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_IP, Encoding.Default.GetBytes(
                    $"{NUMERIC_IP1.Text}.{NUMERIC_IP2.Text}.{NUMERIC_IP3.Text}.{NUMERIC_IP4.Text}")))
                    throw new Exception("Não foi possível salvar o IP.");
                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_PORTA, Encoding.Default.GetBytes(NUMERIC_PORTA.Text)))
                    throw new Exception("Não foi possível salvar a Porta.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0, NOME_TELA, "Configurações salvas com sucesso.", "green", false, false);

                if (ovTXT_Token.Text != string.Empty)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, $"Reinicie o servidor para aplicar as novas configurações!", "blue", false, false);
                }
                Close();

            }
            catch (Exception Ex)
            {
                if (InTransaction)
                    PDVControlador.Rollback();
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();
                SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível salvar as configurações.", "red", false, false);
            }
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

        private void NUMERIC_IP1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NUMERIC_IP1.Text = SyncUtil.SomenteNumeros(NUMERIC_IP1.Text);
        }

        private void NUMERIC_IP2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NUMERIC_IP2.Text = SyncUtil.SomenteNumeros(NUMERIC_IP2.Text);
        }

        private void NUMERIC_IP3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NUMERIC_IP3.Text = SyncUtil.SomenteNumeros(NUMERIC_IP3.Text);
        }

        private void NUMERIC_IP4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NUMERIC_IP4.Text = SyncUtil.SomenteNumeros(NUMERIC_IP4.Text);
        }
    }
}
