namespace AutoPark.Forms.Cadastro
{
    partial class FCAFIN_ChequePagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCAFIN_ChequePagamento));
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ovCKB_Cruzado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ovCMB_Talonario = new CustomControls.SyncControls.SyncComboBox();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.ovTXT_Valor = new CustomControls.SyncControls.EditDecimalGuna2();
            this.ovTXT_Emissao = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_Vencimento = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_Compensado = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_Devolvido = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_Numero = new CustomControls.SyncControls.SyncTextBox();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(300, 144);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 90;
            this.label8.Text = "* Vencimento:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(560, 75);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 17);
            this.label15.TabIndex = 88;
            this.label15.Text = "* Valor:";
            // 
            // ovCKB_Cruzado
            // 
            this.ovCKB_Cruzado.AutoSize = true;
            this.ovCKB_Cruzado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Cruzado.Location = new System.Drawing.Point(818, 74);
            this.ovCKB_Cruzado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Cruzado.Name = "ovCKB_Cruzado";
            this.ovCKB_Cruzado.Size = new System.Drawing.Size(76, 21);
            this.ovCKB_Cruzado.TabIndex = 0;
            this.ovCKB_Cruzado.Text = "Cruzado";
            this.ovCKB_Cruzado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 94;
            this.label1.Text = "* Número:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 95;
            this.label2.Text = "* Emissão:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(560, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 110;
            this.label4.Text = "Compensado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(741, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 111;
            this.label5.Text = "Devolvido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(27, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 112;
            this.label3.Text = "Talonário:";
            // 
            // ovCMB_Talonario
            // 
            this.ovCMB_Talonario.BackColor = System.Drawing.Color.White;
            this.ovCMB_Talonario.BorderColor = System.Drawing.Color.DarkGray;
            this.ovCMB_Talonario.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCMB_Talonario.BorderSize = 1;
            this.ovCMB_Talonario.DropDownHeight = 106;
            this.ovCMB_Talonario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ovCMB_Talonario.DroppedDown = false;
            this.ovCMB_Talonario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCMB_Talonario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_Talonario.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ovCMB_Talonario.ListBackColor = System.Drawing.Color.White;
            this.ovCMB_Talonario.ListTextColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_Talonario.Location = new System.Drawing.Point(30, 234);
            this.ovCMB_Talonario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCMB_Talonario.Name = "ovCMB_Talonario";
            this.ovCMB_Talonario.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ovCMB_Talonario.Padding = new System.Windows.Forms.Padding(1);
            this.ovCMB_Talonario.Size = new System.Drawing.Size(768, 33);
            this.ovCMB_Talonario.TabIndex = 7;
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
            this.BTN_Cancelar.Location = new System.Drawing.Point(550, 293);
            this.BTN_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Cancelar.TabIndex = 10;
            this.BTN_Cancelar.Text = "Cancelar";
            this.BTN_Cancelar.Click += new System.EventHandler(this.metroButton5_Click);
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
            this.BTN_Salvar.Location = new System.Drawing.Point(732, 293);
            this.BTN_Salvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Salvar.TabIndex = 11;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2Button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2Button1.Image = global::AutoPark.Properties.Resources.button_limpar;
            this.guna2Button1.IndicateFocus = true;
            this.guna2Button1.Location = new System.Drawing.Point(859, 234);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(46, 33);
            this.guna2Button1.TabIndex = 9;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Button2.BorderThickness = 1;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2Button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2Button2.Image = global::AutoPark.Properties.Resources.button_find;
            this.guna2Button2.IndicateFocus = true;
            this.guna2Button2.Location = new System.Drawing.Point(806, 234);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(46, 33);
            this.guna2Button2.TabIndex = 8;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Gray;
            this.panel9.Controls.Add(this.label25);
            this.panel9.Location = new System.Drawing.Point(563, 98);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(35, 33);
            this.panel9.TabIndex = 196;
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
            this.ovTXT_Valor.Location = new System.Drawing.Point(597, 98);
            this.ovTXT_Valor.Margin = new System.Windows.Forms.Padding(5);
            this.ovTXT_Valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            131072});
            this.ovTXT_Valor.Name = "ovTXT_Valor";
            this.ovTXT_Valor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ovTXT_Valor.Size = new System.Drawing.Size(308, 33);
            this.ovTXT_Valor.TabIndex = 2;
            this.ovTXT_Valor.ThousandsSeparator = true;
            this.ovTXT_Valor.UpDownButtonFillColor = System.Drawing.Color.Gray;
            this.ovTXT_Valor.UpDownButtonForeColor = System.Drawing.Color.LightGray;
            // 
            // ovTXT_Emissao
            // 
            this.ovTXT_Emissao.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_Emissao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Emissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_Emissao.Location = new System.Drawing.Point(30, 165);
            this.ovTXT_Emissao.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_Emissao.Name = "ovTXT_Emissao";
            this.ovTXT_Emissao.Size = new System.Drawing.Size(254, 33);
            this.ovTXT_Emissao.TabIndex = 3;
            // 
            // ovTXT_Vencimento
            // 
            this.ovTXT_Vencimento.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_Vencimento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Vencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_Vencimento.Location = new System.Drawing.Point(303, 165);
            this.ovTXT_Vencimento.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_Vencimento.Name = "ovTXT_Vencimento";
            this.ovTXT_Vencimento.Size = new System.Drawing.Size(241, 33);
            this.ovTXT_Vencimento.TabIndex = 4;
            // 
            // ovTXT_Compensado
            // 
            this.ovTXT_Compensado.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_Compensado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Compensado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_Compensado.Location = new System.Drawing.Point(563, 165);
            this.ovTXT_Compensado.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_Compensado.Name = "ovTXT_Compensado";
            this.ovTXT_Compensado.Size = new System.Drawing.Size(163, 33);
            this.ovTXT_Compensado.TabIndex = 5;
            // 
            // ovTXT_Devolvido
            // 
            this.ovTXT_Devolvido.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_Devolvido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Devolvido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_Devolvido.Location = new System.Drawing.Point(745, 165);
            this.ovTXT_Devolvido.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_Devolvido.Name = "ovTXT_Devolvido";
            this.ovTXT_Devolvido.Size = new System.Drawing.Size(162, 33);
            this.ovTXT_Devolvido.TabIndex = 6;
            // 
            // ovTXT_Numero
            // 
            this.ovTXT_Numero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Numero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Numero.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Numero.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Numero.BorderRadius = 0;
            this.ovTXT_Numero.BorderSize = 1;
            this.ovTXT_Numero.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Numero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Numero.Location = new System.Drawing.Point(27, 98);
            this.ovTXT_Numero.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Numero.MaxLength = 150;
            this.ovTXT_Numero.Multiline = false;
            this.ovTXT_Numero.Name = "ovTXT_Numero";
            this.ovTXT_Numero.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Numero.PasswordChar = false;
            this.ovTXT_Numero.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Numero.PlaceholderText = "";
            this.ovTXT_Numero.ReadOnly = false;
            this.ovTXT_Numero.Size = new System.Drawing.Size(514, 33);
            this.ovTXT_Numero.TabIndex = 1;
            this.ovTXT_Numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_Numero_KeyPress);
            this.ovTXT_Numero.Validating += new System.ComponentModel.CancelEventHandler(this.ovTXT_Numero_Validating);
            // 
            // FCAFIN_ChequePagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 353);
            this.Controls.Add(this.ovTXT_Numero);
            this.Controls.Add(this.ovTXT_Devolvido);
            this.Controls.Add(this.ovTXT_Compensado);
            this.Controls.Add(this.ovTXT_Vencimento);
            this.Controls.Add(this.ovTXT_Emissao);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.ovTXT_Valor);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.ovCMB_Talonario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovCKB_Cruzado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label15);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCAFIN_ChequePagamento";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cheque pagamento";
            this.Load += new System.EventHandler(this.FCAFIN_ChequePagamento_Load);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ovCKB_Cruzado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private CustomControls.SyncControls.SyncComboBox ovCMB_Talonario;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label25;
        public CustomControls.SyncControls.EditDecimalGuna2 ovTXT_Valor;
        private System.Windows.Forms.DateTimePicker ovTXT_Emissao;
        private System.Windows.Forms.DateTimePicker ovTXT_Vencimento;
        private System.Windows.Forms.DateTimePicker ovTXT_Compensado;
        private System.Windows.Forms.DateTimePicker ovTXT_Devolvido;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Numero;
    }
}