using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoPark.Forms.Cadastro;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Consultas
{
    public partial class FCO_FormaDePagamento : MetroForm
    {
        private string NOME_TELA = "Consulta de forma de pagamento";
        public FCO_FormaDePagamento(bool IsSelect)
        {
            InitializeComponent();
            if (IsSelect)
            {
                BTN_Selecionar.Visible = true;
                //BTN_Novo.Visible = false;
                BTN_Remover.Visible = false;
                BTN_Editar.Visible = false;
            }
        }

        private void AtualizaFormasPagamento(string Codigo, string Descricao)
        {
            ovGRD_FormaPagamento.DataSource = null;
            ovGRD_FormaPagamento.DataSource = FuncoesFormaDePagamento.GetFormasDePagamento(Codigo, Descricao);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_FormaPagamento.RowHeadersVisible = false;
            int WidthGrid = ovGRD_FormaPagamento.Width;
            foreach (DataGridViewColumn column in ovGRD_FormaPagamento.Columns)
            {
                switch (column.Name)
                {
                    /*
                     DESCRICAO
                     DESCRICAO AS BANDEIRACARTAO
                     IDENTIFICACAO
                     ATIVO
                     IDBANDEIRACARTAO      
                     */
                    case "idformadepagamento":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.13);
                        column.HeaderText = "Código";
                        break;
                    case "bandeiracartao":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "Bandeira";
                        break;
                    case "descricaotipopagamento":
                        column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "Tipo";
                        break;
                    case "identificacao":
                        column.DisplayIndex = 4;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.36);
                        column.HeaderText = "Identificação";
                        break;
                    case "ativo":
                        column.DisplayIndex = 5;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.11);
                        column.HeaderText = "Ativo";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_FormaPagamento.Rows.Count > 0)
            {
                ovGRD_FormaPagamento.Rows[0].Selected = true;
            }

        }

        private void ovBTN_LimparFiltros_Click(object sender, System.EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ovTXT_Codigo.Focus();
            ovTXT_Codigo.Text = string.Empty;
            ovTXT_Descricao.Text = string.Empty;
            ovGRD_FormaPagamento.DataSource = null;
        }

        private void ovBTN_Pesquisar_Click(object sender, System.EventArgs e)
        {
            AtualizaFormasPagamento(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
        }

        private void ovBTN_Novo_Click(object sender, System.EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 9) != null)
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
                FCA_FormaDePagamento t = new FCA_FormaDePagamento(new FormaDePagamento());
                t.ShowDialog(this);
                AtualizaFormasPagamento(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }
        }

        private void ovBTN_Editar_Click_1(object sender, EventArgs e)
        {

        }

        private void ovBTN_Excluir_Click(object sender, System.EventArgs e)
        {
            if (this.ovGRD_FormaPagamento.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover a Forma de Pagamento selecionada?", "yellow", true, false) == DialogResult.OK)
                {
                    decimal IDFormaDePagamento = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_FormaPagamento.SelectedRows[0].DataBoundItem as DataRowView), "IDFORMADEPAGAMENTO"));
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesFormaDePagamento.Remover(IDFormaDePagamento))
                            throw new Exception("Não foi possível remover a Forma de Pagamento.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        if (Ex.Message.Contains("formadepagamento_idbandeiracartao_fkey"))
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, "Forma de Pagamento vinculada a Baixa de Pagamento, não será possível remover o registro.", "red", false, false);
                        }
                        else if (Ex.Message.Contains("baixarecebimento_idformadepagamento_fkey"))
                        {
                           SyncMessager.CreateMessage(0,NOME_TELA, "Forma de Pagamento vinculada a Baixa de Recebimento, não será possível remover o registro.", "red", false, false);
                        }
                        else if (Ex.Message.Contains("contacobranca_idformadepagamento_fkey"))
                        {
                           SyncMessager.CreateMessage(0,NOME_TELA, "Forma de Pagamento vinculada a Conta de Cobrança, não será possível remover o registro.", "red", false, false);
                        }
                        else if (Ex.Message.Contains("contapagar_idformadepagamento_fkey"))
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, "Forma de Pagamento vinculada a Conta a Pagar, não será possível remover o registro.", "red", false, false);
                        }
                        else if (Ex.Message.Contains("contareceber_idformadepagamento_fkey"))
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, "Forma de Pagamento vinculada a Conta a Receber, não será possível remover o registro.", "red", false, false);
                        }
                        else if (Ex.Message.Contains("itemvendapagamento_idformadepagamento_fkey"))
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, "Forma de Pagamento vinculada a Item de Venda, não será possível remover o registro.", "red", false, false);
                        }
                        else if (Ex.Message.Contains("nfe_idformadepagamento_fkey"))
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, "Forma de Pagamento vinculada a NFE, não será possível remover o registro.", "red", false, false);
                        }
                        else if (Ex.Message.Contains("pedidocompra_idformadepagamento_fkey"))
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, "Forma de Pagamento vinculada a NFE, não será possível remover o registro.", "red", false, false);
                        }
                        else if (Ex.Message.Contains("orcamento_idformadepagamento_fkey"))
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, "Forma de Pagamento vinculada ao Orçamento, não será possível remover o registro.", "red", false, false);
                        }
                        else
                        {
                            SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
                        }
                        return;
                    }
                    AtualizaFormasPagamento(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione a forma de pagamento que deseja remover.", "red", false, false);
            }
        }

        private void FCO_FormaDePagamento_Load(object sender, EventArgs e)
        {

        }

        private void ovTXT_Codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizaFormasPagamento(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
            }
        }

        private void ovTXT_Descricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizaFormasPagamento(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
            }
        }

        private void FCO_FormaDePagamento_Shown(object sender, EventArgs e)
        {
            Limpar();
        }

        private void FCO_FormaDePagamento_Load_1(object sender, EventArgs e)
        {

        }
        private void ovGRD_FormaPagamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_FormaPagamento.SelectedRows.Count == 1)
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

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {

        }

        private void BTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ovGRD_FormaPagamento.SelectedRows.Count == 1)
                {
                    decimal IDFormaDePagamento = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_FormaPagamento.SelectedRows[0].DataBoundItem as DataRowView), "IDFORMADEPAGAMENTO"));
                    FCA_FormaDePagamento t = new FCA_FormaDePagamento(FuncoesFormaDePagamento.GetFormaDePagamento(IDFormaDePagamento));
                    t.ShowDialog(this);
                    AtualizaFormasPagamento(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a forma de pagamento que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void ovTXT_Codigo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Codigo.Text = SyncUtil.SomenteNumeros(ovTXT_Codigo.Text);
        }
    }
}
