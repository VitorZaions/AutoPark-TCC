using AutoController.Funcoes;
using AutoDAO.Custom;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoPark.Forms.Consultas;
using AutoUTIL;
using Guna.UI2.WinForms;
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
    public partial class FCAFIN_BaixaPagamento : MetroForm
    {
        private string NOME_TELA = "Baixa de pagamento";
        public BaixaPagamento BaixaPag = null;
        private ContaPagar ContaPagamento = null;
        public bool Salvou = false;
        private List<ContaBancaria> Contas = null;
        private List<FormaDePagamento> Formas = null;
        public DataTable Cheques = null;
        decimal? _IDFormaDePagamento;

        public FCAFIN_BaixaPagamento(ContaPagar _ContaPagamento, BaixaPagamento _BaixaPag, decimal? IDFormaDePagamento)
        {
            InitializeComponent();
            ContaPagamento = _ContaPagamento;
            BaixaPag = _BaixaPag;
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
            ovTXT_ValorPag.Value = ContaPagamento.Valor;
            ovTXT_MultaPag.Value = ContaPagamento.Multa;
            ovTXT_JurosPag.Value = ContaPagamento.Juros;
            ovTXT_DescontoRec.Value = ContaPagamento.Desconto;
            ovTXT_SaldoPag.Value = ContaPagamento.Saldo;
            ovTXT_TotalPag.Value = (ContaPagamento.Valor - ContaPagamento.Desconto) + ContaPagamento.Multa + ContaPagamento.Juros;

            ovTXT_Valor.Value = BaixaPag.Valor;
            ovTXT_Multa.Value = BaixaPag.Multa;
            ovTXT_Juros.Value = BaixaPag.Juros;
            ovTXT_Desconto.Value = BaixaPag.Desconto;
            ovTXT_Total.Value = (BaixaPag.Valor - BaixaPag.Desconto) + BaixaPag.Juros + BaixaPag.Multa;
            ovTXT_Baixa.Value = BaixaPag.Baixa;

            ovCMB_ContaBancaria.SelectedItem = Contas.Where(o => o.IDContaBancaria == BaixaPag.IDContaBancaria).FirstOrDefault();

            if (_IDFormaDePagamento != null)
                ovCMB_FormaPagamento.SelectedItem = Formas.Where(o => o.IDFormaDePagamento == _IDFormaDePagamento.Value).FirstOrDefault();
            else
                ovCMB_FormaPagamento.SelectedItem = Formas.Where(o => o.IDFormaDePagamento == BaixaPag.IDFormaDePagamento).FirstOrDefault();
                       
            ovTXT_Origem.Text = BaixaPag.Origem;
            ovTXT_Complemento.Text = BaixaPag.Complemento;

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

                BaixaPag.Valor = ovTXT_Valor.Value;
                BaixaPag.Multa = ovTXT_Multa.Value;
                BaixaPag.Juros = ovTXT_Juros.Value;
                BaixaPag.Desconto = ovTXT_Desconto.Value;
                BaixaPag.Baixa = ovTXT_Baixa.Value;

                BaixaPag.IDContaBancaria = (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria;
                BaixaPag.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
                BaixaPag.Origem = ovTXT_Origem.Text;
                BaixaPag.Complemento = ovTXT_Complemento.Text;

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

            /*if (((FormaPagamento)Enum.Parse(typeof(FormaPagamento), (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).CodigoTipoPagamento.ToString())) != FormaPagamento.fpCheque)
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

            FCAFIN_ChequePagamento Form = new FCAFIN_ChequePagamento(new ChequeContaPagar(), (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria);
            Form.ShowDialog(this);
            if (Form.Salvou)
            {
                DataRow dr = Cheques.NewRow();
                dr["IDCHEQUECONTAPAGAR"] = Sequence.GetNextID("CHEQUECONTAPAGAR", "IDCHEQUECONTAPAGAR");
                dr["NUMERO"] = Form.ChequePagamento.Numero;
                dr["EMISSAO"] = Form.ChequePagamento.Emissao;
                dr["VENCIMENTO"] = Form.ChequePagamento.Vencimento;
                dr["VALOR"] = Form.ChequePagamento.Valor;
                dr["CRUZADO"] = Form.ChequePagamento.Cruzado;
                dr["COMPENSADO"] = Form.ChequePagamento.Compensado;
                dr["DEVOLVIDO"] = Form.ChequePagamento.Devolvido;

                dr["DATACOMPENSACAO"] = DBNull.Value;
                if (Form.ChequePagamento.DataCompensacao.HasValue)
                    dr["DATACOMPENSACAO"] = Form.ChequePagamento.DataCompensacao;

                dr["DATADEVOLUCAO"] = DBNull.Value;
                if (Form.ChequePagamento.DataDevolucao.HasValue)
                    dr["DATADEVOLUCAO"] = Form.ChequePagamento.DataDevolucao;

                dr["IDBAIXAPAGAMENTO"] = BaixaPag.IDBaixaPagamento;

                dr["IDTALONARIO"] = DBNull.Value;
                if (Form.ChequePagamento.IDTalonario.HasValue)
                    dr["IDTALONARIO"] = Form.ChequePagamento.IDTalonario;

                Cheques.Rows.Add(dr);
            }
            CarregarCheques(false);
        }

        private void CarregarCheques(bool Banco)
        {
            if (Banco)
                Cheques = FuncoesChequesCtaPagar.GetChequeContaPagar(BaixaPag.IDBaixaPagamento);
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
                Cheques.DefaultView.RowFilter = "[IDCHEQUECONTAPAGAR] = " + Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Cheques.SelectedRows[0].DataBoundItem as DataRowView), "IDCHEQUECONTAPAGAR"));

                FCAFIN_ChequePagamento Form = new FCAFIN_ChequePagamento(EntityUtil<ChequeContaPagar>.ParseDataRow(Cheques.DefaultView[0].Row), (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria);
                Form.ShowDialog(this);
                if (Form.Salvou)
                {
                    foreach (DataRowView drView in Cheques.DefaultView)
                    {
                        drView.BeginEdit();
                        drView["NUMERO"] = Form.ChequePagamento.Numero;
                        drView["EMISSAO"] = Form.ChequePagamento.Emissao;
                        drView["VENCIMENTO"] = Form.ChequePagamento.Vencimento;
                        drView["VALOR"] = Form.ChequePagamento.Valor;
                        drView["CRUZADO"] = Form.ChequePagamento.Cruzado;
                        drView["COMPENSADO"] = Form.ChequePagamento.Compensado;
                        drView["DEVOLVIDO"] = Form.ChequePagamento.Devolvido;

                        drView["DATACOMPENSACAO"] = DBNull.Value;
                        if (Form.ChequePagamento.DataCompensacao.HasValue)
                            drView["DATACOMPENSACAO"] = Form.ChequePagamento.DataCompensacao;

                        drView["DATADEVOLUCAO"] = DBNull.Value;
                        if (Form.ChequePagamento.DataDevolucao.HasValue)
                            drView["DATADEVOLUCAO"] = Form.ChequePagamento.DataDevolucao;

                        drView.EndEdit();
                        Cheques.DefaultView.RowFilter = string.Empty;
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
                    Cheques.DefaultView.RowFilter = "[IDCHEQUEContaPagar] = " + Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Cheques.SelectedRows[0].DataBoundItem as DataRowView), "IDCHEQUEContaPagar"));
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

        private void ovTXT_Valor_ValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void metroTabPage5_Click(object sender, EventArgs e)
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

        private void FCAFIN_BaixaPagamento_Load(object sender, EventArgs e)
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

        private void BTN_Limpar_Click(object sender, EventArgs e)
        {
            ovCMB_ContaBancaria.SelectedIndex = -1;
            ovCMB_ContaBancaria.SelectedItem = null;
        }
            
        private void IdentificacaoTab_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
