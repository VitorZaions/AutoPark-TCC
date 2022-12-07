namespace AutoPark.Forms.Cadastro
{
    partial class FCA_FormaDePagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_FormaDePagamento));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.ovCMB_FormaPagamento = new CustomControls.SyncControls.SyncComboBox();
            this.ovCMB_Bandeiras = new CustomControls.SyncControls.SyncComboBox();
            this.ovLBL_Codigo = new System.Windows.Forms.Label();
            this.ovTXT_Identificacao = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Codigo = new CustomControls.SyncControls.SyncTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTXT_CNPJ = new CustomControls.SyncControls.SyncMaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Bandeira:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(172, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Tipo:";
            // 
            // ovCKB_Ativo
            // 
            this.ovCKB_Ativo.AutoSize = true;
            this.ovCKB_Ativo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Ativo.Location = new System.Drawing.Point(840, 78);
            this.ovCKB_Ativo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Ativo.Name = "ovCKB_Ativo";
            this.ovCKB_Ativo.Size = new System.Drawing.Size(56, 21);
            this.ovCKB_Ativo.TabIndex = 0;
            this.ovCKB_Ativo.Text = "Ativo";
            this.ovCKB_Ativo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(29, 238);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "* Identificação:";
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
            this.BTN_Cancelar.Location = new System.Drawing.Point(550, 625);
            this.BTN_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Cancelar.TabIndex = 5;
            this.BTN_Cancelar.Text = "Cancelar";
            this.BTN_Cancelar.Click += new System.EventHandler(this.ovBTN_Cancelar_Click);
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
            this.BTN_Salvar.Location = new System.Drawing.Point(732, 625);
            this.BTN_Salvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Salvar.TabIndex = 6;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.ovBTN_Salvar_Click);
            // 
            // ovCMB_FormaPagamento
            // 
            this.ovCMB_FormaPagamento.BackColor = System.Drawing.Color.White;
            this.ovCMB_FormaPagamento.BorderColor = System.Drawing.Color.DarkGray;
            this.ovCMB_FormaPagamento.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCMB_FormaPagamento.BorderSize = 1;
            this.ovCMB_FormaPagamento.DropDownHeight = 106;
            this.ovCMB_FormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ovCMB_FormaPagamento.DroppedDown = false;
            this.ovCMB_FormaPagamento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCMB_FormaPagamento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_FormaPagamento.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ovCMB_FormaPagamento.ListBackColor = System.Drawing.Color.White;
            this.ovCMB_FormaPagamento.ListTextColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_FormaPagamento.Location = new System.Drawing.Point(172, 109);
            this.ovCMB_FormaPagamento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCMB_FormaPagamento.Name = "ovCMB_FormaPagamento";
            this.ovCMB_FormaPagamento.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ovCMB_FormaPagamento.Padding = new System.Windows.Forms.Padding(1);
            this.ovCMB_FormaPagamento.Size = new System.Drawing.Size(734, 33);
            this.ovCMB_FormaPagamento.TabIndex = 2;
            this.ovCMB_FormaPagamento.SelectedIndexChanged += new System.EventHandler(this.ovCMB_FormaPag_SelectedIndexChanged);
            // 
            // ovCMB_Bandeiras
            // 
            this.ovCMB_Bandeiras.BackColor = System.Drawing.Color.White;
            this.ovCMB_Bandeiras.BorderColor = System.Drawing.Color.DarkGray;
            this.ovCMB_Bandeiras.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCMB_Bandeiras.BorderSize = 1;
            this.ovCMB_Bandeiras.DropDownHeight = 106;
            this.ovCMB_Bandeiras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ovCMB_Bandeiras.DroppedDown = false;
            this.ovCMB_Bandeiras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCMB_Bandeiras.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_Bandeiras.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ovCMB_Bandeiras.ListBackColor = System.Drawing.Color.White;
            this.ovCMB_Bandeiras.ListTextColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_Bandeiras.Location = new System.Drawing.Point(30, 185);
            this.ovCMB_Bandeiras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCMB_Bandeiras.Name = "ovCMB_Bandeiras";
            this.ovCMB_Bandeiras.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ovCMB_Bandeiras.Padding = new System.Windows.Forms.Padding(1);
            this.ovCMB_Bandeiras.Size = new System.Drawing.Size(877, 33);
            this.ovCMB_Bandeiras.TabIndex = 3;
            // 
            // ovLBL_Codigo
            // 
            this.ovLBL_Codigo.AutoSize = true;
            this.ovLBL_Codigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovLBL_Codigo.Location = new System.Drawing.Point(27, 86);
            this.ovLBL_Codigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ovLBL_Codigo.Name = "ovLBL_Codigo";
            this.ovLBL_Codigo.Size = new System.Drawing.Size(66, 17);
            this.ovLBL_Codigo.TabIndex = 77;
            this.ovLBL_Codigo.Text = "* Código:";
            // 
            // ovTXT_Identificacao
            // 
            this.ovTXT_Identificacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Identificacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Identificacao.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Identificacao.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Identificacao.BorderRadius = 0;
            this.ovTXT_Identificacao.BorderSize = 1;
            this.ovTXT_Identificacao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Identificacao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Identificacao.Location = new System.Drawing.Point(30, 261);
            this.ovTXT_Identificacao.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Identificacao.MaxLength = 200;
            this.ovTXT_Identificacao.Multiline = false;
            this.ovTXT_Identificacao.Name = "ovTXT_Identificacao";
            this.ovTXT_Identificacao.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Identificacao.PasswordChar = false;
            this.ovTXT_Identificacao.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Identificacao.PlaceholderText = "";
            this.ovTXT_Identificacao.ReadOnly = false;
            this.ovTXT_Identificacao.Size = new System.Drawing.Size(876, 33);
            this.ovTXT_Identificacao.TabIndex = 4;
            this.ovTXT_Identificacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Codigo
            // 
            this.ovTXT_Codigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Codigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Codigo.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Codigo.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Codigo.BorderRadius = 0;
            this.ovTXT_Codigo.BorderSize = 1;
            this.ovTXT_Codigo.Enabled = false;
            this.ovTXT_Codigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Codigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Codigo.Location = new System.Drawing.Point(29, 109);
            this.ovTXT_Codigo.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Codigo.MaxLength = 32767;
            this.ovTXT_Codigo.Multiline = false;
            this.ovTXT_Codigo.Name = "ovTXT_Codigo";
            this.ovTXT_Codigo.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Codigo.PasswordChar = false;
            this.ovTXT_Codigo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Codigo.PlaceholderText = "";
            this.ovTXT_Codigo.ReadOnly = false;
            this.ovTXT_Codigo.Size = new System.Drawing.Size(117, 33);
            this.ovTXT_Codigo.TabIndex = 1;
            this.ovTXT_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(27, 311);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 17);
            this.label4.TabIndex = 79;
            this.label4.Text = "* CNPJ Credenciadora:";
            // 
            // ovTXT_CNPJ
            // 
            this.ovTXT_CNPJ.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_CNPJ.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovTXT_CNPJ.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_CNPJ.Location = new System.Drawing.Point(29, 334);
            this.ovTXT_CNPJ.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovTXT_CNPJ.Mask = "00,000,000/0000-00";
            this.ovTXT_CNPJ.Name = "ovTXT_CNPJ";
            this.ovTXT_CNPJ.PasswordChar = '\0';
            this.ovTXT_CNPJ.Size = new System.Drawing.Size(877, 33);
            this.ovTXT_CNPJ.TabIndex = 78;
            this.ovTXT_CNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_CNPJ.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // FCA_FormaDePagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 692);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ovTXT_CNPJ);
            this.Controls.Add(this.ovTXT_Codigo);
            this.Controls.Add(this.ovTXT_Identificacao);
            this.Controls.Add(this.ovLBL_Codigo);
            this.Controls.Add(this.ovCMB_Bandeiras);
            this.Controls.Add(this.ovCMB_FormaPagamento);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovCKB_Ativo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(933, 692);
            this.Name = "FCA_FormaDePagamento";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cadastro de Forma de Pagamento";
            this.Load += new System.EventHandler(this.FCA_FormaDePagamento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private CustomControls.SyncControls.SyncComboBox ovCMB_FormaPagamento;
        private CustomControls.SyncControls.SyncComboBox ovCMB_Bandeiras;
        private System.Windows.Forms.Label ovLBL_Codigo;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Identificacao;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Codigo;
        private System.Windows.Forms.Label label4;
        private CustomControls.SyncControls.SyncMaskedTextBox ovTXT_CNPJ;
    }
}