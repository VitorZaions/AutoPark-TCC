using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoPark.Forms.Cadastro;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Consultas
{
    public partial class FCO_PerfilAcesso : MetroForm
    {
        private string NOME_TELA = "Consulta de perfil de acesso";
        public DataRow DRSelected = null;
        private bool _IsSelect = false;
        public FCO_PerfilAcesso(bool IsSelect)
        {
            InitializeComponent();

            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                //BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
                _IsSelect = true;
            }
        }

        private void AtualizaPerfis(string Descricao, bool Ativo, bool Inativo)
        {
            ovGRD_Perfis.DataSource = null;
            ovGRD_Perfis.DataSource = FuncoesPerfilAcesso.GetPerfisAcesso(Descricao, Ativo, Inativo);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Perfis.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Perfis.Width;
            foreach (DataGridViewColumn column in ovGRD_Perfis.Columns)
            {
                switch (column.Name)
                {
                    case "descricao":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.90);
                        column.HeaderText = "Descrição";
                        break;
                    case "ativo":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "Ativo";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Perfis.Rows.Count > 0)
            {
                ovGRD_Perfis.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Perfis.Rows[0].Selected = true;
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
            ovTXT_Descricao.Focus();
            ovTXT_Descricao.Text = string.Empty;
            ovGRD_Perfis.DataSource = null;
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            if (CheckBox_Ativo.Checked == false && CheckBox_Inativo.Checked == false)
            {
                Limpar();
                return;
            }

            AtualizaPerfis(ovTXT_Descricao.Text, CheckBox_Ativo.Checked, CheckBox_Inativo.Checked);
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {

            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 10) != null)
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
                FCA_PerfilAcesso t = new FCA_PerfilAcesso(new PerfilAcesso());
                t.ShowDialog(this);
                AtualizaPerfis(ovTXT_Descricao.Text, CheckBox_Ativo.Checked, CheckBox_Inativo.Checked);
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
            if (this.ovGRD_Perfis.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o perfil de Acesso selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    decimal IDPerfilAcesso = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Perfis.SelectedRows[0].DataBoundItem as DataRowView), "IDPERFILACESSO"));
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesPerfilAcesso.Remover(IDPerfilAcesso))
                            throw new Exception("Não foi possível remover o perfil de Acesso.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível remover, verifique pendências.", "red", false, false);
                        return;
                    }
                    AtualizaPerfis(ovTXT_Descricao.Text, CheckBox_Ativo.Checked, CheckBox_Inativo.Checked);
                }
            }
            else
            {
               SyncMessager.CreateMessage(0,NOME_TELA, "Selecione o perfil que deseja remover.", "red", false, false);
            }
        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Perfis.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Perfil de Acesso.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Perfis.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (DRSelected == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Perfil de Acesso.", "yellow", false, false);
                    return;
                }
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível selecionar um Perfil de Acesso.", "red", false, false);
            }
        }

        private void ovTXT_Descricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizaPerfis(ovTXT_Descricao.Text, CheckBox_Ativo.Checked, CheckBox_Inativo.Checked);
            }
        }

        private void FCO_PerfilAcesso_Shown(object sender, EventArgs e)
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

        private void ovGRD_Perfis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Perfis.SelectedRows.Count == 1)
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

                if (this.ovGRD_Perfis.SelectedRows.Count == 1)
                {
                    decimal IDPerfilAcesso = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Perfis.SelectedRows[0].DataBoundItem as DataRowView), "IDPERFILACESSO"));
                    FCA_PerfilAcesso t = new FCA_PerfilAcesso(FuncoesPerfilAcesso.GetPerfil(IDPerfilAcesso));
                    t.ShowDialog(this);
                    AtualizaPerfis(ovTXT_Descricao.Text, CheckBox_Ativo.Checked, CheckBox_Inativo.Checked);
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o perfil que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void FCO_PerfilAcesso_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
