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
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCAFIN_Mensalidade : MetroForm
    {
        private List<Natureza> Naturezas = null;
        private List<FormaDePagamento> FORMASPAGAMENTO = null;
        private List<StatusConta> SITUACAOCONTA = null;
        private Cliente CLIENTE = null;
        private DataTable BAIXAS = null;

        public bool Salvou = false;
        private bool ComitarTransacao = true;

        private Dictionary<decimal, DataTable> Cheques = null;
        private string NOME_TELA = "Cadastro de Conta a Receber";
        private Mensalidade _Mensalidade = null;

        private List<FormaDePagamento> FormasPagamento = null;

        private Veiculo VEICULO = null;

        public FCAFIN_Mensalidade(Mensalidade Mensalidade, bool _ComitarTransacao = true)
        {
            _Mensalidade = Mensalidade;
            ComitarTransacao = _ComitarTransacao;
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
                       
            ovCMB_Natureza.SelectedItem = Naturezas.Where(o => o.IDNatureza == _Mensalidade.IDNatureza).FirstOrDefault();

            if (_Mensalidade.IDFormaDePagamento != null)
                ovCMB_FormaPagamento.SelectedItem = FormasPagamento.AsEnumerable().Where(o => o.IDFormaDePagamento == _Mensalidade.IDFormaDePagamento).FirstOrDefault();

            CLIENTE = _Mensalidade.IDCliente != -1 ? FuncoesCliente.GetCliente(_Mensalidade.IDCliente) : null;
            VEICULO = _Mensalidade.IDVeiculo != -1 ? FuncoesVeiculo.GetVeiculo(_Mensalidade.IDVeiculo) : null;

            if(VEICULO != null)
            {
                ovTXT_Veiculo.Text = $"{VEICULO.Placa} - {VEICULO.Descricao}";
            }

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

            ovTXT_Parcela.Value = _Mensalidade.Parcela;
            ovTXT_Emissao.Value = _Mensalidade.Emissao;
            ovTXT_Vencimento.Value = _Mensalidade.Vencimento;

            if (_Mensalidade.Status == 0)
                ovCBX_Cancelada.Checked = true;
                        
            ovTXT_Origem.Text = _Mensalidade.Origem;
            ovTXT_Complemento.Text = _Mensalidade.Complemento;

            /* Valores */
            ovTXT_Valor.Value = _Mensalidade.Valor;
            ovTXT_Multa.Value = _Mensalidade.Multa;
            ovTXT_Juros.Value = _Mensalidade.Juros;
            ovTXT_Desconto.Value = _Mensalidade.Desconto;
            ovTXT_Saldo.Value = _Mensalidade.Saldo;
            ovTXT_Total.Value = _Mensalidade.ValorTotal;

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

                _Mensalidade.IDNatureza = (ovCMB_Natureza.SelectedItem as Natureza).IDNatureza;
                _Mensalidade.IDCliente = CLIENTE.IDCliente;
                _Mensalidade.IDVeiculo = VEICULO.IDVeiculo;

                if (ovCMB_FormaPagamento.SelectedItem != null)
                {
                    _Mensalidade.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
                }
                else
                {
                    _Mensalidade.IDFormaDePagamento = null;
                }

                _Mensalidade.Parcela = ovTXT_Parcela.Value;
                _Mensalidade.Emissao = ovTXT_Emissao.Value;
                _Mensalidade.Vencimento = ovTXT_Vencimento.Value;
                _Mensalidade.Origem = ovTXT_Origem.Text;
                _Mensalidade.Complemento = ovTXT_Complemento.Text;

                /* Valores */
                _Mensalidade.Valor = ovTXT_Valor.Value;
                _Mensalidade.Multa = ovTXT_Multa.Value;
                _Mensalidade.Juros = ovTXT_Juros.Value;
                _Mensalidade.Desconto = ovTXT_Desconto.Value;
                _Mensalidade.Saldo = ovTXT_Saldo.Value;
                _Mensalidade.ValorTotal = ovTXT_Total.Value;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (_Mensalidade.IDMensalidade == -1)
                {
                    Op = TipoOperacao.INSERT;
                    _Mensalidade.IDMensalidade = Sequence.GetNextID("MENSALIDADE", "IDMENSALIDADE");
                }

                // Status
                if (ovCBX_Cancelada.Checked == true)
                {
                    _Mensalidade.Status = 0;
                }
                else
                {
                    decimal ValorBaixas = BAIXAS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["TOTAL"]));                    
                    
                    if (ValorBaixas >= _Mensalidade.ValorTotal)
                    {
                        //Baixado
                        _Mensalidade.Status = 3;
                    }
                    else if (ValorBaixas > 0 && ValorBaixas < _Mensalidade.ValorTotal)
                    {
                        // Parcial
                        _Mensalidade.Status = 2;
                    }
                    else
                    {
                        // Aberto
                        _Mensalidade.Status = 1;
                    }
                }


                if (!FuncoesMensalidade.Salvar(_Mensalidade, Op))
                    throw new Exception("Não foi possível salvar a Mensalidade.");

                // Salvar as Baixas
                SalvarBaixas();

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Mensalidade salva com sucesso!", "green", false, false);
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
                    dr["IDMENSALIDADE"] = _Mensalidade.IDMensalidade;
                    if (!FuncoesBaixaMensalidade.Salvar(EntityUtil<BaixaMensalidade>.ParseDataRow(dr), TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar as Baixas");
                }

            dt = SyncUtil.GetChanges(BAIXAS, TipoOperacao.UPDATE);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    dr["IDMENSALIDADE"] = _Mensalidade.IDMensalidade;
                    if (!FuncoesBaixaMensalidade.Salvar(EntityUtil<BaixaMensalidade>.ParseDataRow(dr), TipoOperacao.UPDATE))
                        throw new Exception("Não foi possível salvar as Baixas");
                }

            dt = SyncUtil.GetChanges(BAIXAS, TipoOperacao.DELETE);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    if (!FuncoesBaixaMensalidade.Remover(Convert.ToDecimal(dr["IDBAIXAMENSALIDADE"])))
                        throw new Exception("Não foi possível salvar as Baixas");
                }

            /* Salvando os Cheques das Baixas */
            foreach (DataTable dtCheque in Cheques.Values)
            {
                dt = SyncUtil.GetChanges(dtCheque, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesMensalidade.Salvar(EntityUtil<ChequeMensalidade>.ParseDataRow(dr), TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar os Cheques.");

                dt = SyncUtil.GetChanges(dtCheque, TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesMensalidade.Salvar(EntityUtil<ChequeMensalidade>.ParseDataRow(dr), TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar os Cheques.");

                dt = SyncUtil.GetChanges(dtCheque, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesMensalidade.Remover(Convert.ToDecimal(dr["IDCHEQUEMENSALIDADE"])))
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

            if (CLIENTE == null)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovTXT_Cliente.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Cliente.", "yellow", false, false);
                return false;
            }

            if (VEICULO == null)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Veículo.", "yellow", false, false);
                ovTXT_Veiculo.Focus();
                return false;
            }

            if (ovCMB_Natureza.SelectedItem == null)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovCMB_Natureza.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Natureza Financeira.", "yellow", false, false);
                return false;
            }

            // Verifica se já existe mensalidade no mês

            DateTime Inicio = ovTXT_Vencimento.Value;
            DateTime Fim = ovTXT_Vencimento.Value;
            
            while (Inicio.Day > 1)
            {
                Inicio = Inicio.AddDays(-1);
            }
          
            var lastDayOfMonth = DateTime.DaysInMonth(Fim.Year, Fim.Month);
            
            while (Fim.Day < lastDayOfMonth)
            {
                Fim = Fim.AddDays(+1);
            }

            if (FuncoesMensalidade.ExistePorPlacaMes(VEICULO.IDVeiculo, Inicio, Fim, _Mensalidade.IDMensalidade))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Uma mensalidade para este veículo já foi gerada no mês específicado.", "yellow", false, false);
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
                BAIXAS = FuncoesBaixaMensalidade.GetBaixas(_Mensalidade.IDMensalidade);
            if (BAIXAS != null)
                BAIXAS.DefaultView.Sort = "BAIXA";
            ovGRD_Baixas.DataSource = null;
            ovGRD_Baixas.DataSource = BAIXAS;
            AjustaTextHeaderBaixas();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            _Mensalidade.Valor = ovTXT_Valor.Value;
            _Mensalidade.Multa = ovTXT_Multa.Value;
            _Mensalidade.Juros = ovTXT_Juros.Value;
            _Mensalidade.Desconto = ovTXT_Desconto.Value;
            _Mensalidade.Saldo = ovTXT_Saldo.Value;
            _Mensalidade.ValorTotal = ovTXT_Total.Value;

            decimal? IDPagamento = null;
            if(ovCMB_FormaPagamento.SelectedItem != null)
            {
                IDPagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
            }

            FCAFIN_BaixaMensalidade Form = new FCAFIN_BaixaMensalidade(_Mensalidade, new BaixaMensalidade()
            {
                IDBaixaMensalidade = Sequence.GetNextID("BAIXAMENSALIDADE", "IDBAIXAMENSALIDADE"),
                Baixa = DateTime.Now                
            }, IDPagamento);

            Form.ShowDialog(this);

            if (Form.Salvou)
            {
                DataRow dr = BAIXAS.NewRow();
                dr["IDBAIXAMENSALIDADE"] = Form._BaixaMen.IDBaixaMensalidade;
                dr["BAIXA"] = Form._BaixaMen.Baixa;
                dr["CONTABANCARIA"] = FuncoesContaBancaria.GetContaBancaria(Form._BaixaMen.IDContaBancaria).Nome;
                dr["TOTAL"] = (Form._BaixaMen.Valor - Form._BaixaMen.Desconto) + Form._BaixaMen.Juros + Form._BaixaMen.Multa;
                dr["VALOR"] = Form._BaixaMen.Valor;
                dr["IDMENSALIDADE"] = _Mensalidade.IDMensalidade;
                dr["IDFORMADEPAGAMENTO"] = Form._BaixaMen.IDFormaDePagamento;
                dr["IDCONTABANCARIA"] = Form._BaixaMen.IDContaBancaria;
                dr["COMPLEMENTO"] = Form._BaixaMen.Complemento;
                dr["MULTA"] = Form._BaixaMen.Multa;
                dr["JUROS"] = Form._BaixaMen.Juros;
                dr["DESCONTO"] = Form._BaixaMen.Desconto;
                BAIXAS.Rows.Add(dr);

                AtualizaSaldo();

                CarregarBaixas(false);
                VerificaCheques(Form._BaixaMen.IDBaixaMensalidade, false, Form.Cheques);
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            decimal IDBaixa = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Baixas.SelectedRows[0].DataBoundItem as DataRowView), "IDBAIXAMENSALIDADE"));
            BAIXAS.DefaultView.RowFilter = "[IDBAIXAMENSALIDADE] = " + IDBaixa;

            _Mensalidade.Valor = ovTXT_Valor.Value;
            _Mensalidade.Multa = ovTXT_Multa.Value;
            _Mensalidade.Juros = ovTXT_Juros.Value;
            _Mensalidade.Desconto = ovTXT_Desconto.Value;
            _Mensalidade.Saldo = ovTXT_Saldo.Value;
            _Mensalidade.ValorTotal = ovTXT_Total.Value;
            FCAFIN_BaixaMensalidade Form = new FCAFIN_BaixaMensalidade(_Mensalidade, EntityUtil<BaixaMensalidade>.ParseDataRow(BAIXAS.DefaultView[0].Row), null);
            Form.ShowDialog(this);
            if (Form.Salvou)
            {
                foreach (DataRowView drView in BAIXAS.DefaultView)
                {
                    drView.BeginEdit();
                    drView["BAIXA"] = Form._BaixaMen.Baixa;
                    drView["CONTABANCARIA"] = FuncoesContaBancaria.GetContaBancaria(Form._BaixaMen.IDContaBancaria).Nome;
                    drView["VALOR"] = Form._BaixaMen.Valor;
                    drView["TOTAL"] = (Form._BaixaMen.Valor - Form._BaixaMen.Desconto) + Form._BaixaMen.Juros + Form._BaixaMen.Multa;
                    drView["IDMENSALIDADE"] = _Mensalidade.IDMensalidade;
                    drView["IDFORMADEPAGAMENTO"] = Form._BaixaMen.IDFormaDePagamento;
                    drView["IDCONTABANCARIA"] = Form._BaixaMen.IDContaBancaria;
                    drView["COMPLEMENTO"] = Form._BaixaMen.Complemento;
                    drView["MULTA"] = Form._BaixaMen.Multa;
                    drView["JUROS"] = Form._BaixaMen.Juros;
                    drView["DESCONTO"] = Form._BaixaMen.Desconto;
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
                    decimal IDBaixa = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Baixas.SelectedRows[0].DataBoundItem as DataRowView), "IDBAIXAMENSALIDADE"));
                    BAIXAS.DefaultView.RowFilter = "[IDBAIXAMENSALIDADE] = " + IDBaixa;
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
                    if (CLIENTE.TipoDocumento == 0)
                    {
                        // CNPJ
                        //ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CNPJ)).ToString(@"000\.000\.000\-00");
                        ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CNPJ)).ToString(@"00\.000\.000\/0000\-00");
                    }
                    else if (CLIENTE.TipoDocumento == 1)
                    {
                        // CPF
                        ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CPF)).ToString(@"000\.000\.000\-00");
                        //ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CPF)).ToString(@"00\.000\.000\/0000\-00");
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

        private void BTN_BuscarVeiculo_Click(object sender, EventArgs e)
        {
            FCO_Veiculo SeletorVeiculo = new FCO_Veiculo(true);
            SeletorVeiculo.ShowDialog(this);

            if (SeletorVeiculo.DRSelected == null)
                return;

            DataRow DrSelecionada = DrSelecionada = SeletorVeiculo.DRSelected;
            VEICULO = FuncoesVeiculo.GetVeiculo(Convert.ToDecimal(DrSelecionada["IDVEICULO"]));

            if (VEICULO != null)
            {
                ovTXT_Veiculo.Text = $"{VEICULO.Placa} - {VEICULO.Descricao}";
            }
            else
            {
                ovTXT_Veiculo.Text = string.Empty;
            }
        }
    }
}
