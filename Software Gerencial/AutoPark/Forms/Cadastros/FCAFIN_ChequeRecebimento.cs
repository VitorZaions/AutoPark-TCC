using AutoDAO.Entidades;
using AutoUTIL;
using Guna.UI2.WinForms;
using MetroFramework.Forms;
using PDV.UTIL;
using System;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCAFIN_ChequeRecebimento : MetroForm
    {
        private string NOME_TELA = "Cheque recebimento";
        public ChequeContaReceber ChequeRecebimento = null;
        public bool Salvou = false;
        public FCAFIN_ChequeRecebimento(ChequeContaReceber _ChequeRecebimento)
        {
            InitializeComponent();
            ChequeRecebimento = _ChequeRecebimento;
            PreencherTela();
        }

        private void PreencherTela()
        {
            if (ChequeRecebimento.Numero != 0)
                ovTXT_Numero.Text = ChequeRecebimento.Numero.ToString();
            ovTXT_Valor.Value = ChequeRecebimento.Valor;
            ovCKB_Cruzado.Checked = ChequeRecebimento.Cruzado == 1;

            ovTXT_Emissao.Value = ChequeRecebimento.Emissao;
            ovTXT_Vencimento.Value = ChequeRecebimento.Vencimento;

            ovTXT_Compensado.Checked = ChequeRecebimento.Compensado == 1;
            if (ChequeRecebimento.DataCompensacao.HasValue)
                ovTXT_Compensado.Value = ChequeRecebimento.DataCompensacao.Value;

            ovTXT_Devolvido.Checked = ChequeRecebimento.Devolvido == 1;
            if (ChequeRecebimento.DataDevolucao.HasValue)
                ovTXT_Devolvido.Value = ChequeRecebimento.DataDevolucao.Value;

            ovTXT_Repasse.Checked = ChequeRecebimento.Repasse == 1;
            if (ChequeRecebimento.DataRepasse.HasValue)
                ovTXT_Repasse.Value = ChequeRecebimento.DataRepasse.Value;

            if (ChequeRecebimento.ObsRepasse != null)
                ovTXT_Obs.Text = Encoding.UTF8.GetString(ChequeRecebimento.ObsRepasse);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Salvou = false;
            Close();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(ovTXT_Numero.Text))
            {
                ovTXT_Numero.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe o Número.", "yellow", false, false);
                return false;
            }

            if (ovTXT_Valor.Value == 0)
            {
                ovTXT_Valor.Focus();
                SyncMessager.CreateMessage(0, NOME_TELA, "O Valor deve ser maior que zero.", "yellow", false, false);
                return false;
            }

            return true;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                    return;

                ChequeRecebimento.Numero = Convert.ToDecimal(SyncUtil.SomenteNumeros(ovTXT_Numero.Text));
                ChequeRecebimento.Valor = ovTXT_Valor.Value;
                ChequeRecebimento.Cruzado = ovCKB_Cruzado.Checked ? 1 : 0;

                ChequeRecebimento.Emissao = ovTXT_Emissao.Value;
                ChequeRecebimento.Vencimento = ovTXT_Vencimento.Value;

                ChequeRecebimento.Compensado = ovTXT_Compensado.Checked ? 1 : 0;
                ChequeRecebimento.DataCompensacao = null;
                if (ChequeRecebimento.Compensado == 1)
                    ChequeRecebimento.DataCompensacao = ovTXT_Compensado.Value;


                ChequeRecebimento.Devolvido = ovTXT_Devolvido.Checked ? 1 : 0;
                ChequeRecebimento.DataDevolucao = null;
                if (ChequeRecebimento.Devolvido == 1)
                    ChequeRecebimento.DataDevolucao = ovTXT_Devolvido.Value;

                ChequeRecebimento.Repasse = ovTXT_Repasse.Checked ? 1 : 0;
                ChequeRecebimento.DataRepasse = null;
                if (ChequeRecebimento.Repasse == 1)
                    ChequeRecebimento.DataRepasse = ovTXT_Repasse.Value;

                ChequeRecebimento.ObsRepasse = Encoding.Default.GetBytes(ovTXT_Obs.Text);

                Salvou = true;
                Close();
            }
            catch (Exception Ex)
            {
                Salvou = false;
                SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
            }
        }

        private void ovTXT_Numero_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ovTXT_Devolvido_ValueChanged(object sender, EventArgs e)
        {

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

        private void FCAFIN_ChequeRecebimento_Load(object sender, EventArgs e)
        {

        }

        private void ovTXT_Numero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Numero.Text = SyncUtil.SomenteNumeros(ovTXT_Numero.Text);
        }
    }
}
