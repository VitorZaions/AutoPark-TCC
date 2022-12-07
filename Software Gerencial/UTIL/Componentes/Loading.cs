using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace LoadingScreen
{
    public partial class Loading : MetroForm
    {
        private bool finished = false;
        public Loading(string info)
        {
            InitializeComponent();
            Info_Loading.Text = info;
        }

        public void Finish()
        {
            finished = true;
        }

        private void Loading_Load(object sender, EventArgs e)
        {
        }
        private void Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finished == false)
            {
                e.Cancel = true;
            }
        }

        private void Loading_Shown(object sender, EventArgs e)
        {
            Activate();
        }
    }
}
