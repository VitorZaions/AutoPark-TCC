
namespace AutoPark.Forms.Configuracoes
{
    partial class FCONFIG_Geral
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCONFIG_Geral));
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.GeralTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ovTXT_Valor = new CustomControls.SyncControls.EditDecimalGuna2();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TabControl1.SuspendLayout();
            this.GeralTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.GeralTab);
            this.guna2TabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(110, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(27, 73);
            this.guna2TabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(996, 614);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.Gray;
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.DarkGray;
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(110, 40);
            this.guna2TabControl1.TabIndex = 7;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // GeralTab
            // 
            this.GeralTab.BackColor = System.Drawing.Color.White;
            this.GeralTab.Controls.Add(this.groupBox1);
            this.GeralTab.Location = new System.Drawing.Point(4, 44);
            this.GeralTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GeralTab.Name = "GeralTab";
            this.GeralTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GeralTab.Size = new System.Drawing.Size(988, 566);
            this.GeralTab.TabIndex = 0;
            this.GeralTab.Text = "Geral";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ovTXT_Valor);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(962, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Financeiro";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Gray;
            this.panel11.Controls.Add(this.label27);
            this.panel11.Location = new System.Drawing.Point(22, 53);
            this.panel11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(35, 33);
            this.panel11.TabIndex = 201;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(2, 5);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 21);
            this.label27.TabIndex = 0;
            this.label27.Text = "R$";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(22, 30);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 17);
            this.label12.TabIndex = 200;
            this.label12.Text = "* Valor P/Hora:";
            // 
            // ovTXT_Valor
            // 
            this.ovTXT_Valor.BackColor = System.Drawing.Color.Transparent;
            this.ovTXT_Valor.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Valor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_Valor.DecimalPlaces = 2;
            this.ovTXT_Valor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Valor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Valor.Location = new System.Drawing.Point(55, 53);
            this.ovTXT_Valor.Margin = new System.Windows.Forms.Padding(5);
            this.ovTXT_Valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            131072});
            this.ovTXT_Valor.Name = "ovTXT_Valor";
            this.ovTXT_Valor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ovTXT_Valor.Size = new System.Drawing.Size(220, 33);
            this.ovTXT_Valor.TabIndex = 199;
            this.ovTXT_Valor.ThousandsSeparator = true;
            this.ovTXT_Valor.UpDownButtonFillColor = System.Drawing.Color.Gray;
            this.ovTXT_Valor.UpDownButtonForeColor = System.Drawing.Color.LightGray;
            // 
            // BTN_Cancelar
            // 
            this.BTN_Cancelar.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Cancelar.BorderThickness = 1;
            this.BTN_Cancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Cancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Cancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Cancelar.Image = global::AutoPark.Properties.Resources.button_remove;
            this.BTN_Cancelar.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_Cancelar.IndicateFocus = true;
            this.BTN_Cancelar.Location = new System.Drawing.Point(662, 695);
            this.BTN_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Cancelar.TabIndex = 1;
            this.BTN_Cancelar.Text = "Cancelar";
            this.BTN_Cancelar.Click += new System.EventHandler(this.BTN_Cancelar_Click);
            // 
            // BTN_Salvar
            // 
            this.BTN_Salvar.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Salvar.BorderThickness = 1;
            this.BTN_Salvar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Salvar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Salvar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Salvar.Image = global::AutoPark.Properties.Resources.button_save1;
            this.BTN_Salvar.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_Salvar.IndicateFocus = true;
            this.BTN_Salvar.Location = new System.Drawing.Point(844, 695);
            this.BTN_Salvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Salvar.TabIndex = 2;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.BTN_Salvar_Click);
            // 
            // FCONFIG_Geral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 762);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.guna2TabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FCONFIG_Geral";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Configurações Gerais";
            this.Load += new System.EventHandler(this.FCONFIG_Geral_Load);
            this.guna2TabControl1.ResumeLayout(false);
            this.GeralTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage GeralTab;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private System.Windows.Forms.GroupBox groupBox1;
        private Panel panel11;
        private Label label27;
        private Label label12;
        public CustomControls.SyncControls.EditDecimalGuna2 ovTXT_Valor;
    }
}