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
    public partial class FCO_Usuario : MetroForm
    {
        private string NOME_TELA = "Consulta de usuário";
        public DataRow DRSelected = null;
        private decimal _IDUsuario = -1;
        private bool _IsSelect = false;
        public FCO_Usuario(bool IsSelect, decimal IDUsuario)
        {
            InitializeComponent();

            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                //BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
                _IDUsuario = IDUsuario;
                _IsSelect = true;
            }
        }

        private void AtualizaUsuarios(string Login, string Nome)
        {
            ovGRD_Usuarios.DataSource = null;
            ovGRD_Usuarios.DataSource = FuncoesUsuario.GetUsuarios(Nome, Login, _IDUsuario, CheckBox_Ativo.Checked, CheckBox_Inativo.Checked);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Usuarios.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Usuarios.Width;

            foreach (DataGridViewColumn column in ovGRD_Usuarios.Columns)
            {
                switch (column.Name)
                {
                    case "login":
                        column.DisplayIndex = 1;
                        column.HeaderText = "Login";
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.30);
                        break;
                    case "nome":
                        column.DisplayIndex = 2;
                        column.HeaderText = "Nome";
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.60);
                        break;
                    case "ativo":
                        column.DisplayIndex = 3;
                        column.HeaderText = "Ativo";
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Usuarios.Rows.Count > 0)
            {
                ovGRD_Usuarios.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Usuarios.Rows[0].Selected = true;
            }

        }

        private void ovBTN_LimparFiltros_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ovTXT_Login.Focus();
            ovTXT_Login.Text = string.Empty;
            ovTXT_Nome.Text = string.Empty;
            ovGRD_Usuarios.DataSource = null;
            CheckBox_Ativo.Checked = true;
            CheckBox_Inativo.Checked = true;
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            AtualizaUsuarios(ovTXT_Login.Text, ovTXT_Nome.Text);
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 1) != null)
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
                FCA_Usuario t = new FCA_Usuario(new Usuario());
                t.ShowDialog(this);
                AtualizaUsuarios(ovTXT_Login.Text, ovTXT_Nome.Text);
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
            if (this.ovGRD_Usuarios.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o Usuário selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    decimal IDUsuario = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Usuarios.SelectedRows[0].DataBoundItem as DataRowView), "IDUSUARIO"));
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesUsuario.Remover(IDUsuario))
                            throw new Exception("Não foi possível remover o Usuário.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        SyncMessager.CreateMessage(0, NOME_TELA, "Não foi possível remover, verifique pendências.", "red", false, false);
                        return;
                    }
                    AtualizaUsuarios(ovTXT_Login.Text, ovTXT_Nome.Text);
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione o usuário que deseja remover.", "red", false, false);
            }
        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Usuarios.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Usuário.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Usuarios.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (DRSelected == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Usuário.", "yellow", false, false);
                    return;
                }
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível selecionar um Usuário.", "red", false, false);
            }
        }

        private void ovTXT_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizaUsuarios(ovTXT_Login.Text, ovTXT_Nome.Text);
            }
        }

        private void ovTXT_Nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizaUsuarios(ovTXT_Login.Text, ovTXT_Nome.Text);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FCO_Usuario_Shown(object sender, EventArgs e)
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

        private void ovGRD_Usuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Usuarios.SelectedRows.Count == 1)
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
                if (this.ovGRD_Usuarios.SelectedRows.Count == 1)
                {
                    decimal IDUsuario = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Usuarios.SelectedRows[0].DataBoundItem as DataRowView), "IDUSUARIO"));
                    FCA_Usuario t = new FCA_Usuario(FuncoesUsuario.GetUsuario(IDUsuario));
                    t.ShowDialog(this);
                    AtualizaUsuarios(ovTXT_Login.Text, ovTXT_Nome.Text);
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o usuário que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void FCO_Usuario_Load(object sender, EventArgs e)
        {

        }
        
    }
}
