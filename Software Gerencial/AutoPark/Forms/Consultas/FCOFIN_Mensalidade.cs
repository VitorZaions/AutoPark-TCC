using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoPark.Forms.Cadastro;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Consultas
{
    public partial class FCOFIN_Mensalidade : MetroForm
    {
        private string NOME_TELA = "Consulta de Mensalidade";
        private DataTable MENSALIDADES = null;
        public FCOFIN_Mensalidade(bool IsSelect)
        {
            InitializeComponent();
            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
                BTN_RealizarLancamento.Visible = false;
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
            ovTXT_Placa.Text = string.Empty;
            ovTXT_Codigo.Text = string.Empty;
            ovTXT_Cliente.Text = string.Empty;
            ovTXT_VencimentoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_VencimentoFim.Value = DateTime.Now;
            ovTXT_EmissaoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_EmissaoFim.Value = DateTime.Now;
            ovGRD_Mensalidades.DataSource = null;
            ovCKB_Aberto.Checked = true;
            ovCKB_Baixado.Checked = true;
            ovCKB_Parcial.Checked = true;
            ovCKB_Cancelado.Checked = false;
        }

        private void Carregar()
        {
            ovGRD_Mensalidades.DataSource = null;
            MENSALIDADES = FuncoesMensalidade.GetMensalidades(string.IsNullOrWhiteSpace(ovTXT_Codigo.Text) ? null : Convert.ToDecimal(ovTXT_Codigo.Text) , ovTXT_Cliente.Text, ovTXT_Placa.Text, ovTXT_VencimentoInicio.Value, ovTXT_VencimentoFim.Value, ovTXT_EmissaoInicio.Value, ovTXT_EmissaoFim.Value, ovCKB_Aberto.Checked, ovCKB_Parcial.Checked, ovCKB_Baixado.Checked, ovCKB_Cancelado.Checked);
            ovGRD_Mensalidades.DataSource = MENSALIDADES;
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Mensalidades.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Mensalidades.Width;
            foreach (DataGridViewColumn column in ovGRD_Mensalidades.Columns)
            {
                switch (column.Name)
                {
                    case "idmensalidade":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.09);
                        column.HeaderText = "Código";
                        break;
                    case "placa":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.14);
                        column.HeaderText = "Placa";
                        break;
                    case "cliente":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.24);
                        column.HeaderText = "Cliente";
                        break;
                    case "parcela":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Parcela";
                        break;
                    case "emissao":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.11);
                        column.HeaderText = "Emissão";
                        break;
                    case "vencimento":                       
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.11);
                        column.HeaderText = "Vencimento";
                        break;
                    case "valortotal":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.11);
                        column.HeaderText = "Valor Total";
                        break;
                    case "status":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Status";
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Mensalidades.Rows.Count > 0)
            {
                ovGRD_Mensalidades.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Mensalidades.Rows[0].Selected = true;
            }
        }

        private void ovGRD_Contas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (ovGRD_Mensalidades.Columns[e.ColumnIndex].Name)
            {
                case "valortotal":
                    e.Value = Convert.ToDecimal(e.Value).ToString("c2");
                    break;
                case "vencimento":
                    string Vencimento = Convert.ToDateTime((e.Value)).ToString("dd/MM/yyyy");
                    string DataHoje = DateTime.Now.ToString("dd/MM/yyyy");

                    if (Convert.ToDateTime(Vencimento) < Convert.ToDateTime(DataHoje))
                    {
                        string Status = Convert.ToString((ovGRD_Mensalidades.Rows[e.RowIndex].Cells["STATUS"].Value));
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
                        else if (Convert.ToString(e.Value) == "Renegociado")
                        {
                            e.CellStyle.BackColor = Color.FromArgb(238, 130, 238);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(238, 130, 238);
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
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 5) != null)
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
                new FCAFIN_Mensalidade(new Mensalidade()).ShowDialog(this);
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
            if (this.ovGRD_Mensalidades.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o Lançamento selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesMensalidade.Remover(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Mensalidades.SelectedRows[0].DataBoundItem as DataRowView), "IDMENSALIDADE"))))
                            throw new Exception("Não foi possível remover a Mensalidade.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível remover a mensalidade, verifique as baixas.", "red", false, false);

                        return;
                    }
                    Carregar();
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a Mensalidade que deseja remover.", "red", false, false);
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
            if (ovGRD_Mensalidades.SelectedRows.Count == 1)
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
                if (this.ovGRD_Mensalidades.SelectedRows.Count == 1)
                {
                    FCAFIN_Mensalidade Form = new FCAFIN_Mensalidade(FuncoesMensalidade.GetMensalidade(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Mensalidades.SelectedRows[0].DataBoundItem as DataRowView), "IDMENSALIDADE"))));
                    Form.ShowDialog(this);
                    Carregar();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Mensalidade que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void BTN_RealizarLancamento_Click(object sender, EventArgs e)
        {
            FCAFIN_MensalidadeLancamento Form = new FCAFIN_MensalidadeLancamento(null);
            Form.ShowDialog(this);
            Carregar();
        }

        private void ovTXT_Codigo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Codigo.Text = SyncUtil.SomenteNumeros(ovTXT_Codigo.Text);
        }
    }
}
