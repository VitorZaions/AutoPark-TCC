using AutoController.Funcoes;
using AutoDAO.Entidades;
using MetroFramework.Forms;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Relatorios
{
    public partial class REL_Saida : MetroForm
    {
        public REL_Saida()
        {
            InitializeComponent();
        }

        private void REL_Entrada_Load(object sender, EventArgs e)
        {

        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {

            LoadingCall LoadingScreen = new LoadingCall("Gerando Relatório..");
            bool IsLoadingScreen = false;

            try
            {
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                var r = new FastReport.Report();

                List<RelatorioSaida> Saidas = new AutoDAO.Custom.DataTableParser<RelatorioSaida>().ParseDataTable(FuncoesSaida.GetSaidas(string.IsNullOrWhiteSpace(ovTXT_Codigo.Text) ? null : Convert.ToDecimal(ovTXT_Codigo.Text), ovTXT_Cliente.Text, ovTXT_Placa.Text, ovTXT_VencimentoInicio.Value, ovTXT_VencimentoFim.Value, ovCKB_Normal.Checked, ovCKB_OCR.Checked));
                /*r.Dictionary.RegisterBusinessObject(Entradas, "Entrada", 10, true);
                r.Save("C:/Users/vitor/Desktop/Entrada.frx");*/
                r.Report.Load(Contexto.CaminhoSolution + "Relatorios/Saidas.frx");
                r.Dictionary.RegisterBusinessObject(Saidas, "Saidas", 10, true);
                r.Prepare();
                FastReport.Export.PdfSimple.PDFSimpleExport pdf = new FastReport.Export.PdfSimple.PDFSimpleExport();
                using MemoryStream ms = new MemoryStream();
                pdf.Export(r, ms);
                ms.Flush();

                ms.Seek(0, SeekOrigin.Begin);

                var Hoje = DateTime.Now;
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\RelatorioSaida{Hoje.Day}.{Hoje.Month}.{Hoje.Year}.{Hoje.Hour}.{Hoje.Minute}.{Hoje.Second}.pdf";
                var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                ms.CopyTo(fileStream);
                fileStream.Dispose();

                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                Process proc = new Process();
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.FileName = path;
                proc.Start();
            }
            catch(Exception Ex)
            {
                SyncMessager.CreateMessage(0, "Relatório de Saída", "Não foi possível gerar o relatório." + Ex.Message, "red", false, false);
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();
            }

            // var pdfviewer = new PDFSimpleExport();
        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
