
namespace AutoPark.Forms.Cadastro
{
    partial class FCA_EditarVencimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_EditarVencimento));
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.ovTXT_Valor = new CustomControls.SyncControls.EditDecimalGuna2();
            this.label12 = new System.Windows.Forms.Label();
            this.ovTXT_Vencimento = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).BeginInit();
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
            this.BTN_Cancelar.Location = new System.Drawing.Point(93, 149);
            this.BTN_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Cancelar.TabIndex = 2;
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
            this.BTN_Salvar.Location = new System.Drawing.Point(275, 149);
            this.BTN_Salvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Salvar.TabIndex = 3;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.BTN_Salvar_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Gray;
            this.panel9.Controls.Add(this.label25);
            this.panel9.Location = new System.Drawing.Point(31, 90);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(35, 33);
            this.panel9.TabIndex = 209;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(2, 5);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 21);
            this.label25.TabIndex = 0;
            this.label25.Text = "R$";
            // 
            // ovTXT_Valor
            // 
            this.ovTXT_Valor.BackColor = System.Drawing.Color.Transparent;
            this.ovTXT_Valor.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Valor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_Valor.DecimalPlaces = 2;
            this.ovTXT_Valor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Valor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ovTXT_Valor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ovTXT_Valor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Valor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Valor.Location = new System.Drawing.Point(65, 90);
            this.ovTXT_Valor.Margin = new System.Windows.Forms.Padding(5);
            this.ovTXT_Valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            131072});
            this.ovTXT_Valor.Name = "ovTXT_Valor";
            this.ovTXT_Valor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ovTXT_Valor.Size = new System.Drawing.Size(195, 33);
            this.ovTXT_Valor.TabIndex = 0;
            this.ovTXT_Valor.ThousandsSeparator = true;
            this.ovTXT_Valor.UpDownButtonFillColor = System.Drawing.Color.Gray;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(27, 69);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 17);
            this.label12.TabIndex = 208;
            this.label12.Text = "* Valor:";
            // 
            // ovTXT_Vencimento
            // 
            this.ovTXT_Vencimento.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_Vencimento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Vencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_Vencimento.Location = new System.Drawing.Point(287, 90);
            this.ovTXT_Vencimento.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_Vencimento.Name = "ovTXT_Vencimento";
            this.ovTXT_Vencimento.Size = new System.Drawing.Size(163, 33);
            this.ovTXT_Vencimento.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(284, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 207;
            this.label8.Text = "* Vencimento:";
            // 
            // FCA_EditarVencimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 220);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.ovTXT_Valor);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ovTXT_Vencimento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Salvar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FCA_EditarVencimento";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Editar Vencimento";
            this.Load += new System.EventHandler(this.FCA_ItemProdutoOrcamento_Load);
            this.Shown += new System.EventHandler(this.FCA_ItemProdutoOrcamento_Shown);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label25;
        public CustomControls.SyncControls.EditDecimalGuna2 ovTXT_Valor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DateTimePicker ovTXT_Vencimento;
    }
}