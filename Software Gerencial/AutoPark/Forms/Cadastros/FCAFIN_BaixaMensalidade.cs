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
    public partial class FCAFIN_BaixaMensalidade : MetroForm
    {
        private string NOME_TELA = "Baixa de Mensalidade";
        public BaixaMensalidade _BaixaMen = null;
        private Mensalidade _Mensalidade = null;
        public bool Salvou = false;
        private List<ContaBancaria> Contas = null;
        private List<FormaDePagamento> Formas = null;
        public DataTable Cheques = null;
        decimal? _IDFormaDePagamento;

        public FCAFIN_BaixaMensalidade(Mensalidade Mensalidade, BaixaMensalidade BaixaMen, decimal? IDFormaDePagamento)
        {
            InitializeComponent();
            _Mensalidade = Mensalidade;
            _BaixaMen = BaixaMen;
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
            ovTXT_ValorRec.Value = _Mensalidade.Valor;
            ovTXT_MultaRec.Value = _Mensalidade.Multa;
            ovTXT_JurosRec.Value = _Mensalidade.Juros;
            ovTXT_DescontoRec.Value = _Mensalidade.Desconto;
            ovTXT_SaldoRec.Value = _Mensalidade.Saldo;
            ovTXT_TotalRec.Value = (_Mensalidade.Valor - _Mensalidade.Desconto) + _Mensalidade.Multa + _Mensalidade.Juros;

            ovTXT_Valor.Value = _BaixaMen.Valor;
            ovTXT_Multa.Value = _BaixaMen.Multa;
            ovTXT_Juros.Value = _BaixaMen.Juros;
            ovTXT_Desconto.Value = _BaixaMen.Desconto;
            ovTXT_Total.Value = (_BaixaMen.Valor - _BaixaMen.Desconto) + _BaixaMen.Juros + _BaixaMen.Multa;
            ovTXT_Baixa.Value = _BaixaMen.Baixa;

            ovCMB_ContaBancaria.SelectedItem = Contas.Where(o => o.IDContaBancaria == _BaixaMen.IDContaBancaria).FirstOrDefault();
            
            if(_IDFormaDePagamento != null)
                ovCMB_FormaPagamento.SelectedItem = Formas.Where(o => o.IDFormaDePagamento == _IDFormaDePagamento.Value).FirstOrDefault();
            else
                ovCMB_FormaPagamento.SelectedItem = Formas.Where(o => o.IDFormaDePagamento == _BaixaMen.IDFormaDePagamento).FirstOrDefault();

            ovTXT_Complemento.Text = _BaixaMen.Complemento;
            ovTXT_Origem.Text = _BaixaMen.Origem;

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
            bool IsLoadingScreen = false;

            try
            {
                if (!Validar())
                    return;

                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                _BaixaMen.Valor = ovTXT_Valor.Value;
                _BaixaMen.Multa = ovTXT_Multa.Value;
                _BaixaMen.Juros = ovTXT_Juros.Value;
                _BaixaMen.Desconto = ovTXT_Desconto.Value;
                _BaixaMen.Baixa = ovTXT_Baixa.Value;

                _BaixaMen.IDContaBancaria = (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria;
                _BaixaMen.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;

                _BaixaMen.Origem = ovTXT_Origem.Text;
                _BaixaMen.Complemento = ovTXT_Complemento.Text;

                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                Salvou = true;
                Close();

            }
            catch (Exception Ex)
            {
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

        private void Add_Click(object sender, EventArgs e)
        {
            if (!ValidaFormaPagamento())
                return;

            FCAFIN_ChequeMensalidade Form = new FCAFIN_ChequeMensalidade(new ChequeMensalidade());
            Form.ShowDialog(this);
            if (Form.Salvou)
            {
                DataRow dr = Cheques.NewRow();
                dr["IDCHEQUEMENSALIDADE"] = Sequence.GetNextID("CHEQUEMENSALIDADE", "IDCHEQUEMENSALIDADE");
                dr["NUMERO"] = Form._ChequeMensalidade.Numero;
                dr["EMISSAO"] = Form._ChequeMensalidade.Emissao;
                dr["VENCIMENTO"] = Form._ChequeMensalidade.Vencimento;
                dr["VALOR"] = Form._ChequeMensalidade.Valor;
                dr["CRUZADO"] = Form._ChequeMensalidade.Cruzado;
                dr["COMPENSADO"] = Form._ChequeMensalidade.Compensado;
                dr["REPASSE"] = Form._ChequeMensalidade.Repasse;
                dr["DEVOLVIDO"] = Form._ChequeMensalidade.Devolvido;
                dr["DATACOMPENSACAO"] = DBNull.Value;
                if (Form._ChequeMensalidade.DataCompensacao.HasValue)
                    dr["DATACOMPENSACAO"] = Form._ChequeMensalidade.DataCompensacao;
                dr["DATADEVOLUCAO"] = DBNull.Value;
                if (Form._ChequeMensalidade.DataDevolucao.HasValue)
                    dr["DATADEVOLUCAO"] = Form._ChequeMensalidade.DataDevolucao;
                dr["DATAREPASSE"] = DBNull.Value;
                if (Form._ChequeMensalidade.DataRepasse.HasValue)
                    dr["DATAREPASSE"] = Form._ChequeMensalidade.DataRepasse;
                dr["OBSREPASSE"] = Form._ChequeMensalidade.ObsRepasse;
                dr["IDBAIXAMENSALIDADE"] = _BaixaMen.IDBaixaMensalidade;
                Cheques.Rows.Add(dr);
            }
            CarregarCheques(false);
        }

        private void CarregarCheques(bool Banco)
        {
            if (Banco)
                Cheques = FuncoesChequesMensalidade.GetChequeMensalidade(_BaixaMen.IDBaixaMensalidade);
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
                Cheques.DefaultView.RowFilter = "[IDCHEQUEMENSALIDADE] = " + Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Cheques.SelectedRows[0].DataBoundItem as DataRowView), "IDCHEQUEMENSALIDADE"));

                FCAFIN_ChequeMensalidade Form = new FCAFIN_ChequeMensalidade(EntityUtil<ChequeMensalidade>.ParseDataRow(Cheques.DefaultView[0].Row));
                Form.ShowDialog(this);
                if (Form.Salvou)
                {
                    foreach (DataRowView drView in Cheques.DefaultView)
                    {
                        drView.BeginEdit();
                        drView["NUMERO"] = Form._ChequeMensalidade.Numero;
                        drView["EMISSAO"] = Form._ChequeMensalidade.Emissao;
                        drView["VENCIMENTO"] = Form._ChequeMensalidade.Vencimento;
                        drView["VALOR"] = Form._ChequeMensalidade.Valor;
                        drView["CRUZADO"] = Form._ChequeMensalidade.Cruzado;
                        drView["COMPENSADO"] = Form._ChequeMensalidade.Compensado;
                        drView["REPASSE"] = Form._ChequeMensalidade.Repasse;
                        drView["DEVOLVIDO"] = Form._ChequeMensalidade.Devolvido;

                        drView["DATACOMPENSACAO"] = DBNull.Value;
                        if (Form._ChequeMensalidade.DataCompensacao.HasValue)
                            drView["DATACOMPENSACAO"] = Form._ChequeMensalidade.DataCompensacao;

                        drView["DATADEVOLUCAO"] = DBNull.Value;
                        if (Form._ChequeMensalidade.DataDevolucao.HasValue)
                            drView["DATADEVOLUCAO"] = Form._ChequeMensalidade.DataDevolucao;

                        drView["DATAREPASSE"] = DBNull.Value;
                        if (Form._ChequeMensalidade.DataRepasse.HasValue)
                            drView["DATAREPASSE"] = Form._ChequeMensalidade.DataRepasse;

                        drView["OBSREPASSE"] = Form._ChequeMensalidade.ObsRepasse;
                        drView["IDBAIXAMENSALIDADE"] = _BaixaMen.IDBaixaMensalidade;
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
                    Cheques.DefaultView.RowFilter = "[IDCHEQUEMENSALIDADE] = " + Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Cheques.SelectedRows[0].DataBoundItem as DataRowView), "IDCHEQUEMENSALIDADE"));
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
