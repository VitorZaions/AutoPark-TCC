using AutoController.Funcoes;
using AutoDAO.Custom;
using AutoDAO.Entidades;
using Guna.UI2.WinForms;
using MetroFramework.Forms;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Configuracoes
{
    public partial class FCONFIG_Geral : MetroForm
    {
        private string NOME_TELA = "Configurações Gerais";

        public FCONFIG_Geral()
        {
            InitializeComponent();
            PreencherTela();
        }
            
       
        private void FCONFIG_Geral_Load(object sender, EventArgs e)
        {
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

        private void PreencherTela()
        {
            // Configs de Estoque
            Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOGERAL_ESTACIONAMENTO);
            if (config != null)
                ovTXT_Valor.Value = Convert.ToDecimal (Encoding.UTF8.GetString(config.Valor));

        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidouDados()
        {
       
            return true;
        }


        private void BTN_Salvar_Click(object sender, EventArgs e)
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;
            try
            {

                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

              
                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOGERAL_ESTACIONAMENTO, Encoding.Default.GetBytes(Convert.ToString(ovTXT_Valor.Value))))
                    throw new Exception("Não foi possível salvar o Valor P/HORA.");

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
                SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
