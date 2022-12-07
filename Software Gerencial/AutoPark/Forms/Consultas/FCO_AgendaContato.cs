using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoPark.Forms.Cadastro;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Consultas
{
    public partial class FCO_AgendaContato : MetroForm
    {
        private string NOME_TELA = "Consulta de Contatos";
        public DataRow DRSelected = null;
        public FCO_AgendaContato(bool IsSelect)
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

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_Contatos.SelectedRows[0].DataBoundItem == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Contato.", "yellow", false, false);
                    return;
                }

                DRSelected = (ovGRD_Contatos.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (DRSelected == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Contato.", "yellow", false, false);
                    return;
                }
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Não foi possível selecionar um Contato.", "red", false, false);
            }
        }

        private void BTN_Novo_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 11) != null)
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
                FCA_AgendaContato t = new FCA_AgendaContato(new AgendaContato());
                t.ShowDialog(this);
                AttContatos();
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }
        }

        private void BTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ovGRD_Contatos.SelectedRows.Count == 1)
                {
                    decimal IDAgendaContato = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contatos.SelectedRows[0].DataBoundItem as DataRowView), "IDCONTATO"));
                    FCA_AgendaContato t = new FCA_AgendaContato(FuncoesAgendaContato.GetAgendaContato(IDAgendaContato));
                    t.ShowDialog(this);
                    AttContatos();
                }
                else
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Contato que deseja editar.", "red", false, false);
                }
            }
            catch (Exception Ex)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Não foi Possível Editar." + Ex.Message, "red", false, false);
            }
        }

        private void BTN_Remover_Click(object sender, EventArgs e)
        {
            if (this.ovGRD_Contatos.SelectedRows.Count == 1)
            {
                if (SyncMessager.CreateMessage(0,NOME_TELA, "Deseja remover o Contato selecionado?", "yellow", true, false) == DialogResult.OK)
                {
                    decimal IDAgendaContato = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Contatos.SelectedRows[0].DataBoundItem as DataRowView), "IDCONTATO"));
                    try
                    {
                        PDVControlador.BeginTransaction();
                        if (!FuncoesAgendaContato.Remover(IDAgendaContato))
                            throw new Exception("Não foi possível remover o Contato.");
                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        PDVControlador.Rollback();
                        SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
                        return;
                    }
                    AttContatos();
                }
            }
            else
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione o Contato que deseja remover.", "red", false, false);
            }
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            AttContatos();
        }

        private void AttContatos()
        {
            ovGRD_Contatos.DataSource = null;
            ovGRD_Contatos.DataSource = FuncoesAgendaContato.GetAgendaContatos(ovTXT_Nome.Text);
            AjustaHeaderTextGrid();
        }


        private void AjustaHeaderTextGrid()
        {
            int WidthGrid = ovGRD_Contatos.Width;
            foreach (DataGridViewColumn column in ovGRD_Contatos.Columns)
            {
                switch (column.Name)
                {
                    case "nome":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.34);
                        column.HeaderText = "Nome";
                        break;
                    case "celular":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.18);
                        column.HeaderText = "Celular";
                        break;
                    case "telefone":
                        column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.18);
                        column.HeaderText = "Telefone";
                        break;
                    case "email":
                        column.DisplayIndex = 4;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.30);
                        column.HeaderText = "E-mail";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
        }

        private void ovBTN_LimparFiltros_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ovTXT_Nome.Focus();
            ovTXT_Nome.Text = string.Empty;
            ovGRD_Contatos.DataSource = null;
        }

        private void FCO_AgendaContato_Shown(object sender, EventArgs e)
        {
            Limpar();
        }

        private void ovTXT_Nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AttContatos();
            }
        }

        private void FCO_AgendaContato_Load(object sender, EventArgs e)
        {

        }

        private void ovGRD_Contatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Contatos.SelectedRows.Count == 1)
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
    }
}
