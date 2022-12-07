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
    public partial class FCONFIG_CancelaGeral : MetroForm
    {
        private string NOME_TELA = "Configurações da Cancela";
        public FCONFIG_CancelaGeral()
        {
            InitializeComponent();
        }

        private void PreencherTela()
        {
            //Seta o IP1
            Configuracao config1 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_TEMPO_FECHARCANCELA);
            if (config1 != null)
            {
                decimal Tempo = Convert.ToDecimal(Encoding.UTF8.GetString(config1.Valor));
                if (Tempo >= 5 && Tempo <= 600)
                    NUMERIC_Tempo.Value = Tempo;
                else
                    NUMERIC_Tempo.Value = 5;  
            }
            else
            {
                NUMERIC_Tempo.Value = 5;
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
      
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOSERVIDOR_TEMPO_FECHARCANCELA, Encoding.Default.GetBytes($"{NUMERIC_Tempo.Value}")))
                    throw new Exception("Não foi possível salvar o IP.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Configurações salvas com sucesso.", "green", false, false);
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
               

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.AppendLine("Insira em segundos o tempo que a cancela realizará o fechamento após ser aberta.");
            SyncMessager.CreateMessage(0, NOME_TELA, Builder.ToString(), "BLUE", false, false);
        }
    }
}
