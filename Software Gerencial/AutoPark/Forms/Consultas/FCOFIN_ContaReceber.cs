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
    public partial class FCOFIN_ContaReceber : MetroForm
    {
        private string NOME_TELA = "Consulta de contas a receber";
        private DataTable CONTASRECEBER = null;
        public FCOFIN_ContaReceber(bool IsSelect)
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
            ovTXT_Origem.Text = string.Empty;
            ovTXT_Complemento.Text = string.Empty;
            ovTXT_Codigo.Text = string.Empty;
            ovTXT_Cliente.Text = string.Empty;

            ovTXT_VencimentoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_VencimentoFim.Value = DateTime.Now;
            ovTXT_EmissaoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_EmissaoFim.Value = DateTime.Now;
            ovGRD_Contas.DataSource = null;

            ovCKB_Aberto.Checked = true;
            ovCKB_Baixado.Checked = true;
            ovCKB_Parcial.Checked = true;
            ovCKB_Cancelado.Checked = false;
        }

        private void Carregar()
        {
            ovGRD_Contas.DataSource = null;
            CONTASRECEBER = FuncoesContaReceber.GetContas(string.IsNullOrWhiteSpace(ovTXT_Codigo.Text) ? null : Convert.ToDecimal(ovTXT_Codigo.Text) , ovTXT_Cliente.Text, ovTXT_VencimentoInicio.Value, ovTXT_VencimentoFim.Value, ovTXT_EmissaoInicio.Value, ovTXT_EmissaoFim.Value, ovTXT_Complemento.Text, ovTXT_Origem.Text, ovCKB_Aberto.Checked, ovCKB_Parcial.Checked, ovCKB_Baixado.Checked, ovCKB_Cancelado.Checked, 0);
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
                    case "idcontareceber":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.07);
                        column.HeaderText = "Código";
                        break;
                    case "cliente":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.19);
                        column.HeaderText = "Cliente";
                        break;
                    case "parcela":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Parcela";
                        break;
                    case "emissao":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Emissão";
                        break;
                    case "vencimento":                       
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Vencimento";
                        break;
                    case "origem":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Origem";
                        break;
                    case "complemento":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.14);
                        column.HeaderText = "Complemento";
                        break;
                    case "valortotal":
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
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
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 4) != null)
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
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o Lançamento selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesContaReceber.Remover(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDCONTARECEBER"))))
                            throw new Exception("Não foi possível remover o Lançamento.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        if (Ex.Message.Contains("baixarecebimento_idcontareceber_fkey"))
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, "Conta a Receber vinculada a Baixa de Recebimento, não será possível remover o registro.", "red", false, false);
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
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a Conta a Receber que deseja remover.", "red", false, false);
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
                    FCAFIN_ContaReceber Form = new FCAFIN_ContaReceber(FuncoesContaReceber.GetContaReceber(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDCONTARECEBER"))), false);
                    Form.ShowDialog(this);
                    Carregar();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Conta a Receber que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void BTN_RealizarLancamento_Click(object sender, EventArgs e)
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

            FCAFIN_ContaReceberLancamento Form = new FCAFIN_ContaReceberLancamento(null,null,null);
            Form.ShowDialog(this);
            Carregar();
        }

        private void ovGRD_Contas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void ovTXT_Codigo_KeyPress(object sender, KeyPressEventArgs e)
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
