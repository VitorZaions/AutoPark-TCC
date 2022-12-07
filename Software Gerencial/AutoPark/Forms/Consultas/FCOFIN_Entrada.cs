using AutoController.Funcoes;
using AutoDAO.Custom;
using AutoDAO.Entidades;
using AutoPark.Forms.Cadastro;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Consultas
{
    public partial class FCOFIN_Entrada : MetroForm
    {
        private string NOME_TELA = "Consulta de Entrada";
        private DataTable CONTASRECEBER = null;
        decimal UltimoIDSelecionado = -1;
        string UltimoStatus;
        string UltimoTipo;
        public DataRow DRSelected = null;
        public FCOFIN_Entrada(bool IsSelect)
        {
            InitializeComponent();
            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                BTN_Remover.Visible = false;
                BTN_Novo.Visible = false;
            }

            Limpar();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
           // ovTXT_Cliente.Text = string.Empty;
            ovTXT_VencimentoInicio.Value = DateTime.Now;
            ovTXT_VencimentoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_VencimentoFim.Value = DateTime.Now;
            ovGRD_Contas.DataSource = null;
            ovTXT_Codigo.Text = string.Empty;
            ovTXT_Placa.Text = string.Empty;
            ovTXT_Cliente.Text = string.Empty;
            ovCKB_Aberto.Checked = true;
            ovCKB_Baixado.Checked = true;
            ovCKB_Parcial.Checked = true;
            ovCKB_Cancelado.Checked = false;
            ovCKB_Normal.Checked = true;
            ovCKB_OCR.Checked = true;
        }

        private void Carregar()
        {
            ovGRD_Contas.DataSource = null;
            CONTASRECEBER = FuncoesEntrada.GetEntradas(string.IsNullOrWhiteSpace(ovTXT_Codigo.Text) ? null : Convert.ToDecimal(ovTXT_Codigo.Text) , ovTXT_Cliente.Text, ovTXT_Placa.Text, ovTXT_VencimentoInicio.Value, ovTXT_VencimentoFim.Value, ovCKB_Aberto.Checked, ovCKB_Parcial.Checked, ovCKB_Baixado.Checked, ovCKB_Cancelado.Checked, ovCKB_Nulo.Checked, ovCKB_Normal.Checked ,ovCKB_OCR.Checked);
            ovGRD_Contas.DataSource = CONTASRECEBER;
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Contas.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Contas.Width;
            foreach (DataGridViewColumn column in ovGRD_Contas.Columns)
            {
                switch (column.Name)
                {
                    case "identrada":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Código";
                        break;
                    case "placa":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Placa";
                        break;
                    case "cliente":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.35);
                        column.HeaderText = "Cliente";
                        break;
                    case "status":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Financeiro";
                        break;
                    case "dataentrada":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Data Entrada";
                        break;
                    case "tipo":                       
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Tipo";
                        break;                    
                    default:
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Contas.Rows.Count > 0)
            {
                ovGRD_Contas.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Contas.Rows[0].Selected = true;
            }
        }

        private void ovGRD_Contas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (ovGRD_Contas.Columns[e.ColumnIndex].Name)
            {
                case "valortotal":
                    e.Value = Convert.ToDecimal(e.Value).ToString("c2");
                    break;
                case "vencimento":
                    string Vencimento = Convert.ToDateTime((e.Value)).ToString("dd/MM/yyyy");
                    string DataHoje = DateTime.Now.ToString("dd/MM/yyyy");

                    if (Convert.ToDateTime(Vencimento) < Convert.ToDateTime(DataHoje))
                    {
                        string Status = Convert.ToString((ovGRD_Contas.Rows[e.RowIndex].Cells["STATUS"].Value));
                        if (Status != "Cancelado")
                        {
                            e.CellStyle.BackColor = Color.FromArgb(222, 106, 106);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(222, 106, 106);
                        }
                    }
                    break;

                case "status":
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        if (Convert.ToString(e.Value) == "Aberto")
                        {
                            e.CellStyle.BackColor = Color.FromArgb(106, 195, 222);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(106, 195, 222);
                        }
                        else if (Convert.ToString(e.Value) == "Cancelado")
                        {
                            e.CellStyle.BackColor = Color.FromArgb(222, 183, 106);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(222, 183, 106);
                        }
                        else if (Convert.ToString(e.Value) == "Parcial")
                        {
                            e.CellStyle.BackColor = Color.FromArgb(106, 140, 222);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(106, 140, 222);
                        }
                        else if (Convert.ToString(e.Value) == "Baixado")
                        {
                            e.CellStyle.BackColor = Color.FromArgb(106, 222, 116);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(106, 222, 116);
                        }
                        else if (Convert.ToString(e.Value) == "Mensalista")
                        {
                            e.CellStyle.BackColor = Color.FromArgb(238, 130, 238);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(238, 130, 238);
                        }
                        else if (Convert.ToString(e.Value) == "Nulo")
                        {
                            e.CellStyle.BackColor = Color.FromArgb(170, 170, 170);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(170, 170, 170);
                        }
                    }
                    break;
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 56) != null)
                {
                    Perm = true;
                }
            }
            else
            {
                Perm = true;
            }

            if (Perm == true)
            {
                new FCAFIN_ContaReceber(new ContaReceber(), false).ShowDialog(this);
                Carregar();
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (this.ovGRD_Contas.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover a Entrada selecionada?", "yellow", true, false) == DialogResult.OK)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesEntrada.Remover(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDENTRADA"))))
                            throw new Exception("Não foi possível remover a Entrada.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();                        
                        SyncMessager.CreateMessage(0,NOME_TELA,"Não foi possível excluir, verifique as baixas.", "red", false, false);                        
                        return;
                    }
                    Carregar();
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a Entrada deseja remover.", "red", false, false);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void ovTXT_Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Carregar();
            }
        }

        private void ovTXT_Origem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Carregar();
            }
        }

        private void ovTXT_FormaPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Carregar();
            }
        }

        private void FCOFIN_ContaReceber_Shown(object sender, EventArgs e)
        {
            Limpar();
        }

        private void FCOFIN_ContaReceber_Load(object sender, EventArgs e)
        {

        }        
        private void ovGRD_Contas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Contas.SelectedRows.Count == 1)
            {
                if (BTN_Selecionar.Visible)
                {
                    BTN_Selecionar_Click(sender, e);
                }
                else if (BTN_Editar.Visible)
                {
                    BTN_Editar_Click_1(sender, e);
                }
            }
        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Contas.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione uma Entrada.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (DRSelected == null)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione uma Entrada.", "yellow", false, false);
                    return;
                }
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível selecionar a Entrada.", "red", false, false);
            }
        }
               

        private void BTN_RealizarLancamento_Click(object sender, EventArgs e)
        {
            FCAFIN_Entrada Form = new FCAFIN_Entrada(new Entrada());
            Form.ShowDialog(this);
            Carregar();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void BTN_Novo_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 13) != null)
                {
                    Perm = true;
                }
            }
            else
            {
                Perm = true;
            }

            if (Perm == true)
            {
                FCAFIN_Entrada Form = new FCAFIN_Entrada(new Entrada());
                Form.ShowDialog(this);
                Carregar();
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }
           
        }

        private void BTN_Editar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.ovGRD_Contas.SelectedRows.Count == 1)
                {

                    string Status = Convert.ToString(ovGRD_Contas.SelectedRows[0].Cells["STATUS"].Value);
                    string TIPO = Convert.ToString(ovGRD_Contas.SelectedRows[0].Cells["TIPO"].Value);

                    if (Status == "Mensalista" || TIPO == "OCR")
                    {
                        return;
                    }

                    decimal IDEntrada = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDENTRADA"));
                    FCAFIN_Entrada t = new FCAFIN_Entrada(FuncoesEntrada.GetEntrada(IDEntrada));
                    t.ShowDialog(this);
                    Carregar();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Entrada que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void BTN_RealizarLancamento_Click_1(object sender, EventArgs e)
        {
            decimal _ValorHora;

            Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOGERAL_ESTACIONAMENTO);
            if (config != null)
            {
                _ValorHora = Convert.ToDecimal(Encoding.UTF8.GetString(config.Valor));
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Valor P/Hora não configurado (Configurações > Geral).", "yellow", false, false);
                return;
            }

            try
            {
                if (this.ovGRD_Contas.SelectedRows.Count == 1)
                {
                    decimal IDEntrada = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDENTRADA"));
                    Entrada _Entrada = FuncoesEntrada.GetEntrada(IDEntrada);                    
                    FCAFIN_ContaReceberLancamento Form = new FCAFIN_ContaReceberLancamento(Math.Round(_Entrada.Tempo * _ValorHora, 2), $"Entrada Simplificada - {_Entrada.IDEntrada}", _Entrada.IDEntrada);
                    Form.ShowDialog(this);
                    Carregar();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Entrada que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void ovGRD_Contas_SelectionChanged(object sender, EventArgs e)
        {
            if (this.ovGRD_Contas.SelectedRows.Count == 1)
            {
                string status = Convert.ToString(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "STATUS"));
                string tipo = Convert.ToString(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "TIPO"));
                if (status == "Mensalista" || tipo == "OCR")
                {
                    BTN_Editar.Enabled = false;
                    BTN_GerarFinanceiro.Enabled = false;
                }
                else
                {
                    BTN_Editar.Enabled = true;
                    BTN_GerarFinanceiro.Enabled = true;
                }
            }
        }

        private void ovGRD_Contas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void ovGRD_Contas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //handle the row selection on right click
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    // Can leave these here - doesn't hurt
                    ovGRD_Contas.Rows[e.RowIndex].Selected = true;
                    UltimoIDSelecionado = Convert.ToDecimal(ovGRD_Contas.Rows[e.RowIndex].Cells["IDENTRADA"].Value);

                    UltimoStatus = Convert.ToString(ovGRD_Contas.Rows[e.RowIndex].Cells["STATUS"].Value);
                    UltimoTipo = Convert.ToString(ovGRD_Contas.Rows[e.RowIndex].Cells["TIPO"].Value);

                    if (UltimoStatus == "Mensalista" || UltimoStatus == "Nulo" || UltimoTipo == "OCR")
                    {
                        realizarBaixaToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        realizarBaixaToolStripMenuItem.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível Carregar o Menu.", "red", false, false);
                }
            }
        }

        private void realizarBaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (UltimoIDSelecionado != -1)
                {
                    FCAFIN_ContaReceber Form = new FCAFIN_ContaReceber(FuncoesContaReceber.GetContaReceberPorEntrada(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDENTRADA"))), true);
                    Form.ShowDialog(this);
                    Carregar();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Entrada que deseja Realizar Baixa.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void ovTXT_Codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Carregar();
            }
        }

        private void ovTXT_Placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Carregar();
            }
        }

        private void ovTXT_Codigo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Codigo.Text = SyncUtil.SomenteNumeros(ovTXT_Codigo.Text);
        }
    }
}
