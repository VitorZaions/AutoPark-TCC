using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoPark.Forms.Cadastro;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Consultas
{
    public partial class FCO_ContaBancaria : MetroForm
    {
        private string NOME_TELA = "Consulta de conta bancária";
        private DataTable DADOS = null;
        public DataRow DRSelected = null;
        bool _IsSelect = false;

        public FCO_ContaBancaria(bool IsSelect)
        {
            InitializeComponent();
            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                // BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
                _IsSelect = true;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ovGRD_Contas.DataSource = null;
            ovTXT_Nome.Text = string.Empty;
            ovTXT_Nome.Focus();
        }

        private void FCO_ContaBancaria_Load(object sender, EventArgs e)
        {
        }

        private void CarregarContas()
        {
            ovGRD_Contas.DataSource = null;
            DADOS = FuncoesContaBancaria.GetContasBancarias(ovTXT_Nome.Text, CheckBox_Ativo.Checked, CheckBox_Inativo.Checked);
            ovGRD_Contas.DataSource = DADOS;
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
                    case "nome":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.35);
                        column.HeaderText = "Nome";
                        break;
                    case "banco":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.30);
                        column.HeaderText = "Banco";
                        break;
                    case "agencia":
                        column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Agência";
                        break;
                    case "conta":
                        column.DisplayIndex = 4;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Conta";
                        break;
                    case "ativo":
                        column.DisplayIndex = 5;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.05);
                        column.HeaderText = "Ativo";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Contas.Rows.Count > 0)
            {
                ovGRD_Contas.Rows[0].Selected = true;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            CarregarContas();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 8) != null)
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
                new FCA_ContaBancaria(new ContaBancaria()).ShowDialog(this);
                CarregarContas();
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
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover a conta bancária selecionada?", "yellow", true, false) == DialogResult.OK)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesContaBancaria.Remover(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDCONTABANCARIA"))))
                            throw new Exception("Não foi possível remover a conta bancária.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível remover, verifique pendências.", "red", false, false);
                        return;
                    }
                    CarregarContas();
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a conta bancária que deseja remover.", "red", false, false);
            }
        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Contas.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione uma Conta Bancária.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (DRSelected == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione uma Conta Bancária.", "yellow", false, false);
                    return;
                }
                Close();
            }
            catch
            {
               SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível selecionar uma Conta Bancária.", "red", false, false);
            }
        }

        private void ovTXT_Nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CarregarContas();
            }
        }

        private void FCO_ContaBancaria_Shown(object sender, EventArgs e)
        {
            Limpar();
            if (_IsSelect)
            {
                CheckBox_Ativo.Visible = false;
                CheckBox_Inativo.Visible = false;
                CheckBox_Ativo.Checked = true;
                CheckBox_Inativo.Checked = false;
            }
        }

        private void FCO_ContaBancaria_Load_1(object sender, EventArgs e)
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

        private void BTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ovGRD_Contas.SelectedRows.Count == 1)
                {
                    FCA_ContaBancaria FormContaBancaria = new FCA_ContaBancaria(FuncoesContaBancaria.GetContaBancaria(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contas.SelectedRows[0].DataBoundItem as DataRowView), "IDCONTABANCARIA"))));
                    FormContaBancaria.ShowDialog(this);
                    CarregarContas();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a conta bancária que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }
    }
}
