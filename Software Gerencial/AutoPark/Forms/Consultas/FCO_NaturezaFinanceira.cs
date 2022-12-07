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
    public partial class FCO_NaturezaFinanceira : MetroForm
    {
        private string NOME_TELA = "Consulta de natureza financeira";
        private DataTable DADOS = null;
        public DataRow DRSelected = null;
        public decimal _IDNatureza = -1;
        public FCO_NaturezaFinanceira(bool IsSelect, decimal IDNatureza)
        {
            InitializeComponent();
            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                //BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
                _IDNatureza = IDNatureza;
            }
        }

        private void Carregar()
        {
            ovGRD_Natureza.DataSource = null;
            DADOS = FuncoesNatureza.GetNaturezasRestrict(ovTXT_Descricao.Text, _IDNatureza);
            ovGRD_Natureza.DataSource = DADOS;
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Natureza.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Natureza.Width;
            foreach (DataGridViewColumn column in ovGRD_Natureza.Columns)
            {
                switch (column.Name)
                {
                    case "descricao":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.50);
                        column.HeaderText = "Descrição";
                        break;
                    case "tipodesc":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.25);
                        column.HeaderText = "Tipo";
                        break;
                    case "naturezasuperior":
                        column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.25);
                        column.HeaderText = "Natureza superior";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Natureza.Rows.Count > 0)
            {
                ovGRD_Natureza.Rows[0].Selected = true;
            }
        }


        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ovTXT_Descricao.Focus();
            ovTXT_Descricao.Text = string.Empty;
            ovGRD_Natureza.DataSource = null;
        }

        private void metroButton2_Click(object sender, System.EventArgs e)
        {
            Carregar();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 7) != null)
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
                new FCA_NaturezaFinanceira(new Natureza()).ShowDialog(this);
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
            if (this.ovGRD_Natureza.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover a Natureza Financeira selecionada?", "yellow", true, false) == DialogResult.OK)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesNatureza.Remover(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Natureza.SelectedRows[0].DataBoundItem as DataRowView), "IDNATUREZA"))))
                            throw new Exception("Não foi possível remover a Natureza Financeira.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível remover, verifique pendências.", "red", false, false);
                        return;
                    }
                    Carregar();
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a natureza financeira que deseja remover.", "red", false, false);
            }

        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Natureza.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione uma Natureza Financeira.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Natureza.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (DRSelected == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione uma Natureza Financeira.", "yellow", false, false);
                    return;
                }
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível selecionar a Natureza Financeira.", "red", false, false);
            }
        }

        private void ovTXT_Descricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                metroButton2_Click(null, null);
            }
        }

        private void FCO_NaturezaFinanceira_Shown(object sender, EventArgs e)
        {
            Limpar();
        }

        private void FCO_NaturezaFinanceira_Load(object sender, EventArgs e)
        {

        }

        private void ovGRD_Natureza_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Natureza.SelectedRows.Count == 1)
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

                if (this.ovGRD_Natureza.SelectedRows.Count == 1)
                {
                    FCA_NaturezaFinanceira Form = new FCA_NaturezaFinanceira(FuncoesNatureza.GetNatureza(Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Natureza.SelectedRows[0].DataBoundItem as DataRowView), "IDNATUREZA"))));
                    Form.ShowDialog(this);
                    Carregar();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a natureza financeira que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }

        }
    }
}
