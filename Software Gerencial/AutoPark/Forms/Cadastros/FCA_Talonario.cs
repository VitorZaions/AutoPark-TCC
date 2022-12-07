using AutoController.Funcoes;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using AutoPark.Forms.Consultas;
using AutoUTIL;
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

namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    public partial class FCA_Talonario : MetroForm
    {
        private string NOME_TELA = "Cadastro de talonário";
        private Talonario TALONARIO = null;
        private List<ContaBancaria> Contas = null;

        public FCA_Talonario(Talonario _TALONARIO)
        {
            InitializeComponent();
            TALONARIO = _TALONARIO;

            Contas = FuncoesContaBancaria.GetContasBancarias();
            ovCMB_Conta.DataSource = Contas;
            ovCMB_Conta.DisplayMember = "nome";
            ovCMB_Conta.ValueMember = "idcontabancaria";

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovCMB_Conta.SelectedItem = Contas.AsEnumerable().Where(o => o.IDContaBancaria == TALONARIO.IDContaBancaria).FirstOrDefault();
            ovCKB_Ativo.Checked = TALONARIO.Ativo == 1;
            ovTXT_Numero.Text = TALONARIO.Numero;
            ovTXT_Emissao.Value = TALONARIO.Emissao;
            ovTXT_Inicio.Value = TALONARIO.Inicio;
            ovTXT_Fim.Value = TALONARIO.Fim;
            if (TALONARIO.Obs != null)
                ovTXT_Observacao.Text = Encoding.UTF8.GetString(TALONARIO.Obs);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidouDados()
        {
            if (ovCMB_Conta.SelectedItem == null)
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a Conta.", "yellow", false, false);
                ovCMB_Conta.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_Numero.Text))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Número", "yellow", false, false);
                ovTXT_Numero.Focus();
                return false;
            }

            if (FuncoesTalonario.ExistePorNumero(ovTXT_Numero.Text, TALONARIO.IDTalonario, (ovCMB_Conta.SelectedItem as ContaBancaria).IDContaBancaria))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Este número de Talonário já está cadastrado para a conta bancária informada.", "yellow", false, false);
                ovTXT_Numero.Focus();
                return false;
            }

            return true;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {
                ovTXT_Numero.Text = ovTXT_Numero.Text.Trim();
                ovTXT_Observacao.Text = ovTXT_Observacao.Text.Trim();

                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (TALONARIO.IDTalonario == -1)
                {
                    Op = TipoOperacao.INSERT;
                    TALONARIO.IDTalonario = Sequence.GetNextID("TALONARIO", "IDTALONARIO");
                }

                TALONARIO.IDContaBancaria = (ovCMB_Conta.SelectedItem as ContaBancaria).IDContaBancaria;
                TALONARIO.Ativo = ovCKB_Ativo.Checked ? 1 : 0;
                TALONARIO.Numero = ovTXT_Numero.Text;
                TALONARIO.Emissao = ovTXT_Emissao.Value;
                TALONARIO.Inicio = ovTXT_Inicio.Value;
                TALONARIO.Fim = ovTXT_Fim.Value;
                TALONARIO.Obs = Encoding.Default.GetBytes(ovTXT_Observacao.Text);

                if (!FuncoesTalonario.Salvar(TALONARIO, Op))
                    throw new Exception("Não foi possível salvar o Talonário.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Talonário salvo com sucesso.", "green", false, false);
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

        private void ovTXT_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void FCA_Talonario_Load(object sender, EventArgs e)
        {

        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            FCO_ContaBancaria SeletorConta = new FCO_ContaBancaria(true);
            SeletorConta.ShowDialog(this);

            if (SeletorConta.DRSelected == null)
                return;

            Contas = FuncoesContaBancaria.GetContasBancarias();
            ovCMB_Conta.DataSource = Contas;

            DataRow DrSelecionada = SeletorConta.DRSelected;

            decimal ToCompare = Convert.ToDecimal(DrSelecionada["IDCONTABANCARIA"]);
            ContaBancaria SelectedConta = FuncoesContaBancaria.GetContaBancaria(ToCompare);
            ovCMB_Conta.SelectedItem = Contas.Find(x => x.IDContaBancaria == SelectedConta.IDContaBancaria);
        }

        private void BTN_Limpar_Click(object sender, EventArgs e)
        {
            ovCMB_Conta.SelectedIndex = -1;
            ovCMB_Conta.SelectedItem = null;
        }

        private void FCA_Talonario_Shown(object sender, EventArgs e)
        {
            ovCMB_Conta.Focus();
        }

        private void ovTXT_Numero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Numero.Text = SyncUtil.SomenteNumeros(ovTXT_Numero.Text);
        }
    }
}
