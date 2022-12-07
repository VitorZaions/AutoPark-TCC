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
    public partial class SeletorMunicipio : MetroForm
    {
        private string NOME_TELA = "Seletor de Município";
        public DataRow DRMunicipio = null;
        private DataTable MUNICIPIOS = null;
        decimal _UF = 0;

        public SeletorMunicipio(decimal UF)
        {
            InitializeComponent();
            _UF = UF;
        }

        private void SeletorMunicipio_Load(object sender, EventArgs e)
        {
            //AtualizaMunicipios((ovTXT_Nome.Text).Trim());
        }

        private void AtualizaMunicipios(string Nome_RazaoSocial)
        {
            MUNICIPIOS = FuncoesMunicipio.GetMunicipiosDescricaoEUf(Nome_RazaoSocial, _UF);
            ovGRD_Municipios.DataSource = null;
            ovGRD_Municipios.DataSource = MUNICIPIOS;
            AjustaTextHeader();
        }

        private void AjustaTextHeader()
        {
            ovGRD_Municipios.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Municipios.Width;
            foreach (DataGridViewColumn column in ovGRD_Municipios.Columns)
            {
                switch (column.Name)
                {
                    case "codigoibge":
                        column.HeaderText = "Código IBGE";
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.30);
                        break;
                    case "descricao":
                        column.HeaderText = "Nome";
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.70);
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }

            if (ovGRD_Municipios.Rows.Count > 0)
            {
                ovGRD_Municipios.ClearSelection();
                // The row whose index is 1 will be selected
                ovGRD_Municipios.Rows[0].Selected = true;
            }

        }


        private void BTN_Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDUNIDADEFEDERATIVA = Convert.ToDecimal(SyncUtil.GetValueFieldDataRowView((ovGRD_Municipios.SelectedRows[0].DataBoundItem as DataRowView), "CODIGOIBGE"));
                DRMunicipio = MUNICIPIOS.AsEnumerable().Where(o => Convert.ToDecimal(o["CODIGOIBGE"]) == IDUNIDADEFEDERATIVA).FirstOrDefault();
                Close();
            }
            catch
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione um Município.", "yellow", false, false);
            }
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            AtualizaMunicipios((ovTXT_Nome.Text).Trim());
        }

        private void ovBTN_LimparFiltros_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ovTXT_Nome.Text = string.Empty;
            ovGRD_Municipios.DataSource = null;
        }

        private void ovTXT_Nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AtualizaMunicipios((ovTXT_Nome.Text).Trim());
            }
        }

        private void BTN_Remover_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SeletorMunicipio_Shown(object sender, EventArgs e)
        {
            ovTXT_Nome.Focus();
        }

        private void ovGRD_Municipios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ovGRD_Municipios.SelectedRows.Count == 1)
            { 
               BTN_Selecionar_Click(sender, e);
            }
        }

    }
}
