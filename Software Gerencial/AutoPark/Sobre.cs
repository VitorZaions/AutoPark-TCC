using MetroFramework.Forms;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;
using Utils;

namespace AutoPark
{
    public partial class Sobre : MetroForm
    {
        public Sobre()
        {
            InitializeComponent();
            ovTXT_Versao.Text = Contexto.VERSAO.ToString();
            //ovTXT_Footer.Text = string.Format("Copyright ©  {0} - Todos os Direitos Reservados Sync Sistemas - Soluções em TI", DateTime.Now.Year);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    if (SyncMessager.CreateMessage(0, "Sobre", "Deseja sair?", "yellow", true, false) == DialogResult.OK)
                    {
                        Close();
                    }
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.syncsistemas.com.br");
        }

        private void Sobre_Load(object sender, EventArgs e)
        {

        }
    }
}
