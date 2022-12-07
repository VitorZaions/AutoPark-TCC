using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControls.SyncControls
{
    public class EditDecimalGuna2 :  Guna.UI2.WinForms.Guna2NumericUpDown
    {
        private Label mLabel;
        private TextBox mBox;

        public EditDecimalGuna2()
        {
            // Remove a adição pelo scroll, controle 1 é do label do numeric.
            Controls[1].MouseWheel += Ctl_MouseWheel;            
            Controls[0].TabStop = false;               

            this.Leave += delegate (Object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(this.Text))
                {
                    this.Value = this.Minimum;
                    this.Text = "0";
                }
                else
                {
                    this.Value = Convert.ToDecimal(Math.Round(Convert.ToDouble(this.Value), this.DecimalPlaces)); // Suporta somente números positivos.
                }
            };

            ThousandsSeparator = true;
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
        }

        private void Ctl_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;           
        }


    }
}
