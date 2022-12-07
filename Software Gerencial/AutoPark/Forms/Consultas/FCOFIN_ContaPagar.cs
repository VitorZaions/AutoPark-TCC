using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoPark.Forms.Cadastro;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoPark.Forms.Consultas
{
    public partial class FCOFIN_ContaPagar : MetroForm
    {
        private string NOME_TELA = "Consulta de contas a pagar";
        private DataTable CONTASPAGAR = null;

        decimal UltimoIDSelecionado = -1;
        string UltimoStatus;

        public FCOFIN_ContaPagar(bool IsSelect)
        {
            InitializeComponent();

            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
                //BTN_RealizarLancamento.Visible = false;
            }

        }

        private void Limpar()
        {
            ovTXT_Codigo.Text = string.Empty;
            ovTXT_Fornecedor.Text = string.Empty;
            ovTXT_VencimentoInicio.Value = DateTime.Now;
            ovTXT_Origem.Text = string.Empty;
            ovTXT_Complemento.Text = string.Empty;
            ovTXT_VencimentoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_VencimentoFim.Value = DateTime.Now;
            ovTXT_EmissaoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_EmissaoFim.Value = DateTime.Now;
            ovGRD_Contas.DataSource = null;
           // ovTXT_Codigo.Focus();
        }

        private void Carregar()
        {
            ovGRD_Contas.DataSource = null;
            CONTASPAGAR = FuncoesContaPagar.GetContas(string.IsNullOrWhiteSpace(ovTXT_Codigo.Text) ? null : Convert.ToDecimal(ovTXT_Codigo.Text) , ovTXT_Fornecedor.Text, ovTXT_VencimentoInicio.Value, ovTXT_VencimentoFim.Value, ovTXT_EmissaoInicio.Value, ovTXT_EmissaoFim.Value, ovTXT_Complemento.Text, ovTXT_Origem.Text, ovCKB_Aberto.Checked,ovCKB_Parcial.Checked, ovCKB_Baixado.Checked, ovCKB_Cancelado.Checked);
            ovGRD_Contas.DataSource = CONTASPAGAR;
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
                    case "idcontapagar":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.07);
                        column.HeaderText = "Código";
                        break;
                    case "fornecedor":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.19);
                        column.HeaderText = "Fornecedor";
                        break;
                    case "parcela":
                        column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Parcela";
                        break;
                    case "emissao":
                        column.DisplayIndex = 4;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Emissão";
                        break;
                    case "vencimento":
                        column.DisplayIndex = 5;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Vencimento";
                        break;
                    case "origem":
                        column.DisplayIndex = 6;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Origem";
                        break;
                    case "complemento":
                        column.DisplayIndex = 7;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.14);
                        column.HeaderText = "Complemento";
                        break;
                    case "valortotal":
                        column.DisplayIndex = 8;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Valor Total";
                        break;
                    case "status":
                        column.DisplayIndex = 9;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Status";
                        break;
                    default:
                        column.DisplayIndex = 0;
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
                    }
                    break;
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 3) != null)
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
                new FCAFIN_ContaPagar(new ContaPagar(), false).ShowDialog(this);
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
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o Lançamento selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesContaPagar.Remover(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDCONTAPAGAR"))))
                            throw new Exception("Não foi possível remover o Lançamento.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        if (Ex.Message.Contains("baixapagamento_idcontapagar_fkey"))
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, "Conta a Pagar vinculada a Baixa de Pagamento, não será possível remover o registro.", "red", false, false);
                        }
                        else
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
                        }
                        return;
                    }
                    Carregar();
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a Conta a Pagar que deseja remover.", "red", false, false);
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            Limpar();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void ovTXT_Fornecedor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FCOFIN_ContaPagar_Shown(object sender, EventArgs e)
        {
            Limpar();
        }

        private void FCOFIN_ContaPagar_Load(object sender, EventArgs e)
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
                    BTN_Editar_Click(sender, e);
                }
            }
        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {

        }

        private void BTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ovGRD_Contas.SelectedRows.Count == 1)
                {
                    FCAFIN_ContaPagar Form = new FCAFIN_ContaPagar(FuncoesContaPagar.GetContaPagar(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDCONTAPAGAR"))), false);
                    Form.ShowDialog(this);
                    Carregar();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Conta a Pagar que deseja editar.", "red", false, false);
                }
            }
            catch(Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
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
                    UltimoIDSelecionado = Convert.ToDecimal(ovGRD_Contas.Rows[e.RowIndex].Cells["IDCONTAPAGAR"].Value);

                    UltimoStatus = Convert.ToString(ovGRD_Contas.Rows[e.RowIndex].Cells["STATUS"].Value);

                    if (UltimoStatus == "Cancelado")
                    {
                        novaBaixaToolStripMenuItem.Enabled = false;
                        cancelarToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        novaBaixaToolStripMenuItem.Enabled = true;
                        cancelarToolStripMenuItem.Enabled = true;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SyncMessager.CreateMessage(0, NOME_TELA, "Deseja marcar esta conta como Cancelada?", "yellow", true, false) == DialogResult.OK)
            {
                // Marca Como Cancelada

                try
                {
                    PDVControlador.BeginTransaction();
                    if (!FuncoesContaPagar.AlterarStatus(UltimoIDSelecionado, 0))
                        throw new Exception("Não foi possível alterar o Status.");
                    PDVControlador.Commit();
                    
                    Carregar();
                    SyncMessager.CreateMessage(0, NOME_TELA, "Status alterado com sucesso!", "green", false, false);                   
                }
                catch (Exception Ex)
                {  
                    PDVControlador.Rollback();
                    SyncMessager.CreateMessage(0, NOME_TELA, Ex.Message, "red", false, false);
                }
            }
        }

        private void novaBaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (UltimoIDSelecionado != -1)
                {
                    FCAFIN_ContaPagar Form = new FCAFIN_ContaPagar(FuncoesContaPagar.GetContaPagar(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDCONTAPAGAR"))), true);
                    Form.ShowDialog(this);
                    Carregar();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Conta a Pagar que deseja Realizar Baixa.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FCAFIN_ContaPagarLancamento Form = new FCAFIN_ContaPagarLancamento(null, null);
            Form.ShowDialog(this);
            Carregar();
        }

        private void ovTXT_Codigo_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
