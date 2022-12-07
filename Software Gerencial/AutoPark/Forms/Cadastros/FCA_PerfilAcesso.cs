using AutoController.Funcoes;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using MetroFramework.Forms;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_PerfilAcesso : MetroForm
    {
        private string NOME_TELA = "Cadastro de perfil de acesso";
        private PerfilAcesso Perfil = null;
        private List<ItemMenu> ItensMenu = FuncoesItemMenu.GetItensMenu();

        public FCA_PerfilAcesso(PerfilAcesso _Perfil)
        {
            InitializeComponent();
            Perfil = _Perfil;

            ovCKD_ItensMenu.Items.Clear();
            foreach (ItemMenu Item in ItensMenu)
                ovCKD_ItensMenu.Items.Add(Item);

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Descricao.Text = Perfil.Descricao;
            ovCKB_Ativo.Checked = Perfil.Ativo == 1;

            List<ItemMenu> ItensMenuContido = FuncoesPerfilAcesso.GetItensMenuPorPerfilAcesso(Perfil.IDPerfilAcesso);

            for (int i = 0; i < ovCKD_ItensMenu.Items.Count; i++)
            {
                ItemMenu _Item = ItensMenuContido.Where(o => o.IDItemMenu == (ovCKD_ItensMenu.Items[i] as ItemMenu).IDItemMenu).FirstOrDefault();

                if (_Item != null)
                {
                    ovCKD_ItensMenu.SetItemChecked(i, true);
                }
            }
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidouDados()
        {
            if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe a descrição.", "yellow", false, false);
                ovTXT_Descricao.Focus();
                return false;
            }

            if (FuncoesPerfilAcesso.ExistePorDescricao(ovTXT_Descricao.Text, Perfil.IDPerfilAcesso))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Esta descrição já está sendo usada.", "yellow", false, false);
                ovTXT_Descricao.Focus();
                return false;
            }

            return true;
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {
                ovTXT_Descricao.Text = ovTXT_Descricao.Text.Trim();

                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                Perfil.Descricao = ovTXT_Descricao.Text;
                Perfil.Ativo = ovCKB_Ativo.Checked ? 1 : 0;

                TipoOperacao Op = TipoOperacao.UPDATE;

                if (Perfil.IDPerfilAcesso == -1)
                {
                    Perfil.IDPerfilAcesso = Sequence.GetNextID("PERFILACESSO", "IDPERFILACESSO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesPerfilAcesso.Salvar(Perfil, Op))
                    throw new Exception("Não foi possível salvar o Perfil de Acesso.");

                if (!FuncoesPerfilAcesso.RemoverPerfilAcessoItemMenu(Perfil.IDPerfilAcesso))
                    throw new Exception("Não foi possível salvar os Itens de Menu.");

                // RemoverPerfilAcessoItemMenu OLD:RemoverPermissoesPorPerfilAcesso

                /* SALVANDO OS PERFIS DE ACESSO */
                for (int i = 0; i < ovCKD_ItensMenu.CheckedItems.Count; i++)
                {
                    if (!FuncoesPerfilAcesso.SalvarPerfilAcessoItemMenu(Perfil.IDPerfilAcesso, (ovCKD_ItensMenu.CheckedItems[i] as ItemMenu).IDItemMenu))
                        throw new Exception("Não foi possível salvar os Itens de Menu.");
                }
                //SalvarPerfilAcessoItemMenu OLD:SalvarPerfilAcessoItemMen
                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Perfil de Acesso salvo com sucesso.", "green", false, false);
            }
            catch (Exception Ex)
            {
                if (InTransaction)
                    PDVControlador.Rollback();
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();
                SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
            }
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
        private void FCA_PerfilAcesso_Load(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
            guna2TabControl1.SelectedIndex = 0;
        }
    }
}
