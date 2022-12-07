using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CustomControls.SyncControls
{

    [DefaultEvent("TextChange")]
    public partial class SyncTextBox : UserControl
    {
        #region -> Fields
        //Fields
        private Color borderColor = Color.DarkGray;
        private Color borderFocusColor = Color.DodgerBlue;
        private int borderSize = 1;
        private bool underlinedStyle = true;
        private bool isFocused = false;

        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;
        private Panel Painel = new Panel();
        private Panel PainelEsquerda = new Panel();
        private Panel PainelTopo = new Panel();
        private Panel PainelDireita = new Panel();


        //Events
        public event EventHandler TextChange;

        #endregion

        //-> Constructor
        public SyncTextBox()
        {
            //Created by designer
            InitializeComponent();
            
            Painel.BackColor = borderColor;
            PainelEsquerda.BackColor = borderColor;
            PainelDireita.BackColor = borderColor;
            PainelTopo.BackColor = borderColor;

            this.Controls.Add(PainelEsquerda);
            this.Controls.Add(PainelDireita);
            this.Controls.Add(PainelTopo);
            this.Controls.Add(Painel);
            Painel.BringToFront();
            
            this.Resize += delegate (Object sender, EventArgs e)
            {
                DrawPanels();
            };

           this.EnabledChanged += EnabledChangedStatus;
           this.Validating += textBox1_Validating;
        }

        private void DrawPanels()
        {
            Painel.Size = new Size(base.Width, 1);
            Painel.Location = new Point(0, base.Height - 1);

            PainelEsquerda.Size = new Size(1, base.Height);
            PainelEsquerda.Location = new Point(0, 0);

            PainelDireita.Size = new Size(base.Width - 1, base.Height);
            PainelDireita.Location = new Point(base.Width - 1, 0);

            PainelTopo.Size = new Size(base.Width, 1);
            PainelTopo.Location = new Point(0, 0);
        }

        #region -> Properties
        [Category("SyncTextBox")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("SyncTextBox")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        [Category("SyncTextBox")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value >= 1)
                {
                    borderSize = value;
                    this.Invalidate();
                }
            }
        }

        [Category("SyncTextBox")]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set
            {
                isPasswordChar = value;
                if (!isPlaceholder)
                    textBox1.UseSystemPasswordChar = value;
            }
        }

        [Category("SyncTextBox")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("SyncTextBox")]
        public bool ReadOnly
        {
            get { return textBox1.ReadOnly; }
            set { textBox1.ReadOnly = value; }
        }

        [Category("SyncTextBox")]
        public override Color BackColor
        {
            get { return textBox1.BackColor; }
            set
            {               
                textBox1.BackColor = value;
            }
        }

        [Category("SyncTextBox")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("SyncTextBox")]
        public int MaxLength
        {
            get { return textBox1.MaxLength; }
            set
            {
                textBox1.MaxLength = value;
            }
        }

        [Category("SyncTextBox")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Browsable(true)]
        [Category("SyncTextBox")]
        public override string Text
        {
            get
            {
                if (isPlaceholder) return "";
                else return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }

        [Category("SyncTextBox")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();//Redraw control
                }
            }
        }

        [Category("SyncTextBox")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    textBox1.ForeColor = value;
            }
        }

        [Category("SyncTextBox")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                textBox1.Text = "";
                SetPlaceholder();
            }
        }

        [Category("SyncTextBox")]
        public HorizontalAlignment TextAlign
        {
            get { return textBox1.TextAlign; }
            set
            {
                textBox1.TextAlign = value;
            }
        }

        [Category("SyncTextBox")]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return textBox1.AutoCompleteCustomSource; }
            set
            {
                textBox1.AutoCompleteCustomSource = value;
            }
        }

        [Category("SyncTextBox")]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return textBox1.AutoCompleteMode; }
            set
            {
                textBox1.AutoCompleteMode = value;
            }
        }

        [Category("SyncTextBox")]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return textBox1.AutoCompleteSource; }
            set
            {
                textBox1.AutoCompleteSource = value;
            }
        }


        #endregion

        #region -> Overridden methods
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();



            textBox1?.Invoke((MethodInvoker)(() =>
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            }));

        }
        #endregion

        #region -> Private methods
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = false;
            }
            else // Else adicionado porque ao dar load com um texto na opção 'Text' deve fazer as alterações abaixo.
            {
                isPlaceholder = false;
                textBox1.ForeColor = ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }
        private void RemovePlaceholder()
        {
            
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }        
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathTxt);
            }
            pathTxt.Dispose();
        }
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }
        #endregion

        #region -> TextBox events

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextChange != null)
                this.TextChange.Invoke(sender,e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
            isFocused = true;
            Painel.BackColor = borderFocusColor;
            PainelEsquerda.BackColor = borderFocusColor;
            PainelDireita.BackColor = borderFocusColor;
            PainelTopo.BackColor = borderFocusColor;
            RemovePlaceholder();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            Painel.BackColor = borderColor;
            PainelEsquerda.BackColor = borderColor;
            PainelDireita.BackColor = borderColor;
            PainelTopo.BackColor = borderColor;
            SetPlaceholder();
        }

        private void EnabledChangedStatus(object sender, EventArgs e)
        {
            if (this.Enabled == false)
            {
                textBox1.Enabled = false;
                this.BackColor = Color.FromArgb(240, 240, 240);
                textBox1.ScrollBars = ScrollBars.None;
                this.Invalidate(); // Redesenha o TextBox na tela.
            }
            else
            {
                textBox1.Enabled = true;
                this.BackColor = Color.White;
                textBox1.ScrollBars = ScrollBars.Vertical;
                this.Invalidate(); // Redesenha o TextBox na tela.
            }
        }
        #endregion

        private void SyncTextBox_Load(object sender, EventArgs e)
        {
            DrawPanels();
        }
    }
}
