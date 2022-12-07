using AutoController.Funcoes;
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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCAFIN_ContaPagarLancamento : MetroForm
    {
        private List<StatusConta> STATUSCONTA = null;
        private List<Fornecedor> FORNECEDORES = null;

        private List<Natureza> Naturezas = null;
        private List<CentroCusto> Centros = null;
        private List<FormaDePagamento> FormasPagamento = null;

        private string NOME_TELA = "Realizar Lançamento - Pagamento";

        private DataTable DUPLICATAS = null;

        private decimal? _Valor;

        string _Origem = "Financeiro";

        public FCAFIN_ContaPagarLancamento(decimal? valor, string Origem)
        {
            InitializeComponent();
            _Valor = valor;

            if (!string.IsNullOrWhiteSpace(Origem))
                _Origem = Origem;

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

            DUPLICATAS = new DataTable();
            DUPLICATAS.Columns.Add("numerodocumento");
            DUPLICATAS.Columns.Add("datavencimento");
            DUPLICATAS.Columns.Add("valor");
            CarregarFinanceiro(false);

            PreencherTela();
        }

        private void PreencherTela()
        {

            // Preenche o padrão que está configurado, se configurado.

            // Estoque > Financeiro

            if (_Valor != null)
                ovTXT_Valor.Value = _Valor.Value;

            ovTXT_Origem.Text = _Origem;

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

                // Cria as Duplicatas.

                // decimal IDContaPagar = Sequence.GetNextID("CONTAPAGAR", "IDCONTAPAGAR");

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                foreach (DataRow dr in DUPLICATAS.Rows)
                {
                    if (dr.RowState == DataRowState.Deleted)
                        continue;

                    if (!FuncoesContaPagar.Salvar(new ContaPagar()
                    {
                        IDContaPagar = Sequence.GetNextID("CONTAPAGAR", "IDCONTAPAGAR"),
                        Emissao = ovTXT_Emissao.Value,
                        IDFornecedor = (ovCMB_Fornecedor.SelectedItem as Fornecedor).IDFornecedor,
                        Juros = 0,
                        Multa = 0,
                        Origem = ovTXT_Origem.Text,
                        Parcela = Convert.ToDecimal(dr["NUMERODOCUMENTO"]),
                        Saldo = Convert.ToDecimal(dr["VALOR"]),
                        Desconto = 0,
                        Valor = Convert.ToDecimal(dr["VALOR"]),
                        ValorTotal = Convert.ToDecimal(dr["VALOR"]),
                        Complemento = ovTXT_Complemento.Text,
                        Status = 1,
                        Vencimento = Convert.ToDateTime(dr["DATAVENCIMENTO"]),
                        IDNatureza = (ovCMB_Natureza.SelectedItem as Natureza).IDNatureza,
                        IDCentroCusto = (ovCMB_CentroCusto.SelectedItem as CentroCusto).IDCentroCusto,
                        IDFormaDePagamento = ovCMB_FormaPagamento.SelectedItem != null ? (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento : null

                    }, TipoOperacao.INSERT))
                        throw new Exception("Não foi possível lançar as Duplicatas.");
                }
   
                // Realiza o Lançamento.               

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

               SyncMessager.CreateMessage(0,NOME_TELA, "Lançamento realizado com sucesso!", "green", false, false);
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
          

            /*
            if (ovTXT_Valor.Value <= 0)
            {
                guna2TabControl2.SelectedTab = guna2TabControl2.TabPages[1];
                guna2TabControl2.SelectedIndex = 1;
                ovTXT_Valor.Focus();
                PDV.UTIL.SyncMessager.CreateMessage(0, NOME_TELA, "Informe um Valor para o Lançamento.", "yellow", false, false);
                return false;
            }*/

            decimal TotalDuplicatas = ((DUPLICATAS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["VALOR"]))));

            if (TotalDuplicatas <= 0)
            {
                guna2TabControl2.SelectedTab = guna2TabControl2.TabPages[1];
                guna2TabControl2.SelectedIndex = 1;
                BTN_GerarParcelas.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "É necessário gerar pelo menos 1 parcela.", "yellow", false, false);
                return false;
            }


            return true;
        }
                

        private void ovTXT_Valor_ValueChanged(object sender, EventArgs e)
        {
            
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

        }

        private void ovGRD_Financeiro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            switch (ovGRD_Financeiro.Columns[e.ColumnIndex].Name)
            {
                case "valor":
                    e.Value = Convert.ToDecimal(e.Value).ToString("c2");
                    break;
                case "datavencimento":

                    e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");

                    string Vencimento = Convert.ToDateTime((e.Value)).ToString("dd/MM/yyyy");
                    string DataHoje = DateTime.Now.ToString("dd/MM/yyyy");

                    if (Convert.ToDateTime(Vencimento) < Convert.ToDateTime(DataHoje))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(222, 106, 106);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(222, 106, 106);
                    }

                    break;                                   
            }
        }

        private void AjustaHeaderFinanceiro()
        {
            ovGRD_Financeiro.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Financeiro.Width;
            foreach (DataGridViewColumn column in ovGRD_Financeiro.Columns)
            {
                switch (column.Name)
                {
                    case "numerodocumento":
                        column.HeaderText = "Número do Documento";
                        column.DisplayIndex = 0;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.50);
                        break;
                    case "datavencimento":
                        column.HeaderText = "Vencimento";
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        break;
                    case "valor":
                        column.HeaderText = "Valor do Vencimento";
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.30);
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }
        }

        private void LimparDuplicatas()
        {
            foreach (DataRowView dr in DUPLICATAS.DefaultView)
                dr.Delete();
            ovGRD_Financeiro.DataSource = null;
            ovGRD_Financeiro.DataSource = DUPLICATAS;
            AjustaHeaderFinanceiro();
        }

        private void CarregarFinanceiro(bool BuscarBanco)
        { 
            ovGRD_Financeiro.RowHeadersVisible = false;
            ovGRD_Financeiro.DataSource = null;
            ovGRD_Financeiro.DataSource = DUPLICATAS;
            AjustaHeaderFinanceiro();          
        }

        private void BTN_GerarParcelas_Click(object sender, EventArgs e)
        {
            LimparDuplicatas();

            double Total = Convert.ToDouble(ovTXT_Valor.Value);

            if (Total <= 0)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não há nenhum valor para realizar a geração.", "yellow", false, false);
                return;
            }

            DateTime Vencimento = ovTXT_PrimeiraParcela.Value;
            double ValorParcela = SyncUtil.Arredondar(Total / Convert.ToInt32(ovTXT_QuantidadeParcela.Value), 2);

            for (int i = 0; i < ovTXT_QuantidadeParcela.Value; i++)
            {
                Vencimento = Vencimento.Date.AddMonths(i == 0 ? 0 : 1);
                DataRow dr = DUPLICATAS.NewRow();
                dr["NUMERODOCUMENTO"] = (i + 1).ToString("000");
                dr["DATAVENCIMENTO"] = Vencimento.Date;
                dr["VALOR"] = ValorParcela;
                DUPLICATAS.Rows.Add(dr);
            }

            decimal ValorFalta = Convert.ToDecimal(Total) - DUPLICATAS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["VALOR"]));
            foreach (DataRow dr in DUPLICATAS.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                    continue;

                dr["VALOR"] = Convert.ToDecimal(dr["VALOR"]) + ValorFalta;
                break;
            }

            CarregarFinanceiro(false);
        }

        private void BTN_LimparParcelas_Click(object sender, EventArgs e)
        {
            LimparDuplicatas();
        }

        private void BTN_Editar_Click(object sender, EventArgs e)
        {
            if (this.ovGRD_Financeiro.SelectedRows.Count != 1)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione um registro para Editar.", "yellow", false, false);
                return;
            }

            DataRowView dr = ovGRD_Financeiro.SelectedRows[0].DataBoundItem as DataRowView;
            if (dr == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione um registro para Editar.", "yellow", false, false);
                return;
            }

            if (dr != null)
            {

                DateTime Vencimento = Convert.ToDateTime(dr["DATAVENCIMENTO"]);
                decimal Valor = Convert.ToDecimal(dr["VALOR"]);
              
                FCA_EditarVencimento EditarVencimento = new FCA_EditarVencimento(Valor, Vencimento);

                EditarVencimento.ShowDialog(this);

                if (EditarVencimento.Salvou == true)
                {
                    dr.BeginEdit();
                    dr["VALOR"] = EditarVencimento.ovTXT_Valor.Value;
                    dr["DATAVENCIMENTO"] = EditarVencimento.ovTXT_Vencimento.Value;
                    dr.EndEdit();
                    //Recarrega Obs
                    CarregarFinanceiro(false);
                }
            }
        }

        private void ovGRD_Financeiro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Financeiro.SelectedRows.Count == 1)
            {
                    BTN_Editar_Click(sender, e);
            }
        }
    }
}
