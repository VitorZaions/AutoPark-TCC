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
    public partial class FCAFIN_ChequeMensalidade : MetroForm
    {
        private string NOME_TELA = "Cheque Mensalidade";
        public ChequeMensalidade _ChequeMensalidade = null;
        public bool Salvou = false;
        public FCAFIN_ChequeMensalidade(ChequeMensalidade ChequeMensalidade)
        {
            InitializeComponent();
            _ChequeMensalidade = ChequeMensalidade;
            PreencherTela();
        }

        private void PreencherTela()
        {
            if (_ChequeMensalidade.Numero != 0)
                ovTXT_Numero.Text = _ChequeMensalidade.Numero.ToString();
            ovTXT_Valor.Value = _ChequeMensalidade.Valor;
            ovCKB_Cruzado.Checked = _ChequeMensalidade.Cruzado == 1;

            ovTXT_Emissao.Value = _ChequeMensalidade.Emissao;
            ovTXT_Vencimento.Value = _ChequeMensalidade.Vencimento;

            ovTXT_Compensado.Checked = _ChequeMensalidade.Compensado == 1;
            if (_ChequeMensalidade.DataCompensacao.HasValue)
                ovTXT_Compensado.Value = _ChequeMensalidade.DataCompensacao.Value;

            ovTXT_Devolvido.Checked = _ChequeMensalidade.Devolvido == 1;
            if (_ChequeMensalidade.DataDevolucao.HasValue)
                ovTXT_Devolvido.Value = _ChequeMensalidade.DataDevolucao.Value;

            ovTXT_Repasse.Checked = _ChequeMensalidade.Repasse == 1;
            if (_ChequeMensalidade.DataRepasse.HasValue)
                ovTXT_Repasse.Value = _ChequeMensalidade.DataRepasse.Value;

            if (_ChequeMensalidade.ObsRepasse != null)
                ovTXT_Obs.Text = Encoding.UTF8.GetString(_ChequeMensalidade.ObsRepasse);
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

                _ChequeMensalidade.Numero = Convert.ToDecimal(SyncUtil.SomenteNumeros(ovTXT_Numero.Text));
                _ChequeMensalidade.Valor = ovTXT_Valor.Value;
                _ChequeMensalidade.Cruzado = ovCKB_Cruzado.Checked ? 1 : 0;

                _ChequeMensalidade.Emissao = ovTXT_Emissao.Value;
                _ChequeMensalidade.Vencimento = ovTXT_Vencimento.Value;

                _ChequeMensalidade.Compensado = ovTXT_Compensado.Checked ? 1 : 0;
                _ChequeMensalidade.DataCompensacao = null;
                if (_ChequeMensalidade.Compensado == 1)
                    _ChequeMensalidade.DataCompensacao = ovTXT_Compensado.Value;


                _ChequeMensalidade.Devolvido = ovTXT_Devolvido.Checked ? 1 : 0;
                _ChequeMensalidade.DataDevolucao = null;
                if (_ChequeMensalidade.Devolvido == 1)
                    _ChequeMensalidade.DataDevolucao = ovTXT_Devolvido.Value;

                _ChequeMensalidade.Repasse = ovTXT_Repasse.Checked ? 1 : 0;
                _ChequeMensalidade.DataRepasse = null;
                if (_ChequeMensalidade.Repasse == 1)
                    _ChequeMensalidade.DataRepasse = ovTXT_Repasse.Value;

                _ChequeMensalidade.ObsRepasse = Encoding.Default.GetBytes(ovTXT_Obs.Text);

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
