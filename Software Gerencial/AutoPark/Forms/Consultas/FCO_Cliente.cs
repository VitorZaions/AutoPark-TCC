using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoPark.Forms.Cadastro;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Consultas
{
    public partial class FCO_Cliente : MetroForm
    {
        private string NOME_TELA = "Consulta de cliente";
        public DataRow DRSelected = null;

        public FCO_Cliente(bool IsSelect)
        {
            InitializeComponent();

            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                //BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
                CheckBox_Ativo.Checked = true;
                CheckBox_Inativo.Checked = false;
                CheckBox_Ativo.Visible = false;
                CheckBox_Inativo.Visible = false;
            }
        }

        private void AtualizaClientes()
        {
            ovGRD_Clientes.DataSource = null;
            ovGRD_Clientes.DataSource = FuncoesCliente.GetClientes(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text, CheckBox_Ativo.Checked, CheckBox_Inativo.Checked);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Clientes.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Clientes.Width;
            foreach (DataGridViewColumn column in ovGRD_Clientes.Columns)
            {
                switch (column.Name)
                {
                    case "idcliente":
                        column.HeaderText = "Código";
                        //column.DisplayIndex = 0;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        break;
                    case "descricao":
                        column.HeaderText = "Descrição";
                       // column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.35);
                        break;
                    case "tipo":
                        column.HeaderText = "Tipo";
                       // column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        break;
                    case "inscricaoestadual":
                        column.HeaderText = "Insc. Estadual";
                      //  column.DisplayIndex = 5;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        break;
                    case "numerodocumento":
                        column.HeaderText = "Documento";
                      //  column.DisplayIndex = 4;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        break;
                    case "ativo":
                        column.HeaderText = "Ativo";
                      //  column.DisplayIndex = 5;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        break;
                    default:
                       // column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Clientes.Rows.Count > 0)
            {
                ovGRD_Clientes.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Clientes.Rows[0].Selected = true;
            }

        }

        private void ovBTN_Novo_Click(object sender, System.EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 25) != null)
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
                FCA_Cliente t = new FCA_Cliente(new Cliente());
                t.ShowDialog(this);
                AtualizaClientes();
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {

        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (this.ovGRD_Clientes.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o Cliente selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    decimal IDCliente = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Clientes.SelectedRows[0].DataBoundItem as DataRowView), "IDCLIENTE"));
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesCliente.Remover(IDCliente))
                            throw new Exception("Não foi possível remover o Cliente.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        
                        SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível remover, verifique pendências.", "red", false, false);
                        
                        return;
                    }
                    AtualizaClientes();
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione o Cliente que deseja remover.", "red", false, false);
            }
        }



        private void ovBTN_LimparFiltros_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            CheckBox_Ativo.Checked = true;
            CheckBox_Inativo.Checked = true;
            ovTXT_RazaoSocial.Focus();
            ovTXT_CPFCNPJ.Text = string.Empty;
            ovTXT_RazaoSocial.Text = string.Empty;
            ovGRD_Clientes.DataSource = null;
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            if (CheckBox_Ativo.Checked == false && CheckBox_Inativo.Checked == false)
            {
                Limpar();
                return;
            }

            AtualizaClientes();
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizaClientes();
            }
        }

        private void ovTXT_InscricaoEstadual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizaClientes();
            }
        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Clientes.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Cliente.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Clientes.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (DRSelected == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Cliente.", "yellow", false, false);
                    return;
                }
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível selecionar o Cliente.", "red", false, false);
            }
        }

        private void ovTXT_RazaoSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizaClientes();
            }
        }

        private void FCO_Cliente_Shown(object sender, EventArgs e)
        {
            Limpar();
        }

        private void FCO_Cliente_Load(object sender, EventArgs e)
        {

        }

        private void ovGRD_Clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Clientes.SelectedRows.Count == 1)
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

        private void BTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ovGRD_Clientes.SelectedRows.Count == 1)
                {
                    decimal IDCliente = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Clientes.SelectedRows[0].DataBoundItem as DataRowView), "IDCLIENTE"));
                    FCA_Cliente t = new FCA_Cliente(FuncoesCliente.GetCliente(IDCliente));
                    t.ShowDialog(this);
                    AtualizaClientes();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Cliente que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void ovGRD_Clientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (ovGRD_Clientes.Columns[e.ColumnIndex].Name == "numerodocumento" && e.Value != null)
            {
                string documento = e.Value.ToString();

                if (documento.Length == 11) // CPF
                {
                    documento = Convert.ToDecimal(documento).ToString(@"000\.000\.000-00");
                }
                else if(documento.Length == 14) // CNPJ
                {
                    documento = Convert.ToDecimal(documento).ToString(@"00\.000\.000\/0000\-00");
                }
                else
                {
                    documento = documento.ToString();
                }

                e.Value = documento;
                e.FormattingApplied = true;
            }
        }

        private void ovTXT_CPFCNPJ_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_CPFCNPJ.Text = SyncUtil.SomenteNumeros(ovTXT_CPFCNPJ.Text);
        }
    }
}
