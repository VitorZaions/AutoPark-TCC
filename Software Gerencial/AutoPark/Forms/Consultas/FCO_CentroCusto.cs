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
    public partial class FCO_CentroCusto : MetroForm
    {
        private string NOME_TELA = "Consulta de centro de custo";
        public DataRow DRSelected = null;
        private DataTable CENTROS = null;
        private decimal _IDExcluir = -1;
        public FCO_CentroCusto(bool IsSelect, decimal IDExcluir)
        {
            InitializeComponent();

            _IDExcluir = IDExcluir;

            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                //BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
            }
        }

        private void CarregarCentros()
        {
            ovGRD_Centros.DataSource = null;
            CENTROS = FuncoesCentroCusto.GetCentrosCusto(ovTXT_Centro.Text, ovTXT_Descricao.Text, _IDExcluir);
            ovGRD_Centros.DataSource = CENTROS;
            AjustaHeaderTextGrid();
        }

        private void Limpar()
        {
            ovTXT_Centro.Text = string.Empty;
            ovTXT_Descricao.Text = string.Empty;
            ovTXT_Centro.Focus();
            ovGRD_Centros.DataSource = null;
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Centros.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Centros.Width;
            foreach (DataGridViewColumn column in ovGRD_Centros.Columns)
            {
                switch (column.Name)
                {
                    case "centro":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.40);
                        column.HeaderText = "Centro";
                        break;
                    case "descricao":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.60);
                        column.HeaderText = "Descrição";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
            if (ovGRD_Centros.Rows.Count > 0)
            {
                ovGRD_Centros.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Centros.Rows[0].Selected = true;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            CarregarCentros();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 6) != null)
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
                new FCA_CentroCusto(new CentroCusto()).ShowDialog(this);
                CarregarCentros();
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
            if (this.ovGRD_Centros.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o Centro de Custo selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesCentroCusto.Remover(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Centros.SelectedRows[0].DataBoundItem as DataRowView), "IDCENTROCUSTO"))))
                            throw new Exception("Não foi possível remover o Centro de Custo.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();

                        SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível remover, verifique pendências.", "red", false, false);

                        return;
                    }
                    CarregarCentros();
                }
            }
            else
            {
               SyncMessager.CreateMessage(0,NOME_TELA, "Selecione o centro de custo que deseja remover.", "red", false, false);
            }
        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Centros.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Centro de Custo.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Centros.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (DRSelected == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Centro de Custo.", "yellow", false, false);
                    return;
                }
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível selecionar o Centro de Custo.", "red", false, false);
            }
        }

        private void ovTXT_Centro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CarregarCentros();
            }
        }

        private void ovTXT_Descricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CarregarCentros();
            }
        }

        private void FCO_CentroCusto_Shown(object sender, EventArgs e)
        {
            Limpar();
        }

        private void FCO_CentroCusto_Load(object sender, EventArgs e)
        {

        }
              
        private void ovGRD_Centros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ovGRD_Centros.SelectedRows.Count == 1)
                {
                    FCA_CentroCusto FormCentroCusto = new FCA_CentroCusto(FuncoesCentroCusto.GetCentroCusto(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Centros.SelectedRows[0].DataBoundItem as DataRowView), "IDCENTROCUSTO"))));
                    FormCentroCusto.ShowDialog(this);
                    CarregarCentros();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o centro de custo que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
               SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void ovGRD_Centros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Centros.SelectedRows.Count == 1)
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
    }
}
