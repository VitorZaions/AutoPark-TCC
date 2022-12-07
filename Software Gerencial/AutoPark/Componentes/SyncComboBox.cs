using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Design;

namespace CustomControls.SyncControls
{
    [DefaultEvent("SelectedIndexChanged")]
    public class SyncComboBox : UserControl
    {        
        //Cor da borda ao selecionar
        private Color _BorderColorSelected = Color.FromArgb(94, 148, 255);

        //Fields
        private Color DisabledBackColor = Color.FromArgb(240, 240, 240);

        private Color backColor = Color.White;
        private Color OnHoverColor = Color.FromArgb(217,217,217);
        private Color iconColor = Color.FromArgb(64, 64, 64);
        private Color listBackColor = Color.White;
        private Color listTextColor = SystemColors.ControlText;
        private Color borderColor = Color.DarkGray;
        private int borderSize = 1;

        //Items
        private ComboBox cmbList;
        private Label lblText;
        private Guna.UI2.WinForms.Guna2Button btnIcon;

        //Events
        public event EventHandler SelectedIndexChanged;//Default event
        public event EventHandler SelectedValueChanged;
        public event EventHandler SelectionChangeCommitted;
        public event EventHandler DropDown;

        //Constructor
        public SyncComboBox()
        {
            base.Font = new Font("Segoe UI", 9.75F);
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();

            //ComboBox: Dropdown list
            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(this.Font.Name, 9.75F);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);//Default event
            cmbList.SelectedValueChanged += new EventHandler(ComboBox_SelectedValueChanged);//Default event
            cmbList.SelectionChangeCommitted += new EventHandler(ComboBox_SelectionChangeCommitted);//Default event
            cmbList.DropDown += new EventHandler(ComboBox_DropDown);//Default event
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);//Refresh text
            cmbList.TabStop = false;
            cmbList.DropDownClosed += new EventHandler(ComboBox_DroppedClose);//Default event;  

            //Button: Icon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FillColor = backColor;  
            btnIcon.DisabledState.FillColor = Color.FromArgb(240, 240, 240);
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);//Open dropdown list
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);//Draw icon
            btnIcon.TabStop = false;
   


            //Label: Text
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;            
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.TopLeft;
            lblText.Cursor = Cursors.Default;
            //lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 6, 0, 0);
            lblText.Font = new Font(this.Font.Name, 9.75F);
            //->Attach label events to user control event
            lblText.Click += new EventHandler(Surface_Click);//Select combo box
            lblText.MouseEnter += new EventHandler(Surface_MouseEnter);
            lblText.MouseLeave += new EventHandler(Surface_MouseLeave);
            lblText.Click += new EventHandler(Icon_Click);//Open dropdown list
            lblText.TabStop = false;
            lblText.Size = new Size(200,30);
            lblText.Location = new Point(1,1);

            //User Control
            this.Controls.Add(lblText);//2
            this.Controls.Add(btnIcon);//1
            this.Controls.Add(cmbList);//0
            //this.MinimumSize = new Size(200, 31);
            this.Size = new Size(200, 31);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);//Border Size
            this.Font = new Font(this.Font.Name, 9.75F);
            base.BackColor = borderColor; //Border Color
            this.ResumeLayout();
            AdjustComboBoxDimensions();
                       
            // Efeitos na Borda

            // Alterações no MaskedTextBox
            // Alterações no MaskedTextBox
            this.Leave += delegate (Object sender, EventArgs e)
            {
                base.BackColor = borderColor;
            };

            this.Enter += delegate (Object sender, EventArgs e)
            {
                base.BackColor = _BorderColorSelected;
            };


            this.MouseEnter += delegate (Object sender, EventArgs e)
            {
                base.BackColor = _BorderColorSelected;
            };

            
            this.MouseLeave += delegate (Object sender, EventArgs e)
            {
                if (this.Focused != true && cmbList.Focused != true && btnIcon.Focused != true)
                {
                    base.BackColor = borderColor;
                }
            };

            this.EnabledChanged += new System.EventHandler(this.SyncCB_EnabledChanged);
        }

        //Properties
        //-> Appearance
        [Category("Sync Sistemas - Appearance")]
        public new Color BackColor
        {
            get { return backColor; }
            set
            {
                backColor = value;
                btnIcon.FillColor = backColor;
            }
        }

        public new Color OnHoverButtonColor
        {
            get { return OnHoverColor; }
            set
            {
                OnHoverColor = value;
                btnIcon.FillColor = backColor;
                //  btnIcon.BackColor BackColor = backColor;
            }
        }


        [Category("Sync Sistemas - Appearance")]
        public Color IconColor
        {
            get { return iconColor; }
            set
            {
                iconColor = value;
                btnIcon.Invalidate();//Redraw icon
            }
        }

        public bool DroppedDown
        {
            get { return cmbList.DroppedDown; }
            set
            {
                cmbList.DroppedDown = value;
            }
        }

        [Category("Sync Sistemas - Appearance")]
        public Color ListBackColor
        {
            get { return listBackColor; }
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }

        [Category("Sync Sistemas - Appearance")]
        public Color ListTextColor
        {
            get { return listTextColor; }
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }

        [Category("Sync Sistemas - Appearance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                base.BackColor = borderColor; //Border Color
            }
        }

        [Category("Sync Sistemas - Appearance")]
        public Color BorderColorSelected
        {
            get { return _BorderColorSelected; }
            set {
                _BorderColorSelected = value; 
                if (this.Focused == true) { 
                    base.BackColor = value; 
                }; 
            }
        }

        [Category("Sync Sistemas - Appearance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize);//Border Size
                AdjustComboBoxDimensions();
            }
        }

        [Category("Sync Sistemas - Appearance")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                lblText.ForeColor = value;
            }
        }
        [Category("Sync Sistemas - Appearance")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                lblText.Font = value;
                cmbList.Font = value;//Optional
            }
        }

        [Category("Sync Sistemas - Appearance")]
        public override string Text
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        [Category("Sync Sistemas - Appearance")]
        public ComboBoxStyle DropDownStyle
        {
            get { return cmbList.DropDownStyle; }
            set
            {
                if (cmbList.DropDownStyle != ComboBoxStyle.Simple)
                    cmbList.DropDownStyle = value;
            }
        }


        [Category("Sync Sistemas - Appearance")]
        public int DropDownHeight
        {
            get { return cmbList.DropDownHeight; }
            set
            {
                    cmbList.DropDownHeight = value;
            }
        }

        //Properties
        //-> Data
        [Category("Sync Sistemas - Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get { return cmbList.Items; }
        }

        [Category("Sync Sistemas - Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get { return cmbList.DataSource; }
            set { cmbList.DataSource = value; }
        }

        [Category("Sync Sistemas - Data")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return cmbList.AutoCompleteCustomSource; }
            set { cmbList.AutoCompleteCustomSource = value; }
        }

        [Category("Sync Sistemas - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return cmbList.AutoCompleteSource; }
            set { cmbList.AutoCompleteSource = value; }
        }

        [Category("Sync Sistemas - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return cmbList.AutoCompleteMode; }
            set { cmbList.AutoCompleteMode = value; }
        }

        [Category("Sync Sistemas - Data")]
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get { return cmbList.SelectedItem; }
            set { cmbList.SelectedItem = value; }
        }

        [Category("Sync Sistemas - Data")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return cmbList.SelectedIndex; }
            set { cmbList.SelectedIndex = value; }
        }

        [Category("Sync Sistemas - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get { return cmbList.DisplayMember; }
            set { cmbList.DisplayMember = value; }
        }

        [Category("Sync Sistemas - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get { return cmbList.ValueMember; }
            set { cmbList.ValueMember = value; }
        }

        //Private methods
        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = this.Width -2;
            cmbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmbList.Width,
                Y = lblText.Bottom - cmbList.Height
            };
        }

        //Event methods

        //-> Default event
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged.Invoke(sender, e);

            //Refresh text
            lblText.Text = cmbList.Text;
        }


 
        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (SelectionChangeCommitted != null)
                SelectionChangeCommitted.Invoke(sender, e);
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SelectedValueChanged != null)
                SelectedValueChanged.Invoke(sender, e);

            //Refresh text
            lblText.Text = cmbList.Text;
        }

        private void ComboBox_DroppedClose(object sender, EventArgs e)
        {
            btnIcon.Refresh();
        }

        private void ComboBox_DropDown(object sender, EventArgs e)
        {
            if (DropDown != null)
                DropDown.Invoke(sender, e);
        }

        //-> Draw icon
        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            //Fields
            int iconWidht = 10;
            int iconHeight = 4;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidht) / 2, (btnIcon.Height - iconHeight) / 2, iconWidht, iconHeight);
            Graphics graph = e.Graphics;

            //Draw arrow down icon
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidht / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidht / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graph.DrawPath(pen, path);
            }
        }

        //-> Items actions
        private void Icon_Click(object sender, EventArgs e)
        {
            //Open dropdown list
            cmbList.Select();
            cmbList.DroppedDown = true;
        }
        private void Surface_Click(object sender, EventArgs e)
        {
            //Attach label click to user control click
            this.OnClick(e);
            //Select combo box
            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
                cmbList.DroppedDown = true;//Open dropdown list
        }
        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            //Refresh text
            //lblText.MaximumSize = new Size(lblText.Width, lblText.Height);
            lblText.Text = cmbList.Text;
            //lblText.Text = cmbList.Controls[2].Text;
        }

        //->Attach label events to user control event
        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }
        //::::+

        //Overridden methods
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }

        private void SyncCB_EnabledChanged(object sender, EventArgs e)
        {
            if (base.Enabled == false)
            {
                lblText.BackColor = DisabledBackColor;
            }
            else
            {
                lblText.BackColor = backColor;
                btnIcon.FillColor = backColor;
            }
        }

    }
}
