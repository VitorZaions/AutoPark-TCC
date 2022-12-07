using AutoController.Funcoes;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using AutoPark.Forms.Consultas;
using MetroFramework.Forms;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_NaturezaFinanceira : MetroForm
    {
        private string NOME_TELA = "Cadastro de natureza financeira";
        private Natureza NaturezaFinanceira = null;
        private List<Natureza> Naturezas = null;
        public FCA_NaturezaFinanceira(Natureza Natureza)
        {
            InitializeComponent();
            NaturezaFinanceira = Natureza;
            Naturezas = FuncoesNatureza.GetNaturezas(NaturezaFinanceira.IDNatureza);

            ovCMB_NaturezaSuperior.DataSource = Naturezas;
            ovCMB_NaturezaSuperior.DisplayMember = "descricao";
            ovCMB_NaturezaSuperior.ValueMember = "idnatureza";

            ovCMB_NaturezaSuperior.SelectedItem = null;
            if (NaturezaFinanceira.IDNaturezaSuperior.HasValue)
            {
                ovCMB_NaturezaSuperior.SelectedItem = Naturezas.Find(x => x.IDNatureza == Natureza.IDNaturezaSuperior.Value);
            }

            ovTXT_Descricao.Text = NaturezaFinanceira.Descricao;
            ovTXT_Aplicacao.Text = NaturezaFinanceira.Aplicacao;

            if (NaturezaFinanceira.Tipo == 0)
                ovCKB_Receita.Checked = true;
            else
                ovCKB_Despesa.Checked = true;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidouDados()
        {
            if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe a Descrição.", "yellow", false, false);
                ovTXT_Descricao.Focus();
                return false;
            }


            if (FuncoesNatureza.ExistePorDescricao(ovTXT_Descricao.Text, NaturezaFinanceira.IDNatureza))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Esta descrição já está sendo usada.", "yellow", false, false);
                ovTXT_Descricao.Focus();
                return false;
            }

            return true;
        }
        private void metroButton4_Click(object sender, EventArgs e)
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {

                ovTXT_Descricao.Text = ovTXT_Descricao.Text.Trim();
                ovTXT_Aplicacao.Text = ovTXT_Aplicacao.Text.Trim();

                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                NaturezaFinanceira.Aplicacao = ovTXT_Aplicacao.Text;
                NaturezaFinanceira.Descricao = ovTXT_Descricao.Text;
                NaturezaFinanceira.Tipo = ovCKB_Receita.Checked ? 0 : 1;

                NaturezaFinanceira.IDNaturezaSuperior = null;
                if (ovCMB_NaturezaSuperior.SelectedItem != null)
                    NaturezaFinanceira.IDNaturezaSuperior = (ovCMB_NaturezaSuperior.SelectedItem as Natureza).IDNatureza;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (NaturezaFinanceira.IDNatureza == -1)
                {
                    NaturezaFinanceira.IDNatureza = Sequence.GetNextID("NATUREZA", "IDNATUREZA");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesNatureza.Salvar(NaturezaFinanceira, Op))
                    throw new Exception("Não foi possível salvar a Natureza Financeira.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Natureza Financeira salva com sucesso.", "green", false, false);
                Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            ovCMB_NaturezaSuperior.SelectedItem = null;
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
        private void FCA_NaturezaFinanceira_Load(object sender, EventArgs e)
        {

        }

        private void Pesquisar()
        {
            FCO_NaturezaFinanceira SeletorNatureza = new FCO_NaturezaFinanceira(true, NaturezaFinanceira.IDNatureza);
            SeletorNatureza.ShowDialog(this);

            if (SeletorNatureza.DRSelected == null)
                return;


            Naturezas = FuncoesNatureza.GetNaturezas(NaturezaFinanceira.IDNatureza);
            ovCMB_NaturezaSuperior.DataSource = Naturezas;

            DataRow DrSelecionada = SeletorNatureza.DRSelected;

            // PDV.UTIL.SyncMessager.CreateMessage(0,NOME_TELA, "Você não pode escolher a própria natureza como a superior, tente outra!", "yellow", false, false);

            //Natureza SelectedNatureza = EntityUtil<Natureza>.ParseDataRow(SeletorNatureza.DRSelected);

            decimal ToCompare = Convert.ToDecimal(DrSelecionada["IDNATUREZA"]);
            Natureza SelectedNatureza = FuncoesNatureza.GetNatureza(ToCompare);
            ovCMB_NaturezaSuperior.SelectedItem = Naturezas.Find(x => x.IDNatureza == SelectedNatureza.IDNatureza);
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ovTXT_Aplicacao.Focus();
            }
        }

        private void ovTXT_CodigoNaturezaSuperior_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN_Limpar_Click(object sender, EventArgs e)
        {
            ovCMB_NaturezaSuperior.SelectedIndex = -1;
            ovCMB_NaturezaSuperior.SelectedItem = null;
        }

        private void FCA_NaturezaFinanceira_Shown(object sender, EventArgs e)
        {
            ovTXT_Descricao.Focus();
        }
    }
}
