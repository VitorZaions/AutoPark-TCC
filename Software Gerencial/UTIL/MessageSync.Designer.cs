
namespace AutoUTIL
{
    partial class MessageSync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageSync));
            this.LBL_Header = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Confirmar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.PB_Icone = new System.Windows.Forms.PictureBox();
            this.HeaderBG_Default = new System.Windows.Forms.Panel();
            this.LBL_Desc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Icone)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_Header
            // 
            this.LBL_Header.AutoSize = true;
            this.LBL_Header.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBL_Header.Location = new System.Drawing.Point(27, 26);
            this.LBL_Header.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Header.Name = "LBL_Header";
            this.LBL_Header.Size = new System.Drawing.Size(118, 37);
            this.LBL_Header.TabIndex = 59;
            this.LBL_Header.Text = "$Header";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.BTN_Confirmar);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Cancelar);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(392, 141);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(324, 52);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // BTN_Confirmar
            // 
            this.BTN_Confirmar.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Confirmar.BorderThickness = 1;
            this.BTN_Confirmar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Confirmar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Confirmar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Confirmar.Image = global::AutoUTIL.Properties.Resources.ok;
            this.BTN_Confirmar.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_Confirmar.IndicateFocus = true;
            this.BTN_Confirmar.Location = new System.Drawing.Point(170, 3);
            this.BTN_Confirmar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Confirmar.Name = "BTN_Confirmar";
            this.BTN_Confirmar.Size = new System.Drawing.Size(150, 40);
            this.BTN_Confirmar.TabIndex = 2;
            this.BTN_Confirmar.Text = "Confirmar";
            this.BTN_Confirmar.Click += new System.EventHandler(this.BTN_Confirmar_Click);
            // 
            // BTN_Cancelar
            // 
            this.BTN_Cancelar.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Cancelar.BorderThickness = 1;
            this.BTN_Cancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Cancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Cancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Cancelar.Image = global::AutoUTIL.Properties.Resources.button_remover;
            this.BTN_Cancelar.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_Cancelar.IndicateFocus = true;
            this.BTN_Cancelar.Location = new System.Drawing.Point(12, 3);
            this.BTN_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(150, 40);
            this.BTN_Cancelar.TabIndex = 1;
            this.BTN_Cancelar.Text = "Cancelar";
            this.BTN_Cancelar.Click += new System.EventHandler(this.BTN_Cancelar_Click);
            // 
            // PB_Icone
            // 
            this.PB_Icone.Location = new System.Drawing.Point(34, 79);
            this.PB_Icone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PB_Icone.Name = "PB_Icone";
            this.PB_Icone.Size = new System.Drawing.Size(40, 38);
            this.PB_Icone.TabIndex = 62;
            this.PB_Icone.TabStop = false;
            // 
            // HeaderBG_Default
            // 
            this.HeaderBG_Default.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(144)))), ((int)(((byte)(249)))));
            this.HeaderBG_Default.Location = new System.Drawing.Point(0, 0);
            this.HeaderBG_Default.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.HeaderBG_Default.Name = "HeaderBG_Default";
            this.HeaderBG_Default.Size = new System.Drawing.Size(735, 6);
            this.HeaderBG_Default.TabIndex = 63;
            this.HeaderBG_Default.Visible = false;
            // 
            // LBL_Desc
            // 
            this.LBL_Desc.AutoSize = false;
            this.LBL_Desc.AutoSizeHeightOnly = true;
            this.LBL_Desc.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Desc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBL_Desc.Location = new System.Drawing.Point(81, 79);
            this.LBL_Desc.Name = "LBL_Desc";
            this.LBL_Desc.Size = new System.Drawing.Size(627, 22);
            this.LBL_Desc.TabIndex = 216;
            this.LBL_Desc.Text = "#Desc";
            // 
            // MessageSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 204);
            this.Controls.Add(this.LBL_Desc);
            this.Controls.Add(this.HeaderBG_Default);
            this.Controls.Add(this.PB_Icone);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.LBL_Header);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MessageSync";
            this.Padding = new System.Windows.Forms.Padding(23, 35, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "Aviso";
            this.Activated += new System.EventHandler(this.MessageSync_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageSync_FormClosing);
            this.Load += new System.EventHandler(this.MessageSync_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Icone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LBL_Header;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox PB_Icone;
        private System.Windows.Forms.Panel HeaderBG_Default;
        private Guna.UI2.WinForms.Guna2HtmlLabel LBL_Desc;
        private Guna.UI2.WinForms.Guna2Button BTN_Confirmar;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
    }
}