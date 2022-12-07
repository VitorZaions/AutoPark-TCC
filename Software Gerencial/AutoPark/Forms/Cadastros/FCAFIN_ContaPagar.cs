using AutoController.Funcoes;
using AutoDAO.Custom;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCAFIN_ContaPagar : MetroForm
    {
        private List<ContaBancaria> CONTAS = null;
        private List<FormaDePagamento> FORMASPAGAMENTO = null;
        private List<StatusConta> STATUSCONTA = null;
        private List<Fornecedor> FORNECEDORES = null;
        private DataTable BAIXAS = null;
        private List<FormaDePagamento> FormasPagamento = null;
        private List<Natureza> Naturezas = null;
        private List<CentroCusto> Centros = null;

        private Dictionary<decimal, DataTable> Cheques = null;

        private string NOME_TELA = "Cadastro de conta a pagar";
        private ContaPagar Conta = null;

        private bool _AbaBaixa = false;

        public FCAFIN_ContaPagar(ContaPagar _Conta, bool AbaBaixa)
        {
            InitializeComponent();
            Conta = _Conta;
            _AbaBaixa = AbaBaixa;
            CONTAS = FuncoesContaBancaria.GetContasBancarias();
            FORMASPAGAMENTO = FuncoesFormaDePagamento.GetFormasPagamento();
            STATUSCONTA = StatusConta.GetSituacoesConta();
            FORNECEDORES = FuncoesFornecedor.GetFornecedores();

            ovCMB_Fornecedor.DataSource = FORNECEDORES;
            ovCMB_Fornecedor.ValueMember = "idfornecedor";
            ovCMB_Fornecedor.DisplayMember = "descricao";
            ovCMB_Fornecedor.SelectedItem = null;

            Naturezas = FuncoesNatureza.GetNaturezas();
            ovCMB_Natureza.DataSource = Naturezas;
            ovCMB_Natureza.DisplayMember = "descricao";
            ovCMB_Natureza.ValueMember = "idnatureza";
            ovCMB_Natureza.SelectedItem = null;

            Centros = FuncoesCentroCusto.GetCentrosCusto();
            ovCMB_CentroCusto.DataSource = Centros;
            ovCMB_CentroCusto.DisplayMember = "descricao";
            ovCMB_CentroCusto.ValueMember = "idcentrocusto";
            ovCMB_CentroCusto.SelectedItem = null;

            FormasPagamento = FuncoesFormaDePagamento.GetFormasPagamento();
            ovCMB_FormaPagamento.DataSource = FormasPagamento;
            ovCMB_FormaPagamento.ValueMember = "idformadepagamento";
            ovCMB_FormaPagamento.DisplayMember = "identificacao";
            ovCMB_FormaPagamento.SelectedItem = null;                        

            PreencherTela();
        }

        private void PreencherTela()
        {
            Cheques = new Dictionary<decimal, DataTable>();                       
            ovCMB_Fornecedor.SelectedItem = FORNECEDORES.Where(o => o.IDFornecedor == Conta.IDFornecedor).FirstOrDefault();

            ovTXT_Parcela.Value = Conta.Parcela;
            ovTXT_Emissao.Value = Conta.Emissao;
            ovTXT_Vencimento.Value = Conta.Vencimento;

            if (Conta.Status == 0)
                ovCBX_Cancelada.Checked = true;

            ovCMB_CentroCusto.SelectedItem = Centros.Where(o => o.IDCentroCusto == Conta.IDCentroCusto).FirstOrDefault();
            ovCMB_Natureza.SelectedItem = Naturezas.Where(o => o.IDNatureza == Conta.IDNatureza).FirstOrDefault();
            
            if(Conta.IDFormaDePagamento != null)
                ovCMB_FormaPagamento.SelectedItem = FormasPagamento.AsEnumerable().Where(o => o.IDFormaDePagamento == Conta.IDFormaDePagamento).FirstOrDefault();

            ovTXT_Origem.Text = Conta.Origem;
            ovTXT_Complemento.Text = Conta.Complemento;

            /* Valores */
            ovTXT_Valor.Value = Conta.Valor;
            ovTXT_Multa.Value = Conta.Multa;
            ovTXT_Juros.Value = Conta.Juros;
            ovTXT_Desconto.Value = Conta.Desconto;
            ovTXT_Saldo.Value = Conta.Saldo;
            ovTXT_Total.Value = Conta.ValorTotal;

            CarregarBaixas(true);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
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
               
                Conta.IDFornecedor = (ovCMB_Fornecedor.SelectedItem as Fornecedor).IDFornecedor;

                Conta.Parcela = ovTXT_Parcela.Value;
                Conta.Emissao = ovTXT_Emissao.Value;
                Conta.Vencimento = ovTXT_Vencimento.Value;

                Conta.IDCentroCusto = (ovCMB_CentroCusto.SelectedItem as CentroCusto).IDCentroCusto;
                Conta.IDNatureza = (ovCMB_Natureza.SelectedItem as Natureza).IDNatureza;

                if(ovCMB_FormaPagamento.SelectedItem != null)
                {
                    Conta.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
                }
                else
                {
                    Conta.IDFormaDePagamento = null;
                }

                Conta.Origem = ovTXT_Origem.Text;
                Conta.Complemento = ovTXT_Complemento.Text;

                /* Valores */
                Conta.Valor = ovTXT_Valor.Value;
                Conta.Multa = ovTXT_Multa.Value;
                Conta.Juros = ovTXT_Juros.Value;
                Conta.Desconto = ovTXT_Desconto.Value;
                Conta.Saldo = ovTXT_Saldo.Value;
                Conta.ValorTotal = ovTXT_Total.Value;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (Conta.IDContaPagar == -1)
                {
                    Op = TipoOperacao.INSERT;                                        
                    Conta.IDContaPagar = Sequence.GetNextID("CONTAPAGAR", "IDCONTAPAGAR");
                }

                // Status
                if (ovCBX_Cancelada.Checked == true)
                {
                    Conta.Status = 0;
                }
                else
                {
                    decimal ValorBaixas = BAIXAS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["TOTAL"]));
                    if (ValorBaixas >= Conta.ValorTotal)
                    {
                        //Baixado
                        Conta.Status = 3;
                    }
                    else if (ValorBaixas > 0 && ValorBaixas < Conta.ValorTotal)
                    {
                        // Parcial
                        Conta.Status = 2;
                    }
                    else
                    {
                        // Aberto
                        Conta.Status = 1;
                    }
                }


                if (!FuncoesContaPagar.Salvar(Conta, Op))
                    throw new Exception("Não foi possível salvar o Lançamento.");                               

                SalvarBaixas();

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Lançamento salvo com sucesso.", "green", false, false);
                CarregarBaixas(true);
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

        private void SalvarBaixas()
        {
            DataTable dt = SyncUtil.GetChanges(BAIXAS, TipoOperacao.INSERT);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    BaixaPagamento Baixa = EntityUtil<BaixaPagamento>.ParseDataRow(dr);
                    Baixa.IDContaPagar = Conta.IDContaPagar;
                    if (!FuncoesBaixaPagamento.Salvar(Baixa, TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar as Baixas");
                }

            dt = SyncUtil.GetChanges(BAIXAS, TipoOperacao.UPDATE);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    BaixaPagamento Baixa = EntityUtil<BaixaPagamento>.ParseDataRow(dr);
                    Baixa.IDContaPagar = Conta.IDContaPagar;

                    if (!FuncoesBaixaPagamento.Salvar(Baixa, TipoOperacao.UPDATE))
                        throw new Exception("Não foi possível salvar as Baixas");
                }

            dt = SyncUtil.GetChanges(BAIXAS, TipoOperacao.DELETE);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    decimal id = Convert.ToDecimal(dr["IDBAIXAPAGAMENTO"]);
                  //  if (id != -1)
                  //  {
                        if (!FuncoesBaixaPagamento.Remover(id))
                            throw new Exception("Não foi possível salvar as Baixas");
                 //   }
                }

            /* Salvando os Cheques das Baixas */
            foreach (DataTable dtCheque in Cheques.Values)
            {
                dt = SyncUtil.GetChanges(dtCheque, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaPagar.Salvar(EntityUtil<ChequeContaPagar>.ParseDataRow(dr), TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar os Cheques.");

                dt = SyncUtil.GetChanges(dtCheque, TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaPagar.Salvar(EntityUtil<ChequeContaPagar>.ParseDataRow(dr), TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar os Cheques.");

                dt = SyncUtil.GetChanges(dtCheque, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaPagar.Remover(Convert.ToDecimal(dr["IDCHEQUECONTAPAGAR"])))
                            throw new Exception("Não foi possível salvar os Cheques.");
            }
        }

        private bool Validar()
        {            
            if (ovCMB_Fornecedor.SelectedItem == null)
            {
                guna2TabControl2.SelectedTab = guna2TabControl2.TabPages[0];
                guna2TabControl2.SelectedIndex = 0;
                ovCMB_Fornecedor.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Fornecedor.", "yellow", false, false);
                return false;
            }
                        
            if (ovCMB_CentroCusto.SelectedItem == null)
            {
                guna2TabControl2.SelectedTab = guna2TabControl2.TabPages[0];
                guna2TabControl2.SelectedIndex = 0;
                ovCMB_CentroCusto.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Centro de Custo.", "yellow", false, false);
                return false;
            }

            if (ovCMB_Natureza.SelectedItem == null)
            {
                guna2TabControl2.SelectedTab = guna2TabControl2.TabPages[0];
                guna2TabControl2.SelectedIndex = 0;
                ovCMB_Natureza.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Natureza Financeira.", "yellow", false, false);
                return false;
            }

            CalculaTotal();

            if (ovTXT_Total.Value == 0)
            {
                guna2TabControl2.SelectedTab = guna2TabControl2.TabPages[1];
                guna2TabControl2.SelectedIndex = 1;
                ovTXT_Valor.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe um Valor para o Lançamento.", "yellow", false, false);
                return false;
            }

            return true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            /*FCAFIN_Classificacao AdicionarClassificacao = new FCAFIN_Classificacao(null, new ClassificacaoContaPagar(), null, false);
            AdicionarClassificacao.ShowDialog(this);
            if (AdicionarClassificacao.Salvou)
            {
                // Verifica se o produto já esta adicionado.
                var lQueryProduto = CLASSIFICACAO.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted &&
                                                  Convert.ToDecimal(o["IDNATUREZA"]) == (AdicionarClassificacao.ovCMB_Natureza.SelectedItem as Natureza).IDNatureza && Convert.ToDecimal(o["IDCENTROCUSTO"]) == (AdicionarClassificacao.ovCMB_CentroCusto.SelectedItem as CentroCusto).IDCentroCusto);
                if (lQueryProduto != null && lQueryProduto.Count() > 0)
                {
                    PDV.UTIL.SyncMessager.CreateMessage(0, NOME_TELA, $"Uma Classificação de Centro de Custo <b>{(AdicionarClassificacao.ovCMB_CentroCusto.SelectedItem as CentroCusto).Descricao}</b> e Natureza <b>{(AdicionarClassificacao.ovCMB_Natureza.SelectedItem as Natureza).Descricao}</b> já está adicionada, esta entrada será descartada.", "yellow", false, false);
                    return;
                }

                DataRow dr = CLASSIFICACAO.NewRow();
                dr["CENTROCUSTO"] = (AdicionarClassificacao.ovCMB_CentroCusto.SelectedItem as CentroCusto).Descricao;
                dr["NATUREZA"] = (AdicionarClassificacao.ovCMB_Natureza.SelectedItem as Natureza).Descricao;
                dr["IDCLASSIFICACAOCONTAPAGAR"] = -1;
                dr["IDNATUREZA"] = (AdicionarClassificacao.ovCMB_Natureza.SelectedItem as Natureza).IDNatureza;
                dr["IDCENTROCUSTO"] = (AdicionarClassificacao.ovCMB_CentroCusto.SelectedItem as CentroCusto).IDCentroCusto;
                dr["IDCONTAPAGAR"] = Conta.IDContaPagar;
                CLASSIFICACAO.Rows.Add(dr);
            }*/
        }
               

        private void ovGRD_Baixas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (ovGRD_Baixas.Columns[e.ColumnIndex].Name)
            {
                case "total":
                    e.Value = Convert.ToDecimal(e.Value).ToString("c2");
                    break;
              //  case "baixa":
                   // if (e.Value != null && e.Value != DBNull.Value)
                    //    e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                   // break;
            }
        }

        private void AjustaTextHeaderBaixas()
        {
            ovGRD_Baixas.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Baixas.Width;
            foreach (DataGridViewColumn column in ovGRD_Baixas.Columns)
            {
                switch (column.Name)
                {
                    case "baixa":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Data Baixa";
                        break;
                    case "origem":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "Origem";
                        break;
                    case "complemento":
                        column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "Complemento";
                        break;
                    case "contabancaria":
                        column.DisplayIndex = 4;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.30);
                        column.HeaderText = "Conta Bancária";
                        break;
                    case "total":
                        column.DisplayIndex = 5;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Valor";
                        break;
                    default:
                       // column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Baixas.Rows.Count > 0)
            {
                ovGRD_Baixas.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Baixas.Rows[0].Selected = true;
            }

        }

        private void CarregarBaixas(bool Banco)
        {
            if (Banco)
                BAIXAS = FuncoesBaixaPagamento.GetBaixas(Conta.IDContaPagar);
            if (BAIXAS != null)
                BAIXAS.DefaultView.Sort = "BAIXA";
            ovGRD_Baixas.DataSource = null;
            ovGRD_Baixas.DataSource = BAIXAS;
            AjustaTextHeaderBaixas();
        }

        private void VerificaCheques(decimal IDBaixa, bool Removeu, DataTable dtCheques)
        {
            if (Removeu && Cheques.ContainsKey(IDBaixa))
            {
                Cheques.Remove(IDBaixa);
                return;
            }

            Cheques[IDBaixa] = dtCheques;
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            Conta.Valor = ovTXT_Valor.Value;
            Conta.Multa = ovTXT_Multa.Value;
            Conta.Juros = ovTXT_Juros.Value;
            Conta.Desconto = ovTXT_Desconto.Value;
            Conta.Saldo = ovTXT_Saldo.Value;
            Conta.ValorTotal = ovTXT_Total.Value;

            decimal? IDPagamento = null;
            if (ovCMB_FormaPagamento.SelectedItem != null)
            {
                IDPagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
            }

            FCAFIN_BaixaPagamento Form = new FCAFIN_BaixaPagamento(Conta, new BaixaPagamento()
            {
                IDBaixaPagamento = Sequence.GetNextID("BAIXAPAGAMENTO", "IDBAIXAPAGAMENTO"),
                Baixa = DateTime.Now
            }, IDPagamento);
            Form.ShowDialog(this);

            if (Form.Salvou)
            {
                DataRow dr = BAIXAS.NewRow();
                dr["IDBAIXAPAGAMENTO"] = Form.BaixaPag.IDBaixaPagamento;
                dr["BAIXA"] = Form.BaixaPag.Baixa;
                dr["CONTABANCARIA"] = FuncoesContaBancaria.GetContaBancaria(Form.BaixaPag.IDContaBancaria).Nome;
                dr["TOTAL"] = (Form.BaixaPag.Valor - Form.BaixaPag.Desconto) + Form.BaixaPag.Juros +
                              Form.BaixaPag.Multa;
                dr["VALOR"] = Form.BaixaPag.Valor;
                dr["IDCONTAPAGAR"] = Conta.IDContaPagar;
                dr["IDFORMADEPAGAMENTO"] = Form.BaixaPag.IDFormaDePagamento;
                dr["IDCONTABANCARIA"] = Form.BaixaPag.IDContaBancaria;
                dr["ORIGEM"] = Form.BaixaPag.Origem;
                dr["COMPLEMENTO"] = Form.BaixaPag.Complemento;
                dr["MULTA"] = Form.BaixaPag.Multa;
                dr["JUROS"] = Form.BaixaPag.Juros;
                dr["DESCONTO"] = Form.BaixaPag.Desconto;
                BAIXAS.Rows.Add(dr);
                VerificaCheques(Form.BaixaPag.IDBaixaPagamento, false, Form.Cheques);
                CarregarBaixas(false);
                AtualizaSaldo();

            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            decimal IDBaixa = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Baixas.SelectedRows[0].DataBoundItem as DataRowView), "IDBAIXAPAGAMENTO"));
            BAIXAS.DefaultView.RowFilter = "[IDBAIXAPAGAMENTO] = " + IDBaixa;

            Conta.Valor = ovTXT_Valor.Value;
            Conta.Multa = ovTXT_Multa.Value;
            Conta.Juros = ovTXT_Juros.Value;
            Conta.Desconto = ovTXT_Desconto.Value;
            Conta.Saldo = ovTXT_Saldo.Value;
            Conta.ValorTotal = ovTXT_Total.Value;
            FCAFIN_BaixaPagamento Form = new FCAFIN_BaixaPagamento(Conta, EntityUtil<BaixaPagamento>.ParseDataRow(BAIXAS.DefaultView[0].Row), null);
            Form.ShowDialog(this);
            if (Form.Salvou)
            {
                foreach (DataRowView drView in BAIXAS.DefaultView)
                {
                    drView.BeginEdit();
                    drView["BAIXA"] = Form.BaixaPag.Baixa;
                    drView["CONTABANCARIA"] = FuncoesContaBancaria.GetContaBancaria(Form.BaixaPag.IDContaBancaria).Nome;
                    drView["VALOR"] = Form.BaixaPag.Valor;
                    drView["TOTAL"] = (Form.BaixaPag.Valor - Form.BaixaPag.Desconto) + Form.BaixaPag.Juros + Form.BaixaPag.Multa;
                    drView["IDCONTAPAGAR"] = Conta.IDContaPagar;
                    drView["IDFORMADEPAGAMENTO"] = Form.BaixaPag.IDFormaDePagamento;
                    drView["IDCONTABANCARIA"] = Form.BaixaPag.IDContaBancaria;
                    drView["ORIGEM"] = Form.BaixaPag.Origem;
                    drView["COMPLEMENTO"] = Form.BaixaPag.Complemento;
                    drView["MULTA"] = Form.BaixaPag.Multa;
                    drView["JUROS"] = Form.BaixaPag.Juros;
                    drView["DESCONTO"] = Form.BaixaPag.Desconto;
                    drView.EndEdit();
                }
                VerificaCheques(IDBaixa, false, Form.Cheques);
            }
            BAIXAS.DefaultView.RowFilter = string.Empty;
            CarregarBaixas(false);
            AtualizaSaldo();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover a Baixa selecionada?", "yellow", true, false) == DialogResult.OK)
            {
                try
                {
                    decimal IDBaixa = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Baixas.SelectedRows[0].DataBoundItem as DataRowView), "IDBAIXAPAGAMENTO"));
                    BAIXAS.DefaultView.RowFilter = "[IDBAIXAPAGAMENTO] = " + IDBaixa;
                    foreach (DataRowView drView in BAIXAS.DefaultView)
                        drView.Delete();

                    VerificaCheques(IDBaixa, true, null);
                }
                catch (Exception Ex)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
                    return;
                }
                finally
                {
                    BAIXAS.DefaultView.RowFilter = string.Empty;
                    CarregarBaixas(false);
                    AtualizaSaldo();
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
            AtualizaSaldo();
        }

        private void AtualizaSaldo()
        {
            if (BAIXAS == null)
                return;

            decimal ValorSaldo = ovTXT_Total.Value - BAIXAS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["TOTAL"]));
            ovTXT_Saldo.Value = ValorSaldo < 0 ? 0 : ValorSaldo;
        }

        private void FCAFIN_ContaPagar_Load_1(object sender, EventArgs e)
        {
            guna2TabControl2.SelectedTab = guna2TabControl2.TabPages[0];
            guna2TabControl2.SelectedIndex = 0;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            FCO_Fornecedor SeletorFornecedor = new FCO_Fornecedor(true);
            SeletorFornecedor.ShowDialog(this);

            if (SeletorFornecedor.DRSelected == null)
                return;

            FORNECEDORES = FuncoesFornecedor.GetFornecedores();
            ovCMB_Fornecedor.DataSource = FORNECEDORES;

            DataRow DrSelecionada = SeletorFornecedor.DRSelected;

            decimal ToCompare = Convert.ToDecimal(DrSelecionada["IDFORNECEDOR"]);
            Fornecedor SelectedFornecedor = FuncoesFornecedor.GetFornecedor(ToCompare);
            ovCMB_Fornecedor.SelectedItem = FORNECEDORES.Find(x => x.IDFornecedor == SelectedFornecedor.IDFornecedor);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ovCMB_Fornecedor.SelectedIndex = -1;
            ovCMB_Fornecedor.SelectedItem = null;
        }
               
        private void ovTXT_Juros_Leave(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FCO_NaturezaFinanceira SeletorNatureza = new FCO_NaturezaFinanceira(true, -1);
            SeletorNatureza.ShowDialog(this);

            if (SeletorNatureza.DRSelected == null)
                return;

            Naturezas = FuncoesNatureza.GetNaturezas();
            ovCMB_Natureza.DataSource = Naturezas;

            DataRow DrSelecionada = SeletorNatureza.DRSelected;

            decimal ToCompare = Convert.ToDecimal(DrSelecionada["IDNATUREZA"]);
            Natureza SelectedNatureza = FuncoesNatureza.GetNatureza(ToCompare);
            ovCMB_Natureza.SelectedItem = Naturezas.Find(x => x.IDNatureza == SelectedNatureza.IDNatureza);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            FCO_CentroCusto SeletorCentroCusto = new FCO_CentroCusto(true, -1);
            SeletorCentroCusto.ShowDialog(this);

            if (SeletorCentroCusto.DRSelected == null)
                return;

            Centros = FuncoesCentroCusto.GetCentrosCusto();
            ovCMB_CentroCusto.DataSource = Centros;

            DataRow DrSelecionada = SeletorCentroCusto.DRSelected;

            decimal ToCompare = Convert.ToDecimal(DrSelecionada["IDCENTROCUSTO"]);
            CentroCusto SelectedCentroCusto = FuncoesCentroCusto.GetCentroCusto(ToCompare);
            ovCMB_CentroCusto.SelectedItem = Centros.Find(x => x.IDCentroCusto == SelectedCentroCusto.IDCentroCusto);
        }

        private void FCAFIN_ContaPagar_Shown(object sender, EventArgs e)
        {
            if (_AbaBaixa)
            {
                guna2TabControl2.SelectedTab = guna2TabControl2.TabPages[1];
                guna2TabControl2.SelectedIndex = 1;
            }
        }

        private void ovCMB_Fornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ovCMB_FormaPagamento.SelectedItem = null;
            ovCMB_FormaPagamento.SelectedIndex = -1;
        }
    }
}
