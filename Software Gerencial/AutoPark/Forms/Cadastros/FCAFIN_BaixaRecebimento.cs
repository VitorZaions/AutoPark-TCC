using AutoController.Funcoes;
using AutoDAO.Custom;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoPark.Forms.Consultas;
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
    public partial class FCAFIN_BaixaRecebimento : MetroForm
    {
        private string NOME_TELA = "Baixa de recebimento";
        public BaixaRecebimento BaixaRec = null;
        private ContaReceber ContaRecebimento = null;
        public bool Salvou = false;
        private List<ContaBancaria> Contas = null;
        private List<FormaDePagamento> Formas = null;
        public DataTable Cheques = null;
        decimal? _IDFormaDePagamento;

        public FCAFIN_BaixaRecebimento(ContaReceber _ContaRecebimento, BaixaRecebimento _BaixaRec, decimal? IDFormaDePagamento)
        {
            InitializeComponent();
            ContaRecebimento = _ContaRecebimento;
            BaixaRec = _BaixaRec;
            _IDFormaDePagamento = IDFormaDePagamento;

            Contas = FuncoesContaBancaria.GetContasBancarias(true);
            Formas = FuncoesFormaDePagamento.GetFormasPagamento();

            ovCMB_ContaBancaria.DataSource = Contas;
            ovCMB_ContaBancaria.ValueMember = "idcontabancaria";
            ovCMB_ContaBancaria.DisplayMember = "nome";
            ovCMB_ContaBancaria.SelectedItem = null;

            ovCMB_FormaPagamento.DataSource = Formas;
            ovCMB_FormaPagamento.ValueMember = "idformadepagamento";
            ovCMB_FormaPagamento.DisplayMember = "identificacao";
            ovCMB_FormaPagamento.SelectedItem = null;

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_ValorRec.Value = ContaRecebimento.Valor;
            ovTXT_MultaRec.Value = ContaRecebimento.Multa;
            ovTXT_JurosRec.Value = ContaRecebimento.Juros;
            ovTXT_DescontoRec.Value = ContaRecebimento.Desconto;
            ovTXT_SaldoRec.Value = ContaRecebimento.Saldo;
            ovTXT_TotalRec.Value = (ContaRecebimento.Valor - ContaRecebimento.Desconto) + ContaRecebimento.Multa + ContaRecebimento.Juros;

            ovTXT_Valor.Value = BaixaRec.Valor;
            ovTXT_Multa.Value = BaixaRec.Multa;
            ovTXT_Juros.Value = BaixaRec.Juros;
            ovTXT_Desconto.Value = BaixaRec.Desconto;
            ovTXT_Total.Value = (BaixaRec.Valor - BaixaRec.Desconto) + BaixaRec.Juros + BaixaRec.Multa;
            ovTXT_Baixa.Value = BaixaRec.Baixa;

            ovCMB_ContaBancaria.SelectedItem = Contas.Where(o => o.IDContaBancaria == BaixaRec.IDContaBancaria).FirstOrDefault();
            
            if(_IDFormaDePagamento != null)
                ovCMB_FormaPagamento.SelectedItem = Formas.Where(o => o.IDFormaDePagamento == _IDFormaDePagamento.Value).FirstOrDefault();
            else
                ovCMB_FormaPagamento.SelectedItem = Formas.Where(o => o.IDFormaDePagamento == BaixaRec.IDFormaDePagamento).FirstOrDefault();

            ovTXT_Complemento.Text = BaixaRec.Complemento;
            ovTXT_Origem.Text = BaixaRec.Origem;

            CarregarCheques(true);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Salvou = false;
            Close();
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

                BaixaRec.Valor = ovTXT_Valor.Value;
                BaixaRec.Multa = ovTXT_Multa.Value;
                BaixaRec.Juros = ovTXT_Juros.Value;
                BaixaRec.Desconto = ovTXT_Desconto.Value;
                BaixaRec.Baixa = ovTXT_Baixa.Value;

                BaixaRec.IDContaBancaria = (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria;
                BaixaRec.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;

                BaixaRec.Origem = ovTXT_Origem.Text;
                BaixaRec.Complemento = ovTXT_Complemento.Text;

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                Salvou = true;
                Close();

            }
            catch (Exception Ex)
            {
                if (InTransaction)
                    PDVControlador.Rollback();
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();

                SyncMessager.CreateMessage(0, NOME_TELA, Ex.Message, "red", false, false);
                Salvou = false;
            }
        }

        private bool Validar()
        {
            if (ovCMB_ContaBancaria.SelectedItem == null)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovCMB_ContaBancaria.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Conta Bancária.", "yellow", false, false);
                return false;
            }

            if (ovCMB_FormaPagamento.SelectedItem == null)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovCMB_FormaPagamento.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Forma de Pagamento.", "yellow", false, false);
                return false;
            }

            CalculaTotal();

            if (ovTXT_Total.Value == 0)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovTXT_Valor.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe um Valor para a Baixa.", "yellow", false, false);
                return false;
            }

            return true;
        }

        private bool ValidaFormaPagamento()
        {
            if (ovCMB_FormaPagamento.SelectedItem == null)
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a Forma de Pagamento.", "yellow", false, false);
                return false;
            }

            /*
            if (((FormaPagamento)Enum.Parse(typeof(FormaPagamento), (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).CodigoTipoPagamento.ToString())) != FormaPagamento.fpCheque)
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "A Forma de Pagamento não é Cheque.", "yellow", false, false);
                return false;
            }*/
            return true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!ValidaFormaPagamento())
                return;

            FCAFIN_ChequeRecebimento Form = new FCAFIN_ChequeRecebimento(new ChequeContaReceber());
            Form.ShowDialog(this);
            if (Form.Salvou)
            {
                DataRow dr = Cheques.NewRow();
                dr["IDCHEQUECONTARECEBER"] = Sequence.GetNextID("CHEQUECONTARECEBER", "IDCHEQUECONTARECEBER");
                dr["NUMERO"] = Form.ChequeRecebimento.Numero;
                dr["EMISSAO"] = Form.ChequeRecebimento.Emissao;
                dr["VENCIMENTO"] = Form.ChequeRecebimento.Vencimento;
                dr["VALOR"] = Form.ChequeRecebimento.Valor;
                dr["CRUZADO"] = Form.ChequeRecebimento.Cruzado;
                dr["COMPENSADO"] = Form.ChequeRecebimento.Compensado;
                dr["REPASSE"] = Form.ChequeRecebimento.Repasse;
                dr["DEVOLVIDO"] = Form.ChequeRecebimento.Devolvido;

                dr["DATACOMPENSACAO"] = DBNull.Value;
                if (Form.ChequeRecebimento.DataCompensacao.HasValue)
                    dr["DATACOMPENSACAO"] = Form.ChequeRecebimento.DataCompensacao;

                dr["DATADEVOLUCAO"] = DBNull.Value;
                if (Form.ChequeRecebimento.DataDevolucao.HasValue)
                    dr["DATADEVOLUCAO"] = Form.ChequeRecebimento.DataDevolucao;

                dr["DATAREPASSE"] = DBNull.Value;
                if (Form.ChequeRecebimento.DataRepasse.HasValue)
                    dr["DATAREPASSE"] = Form.ChequeRecebimento.DataRepasse;

                dr["OBSREPASSE"] = Form.ChequeRecebimento.ObsRepasse;
                dr["IDBAIXARECEBIMENTO"] = BaixaRec.IDBaixaRecebimento;
                Cheques.Rows.Add(dr);
            }
            CarregarCheques(false);
        }

        private void CarregarCheques(bool Banco)
        {
            if (Banco)
                Cheques = FuncoesChequesCtaReceber.GetChequeContaReceber(BaixaRec.IDBaixaRecebimento);
            if (Cheques != null)
                Cheques.DefaultView.Sort = "VALOR, EMISSAO";
            ovGRD_Cheques.DataSource = null;
            ovGRD_Cheques.DataSource = Cheques;
            AjustaTextHeaderCheques();
        }

        private void AjustaTextHeaderCheques()
        {
            ovGRD_Cheques.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Cheques.Width;
            foreach (DataGridViewColumn column in ovGRD_Cheques.Columns)
            {
                switch (column.Name)
                {
                    case "numero":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.35);
                        column.HeaderText = "Número";
                        break;
                    case "emissao":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "Emissão";
                        break;
                    case "vencimento":
                        column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "Vencimento";
                        break;
                    case "valor":
                        column.DisplayIndex = 4;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.25);
                        column.HeaderText = "Valor";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Cheques.Rows.Count > 0)
            {
                ovGRD_Cheques.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Cheques.Rows[0].Selected = true;
            }

        }

        private void ovGRD_Cheques_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                switch (ovGRD_Cheques.Columns[e.ColumnIndex].Name)
                {
                    case "emissao":
                    case "vencimento":
                        if (e.Value != null)
                            e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                        break;
                    case "valor":
                        if (e.Value != null)
                            e.Value = Convert.ToDecimal(e.Value).ToString("c2");
                        break;
                    case "obsrepasse":
                        e.Value = null;
                        break;
                }
            }
            catch
            {

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (!ValidaFormaPagamento())
                return;

            try
            {
                Cheques.DefaultView.RowFilter = "[IDCHEQUECONTARECEBER] = " + Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Cheques.SelectedRows[0].DataBoundItem as DataRowView), "IDCHEQUECONTARECEBER"));

                FCAFIN_ChequeRecebimento Form = new FCAFIN_ChequeRecebimento(EntityUtil<ChequeContaReceber>.ParseDataRow(Cheques.DefaultView[0].Row));
                Form.ShowDialog(this);
                if (Form.Salvou)
                {
                    foreach (DataRowView drView in Cheques.DefaultView)
                    {
                        drView.BeginEdit();
                        drView["NUMERO"] = Form.ChequeRecebimento.Numero;
                        drView["EMISSAO"] = Form.ChequeRecebimento.Emissao;
                        drView["VENCIMENTO"] = Form.ChequeRecebimento.Vencimento;
                        drView["VALOR"] = Form.ChequeRecebimento.Valor;
                        drView["CRUZADO"] = Form.ChequeRecebimento.Cruzado;
                        drView["COMPENSADO"] = Form.ChequeRecebimento.Compensado;
                        drView["REPASSE"] = Form.ChequeRecebimento.Repasse;
                        drView["DEVOLVIDO"] = Form.ChequeRecebimento.Devolvido;

                        drView["DATACOMPENSACAO"] = DBNull.Value;
                        if (Form.ChequeRecebimento.DataCompensacao.HasValue)
                            drView["DATACOMPENSACAO"] = Form.ChequeRecebimento.DataCompensacao;

                        drView["DATADEVOLUCAO"] = DBNull.Value;
                        if (Form.ChequeRecebimento.DataDevolucao.HasValue)
                            drView["DATADEVOLUCAO"] = Form.ChequeRecebimento.DataDevolucao;

                        drView["DATAREPASSE"] = DBNull.Value;
                        if (Form.ChequeRecebimento.DataRepasse.HasValue)
                            drView["DATAREPASSE"] = Form.ChequeRecebimento.DataRepasse;

                        drView["OBSREPASSE"] = Form.ChequeRecebimento.ObsRepasse;
                        drView["IDBAIXARECEBIMENTO"] = BaixaRec.IDBaixaRecebimento;
                        drView.EndEdit();
                    }
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
            }
            finally
            {
                Cheques.DefaultView.RowFilter = string.Empty;
                CarregarCheques(false);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (!ValidaFormaPagamento())
                return;

            if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o Cheque selecionado?", "yellow", false, false) == DialogResult.OK)
            {
                try
                {
                    Cheques.DefaultView.RowFilter = "[IDCHEQUECONTARECEBER] = " + Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Cheques.SelectedRows[0].DataBoundItem as DataRowView), "IDCHEQUECONTARECEBER"));
                    foreach (DataRowView drView in Cheques.DefaultView)
                        drView.Delete();
                }
                catch (Exception Ex)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
                    return;
                }
                finally
                {
                    Cheques.DefaultView.RowFilter = string.Empty;
                    CarregarCheques(false);
                }
            }
        }

        private void ovTXT_Valor_ValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }
        private void CalculaTotal()
        {
            decimal desconto = ovTXT_Desconto.Value;
            decimal total = ovTXT_Valor.Value + ovTXT_Multa.Value + ovTXT_Juros.Value;

            if (desconto > total)
            {
                ovTXT_Desconto.Value = 0;
                SyncMessager.CreateMessage(0, NOME_TELA, "Valor de desconto maior que o valor total, desconto alterado para 0.", "yellow", false, false);
            }

            ovTXT_Total.Value = (ovTXT_Valor.Value - ovTXT_Desconto.Value) + ovTXT_Multa.Value + ovTXT_Juros.Value;
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
        private void FCAFIN_BaixaRecebimento_Load(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
            guna2TabControl1.SelectedIndex = 0;
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            FCO_ContaBancaria SeletorConta = new FCO_ContaBancaria(true);
            SeletorConta.ShowDialog(this);

            if (SeletorConta.DRSelected == null)
                return;

            Contas = FuncoesContaBancaria.GetContasBancarias(true);
            ovCMB_ContaBancaria.DataSource = Contas;

            DataRow DrSelecionada = SeletorConta.DRSelected;

            decimal ToCompare = Convert.ToDecimal(DrSelecionada["IDCONTABANCARIA"]);
            ContaBancaria SelectedConta = FuncoesContaBancaria.GetContaBancaria(ToCompare);
            ovCMB_ContaBancaria.SelectedItem = Contas.Find(x => x.IDContaBancaria == SelectedConta.IDContaBancaria);
        }

        private void IdentificacaoTab_Click(object sender, EventArgs e)
        {

        }
    }
}
