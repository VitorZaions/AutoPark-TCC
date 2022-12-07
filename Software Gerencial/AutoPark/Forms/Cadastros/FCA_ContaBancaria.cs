using AutoController.Funcoes;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using AutoPark.Forms.Seletores;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_ContaBancaria : MetroForm
    {
        private string NOME_TELA = "Cadastro de conta bancária";
        private ContaBancaria CONTA = null;
        private List<Banco> Bancos = null;
        private Banco SelectedBanco = null;

        public FCA_ContaBancaria(ContaBancaria Conta)
        {
            InitializeComponent();
            CONTA = Conta;
            Bancos = FuncoesBanco.GetBancos();
            Carregar();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidouDados()
        {
            if (string.IsNullOrEmpty(ovTXT_Nome.Text.Trim()))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Nome.", "yellow", false, false);
                ovTXT_Nome.Focus();
                return false;
            }

            if (!ovCKB_CaixaInterno.Checked && SelectedBanco == null)
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione o Banco.", "yellow", false, false);
                TXT_IDBanco.Focus();
                return false;
            }

            if (!ovCKB_CaixaInterno.Checked)
            {
                if (string.IsNullOrEmpty(ovTXT_Agencia.Text.Trim()))
                {
                   SyncMessager.CreateMessage(0,NOME_TELA, "Informe o número da agência.", "yellow", false, false);
                    ovTXT_Agencia.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(ovTXT_Conta.Text.Trim()))
                {
                   SyncMessager.CreateMessage(0,NOME_TELA, "Informe o número da conta.", "yellow", false, false);
                    ovTXT_Conta.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(ovTXT_Operacao.Text.Trim()))
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Informe a operação.", "yellow", false, false);
                    ovTXT_Operacao.Focus();
                    return false;
                }
            }

            if (FuncoesContaBancaria.ExistePorNome(ovTXT_Nome.Text, SelectedBanco.IDBanco, ovTXT_Agencia.Text.Trim(), ovTXT_DigitoAgencia.Value.ToString(), ovTXT_Conta.Text.Trim(), ovTXT_Digito.Value.ToString(), ovTXT_Operacao.Text.Trim(),  CONTA.IDContaBancaria))
            {
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Esta conta já existe.", "yellow", false, false);
                    ovTXT_Nome.Focus();
                    return false;
                }
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
                ovTXT_Nome.Text = ovTXT_Nome.Text.Trim();
                ovTXT_Agencia.Text = ovTXT_Agencia.Text.Trim();
                ovTXT_Conta.Text = ovTXT_Conta.Text.Trim();
                ovTXT_Operacao.Text = ovTXT_Operacao.Text.Trim();

                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                CONTA.Nome = ovTXT_Nome.Text;
                CONTA.Agencia = ovTXT_Agencia.Text;
                CONTA.Conta = ovTXT_Conta.Text;
                CONTA.Digito = ovTXT_Digito.Text.ToString();
                CONTA.DigitoAgencia = ovTXT_DigitoAgencia.Value.ToString();
                CONTA.Operacao = ovTXT_Operacao.Text;

                if (SelectedBanco != null)
                    CONTA.IDBanco = SelectedBanco.IDBanco;

                CONTA.Ativo = ovCKB_Ativo.Checked ? 1 : 0;
                CONTA.Caixa = ovCKB_CaixaInterno.Checked ? 1 : 0;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (CONTA.IDContaBancaria == -1)
                {
                    CONTA.IDContaBancaria = Sequence.GetNextID("CONTABANCARIA", "IDCONTABANCARIA");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesContaBancaria.Salvar(CONTA, Op))
                    throw new Exception("Não foi possível salvar a Conta Bancária.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Conta Bancária salva com sucesso.", "green", false, false);
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

        private void Carregar()
        {
            ovTXT_Nome.Text = CONTA.Nome;
            ovTXT_Agencia.Text = CONTA.Agencia;
            ovTXT_Conta.Text = CONTA.Conta;
            ovTXT_Digito.Value = Convert.ToDecimal(CONTA.Digito);
            ovTXT_DigitoAgencia.Value = Convert.ToDecimal(CONTA.DigitoAgencia);
            ovTXT_Operacao.Text = CONTA.Operacao;

            if (CONTA.IDBanco.HasValue)
            {
                SelectedBanco = Bancos.Where(o => o.IDBanco == CONTA.IDBanco).FirstOrDefault();
                TXT_IDBanco.Text = Convert.ToString(SelectedBanco.CodBacen);
                TXT_BancoNome.Text = SelectedBanco.Nome;
            }

            ovCKB_Ativo.Checked = CONTA.Ativo == 1;
            ovCKB_CaixaInterno.Checked = CONTA.Caixa == 1;

            VerificaSelecaoBanco();
        }

        private void ovCKB_CaixaInterno_CheckedChanged(object sender, EventArgs e)
        {
            VerificaSelecaoBanco();
        }

        private void VerificaSelecaoBanco()
        {
            if (!ovCKB_CaixaInterno.Checked)
            {
                label1.Font = new System.Drawing.Font("Open Sans", 9.75f, System.Drawing.FontStyle.Bold);
                label1.Text = "* Banco:";
            }
            else
            {
                label1.Font = new System.Drawing.Font("Open Sans", 9.75f, System.Drawing.FontStyle.Regular);
                label1.Text = "Banco:";
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
        private void FCA_ContaBancaria_Load(object sender, EventArgs e)
        {
            ovTXT_Nome.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ovTXT_Agencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ovTXT_Conta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ovTXT_Operacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            SEL_Banco SeletorBanco = new SEL_Banco();
            SeletorBanco.ShowDialog(this);

            if (SeletorBanco.DRSelected == null)
                return;

            DataRow DrSelecionada = SeletorBanco.DRSelected;

            SelectedBanco = FuncoesBanco.GetBancoCodigo(Convert.ToDecimal(DrSelecionada["CODBACEN"]));
            TXT_IDBanco.Text = SelectedBanco.CodBacen.ToString();
            TXT_BancoNome.Text = SelectedBanco.Nome;
        }

        private void TXT_IDBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ovTXT_Agencia.Focus();
            }
        }

        private void TXT_IDBanco_Leave(object sender, EventArgs e)
        {
            if (TXT_IDBanco.Text != string.Empty)
            {
                SelectedBanco = FuncoesBanco.GetBancoCodigo(Convert.ToDecimal(TXT_IDBanco.Text));

                if (SelectedBanco == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Banco Inexistente, insira um Banco válido.", "yellow", false, false);
                    TXT_IDBanco.Text = null;
                    TXT_BancoNome.Text = null;
                    TXT_IDBanco.Focus();
                }
                else
                {
                    TXT_BancoNome.Text = SelectedBanco.Nome;
                }
            }
            else
            {
                SelectedBanco = null;
                TXT_IDBanco.Text = string.Empty;
                TXT_BancoNome.Text = string.Empty;
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            SelectedBanco = null;
            TXT_IDBanco.Text = string.Empty;
            TXT_BancoNome.Text = string.Empty;

        }

        private void FCA_ContaBancaria_Shown(object sender, EventArgs e)
        {
            ovTXT_Nome.Focus();
        }

        private void TXT_IDBanco_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TXT_IDBanco.Text = SyncUtil.SomenteNumeros(TXT_IDBanco.Text);
        }

        private void ovTXT_Agencia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Agencia.Text = SyncUtil.SomenteNumeros(ovTXT_Agencia.Text);
        }

        private void ovTXT_Conta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Conta.Text = SyncUtil.SomenteNumeros(ovTXT_Conta.Text);
        }

        private void ovTXT_Operacao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Operacao.Text = SyncUtil.SomenteNumeros(ovTXT_Operacao.Text);
        }
    }
}
