
namespace AutoPark.Forms.Configuracoes
{
    partial class FCONFIG_CancelaGeral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCONFIG_CancelaGeral));
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.NUMERIC_Tempo = new CustomControls.SyncControls.EditDecimalGuna2();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUMERIC_Tempo)).BeginInit();
            this.SuspendLayout();
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
            this.BTN_Cancelar.Location = new System.Drawing.Point(154, 204);
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
            this.BTN_Salvar.Location = new System.Drawing.Point(336, 204);
            this.BTN_Salvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Salvar.TabIndex = 2;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.BTN_Salvar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.panel6);
            this.groupBox3.Controls.Add(this.NUMERIC_Tempo);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(27, 72);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(484, 103);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fechamento";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AutoPark.Properties.Resources.button_info;
            this.pictureBox1.Location = new System.Drawing.Point(83, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 224;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gray;
            this.panel6.Controls.Add(this.label24);
            this.panel6.Location = new System.Drawing.Point(18, 51);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(35, 33);
            this.panel6.TabIndex = 223;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(2, 5);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(24, 21);
            this.label24.TabIndex = 0;
            this.label24.Text = "**";
            // 
            // NUMERIC_Tempo
            // 
            this.NUMERIC_Tempo.BackColor = System.Drawing.Color.Transparent;
            this.NUMERIC_Tempo.BorderColor = System.Drawing.Color.DarkGray;
            this.NUMERIC_Tempo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NUMERIC_Tempo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.NUMERIC_Tempo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.NUMERIC_Tempo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NUMERIC_Tempo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NUMERIC_Tempo.Location = new System.Drawing.Point(51, 51);
            this.NUMERIC_Tempo.Margin = new System.Windows.Forms.Padding(5);
            this.NUMERIC_Tempo.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.NUMERIC_Tempo.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUMERIC_Tempo.Name = "NUMERIC_Tempo";
            this.NUMERIC_Tempo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NUMERIC_Tempo.Size = new System.Drawing.Size(264, 33);
            this.NUMERIC_Tempo.TabIndex = 0;
            this.NUMERIC_Tempo.ThousandsSeparator = true;
            this.NUMERIC_Tempo.UpDownButtonFillColor = System.Drawing.Color.Gray;
            this.NUMERIC_Tempo.UpDownButtonForeColor = System.Drawing.Color.LightGray;
            this.NUMERIC_Tempo.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(15, 28);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 17);
            this.label19.TabIndex = 33;
            this.label19.Text = "Tempo (S):";
            // 
            // FCONFIG_CancelaGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 267);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Salvar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FCONFIG_CancelaGeral";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Configurações da Cancela";
            this.Load += new System.EventHandler(this.FCONFIG_BackupServidor_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUMERIC_Tempo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private GroupBox groupBox3;
        private Panel panel6;
        private Label label24;
        public CustomControls.SyncControls.EditDecimalGuna2 NUMERIC_Tempo;
        private Label label19;
        private PictureBox pictureBox1;
    }
}