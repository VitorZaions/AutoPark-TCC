using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro.Financeiro;
using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Consultas
{
    public partial class FCO_Talonario : MetroForm
    {
        private string NOME_TELA = "Consulta de talonário";
        private DataTable TALONARIOS = null;
        public DataRow DRSelected = null;
        private decimal _IDContaBancaria = -1;
        public FCO_Talonario(bool IsSelect, decimal IDContaBancaria, bool SomenteAtivos = false)
        {
            InitializeComponent();
            _IDContaBancaria = IDContaBancaria;
            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                //BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
            }
            if (SomenteAtivos)
            {
                CheckBox_Ativo.Checked = true;
                CheckBox_Inativo.Checked = false;
                CheckBox_Ativo.Visible = false;
                CheckBox_Inativo.Visible = false;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ovTXT_Numero.Focus();
            ovTXT_Conta.Text = string.Empty;
            ovTXT_Numero.Text = string.Empty;
            ovGRD_Talonarios.DataSource = null;
        }

        private void Carregar(string Numero, string Conta)
        {
            ovGRD_Talonarios.DataSource = null;
            TALONARIOS = FuncoesTalonario.GetTalonarios(Numero, Conta, _IDContaBancaria, CheckBox_Ativo.Checked, CheckBox_Inativo.Checked);
            ovGRD_Talonarios.DataSource = TALONARIOS;
            AjustaHeaderTextGrid();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Carregar(ovTXT_Numero.Text, ovTXT_Conta.Text);
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Talonarios.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Talonarios.Width;
            foreach (DataGridViewColumn column in ovGRD_Talonarios.Columns)
            {
                switch (column.Name)
                {
                    case "nome":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.40);
                        column.HeaderText = "Conta bancária";
                        break;
                    case "numero":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "Número";
                        break;
                    case "inicio":
                        column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Início";
                        break;
                    case "fim":
                        column.DisplayIndex = 4;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Fim";
                        break;
                    case "ativo":
                        column.DisplayIndex = 5;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Ativo";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
            if (ovGRD_Talonarios.Rows.Count > 0)
            {
                ovGRD_Talonarios.Rows[0].Selected = true;
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 27) != null)
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
                new FCA_Talonario(new Talonario()).ShowDialog(this);
                Carregar(ovTXT_Numero.Text, ovTXT_Conta.Text);
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
            if (this.ovGRD_Talonarios.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o Talonário selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesTalonario.Remover(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Talonarios.SelectedRows[0].DataBoundItem as DataRowView), "IDTALONARIO"))))
                            throw new Exception("Não foi possível remover o Talonário.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível remover, verifique pendências.", "red", false, false);
                        return;
                    }
                    Carregar(ovTXT_Numero.Text, ovTXT_Conta.Text);
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione o Talonário que deseja remover.", "red", false, false);
            }
        }

        private void ovTXT_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Carregar(ovTXT_Numero.Text, ovTXT_Conta.Text);
            }
        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Talonarios.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Talonário.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Talonarios.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (DRSelected == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Talonário.", "yellow", false, false);
                    return;
                }
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível selecionar o Talonário.", "red", false, false);
            }
        }

        private void ovTXT_Conta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Carregar(ovTXT_Numero.Text, ovTXT_Conta.Text);
            }
        }

        private void FCO_Talonario_Shown(object sender, EventArgs e)
        {
            Limpar();
        }

        private void FCO_Talonario_Load(object sender, EventArgs e)
        {

        }

        private void ovGRD_Talonarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Talonarios.SelectedRows.Count == 1)
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

                if (this.ovGRD_Talonarios.SelectedRows.Count == 1)
                {
                    FCA_Talonario Form = new FCA_Talonario(FuncoesTalonario.GetTalonario(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Talonarios.SelectedRows[0].DataBoundItem as DataRowView), "IDTALONARIO"))));
                    Form.ShowDialog(this);
                    Carregar(ovTXT_Numero.Text, ovTXT_Conta.Text);
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Talonário que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void ovTXT_Numero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Numero.Text = SyncUtil.SomenteNumeros(ovTXT_Numero.Text);
        }
    }
}
