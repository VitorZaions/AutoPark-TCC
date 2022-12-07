namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    partial class FCA_Talonario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Talonario));
            this.label1 = new System.Windows.Forms.Label();
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ovCMB_Conta = new CustomControls.SyncControls.SyncComboBox();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Limpar = new Guna.UI2.WinForms.Guna2Button();
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.ovTXT_Fim = new CustomControls.SyncControls.EditDecimalGuna2();
            this.ovTXT_Inicio = new CustomControls.SyncControls.EditDecimalGuna2();
            this.ovTXT_Numero = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Observacao = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Emissao = new System.Windows.Forms.DateTimePicker();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Fim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Inicio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 238);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Observação:";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(27, 87);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 17);
            this.label12.TabIndex = 58;
            this.label12.Text = "* Conta Bancária:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(27, 162);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 60;
            this.label7.Text = "* Número:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(296, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "* Emissão:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(708, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 68;
            this.label3.Text = "* Fim:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(485, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 70;
            this.label4.Text = "* Início:";
            // 
            // ovCMB_Conta
            // 
            this.ovCMB_Conta.BackColor = System.Drawing.Color.White;
            this.ovCMB_Conta.BorderColor = System.Drawing.Color.DarkGray;
            this.ovCMB_Conta.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCMB_Conta.BorderSize = 1;
            this.ovCMB_Conta.DropDownHeight = 106;
            this.ovCMB_Conta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ovCMB_Conta.DroppedDown = false;
            this.ovCMB_Conta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCMB_Conta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_Conta.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ovCMB_Conta.ListBackColor = System.Drawing.Color.White;
            this.ovCMB_Conta.ListTextColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_Conta.Location = new System.Drawing.Point(30, 108);
            this.ovCMB_Conta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCMB_Conta.Name = "ovCMB_Conta";
            this.ovCMB_Conta.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ovCMB_Conta.Padding = new System.Windows.Forms.Padding(1);
            this.ovCMB_Conta.Size = new System.Drawing.Size(770, 33);
            this.ovCMB_Conta.TabIndex = 1;
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
            this.BTN_Cancelar.TabIndex = 9;
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
            this.BTN_Salvar.Location = new System.Drawing.Point(732, 625);
            this.BTN_Salvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Salvar.TabIndex = 10;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // BTN_Limpar
            // 
            this.BTN_Limpar.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Limpar.BorderThickness = 1;
            this.BTN_Limpar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Limpar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Limpar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Limpar.Image = global::AutoPark.Properties.Resources.button_limpar;
            this.BTN_Limpar.IndicateFocus = true;
            this.BTN_Limpar.Location = new System.Drawing.Point(861, 108);
            this.BTN_Limpar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Limpar.Name = "BTN_Limpar";
            this.BTN_Limpar.Size = new System.Drawing.Size(46, 33);
            this.BTN_Limpar.TabIndex = 3;
            this.BTN_Limpar.Click += new System.EventHandler(this.BTN_Limpar_Click);
            // 
            // ovBTN_Pesquisar
            // 
            this.ovBTN_Pesquisar.BorderColor = System.Drawing.Color.Silver;
            this.ovBTN_Pesquisar.BorderThickness = 1;
            this.ovBTN_Pesquisar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ovBTN_Pesquisar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovBTN_Pesquisar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovBTN_Pesquisar.Image = global::AutoPark.Properties.Resources.button_find;
            this.ovBTN_Pesquisar.IndicateFocus = true;
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(808, 108);
            this.ovBTN_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_Pesquisar.Name = "ovBTN_Pesquisar";
            this.ovBTN_Pesquisar.Size = new System.Drawing.Size(46, 33);
            this.ovBTN_Pesquisar.TabIndex = 2;
            this.ovBTN_Pesquisar.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gray;
            this.panel6.Controls.Add(this.label24);
            this.panel6.Location = new System.Drawing.Point(485, 184);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(35, 33);
            this.panel6.TabIndex = 215;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(710, 184);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 33);
            this.panel1.TabIndex = 217;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "**";
            // 
            // ovTXT_Fim
            // 
            this.ovTXT_Fim.BackColor = System.Drawing.Color.Transparent;
            this.ovTXT_Fim.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Fim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_Fim.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Fim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ovTXT_Fim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ovTXT_Fim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Fim.Location = new System.Drawing.Point(743, 184);
            this.ovTXT_Fim.Margin = new System.Windows.Forms.Padding(5);
            this.ovTXT_Fim.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.ovTXT_Fim.Name = "ovTXT_Fim";
            this.ovTXT_Fim.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ovTXT_Fim.Size = new System.Drawing.Size(162, 32);
            this.ovTXT_Fim.TabIndex = 7;
            this.ovTXT_Fim.ThousandsSeparator = true;
            this.ovTXT_Fim.UpDownButtonFillColor = System.Drawing.Color.Gray;
            this.ovTXT_Fim.UpDownButtonForeColor = System.Drawing.Color.LightGray;
            // 
            // ovTXT_Inicio
            // 
            this.ovTXT_Inicio.BackColor = System.Drawing.Color.Transparent;
            this.ovTXT_Inicio.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Inicio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_Inicio.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Inicio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ovTXT_Inicio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ovTXT_Inicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Inicio.Location = new System.Drawing.Point(519, 184);
            this.ovTXT_Inicio.Margin = new System.Windows.Forms.Padding(5);
            this.ovTXT_Inicio.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.ovTXT_Inicio.Name = "ovTXT_Inicio";
            this.ovTXT_Inicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ovTXT_Inicio.Size = new System.Drawing.Size(162, 33);
            this.ovTXT_Inicio.TabIndex = 6;
            this.ovTXT_Inicio.ThousandsSeparator = true;
            this.ovTXT_Inicio.UpDownButtonFillColor = System.Drawing.Color.Gray;
            this.ovTXT_Inicio.UpDownButtonForeColor = System.Drawing.Color.LightGray;
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
            this.ovTXT_Numero.Location = new System.Drawing.Point(30, 184);
            this.ovTXT_Numero.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Numero.MaxLength = 150;
            this.ovTXT_Numero.Multiline = false;
            this.ovTXT_Numero.Name = "ovTXT_Numero";
            this.ovTXT_Numero.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Numero.PasswordChar = false;
            this.ovTXT_Numero.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Numero.PlaceholderText = "";
            this.ovTXT_Numero.ReadOnly = false;
            this.ovTXT_Numero.Size = new System.Drawing.Size(239, 33);
            this.ovTXT_Numero.TabIndex = 4;
            this.ovTXT_Numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_Numero_KeyPress);
            this.ovTXT_Numero.Validating += new System.ComponentModel.CancelEventHandler(this.ovTXT_Numero_Validating);
            // 
            // ovTXT_Observacao
            // 
            this.ovTXT_Observacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Observacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Observacao.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Observacao.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Observacao.BorderRadius = 0;
            this.ovTXT_Observacao.BorderSize = 1;
            this.ovTXT_Observacao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Observacao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Observacao.Location = new System.Drawing.Point(31, 265);
            this.ovTXT_Observacao.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Observacao.MaxLength = 150;
            this.ovTXT_Observacao.Multiline = true;
            this.ovTXT_Observacao.Name = "ovTXT_Observacao";
            this.ovTXT_Observacao.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Observacao.PasswordChar = false;
            this.ovTXT_Observacao.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Observacao.PlaceholderText = "";
            this.ovTXT_Observacao.ReadOnly = false;
            this.ovTXT_Observacao.Size = new System.Drawing.Size(876, 345);
            this.ovTXT_Observacao.TabIndex = 8;
            this.ovTXT_Observacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Emissao
            // 
            this.ovTXT_Emissao.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_Emissao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Emissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_Emissao.Location = new System.Drawing.Point(296, 184);
            this.ovTXT_Emissao.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_Emissao.Name = "ovTXT_Emissao";
            this.ovTXT_Emissao.Size = new System.Drawing.Size(157, 33);
            this.ovTXT_Emissao.TabIndex = 5;
            // 
            // FCA_Talonario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 692);
            this.Controls.Add(this.ovTXT_Emissao);
            this.Controls.Add(this.ovTXT_Observacao);
            this.Controls.Add(this.ovTXT_Numero);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ovTXT_Fim);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.ovTXT_Inicio);
            this.Controls.Add(this.BTN_Limpar);
            this.Controls.Add(this.ovBTN_Pesquisar);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.ovCMB_Conta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ovCKB_Ativo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(933, 692);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(933, 692);
            this.Name = "FCA_Talonario";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cadastro de talonário";
            this.Load += new System.EventHandler(this.FCA_Talonario_Load);
            this.Shown += new System.EventHandler(this.FCA_Talonario_Shown);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Fim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Inicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomControls.SyncControls.SyncComboBox ovCMB_Conta;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private Guna.UI2.WinForms.Guna2Button BTN_Limpar;
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label24;
        public CustomControls.SyncControls.EditDecimalGuna2 ovTXT_Inicio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        public CustomControls.SyncControls.EditDecimalGuna2 ovTXT_Fim;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Numero;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Observacao;
        private System.Windows.Forms.DateTimePicker ovTXT_Emissao;
    }
}