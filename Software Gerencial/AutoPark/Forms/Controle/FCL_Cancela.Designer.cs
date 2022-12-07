
namespace AutoPark.Forms.Controle
{
    partial class FCL_Cancela
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCL_Cancela));
            this.BTN_Fechar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Abrir = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Fechar
            // 
            this.BTN_Fechar.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Fechar.BorderThickness = 1;
            this.BTN_Fechar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Fechar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Fechar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Fechar.Image = global::AutoPark.Properties.Resources.fechar_cancela;
            this.BTN_Fechar.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_Fechar.ImageSize = new System.Drawing.Size(35, 35);
            this.BTN_Fechar.IndicateFocus = true;
            this.BTN_Fechar.Location = new System.Drawing.Point(279, 355);
            this.BTN_Fechar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Fechar.Name = "BTN_Fechar";
            this.BTN_Fechar.Size = new System.Drawing.Size(203, 60);
            this.BTN_Fechar.TabIndex = 2;
            this.BTN_Fechar.Text = "Fechar";
            this.BTN_Fechar.Click += new System.EventHandler(this.BTN_Fechar_Click);
            // 
            // BTN_Abrir
            // 
            this.BTN_Abrir.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Abrir.BorderThickness = 1;
            this.BTN_Abrir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Abrir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Abrir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Abrir.Image = global::AutoPark.Properties.Resources.abrir_cancela;
            this.BTN_Abrir.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_Abrir.ImageSize = new System.Drawing.Size(33, 33);
            this.BTN_Abrir.IndicateFocus = true;
            this.BTN_Abrir.Location = new System.Drawing.Point(48, 355);
            this.BTN_Abrir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Abrir.Name = "BTN_Abrir";
            this.BTN_Abrir.Size = new System.Drawing.Size(203, 60);
            this.BTN_Abrir.TabIndex = 3;
            this.BTN_Abrir.Text = "Abrir";
            this.BTN_Abrir.Click += new System.EventHandler(this.BTN_Abrir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AutoPark.Properties.Resources.cancela_controle;
            this.pictureBox1.Location = new System.Drawing.Point(132, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 253);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // FCL_Cancela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 459);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BTN_Fechar);
            this.Controls.Add(this.BTN_Abrir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FCL_Cancela";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "Controle da Cancela";
            this.Load += new System.EventHandler(this.FCONFIG_BackupServidor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button BTN_Fechar;
        private Guna.UI2.WinForms.Guna2Button BTN_Abrir;
        private PictureBox pictureBox1;
    }
}