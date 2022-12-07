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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCAFIN_ContaReceber : MetroForm
    {
        private List<Natureza> Naturezas = null;
        private List<FormaDePagamento> FORMASPAGAMENTO = null;
        private List<StatusConta> SITUACAOCONTA = null;
        private Cliente CLIENTE = null;
        private DataTable BAIXAS = null;

        public bool Salvou = false;

        private Dictionary<decimal, DataTable> Cheques = null;
        private string NOME_TELA = "Cadastro de Conta a Receber";
        private ContaReceber Conta = null;
        bool _AbaBaixa;
        private List<FormaDePagamento> FormasPagamento = null;

        public FCAFIN_ContaReceber(ContaReceber _Conta, bool AbaBaixa)
        {
            Conta = _Conta;
            _AbaBaixa = AbaBaixa;
            InitializeComponent();

            FORMASPAGAMENTO = FuncoesFormaDePagamento.GetFormasPagamento();
            SITUACAOCONTA = StatusConta.GetSituacoesConta();

            Naturezas = FuncoesNatureza.GetNaturezas();
            ovCMB_Natureza.DataSource = Naturezas;
            ovCMB_Natureza.DisplayMember = "descricao";
            ovCMB_Natureza.ValueMember = "idnatureza";
            ovCMB_Natureza.SelectedItem = null;

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
                       
            ovCMB_Natureza.SelectedItem = Naturezas.Where(o => o.IDNatureza == Conta.IDNatureza).FirstOrDefault();

            if (Conta.IDFormaDePagamento != null)
                ovCMB_FormaPagamento.SelectedItem = FormasPagamento.AsEnumerable().Where(o => o.IDFormaDePagamento == Conta.IDFormaDePagamento).FirstOrDefault();

            CLIENTE = Conta.IDCliente.HasValue ? FuncoesCliente.GetCliente(Conta.IDCliente.Value) : null;
            
            
            if (CLIENTE != null)
            {
                if (CLIENTE.TipoDocumento == 0)
                {
                    // CNPJ
                    ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CNPJ)).ToString(@"00\.000\.000\/0000\-00");
                }
                else if (CLIENTE.TipoDocumento == 1)
                {
                    // CPF
                    ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CPF)).ToString(@"000\.000\.000\-00");
                }
                else
                {
                    //Estrangeiro
                    ovTXT_CodCliente.Text = CLIENTE.DocEstrangeiro;
                }

                ovTXT_Cliente.Text = CLIENTE.TipoDocumento == 0 ? CLIENTE.RazaoSocial : CLIENTE.Nome;
            }
            else
            {
                ovTXT_Cliente.Text = "<Cliente Não Informado>";
            }

            ovTXT_Parcela.Value = Conta.Parcela;
            ovTXT_Emissao.Value = Conta.Emissao;
            ovTXT_Vencimento.Value = Conta.Vencimento;

            if (Conta.Status == 0)
                ovCBX_Cancelada.Checked = true;
                        
            ovTXT_Origem.Text = Conta.Origem;
            ovTXT_Complemento.Text = Conta.Complemento;

            /* Valores */
            ovTXT_Valor.Value = Conta.Valor;
            ovTXT_Multa.Value = Conta.Multa;
            ovTXT_Juros.Value = Conta.Juros;
            ovTXT_Desconto.Value = Conta.Desconto;
            ovTXT_Saldo.Value = Conta.Saldo;
            ovTXT_Total.Value = Conta.ValorTotal;

            if (!Conta.Origem.Contains("Entrada") || !Conta.Origem.Contains("Saida"))
            {
                LBL_Cliente.Text = "* Cliente:";
                LBL_Cliente.Font = new Font("Segoe UI", (float)9.75, FontStyle.Bold);
            }
            else
            {
                LBL_Cliente.Text = "Cliente:";
                LBL_Cliente.Font = new Font("Segoe UI", (float)9.75, FontStyle.Regular);
            }

            CarregarBaixas(true);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Salvou = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FCO_Cliente SeletorCliente = new FCO_Cliente(true);
            SeletorCliente.ShowDialog(this);

            if (SeletorCliente.DRSelected == null)
                return;

            DataRow DrSelecionada = SeletorCliente.DRSelected;
            CLIENTE = FuncoesCliente.GetCliente(Convert.ToDecimal(DrSelecionada["IDCLIENTE"]));

            if (CLIENTE == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Cliente inexistente, insira uma Cliente válido.", "yellow", false, false);
                ovTXT_Cliente.Text = "<Cliente Não Informado>";
                ovTXT_CodCliente.Text = null;
                ovTXT_CodCliente.Focus();
            }
            else
            {
                if (CLIENTE.TipoDocumento == 0)
                {
                    // CNPJ
                    ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CNPJ)).ToString(@"00\.000\.000\/0000\-00");
                }
                else if (CLIENTE.TipoDocumento == 1)
                {
                    //CPF
                    ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CPF)).ToString(@"000\.000\.000\-00");
                }
                else
                {
                    //Estrangeiro
                    ovTXT_CodCliente.Text = CLIENTE.DocEstrangeiro;
                }

                ovTXT_Cliente.Text = CLIENTE.TipoDocumento == 0 ? CLIENTE.RazaoSocial : CLIENTE.Nome;
            }
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
                               
                Conta.IDNatureza = (ovCMB_Natureza.SelectedItem as Natureza).IDNatureza;
                Conta.IDCliente = CLIENTE == null ? null : (decimal?)CLIENTE.IDCliente;

                if (ovCMB_FormaPagamento.SelectedItem != null)
                {
                    Conta.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
                }
                else
                {
                    Conta.IDFormaDePagamento = null;
                }

                Conta.Parcela = ovTXT_Parcela.Value;
                Conta.Emissao = ovTXT_Emissao.Value;
                Conta.Vencimento = ovTXT_Vencimento.Value;
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
                if (Conta.IDContaReceber == -1)
                {
                    Op = TipoOperacao.INSERT;
                    Conta.IDContaReceber = Sequence.GetNextID("CONTARECEBER", "IDCONTARECEBER");
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


                if (!FuncoesContaReceber.Salvar(Conta, Op))
                    throw new Exception("Não foi possível salvar o Lançamento.");

                // Salvar as Baixas
                SalvarBaixas();

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Lançamento salvo com sucesso!", "green", false, false);
                Salvou = true;
            }
            catch (Exception Ex)
            {
                if (InTransaction)
                    PDVControlador.Rollback();
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();

                SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
                Salvou = false;
            }
        }

        private void SalvarBaixas()
        {
            DataTable dt = SyncUtil.GetChanges(BAIXAS, TipoOperacao.INSERT);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    dr["IDCONTARECEBER"] = Conta.IDContaReceber;
                    if (!FuncoesBaixaRecebimento.Salvar(EntityUtil<BaixaRecebimento>.ParseDataRow(dr), TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar as Baixas");
                }

            dt = SyncUtil.GetChanges(BAIXAS, TipoOperacao.UPDATE);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    dr["IDCONTARECEBER"] = Conta.IDContaReceber;
                    if (!FuncoesBaixaRecebimento.Salvar(EntityUtil<BaixaRecebimento>.ParseDataRow(dr), TipoOperacao.UPDATE))
                        throw new Exception("Não foi possível salvar as Baixas");
                }

            dt = SyncUtil.GetChanges(BAIXAS, TipoOperacao.DELETE);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    if (!FuncoesBaixaRecebimento.Remover(Convert.ToDecimal(dr["IDBAIXARECEBIMENTO"])))
                        throw new Exception("Não foi possível salvar as Baixas");
                }

            /* Salvando os Cheques das Baixas */
            foreach (DataTable dtCheque in Cheques.Values)
            {
                dt = SyncUtil.GetChanges(dtCheque, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaReceber.Salvar(EntityUtil<ChequeContaReceber>.ParseDataRow(dr), TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar os Cheques.");

                dt = SyncUtil.GetChanges(dtCheque, TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaReceber.Salvar(EntityUtil<ChequeContaReceber>.ParseDataRow(dr), TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar os Cheques.");

                dt = SyncUtil.GetChanges(dtCheque, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaReceber.Remover(Convert.ToDecimal(dr["IDCHEQUECONTARECEBER"])))
                            throw new Exception("Não foi possível salvar os Cheques.");
            }
        }

        private bool Validar()
        {
           /* if (ovCMB_Conta.SelectedItem == null)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovCMB_Conta.Focus();
                PDV.UTIL.SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Conta Bancária.", "yellow", false, false);
                return false;
            }*/

            if (ovCMB_Natureza.SelectedItem == null)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovCMB_Natureza.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Natureza Financeira.", "yellow", false, false);
                return false;
            }

            if (CLIENTE == null && !ovTXT_Origem.Text.Contains("Entrada") && !ovTXT_Origem.Text.Contains("Saida"))
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovTXT_Cliente.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Cliente.", "yellow", false, false);
                return false;
            }

            if (ovCBX_Cancelada.Checked)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovCBX_Cancelada.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Não é possível marcar uma conta renegociada como cancelada, verifique.", "yellow", false, false);
                return false;
            }

            CalculaTotal();

            if (ovTXT_Total.Value == 0)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovTXT_Valor.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe um Valor para o Lançamento.", "yellow", false, false);
                return false;                                
            }

            return true;
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

        private void FCAFIN_ContaReceber_Load(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
            guna2TabControl1.SelectedIndex = 0;
        }
          
        /* Baixas */
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
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "Data Baixa";
                        break;
                    case "contabancaria":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.50);
                        column.HeaderText = "Conta Bancária";
                        break;
                    case "total":
                        column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.30);
                        column.HeaderText = "Valor";
                        break;
                    default:
                        column.DisplayIndex = 0;
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
                BAIXAS = FuncoesBaixaRecebimento.GetBaixas(Conta.IDContaReceber);
            if (BAIXAS != null)
                BAIXAS.DefaultView.Sort = "BAIXA";
            ovGRD_Baixas.DataSource = null;
            ovGRD_Baixas.DataSource = BAIXAS;
            AjustaTextHeaderBaixas();
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
            if(ovCMB_FormaPagamento.SelectedItem != null)
            {
                IDPagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
            }

            FCAFIN_BaixaRecebimento Form = new FCAFIN_BaixaRecebimento(Conta, new BaixaRecebimento()
            {
                IDBaixaRecebimento = Sequence.GetNextID("BAIXARECEBIMENTO", "IDBAIXARECEBIMENTO"),
                Baixa = DateTime.Now                
            }, IDPagamento);

            Form.ShowDialog(this);

            if (Form.Salvou)
            {
                DataRow dr = BAIXAS.NewRow();
                dr["IDBAIXARECEBIMENTO"] = Form.BaixaRec.IDBaixaRecebimento;
                dr["BAIXA"] = Form.BaixaRec.Baixa;
                dr["CONTABANCARIA"] = FuncoesContaBancaria.GetContaBancaria(Form.BaixaRec.IDContaBancaria).Nome;
                dr["TOTAL"] = (Form.BaixaRec.Valor - Form.BaixaRec.Desconto) + Form.BaixaRec.Juros + Form.BaixaRec.Multa;
                dr["VALOR"] = Form.BaixaRec.Valor;
                dr["IDCONTARECEBER"] = Conta.IDContaReceber;
                dr["IDFORMADEPAGAMENTO"] = Form.BaixaRec.IDFormaDePagamento;
                dr["IDCONTABANCARIA"] = Form.BaixaRec.IDContaBancaria;
                dr["COMPLEMENTO"] = Form.BaixaRec.Complemento;
                dr["MULTA"] = Form.BaixaRec.Multa;
                dr["JUROS"] = Form.BaixaRec.Juros;
                dr["DESCONTO"] = Form.BaixaRec.Desconto;
                BAIXAS.Rows.Add(dr);

                AtualizaSaldo();

                CarregarBaixas(false);
                VerificaCheques(Form.BaixaRec.IDBaixaRecebimento, false, Form.Cheques);
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            decimal IDBaixa = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Baixas.SelectedRows[0].DataBoundItem as DataRowView), "IDBAIXARECEBIMENTO"));
            BAIXAS.DefaultView.RowFilter = "[IDBAIXARECEBIMENTO] = " + IDBaixa;

            Conta.Valor = ovTXT_Valor.Value;
            Conta.Multa = ovTXT_Multa.Value;
            Conta.Juros = ovTXT_Juros.Value;
            Conta.Desconto = ovTXT_Desconto.Value;
            Conta.Saldo = ovTXT_Saldo.Value;
            Conta.ValorTotal = ovTXT_Total.Value;
            FCAFIN_BaixaRecebimento Form = new FCAFIN_BaixaRecebimento(Conta, EntityUtil<BaixaRecebimento>.ParseDataRow(BAIXAS.DefaultView[0].Row), null);
            Form.ShowDialog(this);
            if (Form.Salvou)
            {
                foreach (DataRowView drView in BAIXAS.DefaultView)
                {
                    drView.BeginEdit();
                    drView["BAIXA"] = Form.BaixaRec.Baixa;
                    drView["CONTABANCARIA"] = FuncoesContaBancaria.GetContaBancaria(Form.BaixaRec.IDContaBancaria).Nome;
                    drView["VALOR"] = Form.BaixaRec.Valor;
                    drView["TOTAL"] = (Form.BaixaRec.Valor - Form.BaixaRec.Desconto) + Form.BaixaRec.Juros + Form.BaixaRec.Multa;
                    drView["IDCONTARECEBER"] = Conta.IDContaReceber;
                    drView["IDFORMADEPAGAMENTO"] = Form.BaixaRec.IDFormaDePagamento;
                    drView["IDCONTABANCARIA"] = Form.BaixaRec.IDContaBancaria;
                    drView["COMPLEMENTO"] = Form.BaixaRec.Complemento;
                    drView["MULTA"] = Form.BaixaRec.Multa;
                    drView["JUROS"] = Form.BaixaRec.Juros;
                    drView["DESCONTO"] = Form.BaixaRec.Desconto;
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
                    decimal IDBaixa = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Baixas.SelectedRows[0].DataBoundItem as DataRowView), "IDBAIXARECEBIMENTO"));
                    BAIXAS.DefaultView.RowFilter = "[IDBAIXARECEBIMENTO] = " + IDBaixa;
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

        private void ovGRD_Baixas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (ovGRD_Baixas.Columns[e.ColumnIndex].Name)
            {
                case "total":
                    e.Value = Convert.ToDecimal(e.Value).ToString("c2");
                    break;
                case "baixa":
                    if (e.Value != null && e.Value != DBNull.Value)
                        e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                    break;
            }
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
            if ((BAIXAS == null))
                return;

            decimal ValorSaldo = 0;
            if (BAIXAS != null)
                ValorSaldo = ovTXT_Total.Value - BAIXAS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["TOTAL"]));

            ovTXT_Saldo.Value = ValorSaldo < 0 ? 0 : ValorSaldo;
        }

        private void ovTXT_CodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ovTXT_Emissao.Focus();
            }
        }

        private void ovTXT_CodCliente_Leave(object sender, EventArgs e)
        {
            if (ovTXT_CodCliente.Text != string.Empty)
            {
                CLIENTE = FuncoesCliente.GetClientePorDocumento(SyncUtil.SomenteNumeros(ovTXT_CodCliente.Text));

                if (CLIENTE == null)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Cliente inexistente, insira uma Cliente válido.", "yellow", false, false);
                    ovTXT_Cliente.Text = "<Cliente Não Informado>";
                    ovTXT_CodCliente.Text = null;
                    ovTXT_CodCliente.Focus();
                }
                else
                {
                    if (CLIENTE.TipoDocumento == 1)
                    {
                        // CNPJ
                        ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CNPJ)).ToString(@"000\.000\.000\-00");
                    }
                    else if (CLIENTE.TipoDocumento == 0)
                    {
                        // CPF
                        ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CPF)).ToString(@"00\.000\.000\/0000\-00");
                    }
                    else
                    {
                        //Estrangeiro
                        ovTXT_CodCliente.Text = CLIENTE.DocEstrangeiro;
                    }
                    ovTXT_Cliente.Text = CLIENTE.TipoDocumento == 0 ? CLIENTE.RazaoSocial : CLIENTE.Nome;
                }
            }
            else
            {
                CLIENTE = null;
                ovTXT_Cliente.Text = "<Cliente Não Informado>";
                ovTXT_CodCliente.Text = null;
            }

        }

        private void ovGRD_Baixas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Baixas.SelectedRows.Count == 1)
            {
                    metroButton7_Click(sender, e);
            }
        }

        private void IdentificacaoTab_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
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
            ovCMB_FormaPagamento.SelectedItem = null;
            ovCMB_FormaPagamento.SelectedIndex = -1;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            CLIENTE = null;
            ovTXT_Cliente.Text = "<Cliente Não Informado>";
            ovTXT_CodCliente.Text = null;
        }

        private void FCAFIN_ContaReceber_Shown(object sender, EventArgs e)
        {
            if (_AbaBaixa)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[1];
                guna2TabControl1.SelectedIndex = 1;
            }
        }
    }
}
