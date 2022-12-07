using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls.SyncControls
{
    public partial class SyncMaskedTextBox : UserControl
    {
        private Color _BorderColor = Color.DarkGray;
        private Color _BorderColorSelected = Color.FromArgb(94, 148, 255);

        public event KeyPressEventHandler KeyPress;

        public string Mask
        {
            get { return TextBoxMask.Mask; }
            set { TextBoxMask.Mask = value; }
        }

        public override Color ForeColor
        {
            get { return TextBoxMask.ForeColor; }
            set { TextBoxMask.ForeColor = value; }
        }

        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; panel1.BackColor = value; panel2.BackColor = value; panel3.BackColor = value; panel4.BackColor = value; }
        }

        public Color BorderColorSelected
        {
            get { return _BorderColorSelected; }
            set { _BorderColorSelected = value; if (TextBoxMask.Focused == true) { panel1.BackColor = value; panel2.BackColor = value; panel3.BackColor = value; panel4.BackColor = value; }; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public override string Text
        {
            get { return TextBoxMask.Text; }
            set { TextBoxMask.Text = value; }
        }

        public override Font Font
        {
            get { return TextBoxMask.Font; }
            set { TextBoxMask.Font = value; }
        }

        public char PasswordChar
        {
            get { return TextBoxMask.PasswordChar; }
            set { TextBoxMask.PasswordChar = value; }
        }

        public HorizontalAlignment TextAlign
        {
            get { return TextBoxMask.TextAlign; }
            set { TextBoxMask.TextAlign = value; }
        }

        public MaskFormat TextMaskFormat
        {
            get { return TextBoxMask.TextMaskFormat; }
            set { TextBoxMask.TextMaskFormat = value; }
        }

        public SyncMaskedTextBox()
        {
            InitializeComponent();
            //TextBoxMask.AutoSize = false;


            // Alterações no MaskedTextBox
            TextBoxMask.Leave += delegate (Object sender, EventArgs e)
            {
                panel1.BackColor = _BorderColor;
                panel2.BackColor = _BorderColor;
                panel3.BackColor = _BorderColor;
                panel4.BackColor = _BorderColor;
            };

            TextBoxMask.Enter += delegate (Object sender, EventArgs e)
            {
                panel1.BackColor = _BorderColorSelected; 
                panel2.BackColor = _BorderColorSelected;
                panel3.BackColor = _BorderColorSelected; 
                panel4.BackColor = _BorderColorSelected;
            };

            
            TextBoxMask.MouseEnter += delegate (Object sender, EventArgs e)
            {
                panel1.BackColor = _BorderColorSelected;
                panel2.BackColor = _BorderColorSelected;
                panel3.BackColor = _BorderColorSelected;
                panel4.BackColor = _BorderColorSelected;
            };

            TextBoxMask.MouseLeave += delegate (Object sender, EventArgs e)
            {
                if (TextBoxMask.Focused != true)
                {
                    panel1.BackColor = _BorderColor;
                    panel2.BackColor = _BorderColor;
                    panel3.BackColor = _BorderColor;
                    panel4.BackColor = _BorderColor;
                }
            };

            this.MouseEnter += delegate (Object sender, EventArgs e)
            {
                panel1.BackColor = _BorderColorSelected;
                panel2.BackColor = _BorderColorSelected;
                panel3.BackColor = _BorderColorSelected;
                panel4.BackColor = _BorderColorSelected;
            };

            this.MouseLeave += delegate (Object sender, EventArgs e)
            {
                if (TextBoxMask.Focused != true)
                {
                    panel1.BackColor = _BorderColor;
                    panel2.BackColor = _BorderColor;
                    panel3.BackColor = _BorderColor;
                    panel4.BackColor = _BorderColor;
                }
            };

            this.Click += delegate (Object sender, EventArgs e)
            {
                TextBoxMask.Select();
            };

            TextBoxMask.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);//Default event

        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPress != null)
                KeyPress.Invoke(sender, e);
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void SyncMaskedTextBox_Load(object sender, EventArgs e)
        {

        }

        private void SyncMaskedTextBox_EnabledChanged(object sender, EventArgs e)
        {
            if (base.Enabled == false)
            {
                BackColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                BackColor = Color.White;
            }
        }
    }
}
