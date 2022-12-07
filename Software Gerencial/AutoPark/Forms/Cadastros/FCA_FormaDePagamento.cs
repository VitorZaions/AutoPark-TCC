using AutoController.Funcoes;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using MetroFramework.Forms;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_FormaDePagamento : MetroForm
    {
        private string NOME_TELA = "Cadastro de forma de pagamento";
        private FormaDePagamento Forma = null;
        private List<BandeiraCartao> Bandeiras = FuncoesBandeiraCartao.GetBandeiras();

        private List<TipoPagamento> TIPOPAGAMENTO = null;

        public FCA_FormaDePagamento(FormaDePagamento _Forma)
        {
            InitializeComponent();
            Forma = _Forma;

            TIPOPAGAMENTO = FuncoesTipoPagamento.GetTiposPagamento();
            ovCMB_FormaPagamento.DisplayMember = "descricao";
            ovCMB_FormaPagamento.ValueMember = "codigotipopagamento";
            ovCMB_FormaPagamento.DataSource = TIPOPAGAMENTO;

            ovCMB_Bandeiras.ValueMember = "idbandeiracartao";
            ovCMB_Bandeiras.DisplayMember = "descricao";
            ovCMB_Bandeiras.DataSource = Bandeiras;
            ovCMB_Bandeiras.SelectedItem = null;

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovCMB_FormaPagamento.SelectedItem = TIPOPAGAMENTO.Where(o => o.CodigoTipoPagamento == Forma.CodigoTipoPagamento).FirstOrDefault();
            if (Forma.IDBandeiraCartao.HasValue)
                ovCMB_Bandeiras.SelectedItem = Bandeiras.Where(o => o.IDBandeiraCartao == Forma.IDBandeiraCartao).FirstOrDefault();
            ovCKB_Ativo.Checked = Forma.Ativo == 1;
            ovTXT_Identificacao.Text = Forma.Identificacao;


            if (Forma.IDFormaDePagamento != -1)
            {
                ovTXT_Codigo.Text = Forma.IDFormaDePagamento.ToString();
            }
        }

        private void ovBTN_Cancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        private bool ValidouDados()
        {

            if (ovCMB_FormaPagamento.SelectedItem == null)
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione o Tipo.", "yellow", false, false);
                ovCMB_FormaPagamento.Focus();
                return false;
            }

            if (ovTXT_Identificacao.Text == string.Empty)
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe a Identificação.", "yellow", false, false);
                ovTXT_Identificacao.Focus();
                return false;
            }

            if (FuncoesFormaDePagamento.ExistePorIdentificacao(ovTXT_Identificacao.Text, Forma.IDFormaDePagamento))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Esta identificação já está sendo usada.", "yellow", false, false);
                ovTXT_Identificacao.Focus();
                return false;
            }

            switch ((ovCMB_FormaPagamento.SelectedItem as TipoPagamento).CodigoTipoPagamento)
            {
                case 3:
                case 4:
                case 10:
                case 11:
                    if (ovCMB_Bandeiras.SelectedItem == null)
                    {
                        SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a Bandeira.", "yellow", false, false);
                        ovCMB_Bandeiras.Focus();
                        return false;
                    }
                    break;
            }

            if ((ovTXT_CNPJ.Visible) && (string.IsNullOrWhiteSpace(ovTXT_CNPJ.Text)))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe o CNPJ da Credenciadora.", "yellow", false, false);
                ovTXT_CNPJ.Focus();
                return false;
            }

            return true;
        }

        private void ovBTN_Salvar_Click(object sender, System.EventArgs e)
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {
                ovTXT_Identificacao.Text = ovTXT_Identificacao.Text.Trim();

                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                Forma.CodigoTipoPagamento = (ovCMB_FormaPagamento.SelectedItem as TipoPagamento).CodigoTipoPagamento;                
                Forma.Ativo = ovCKB_Ativo.Checked ? 1 : 0;
                Forma.Identificacao = ovTXT_Identificacao.Text;

                Forma.IDBandeiraCartao = null;
                if (ovCMB_Bandeiras.SelectedItem != null)
                    Forma.IDBandeiraCartao = (ovCMB_Bandeiras.SelectedItem as BandeiraCartao).IDBandeiraCartao;

                TipoOperacao Op = TipoOperacao.UPDATE;
                //if (!FuncoesFormaDePagamento.Existe(Forma.IDFormaDePagamento))
                if (Forma.IDFormaDePagamento == -1)
                {
                    Forma.IDFormaDePagamento = Sequence.GetNextID("FORMADEPAGAMENTO", "IDFORMADEPAGAMENTO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesFormaDePagamento.Salvar(Forma, Op))
                    throw new Exception("Não foi possível salvar a Forma de Pagamento.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Forma de Pagamento salva com sucesso.", "green", false, false);
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

        private void ovCMB_FormaPagamento_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label4.Visible = false;
            ovTXT_CNPJ.Visible = false;
            if (ovCMB_FormaPagamento.SelectedItem == null)
            {
                ovCMB_Bandeiras.Enabled = false;
                ovCMB_Bandeiras.SelectedItem = null;
                label1.Font = new System.Drawing.Font("Open Sans", 9.75f);
                label1.Text = "Bandeira:";
            }
            else
            {
                switch ((ovCMB_FormaPagamento.SelectedItem as TipoPagamento).CodigoTipoPagamento)
                {
                    case 3:
                        label4.Visible = true;
                        ovTXT_CNPJ.Visible = true;
                        break;
                    case 4:
                        label4.Visible = true;
                        ovTXT_CNPJ.Visible = true;
                        break;
                    case 10:
                    case 11:
                        ovCMB_Bandeiras.Enabled = true;
                        label1.Font = new System.Drawing.Font("Open Sans", 9.75f, System.Drawing.FontStyle.Bold);
                        label1.Text = "* Bandeira:";
                        break;
                    default:
                        ovCMB_Bandeiras.Enabled = false;
                        ovCMB_Bandeiras.SelectedItem = null;
                        label1.Font = new System.Drawing.Font("Open Sans", 9.75f);
                        label1.Text = "Bandeira:";
                        break;
                }
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
        private void FCA_FormaDePagamento_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            ovTXT_CNPJ.Visible = false;
        }

        private void ovCMB_FormaPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ovCMB_FormaPagamento.SelectedItem == null)
            {
                ovCMB_Bandeiras.Enabled = false;
                ovCMB_Bandeiras.SelectedItem = null;
                label1.Font = new System.Drawing.Font("Open Sans", 9.75f);
                label1.Text = "Bandeira:";
            }
            else
            {
                switch ((ovCMB_FormaPagamento.SelectedItem as TipoPagamento).CodigoTipoPagamento)
                {
                    case 3:
                    case 4:
                    case 10:
                    case 11:
                        ovCMB_Bandeiras.Enabled = true;
                        label1.Font = new System.Drawing.Font("Open Sans", 9.75f, System.Drawing.FontStyle.Bold);
                        label1.Text = "* Bandeira:";
                        break;
                    default:
                        ovCMB_Bandeiras.SelectedItem = null;
                        ovCMB_Bandeiras.SelectedIndex = -1;
                        ovCMB_Bandeiras.Enabled = false;                        
                        label1.Font = new System.Drawing.Font("Open Sans", 9.75f);
                        label1.Text = "Bandeira:";
                        break;
                }
            }
        }
    }
}
