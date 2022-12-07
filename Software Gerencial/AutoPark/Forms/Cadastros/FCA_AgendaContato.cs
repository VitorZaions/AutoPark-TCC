using AutoController.Funcoes;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_AgendaContato : MetroForm
    {
        private AgendaContato _AgendaContato = null;
        private string NOME_TELA = "Cadastro de Contato";
        public FCA_AgendaContato(AgendaContato Contato)
        {
            InitializeComponent();
            _AgendaContato = Contato;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Codigo.Text = _AgendaContato.IDCONTATO == -1 ? "" : _AgendaContato.IDCONTATO.ToString();
            ovTXT_Nome.Text = _AgendaContato.NOME;
            ovTXT_Telefone.Text = _AgendaContato.Telefone;
            ovTXT_Celular.Text = _AgendaContato.Celular;
            ovTXT_Email.Text = _AgendaContato.EMAIL;
            ovTXT_Obs.Text = _AgendaContato.OBSERVACAO;

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

        private void FCA_AgendaContato_Load(object sender, EventArgs e)
        {
        }

        private bool ValidouDados()
        {
            if (ovTXT_Nome.Text.Trim() == "")
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Insira um nome.", "yellow", false, false);
                ovTXT_Nome.Focus();
                return false;
            }

            if (FuncoesAgendaContato.ExistePorNome(ovTXT_Nome.Text.Trim(), _AgendaContato.IDCONTATO))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Um contato com este nome já existe.", "yellow", false, false);
                ovTXT_Nome.Focus();
                return false;
            }

            // Verificar telefone e celular

            if (ovTXT_Telefone.Text != "")
            {
                if (ovTXT_Telefone.Text.Length < 10)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Insira um celular válido, com pelo menos 10 digitos.", "yellow", false, false);
                    ovTXT_Telefone.Focus();
                    return false;
                }
            }

            if (ovTXT_Celular.Text != "")
            {
                if (ovTXT_Celular.Text.Length < 11)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Insira um celular válido (2), com pelo menos 11 digitos.", "yellow", false, false);
                    ovTXT_Celular.Focus();
                    return false;
                }
            }



            return true;
        }


        private void BTN_Salvar_Click(object sender, EventArgs e)
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {
                ovTXT_Nome.Text.Trim();
                ovTXT_Telefone.Text.Trim();
                ovTXT_Celular.Text.Trim();
                ovTXT_Email.Text.Trim();



                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                _AgendaContato.NOME = ovTXT_Nome.Text;
                _AgendaContato.Telefone = ovTXT_Telefone.Text;
                _AgendaContato.Celular = ovTXT_Celular.Text;
                _AgendaContato.EMAIL = ovTXT_Email.Text;
                _AgendaContato.OBSERVACAO = ovTXT_Obs.Text;

                TipoOperacao Op = TipoOperacao.UPDATE;
                //if (!FuncoesComanda.Existe(COMANDA.IDComanda))
                if (_AgendaContato.IDCONTATO == -1)
                {
                    _AgendaContato.IDCONTATO = Sequence.GetNextID("AGENDACONTATO", "IDCONTATO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesAgendaContato.Salvar(_AgendaContato, Op))
                    throw new Exception("Não foi possível salvar o contato.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Contato salvo com sucesso.", "green", false, false);
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

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FCA_AgendaContato_Shown(object sender, EventArgs e)
        {
            ovTXT_Nome.Focus();
        }

        private void ovTXT_Nome_TextChanged(object sender, EventArgs e)
        {
        }

        public static string GetMaskedString(string mask, string input)
        {
            try
            {
                MaskedTextProvider provider = new MaskedTextProvider(mask);
                provider.Add(input);
                return provider.ToDisplayString();
            }
            catch { return input; }
        }

        private void ovTXT_Telefone_Validating(object sender, CancelEventArgs e)
        {
            ovTXT_Telefone.Text = SyncUtil.SomenteNumeros(ovTXT_Telefone.Text);
        }

        private void ovTXT_Celular_Validating(object sender, CancelEventArgs e)
        {
            ovTXT_Celular.Text = SyncUtil.SomenteNumeros(ovTXT_Celular.Text);
        }
    }
}
