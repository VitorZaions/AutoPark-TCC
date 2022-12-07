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
using static Guna.UI2.Native.WinApi;

namespace AutoPark.Forms.Consultas
{
    public partial class FCO_Veiculo : MetroForm
    {
        private string NOME_TELA = "Consulta de Veículo";
        public DataRow DRSelected = null;

        public FCO_Veiculo(bool IsSelect)
        {
            InitializeComponent();

            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                //BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
            }
        }

        private void AtualizarVeiculos()
        {
            ovGRD_Veiculos.DataSource = null;
            ovGRD_Veiculos.DataSource = FuncoesVeiculo.GetVeiculos(ovTXT_Descricao.Text, ovTXT_Cliente.Text, ovTXT_Placa.Text, 
                CheckBox_Ativo.Checked, CheckBox_Inativo.Checked, Checkbox_Leve.Checked, Checkbox_Pesado.Checked);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Veiculos.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Veiculos.Width;
            foreach (DataGridViewColumn column in ovGRD_Veiculos.Columns)
            {
                switch (column.Name)
                {
                    case "descricao":
                        //column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.40);
                        column.HeaderText = "Descrição";
                        break;
                    case "placa":
                        column.HeaderText = "Placa";
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        break;
                    case "tipo":
                        column.HeaderText = "Tipo";
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        break;
                    case "cliente":
                        column.HeaderText = "Cliente";
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.30);
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Veiculos.Rows.Count > 0)
            {
                ovGRD_Veiculos.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Veiculos.Rows[0].Selected = true;
            }

        }

        private bool CheckPerm()
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 2) != null)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            if (CheckPerm() == true)
            {
                FCA_Veiculo t = new FCA_Veiculo(new Veiculo());
                t.ShowDialog(this);
                AtualizarVeiculos();
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA,
                "Oops, sem permissão para realizar um novo cadastro.", "yellow",
                false, false);
            }
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {

        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (this.ovGRD_Veiculos.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o veículo selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    decimal IDVeiculo = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Veiculos.SelectedRows[0].DataBoundItem as DataRowView), "IDVEICULO"));
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesVeiculo.Remover(IDVeiculo))
                            throw new Exception("Não foi possível remover a Transportadora.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();

                        SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível remover, verifique pendências.", "red", false, false);
                       
                        return;
                    }
                    AtualizarVeiculos();
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a transportadora que deseja remover.", "red", false, false);
            }
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            AtualizarVeiculos();
        }

        private void ovBTN_LimparFiltros_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ovTXT_Descricao.Focus();
            ovTXT_Cliente.Text = string.Empty;
            ovTXT_Placa.Text = string.Empty;
            ovTXT_Descricao.Text = string.Empty;
            ovGRD_Veiculos.DataSource = null;
            CheckBox_Ativo.Checked = true;
            CheckBox_Inativo.Checked = true;
            Checkbox_Leve.Checked = true;
            Checkbox_Pesado.Checked = true;
        }

        private void ovTXT_CPFCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizarVeiculos();
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
                AtualizarVeiculos();
            }

        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Veiculos.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Veículo.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Veiculos.SelectedRows[0].DataBoundItem as DataRowView).Row;
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível selecionar um Veículo.", "red", false, false);
            }
        }

        private void ovTXT_RazaoSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizarVeiculos();
            }
        }

        private void FCO_Transportadora_Shown(object sender, EventArgs e)
        {
           // Limpar();
        }

        private void ovGRD_Transportadora_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if (ovGRD_Veiculos.Columns[e.ColumnIndex].Name == "placa" && e.Value != null)
            {
                string placa = e.Value.ToString().ToUpper();
                placa = MaskUtil.Mask(placa, "&&&-&&&&", '&');
                e.Value = placa;
                e.FormattingApplied = true;
            }*/
        }
                

        private void ovGRD_Transportadora_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Veiculos.SelectedRows.Count == 1)
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
                if (this.ovGRD_Veiculos.SelectedRows.Count == 1)
                {
                    decimal IDVeiculo = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView(
                        (ovGRD_Veiculos.SelectedRows[0].DataBoundItem as DataRowView), "IDVEICULO"));
                    FCA_Veiculo t = new FCA_Veiculo(FuncoesVeiculo.GetVeiculo(IDVeiculo));
                    t.ShowDialog(this);
                    AtualizarVeiculos();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Veículo que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void FCO_Transportadora_Load(object sender, EventArgs e)
        {
            this.ShowIcon = true;
        }

        private void ovTXT_Placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizarVeiculos();
            }
        }

        private void syncTextBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Placa.Text = SyncUtil.RemoveSpecialCharacters(ovTXT_Placa.Text);
        }

        private void syncTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
