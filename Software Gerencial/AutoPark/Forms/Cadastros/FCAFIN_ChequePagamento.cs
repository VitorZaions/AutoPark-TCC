using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoPark.Forms.Consultas;
using AutoUTIL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCAFIN_ChequePagamento : MetroForm
    {
        private string NOME_TELA = "Cheque pagamento";
        public ChequeContaPagar ChequePagamento = null;
        public bool Salvou = false;
        private List<Talonario> Talonarios = null;
        private decimal _IDContaBancaria;
        public FCAFIN_ChequePagamento(ChequeContaPagar _ChequePagamento, decimal IDContaBancaria)
        {
            InitializeComponent();
            _IDContaBancaria = IDContaBancaria;
            ChequePagamento = _ChequePagamento;

            Talonarios = FuncoesTalonario.GetTalonarios(IDContaBancaria);

            ovCMB_Talonario.DataSource = Talonarios;
            ovCMB_Talonario.DisplayMember = "descricao";
            ovCMB_Talonario.ValueMember = "idtalonario";

            PreencherTela();
        }

        private void PreencherTela()
        {
            if (ChequePagamento.Numero != 0)
                ovTXT_Numero.Text = ChequePagamento.Numero.ToString();
            ovTXT_Valor.Value = ChequePagamento.Valor;
            ovCKB_Cruzado.Checked = ChequePagamento.Cruzado == 1;

            ovCMB_Talonario.SelectedItem = null;
            if (ChequePagamento.IDTalonario.HasValue)
                ovCMB_Talonario.SelectedItem = Talonarios.Where(o => o.IDTalonario == ChequePagamento.IDTalonario).FirstOrDefault();

            ovTXT_Emissao.Value = ChequePagamento.Emissao;
            ovTXT_Vencimento.Value = ChequePagamento.Vencimento;

            ovTXT_Compensado.Checked = ChequePagamento.Compensado == 1;
            if (ChequePagamento.DataCompensacao.HasValue)
                ovTXT_Compensado.Value = ChequePagamento.DataCompensacao.Value;

            ovTXT_Devolvido.Checked = ChequePagamento.Devolvido == 1;
            if (ChequePagamento.DataDevolucao.HasValue)
                ovTXT_Devolvido.Value = ChequePagamento.DataDevolucao.Value;

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

                ChequePagamento.Numero = Convert.ToDecimal(SyncUtil.SomenteNumeros(ovTXT_Numero.Text));
                ChequePagamento.Valor = ovTXT_Valor.Value;
                ChequePagamento.Cruzado = ovCKB_Cruzado.Checked ? 1 : 0;

                ChequePagamento.Emissao = ovTXT_Emissao.Value;
                ChequePagamento.Vencimento = ovTXT_Vencimento.Value;

                ChequePagamento.Compensado = ovTXT_Compensado.Checked ? 1 : 0;
                ChequePagamento.DataCompensacao = null;
                if (ChequePagamento.Compensado == 1)
                    ChequePagamento.DataCompensacao = ovTXT_Compensado.Value;

                ChequePagamento.IDTalonario = null;
                if (ovCMB_Talonario.SelectedItem != null)
                    ChequePagamento.IDTalonario = (ovCMB_Talonario.SelectedItem as Talonario).IDTalonario;

                ChequePagamento.Devolvido = ovTXT_Devolvido.Checked ? 1 : 0;
                ChequePagamento.DataDevolucao = null;
                if (ChequePagamento.Devolvido == 1)
                    ChequePagamento.DataDevolucao = ovTXT_Devolvido.Value;

                Salvou = true;
                Close();
            }
            catch (Exception Ex)
            {
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

        private void ovTXT_Numero_TextChanged(object sender, EventArgs e)
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

        private void FCAFIN_ChequePagamento_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ovCMB_Talonario.SelectedIndex = -1;
            ovCMB_Talonario.SelectedItem = null;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FCO_Talonario SeletorTalonario = new FCO_Talonario(true, _IDContaBancaria, true);
            SeletorTalonario.ShowDialog(this);

            if (SeletorTalonario.DRSelected == null)
                return;

            Talonarios = FuncoesTalonario.GetTalonarios(_IDContaBancaria);
            ovCMB_Talonario.DataSource = Talonarios;

            DataRow DrSelecionada = SeletorTalonario.DRSelected;
            ovCMB_Talonario.SelectedItem = Talonarios.Find(x => x.IDTalonario == Convert.ToDecimal(DrSelecionada["IDTALONARIO"]));
        }

        private void ovTXT_Numero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Numero.Text = SyncUtil.SomenteNumeros(ovTXT_Numero.Text);
        }
    }
}
