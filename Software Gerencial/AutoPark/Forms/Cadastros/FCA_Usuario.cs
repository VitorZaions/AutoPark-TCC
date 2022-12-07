using AutoController.Funcoes;
using AutoDAO.Custom;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using AutoPark.Forms.Consultas;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_Usuario : MetroForm
    {

        private string NOME_TELA = "Cadastro de usuário";
        private Usuario User = null;
        private List<PerfilAcesso> Perfis = FuncoesPerfilAcesso.GetPerfisAcesso_CadastroUsuario(true);
        private List<Usuario> Usuarios = null;

        public FCA_Usuario(Usuario _Usuario)
        {
            InitializeComponent();
            User = _Usuario;

            Usuarios = FuncoesUsuario.GetUsuarios(-1);

            ovCMB_Perfil.DataSource = Perfis;
            ovCMB_Perfil.DisplayMember = "descricao";
            ovCMB_Perfil.ValueMember = "idperfilacesso";


            ovCMB_UsuarioSupervisor.DataSource = Usuarios;
            ovCMB_UsuarioSupervisor.DisplayMember = "nome";
            ovCMB_UsuarioSupervisor.ValueMember = "idusuario";

            if (User != null)
                PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Nome.Text = User.Nome;
            ovTXT_Login.Text = User.Login;
            ovTXT_Email.Text = User.Email;
            //ovTXT_Senha.Text = Criptografia.DecodificaSenha(User.Senha);
            //ovTXT_ConfirmaSenha.Text = Criptografia.DecodificaSenha(User.Senha);
            ovCKB_Ativo.Checked = User.Ativo == 1;
            if (Perfis != null)
                ovCMB_Perfil.SelectedItem = Perfis.Where(o => o.IDPerfilAcesso == User.IDPerfilAcesso).FirstOrDefault();

            //ovTXT_Login.Enabled = User.IDUsuario == -1;

            ovCMB_UsuarioSupervisor.SelectedItem = Usuarios.Where(o => o.IDUsuario == User.IDUsuarioSupervisor).FirstOrDefault();
        }

        private void ovBTN_Cancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private bool ValidouDados()
        {
            if (User.Root == 1 && (Contexto.USUARIOLOGADO.Root != 1))
            {
               SyncMessager.CreateMessage(0, NOME_TELA, "Somente um usuário root pode editar este perfil.", "yellow", false, false);
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_Nome.Text.Trim()))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Nome.", "yellow", false, false);
                ovTXT_Nome.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_Login.Text.Trim()))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Login.", "yellow", false, false);
                ovTXT_Login.Focus();
                return false;
            }

            if (FuncoesUsuario.ExisteLogin(User.IDUsuario, ovTXT_Login.Text))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "O Login informado já existe.", "yellow", false, false);
                ovCMB_Perfil.Focus();
                return false;
            }

            if (ovTXT_Senha.Text == string.Empty && User.IDUsuario == -1)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe a Senha.", "yellow", false, false);
                ovTXT_Senha.Focus();
                return false;
            }

            if (ovTXT_ConfirmaSenha.Text == string.Empty && User.IDUsuario == -1)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "informe a Confirmação da Senha.", "yellow", false, false);
                ovTXT_ConfirmaSenha.Focus();
                return false;
            }

            if (ovTXT_Senha.Text != ovTXT_ConfirmaSenha.Text)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "A senha e a confirmação não coincidem.", "yellow", false, false);
                ovTXT_ConfirmaSenha.Focus();
                return false;
            }

            if (ovCMB_Perfil.SelectedItem == null)
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Perfil.", "yellow", false, false);
                ovCMB_Perfil.Focus();
                return false;
            }

            /*if (ovCMB_UsuarioSupervisor.SelectedItem == null)
            {
                PDV.UTIL.SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um supervisor.", "red", false, false);
                ovCMB_UsuarioSupervisor.Focus();
                return false;
            }*/


            if (ovTXT_Email.Text != "")
            {
                if (!SyncUtil.IsValidEmail(User.Email))
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Informe um e-mail válido.", "yellow", false, false);
                    ovTXT_Email.Focus();
                    return false;
                }
            }

            return true;
        }

        private void ovBTN_Salvar_Click(object sender, System.EventArgs e)
        {

            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {
                User.Nome = ovTXT_Nome.Text.Trim();
                User.Login = ovTXT_Login.Text.Trim();
                User.Email = ovTXT_Email.Text.Trim();

                if (!ValidouDados())
                {
                    return;
                }

                if (User.IDUsuario == -1)
                {
                    User.Senha = SyncUtil.RetornarMD5(ovTXT_Senha.Text);
                }
                else
                {
                    if(ovTXT_Senha.Text != string.Empty || ovTXT_ConfirmaSenha.Text != string.Empty)
                    {
                        User.Senha = SyncUtil.RetornarMD5(ovTXT_Senha.Text);
                    }
                }
                User.Ativo = ovCKB_Ativo.Checked ? 1 : 0;
                User.IDPerfilAcesso = (ovCMB_Perfil.SelectedItem as PerfilAcesso).IDPerfilAcesso;
                if (ovCMB_UsuarioSupervisor.SelectedItem != null)
                {
                    User.IDUsuarioSupervisor = (ovCMB_UsuarioSupervisor.SelectedItem as Usuario).IDUsuario;
                }
                else
                {
                    User.IDUsuarioSupervisor = -1;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

               TipoOperacao Op = TipoOperacao.UPDATE;
                if (User.IDUsuario == -1)
                {
                    User.IDUsuario = Sequence.GetNextID("USUARIO", "IDUSUARIO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesUsuario.Salvar(User, Op))
                    throw new Exception("Não foi possível salvar o usuário.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0, NOME_TELA, "Usuário salvo com sucesso.", "green", false, false);
            }
            catch(Exception Ex)
            {
                if (InTransaction)
                    PDVControlador.Rollback();
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();
               SyncMessager.CreateMessage(0, NOME_TELA, Ex.Message, "red", false, false);
            }

        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ovCMB_Perfil_DropDown_1(object sender, EventArgs e)
        {
            //if (Perfis != null)
            //     ovCMB_Perfil.DataSource = Perfis.Where(o => o.Ativo == 1).ToList();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    if (SyncMessager.CreateMessage(0, NOME_TELA, "Deseja sair?", "yellow", true, false) == DialogResult.OK)
                    {
                        Close();
                    }
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void FCA_Usuario_Load(object sender, EventArgs e)
        {

        }

        private void Pesquisar()
        {
            FCO_Usuario SeletorUsuario = new FCO_Usuario(true, User.IDUsuario);
            SeletorUsuario.ShowDialog(this);

            if (SeletorUsuario.DRSelected == null)
                return;

            Usuarios = FuncoesUsuario.GetUsuarios(User.IDUsuario);
            ovCMB_UsuarioSupervisor.DataSource = Usuarios;

            Usuario SelectedUser = EntityUtil<Usuario>.ParseDataRow(SeletorUsuario.DRSelected);
            ovCMB_UsuarioSupervisor.SelectedItem = Usuarios.Find(x => x.IDUsuario == SelectedUser.IDUsuario);
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void BTN_Limpar_Click(object sender, EventArgs e)
        {
            ovCMB_UsuarioSupervisor.SelectedIndex = -1;
            ovCMB_UsuarioSupervisor.SelectedItem = null;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FCO_PerfilAcesso SeletorPerfilAcesso = new FCO_PerfilAcesso(true);
            SeletorPerfilAcesso.ShowDialog(this);

            if (SeletorPerfilAcesso.DRSelected == null)
                return;

            Perfis = FuncoesPerfilAcesso.GetPerfisAcesso_CadastroUsuario(true);
            ovCMB_Perfil.DataSource = Perfis;


            DataRow DrSelecionada = SeletorPerfilAcesso.DRSelected;
            decimal ToCompare = Convert.ToDecimal(DrSelecionada["IDPERFILACESSO"]);
            PerfilAcesso SelectedPerfil = FuncoesPerfilAcesso.GetPerfil(ToCompare);
            ovCMB_Perfil.SelectedItem = Perfis.Find(x => x.IDPerfilAcesso == SelectedPerfil.IDPerfilAcesso);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ovCMB_Perfil.SelectedIndex = -1;
            ovCMB_Perfil.SelectedItem = null;
        }

        private void FCA_Usuario_Shown(object sender, EventArgs e)
        {
            ovTXT_Nome.Focus();
        }

        private void syncTextBox5_TextChange(object sender, EventArgs e)
        {

        }
    }
}
