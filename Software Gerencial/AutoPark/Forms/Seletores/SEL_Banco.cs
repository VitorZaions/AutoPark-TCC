using AutoController.Funcoes;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.UTIL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Seletores
{
    public partial class SEL_Banco : MetroForm
    {
        private string NOME_TELA = "Seletor de Banco";
        public DataRow DRSelected = null;
        private DataTable BANCOS = null;

        public SEL_Banco()
        {
            InitializeComponent();
        }

        private void SEL_Banco_Load(object sender, EventArgs e)
        {
            //AtualizaBancos((ovTXT_Nome.Text).Trim());
        }
        private void AtualizaBancos(string Nome)
        {
            BANCOS = FuncoesBanco.GetBancosNome(ovTXT_Nome.Text.Trim());
            ovGRD_Bancos.DataSource = null;
            ovGRD_Bancos.DataSource = BANCOS;
            AjustaTextHeader();
        }

        private void AjustaTextHeader()
        {
            ovGRD_Bancos.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Bancos.Width;
            foreach (DataGridViewColumn column in ovGRD_Bancos.Columns)
            {
                switch (column.Name)
                {
                    /*case "codbacen":
                        column.HeaderText = "C.Bacen";
                        column.DisplayIndex = 1;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.25);
                        column.Width = Convert.ToInt32(WidthGrid * 0.25);
                        break;*/
                    case "nome":
                        column.HeaderText = "Nome";
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid);
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }


            if (ovGRD_Bancos.Rows.Count > 0)
            {
                ovGRD_Bancos.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Bancos.Rows[0].Selected = true;
            }

        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            AtualizaBancos((ovTXT_Nome.Text).Trim());
        }

        private void ovTXT_Nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizaBancos((ovTXT_Nome.Text).Trim());
            }
        }

        private void ovBTN_LimparFiltros_Click(object sender, EventArgs e)
        {
            ovTXT_Nome.Text = null;
            AtualizaBancos((ovTXT_Nome.Text).Trim());
        }

        private void Limpar()
        {
            ovTXT_Nome.Text = string.Empty;
            ovGRD_Bancos.DataSource = null;
        }

        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDBANCO = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Bancos.SelectedRows[0].DataBoundItem as DataRowView), "CODBACEN"));
                DRSelected = BANCOS.AsEnumerable().Where(o => Convert.ToDecimal(o["CODBACEN"]) == IDBANCO).FirstOrDefault();
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Banco.", "yellow", false, false);
            }
        }

        private void BTN_Remover_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SEL_Banco_Shown(object sender, EventArgs e)
        {
            ovTXT_Nome.Focus();
        }

        private void ovGRD_Bancos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Bancos.SelectedRows.Count == 1)
            {
                BTN_Selecionar_Click(sender, e);
            }
        }
    }
}
