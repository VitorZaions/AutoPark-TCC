using Guna.UI2.WinForms;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_EditarVencimento : MetroForm
    {
        public bool Salvou = false;

        decimal _Valor;
        DateTime _Vencimento;

        private string NOME_TELA = "Editar Vencimento";
        public FCA_EditarVencimento(decimal Valor, DateTime Vencimento)
        {
            InitializeComponent();
            _Valor = Valor;
            _Vencimento = Vencimento;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Valor.Value = _Valor;
            ovTXT_Vencimento.Value = _Vencimento;
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

        private void FCA_ItemProdutoOrcamento_Load(object sender, EventArgs e)
        {

        }

        private bool Validar()
        {
            if (ovTXT_Valor.Value <= 0)
            {
                ovTXT_Valor.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe um valor para o Vencimento.", "yellow", false, false);
                return false;
            }

            return true;
        }

        private void BTN_Salvar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            Salvou = true;
           Close();
        }       
               

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovTXT_Quantidade_ValueChanged(object sender, EventArgs e)
        {
        }             

        private void FCA_ItemProdutoOrcamento_Shown(object sender, EventArgs e)
        {
            ovTXT_Valor.Focus();
        }
    }
}
