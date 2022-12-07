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
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Consultas
{
    public partial class FCO_Fornecedor : MetroForm
    {
        private string NOME_TELA = "Consulta de fornecedor";
        public DataRow DRSelected = null;
        public FCO_Fornecedor(bool IsSelect)
        {
            InitializeComponent();
            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                //BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
            }

            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Where(o => o.Codigo == 33).FirstOrDefault() != null)
                {
                    BTN_Novo.Visible = true;
                }
            }
            else
            {
                BTN_Novo.Visible = true;
            }
        }

        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ovTXT_RazaoSocial.Focus();
            ovTXT_CPFCNPJ.Text = string.Empty;
            ovTXT_RazaoSocial.Text = string.Empty;
            ovGRD_Fornecedor.DataSource = null;
        }

        private void metroButton2_Click(object sender, System.EventArgs e)
        {
            AtualizarFornecedor(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text);
        }

        private void metroButton5_Click(object sender, System.EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 26) != null)
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
                FCA_Fornecedor t = new FCA_Fornecedor(new Fornecedor());
                t.ShowDialog(this);
                AtualizarFornecedor(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text);
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (this.ovGRD_Fornecedor.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o fornecedor selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    decimal IDFornecedor = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Fornecedor.SelectedRows[0].DataBoundItem as DataRowView), "IDFORNECEDOR"));
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesFornecedor.Remover(IDFornecedor))
                            throw new Exception("Não foi possível remover o Fornecedor.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível remover, verifique pendências.", "red", false, false);
                        return;
                    }
                    AtualizarFornecedor(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text);
                }
            }
            else
            {
               SyncMessager.CreateMessage(0,NOME_TELA, "Selecione o fornecedor que deseja remover.", "red", false, false);
            }
        }

        private void AtualizarFornecedor(string RazaoSocial, string CNPJ)
        {
            ovGRD_Fornecedor.DataSource = null;
            ovGRD_Fornecedor.DataSource = FuncoesFornecedor.GetFornecedores(RazaoSocial, CNPJ);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Fornecedor.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Fornecedor.Width;
            foreach (DataGridViewColumn column in ovGRD_Fornecedor.Columns)
            {
                switch (column.Name)
                {
                    case "razaosocial":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.75);
                        column.HeaderText = "Razão Social";
                        break;
                    case "cpfcnpj":
                        column.DisplayIndex = 2;
                        column.HeaderText = "CNPJ";
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.25);
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
            if (ovGRD_Fornecedor.Rows.Count > 0)
            {
                ovGRD_Fornecedor.Rows[0].Selected = true;
            }
        }

        private void FCO_Fornecedor_Load(object sender, EventArgs e)
        {
            //AtualizarFornecedor(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text);
        }

        private void ovGRD_Fornecedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ovTXT_CPFCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizarFornecedor(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text);
            }
        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Fornecedor.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Fornecedor.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Fornecedor.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (DRSelected == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Fornecedor.", "yellow", false, false);
                    return;
                }
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível selecionar um Fornecedor.", "red", false, false);
            }
        }

        private void ovTXT_RazaoSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizarFornecedor(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text);
            }
        }

        private void ovGRD_Fornecedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Fornecedor.SelectedRows.Count == 1)
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
                if (this.ovGRD_Fornecedor.SelectedRows.Count == 1)
                {
                    decimal IDFornecedor = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Fornecedor.SelectedRows[0].DataBoundItem as DataRowView), "IDFORNECEDOR"));
                    FCA_Fornecedor t = new FCA_Fornecedor(FuncoesFornecedor.GetFornecedor(IDFornecedor));
                    t.ShowDialog(this);
                    AtualizarFornecedor(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text);
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o fornecedor que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void ovGRD_Fornecedor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (ovGRD_Fornecedor.Columns[e.ColumnIndex].Name == "cnpj" && e.Value != null)
            {
                string documento = e.Value.ToString();

                if(documento.Length == 11) // cpf
                {
                    documento = Convert.ToDecimal(documento).ToString(@"000\.000\.000-00");
                }
                else
                {
                    documento = Convert.ToDecimal(documento).ToString(@"00\.000\.000\/0000\-00");
                }

                e.Value = documento;
                e.FormattingApplied = true;                 
            }
            else if (ovGRD_Fornecedor.Columns[e.ColumnIndex].Name == "cpfcnpj" && e.Value != null)
            {
                string documento = e.Value.ToString();

                if (documento.Length == 11) // CPF
                {
                    documento = Convert.ToDecimal(documento).ToString(@"000\.000\.000-00");
                }
                else if (documento.Length == 14) // CNPJ
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
