using AutoController.Funcoes;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using AutoPark.Forms.Consultas;
using MetroFramework.Forms;
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
    public partial class FCA_CentroCusto : MetroForm
    {
        private string NOME_TELA = "Cadastro de centro de custo";
        private CentroCusto CENTRO = null;
        private List<CentroCusto> CentroSuperior = null;

        public FCA_CentroCusto(CentroCusto Centro)
        {
            InitializeComponent();
            CENTRO = Centro;

            CentroSuperior = FuncoesCentroCusto.GetCentrosCusto(CENTRO.IDCentroCusto);
            ovCMB_CentroCustoSuperior.DataSource = CentroSuperior;
            ovCMB_CentroCustoSuperior.ValueMember = "idcentrocusto";
            ovCMB_CentroCustoSuperior.DisplayMember = "descricao";

            CarregaCentro();
        }

        private void CarregaCentro()
        {
            ovTXT_Centro.Text = CENTRO.Centro;
            ovTXT_Descricao.Text = CENTRO.Descricao;
            ovTXT_Obs.Text = CENTRO.Observacao;

            ovCMB_CentroCustoSuperior.SelectedItem = null;
            if (CENTRO.IDCentroCustoSuperior.HasValue)
                ovCMB_CentroCustoSuperior.SelectedItem = CentroSuperior.Where(o => o.IDCentroCusto == CENTRO.IDCentroCustoSuperior.Value).FirstOrDefault();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidouDados()
        {
            if (string.IsNullOrEmpty(ovTXT_Centro.Text.Trim()))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Centro.", "yellow", false, false);
                ovTXT_Centro.Focus();
                return false;
            }

            if (FuncoesCentroCusto.ExistePorCentroDescricao(ovTXT_Centro.Text, CENTRO.IDCentroCusto))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Este centro de custo já está cadastrado.", "yellow", false, false);
                ovTXT_Centro.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe a Descrição.", "yellow", false, false);
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
                ovTXT_Centro.Text = ovTXT_Centro.Text.Trim();
                ovTXT_Descricao.Text = ovTXT_Descricao.Text.Trim();
                ovTXT_Obs.Text = ovTXT_Obs.Text.Trim();

                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                CENTRO.Centro = ovTXT_Centro.Text;
                CENTRO.Descricao = ovTXT_Descricao.Text;
                CENTRO.Observacao = ovTXT_Obs.Text;

                CENTRO.IDCentroCustoSuperior = null;
                if (ovCMB_CentroCustoSuperior.SelectedItem != null)
                    CENTRO.IDCentroCustoSuperior = (ovCMB_CentroCustoSuperior.SelectedItem as CentroCusto).IDCentroCusto;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (CENTRO.IDCentroCusto == -1)
                {
                    CENTRO.IDCentroCusto = Sequence.GetNextID("CENTROCUSTO", "IDCENTROCUSTO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesCentroCusto.Salvar(CENTRO, Op))
                    throw new Exception("Não foi possível salvar o Centro de Custo.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Centro de Custo salvo com sucesso.", "green", false, false);
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
            ovCMB_CentroCustoSuperior.SelectedItem = null;
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

        private void FCA_CentroCusto_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Limpar_Click(object sender, EventArgs e)
        {
            ovCMB_CentroCustoSuperior.SelectedIndex = -1;
            ovCMB_CentroCustoSuperior.SelectedItem = null;
        }

        private void Pesquisar()
        {
            FCO_CentroCusto SeletorCentroCusto = new FCO_CentroCusto(true, CENTRO.IDCentroCusto);
            SeletorCentroCusto.ShowDialog(this);

            if (SeletorCentroCusto.DRSelected == null)
                return;

            CentroSuperior = FuncoesCentroCusto.GetCentrosCusto(CENTRO.IDCentroCusto);
            ovCMB_CentroCustoSuperior.DataSource = CentroSuperior;

            DataRow DrSelecionada = SeletorCentroCusto.DRSelected;

            decimal ToCompare = Convert.ToDecimal(DrSelecionada["IDCENTROCUSTO"]);
            //CentroCusto SelectedCentro = EntityUtil<CentroCusto>.ParseDataRow(SeletorCentroCusto.DRSelected);
            CentroCusto SelectedCentro = FuncoesCentroCusto.GetCentroCusto(ToCompare);
            ovCMB_CentroCustoSuperior.SelectedItem = CentroSuperior.Find(x => x.IDCentroCusto == SelectedCentro.IDCentroCusto);
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
