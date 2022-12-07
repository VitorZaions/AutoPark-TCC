namespace AutoPark.Forms.Cadastro
{
    partial class FCA_ContaBancaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_ContaBancaria));
            this.ovLBL_Centro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ovCKB_CaixaInterno = new System.Windows.Forms.CheckBox();
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Button7 = new Guna.UI2.WinForms.Guna2Button();
            this.ovTXT_Digito = new CustomControls.SyncControls.EditDecimalGuna2();
            this.ovTXT_DigitoAgencia = new CustomControls.SyncControls.EditDecimalGuna2();
            this.ovTXT_Nome = new CustomControls.SyncControls.SyncTextBox();
            this.TXT_BancoNome = new CustomControls.SyncControls.SyncTextBox();
            this.TXT_IDBanco = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Agencia = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Conta = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Operacao = new CustomControls.SyncControls.SyncTextBox();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Digito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_DigitoAgencia)).BeginInit();
            this.SuspendLayout();
            // 
            // ovLBL_Centro
            // 
            this.ovLBL_Centro.AutoSize = true;
            this.ovLBL_Centro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovLBL_Centro.Location = new System.Drawing.Point(26, 93);
            this.ovLBL_Centro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ovLBL_Centro.Name = "ovLBL_Centro";
            this.ovLBL_Centro.Size = new System.Drawing.Size(59, 17);
            this.ovLBL_Centro.TabIndex = 30;
            this.ovLBL_Centro.Text = "* Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "* Banco:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 235);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "* Agência:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(27, 306);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "* Conta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(233, 306);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "* Digito:";
            // 
            // ovCKB_CaixaInterno
            // 
            this.ovCKB_CaixaInterno.AutoSize = true;
            this.ovCKB_CaixaInterno.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_CaixaInterno.Location = new System.Drawing.Point(712, 78);
            this.ovCKB_CaixaInterno.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_CaixaInterno.Name = "ovCKB_CaixaInterno";
            this.ovCKB_CaixaInterno.Size = new System.Drawing.Size(103, 21);
            this.ovCKB_CaixaInterno.TabIndex = 0;
            this.ovCKB_CaixaInterno.Text = "Caixa Interno";
            this.ovCKB_CaixaInterno.UseVisualStyleBackColor = true;
            this.ovCKB_CaixaInterno.CheckedChanged += new System.EventHandler(this.ovCKB_CaixaInterno_CheckedChanged);
            // 
            // ovCKB_Ativo
            // 
            this.ovCKB_Ativo.AutoSize = true;
            this.ovCKB_Ativo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Ativo.Location = new System.Drawing.Point(840, 78);
            this.ovCKB_Ativo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Ativo.Name = "ovCKB_Ativo";
            this.ovCKB_Ativo.Size = new System.Drawing.Size(56, 21);
            this.ovCKB_Ativo.TabIndex = 1;
            this.ovCKB_Ativo.Text = "Ativo";
            this.ovCKB_Ativo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(233, 237);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "* Digito:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(27, 380);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "* Operação:";
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
            this.BTN_Cancelar.TabIndex = 12;
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
            this.BTN_Salvar.TabIndex = 13;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.metroButton4_Click);
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
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(147, 187);
            this.ovBTN_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_Pesquisar.Name = "ovBTN_Pesquisar";
            this.ovBTN_Pesquisar.Size = new System.Drawing.Size(35, 33);
            this.ovBTN_Pesquisar.TabIndex = 4;
            this.ovBTN_Pesquisar.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gray;
            this.panel6.Controls.Add(this.label24);
            this.panel6.Location = new System.Drawing.Point(237, 257);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(35, 33);
            this.panel6.TabIndex = 213;
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
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(237, 328);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 33);
            this.panel1.TabIndex = 215;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(2, 5);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "**";
            // 
            // guna2Button7
            // 
            this.guna2Button7.BorderColor = System.Drawing.Color.Silver;
            this.guna2Button7.BorderThickness = 1;
            this.guna2Button7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.guna2Button7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2Button7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2Button7.Image = global::AutoPark.Properties.Resources.button_limpar;
            this.guna2Button7.IndicateFocus = true;
            this.guna2Button7.Location = new System.Drawing.Point(861, 188);
            this.guna2Button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.Size = new System.Drawing.Size(46, 33);
            this.guna2Button7.TabIndex = 6;
            this.guna2Button7.Click += new System.EventHandler(this.guna2Button7_Click);
            // 
            // ovTXT_Digito
            // 
            this.ovTXT_Digito.BackColor = System.Drawing.Color.Transparent;
            this.ovTXT_Digito.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Digito.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_Digito.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Digito.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ovTXT_Digito.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ovTXT_Digito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Digito.Location = new System.Drawing.Point(271, 328);
            this.ovTXT_Digito.Margin = new System.Windows.Forms.Padding(5);
            this.ovTXT_Digito.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.ovTXT_Digito.Name = "ovTXT_Digito";
            this.ovTXT_Digito.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ovTXT_Digito.Size = new System.Drawing.Size(72, 33);
            this.ovTXT_Digito.TabIndex = 10;
            this.ovTXT_Digito.ThousandsSeparator = true;
            this.ovTXT_Digito.UpDownButtonFillColor = System.Drawing.Color.Gray;
            this.ovTXT_Digito.UpDownButtonForeColor = System.Drawing.Color.LightGray;
            // 
            // ovTXT_DigitoAgencia
            // 
            this.ovTXT_DigitoAgencia.BackColor = System.Drawing.Color.Transparent;
            this.ovTXT_DigitoAgencia.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_DigitoAgencia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_DigitoAgencia.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_DigitoAgencia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ovTXT_DigitoAgencia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ovTXT_DigitoAgencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_DigitoAgencia.Location = new System.Drawing.Point(271, 257);
            this.ovTXT_DigitoAgencia.Margin = new System.Windows.Forms.Padding(5);
            this.ovTXT_DigitoAgencia.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.ovTXT_DigitoAgencia.Name = "ovTXT_DigitoAgencia";
            this.ovTXT_DigitoAgencia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ovTXT_DigitoAgencia.Size = new System.Drawing.Size(72, 33);
            this.ovTXT_DigitoAgencia.TabIndex = 8;
            this.ovTXT_DigitoAgencia.ThousandsSeparator = true;
            this.ovTXT_DigitoAgencia.UpDownButtonFillColor = System.Drawing.Color.Gray;
            this.ovTXT_DigitoAgencia.UpDownButtonForeColor = System.Drawing.Color.LightGray;
            // 
            // ovTXT_Nome
            // 
            this.ovTXT_Nome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Nome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Nome.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Nome.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Nome.BorderRadius = 0;
            this.ovTXT_Nome.BorderSize = 1;
            this.ovTXT_Nome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Nome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Nome.Location = new System.Drawing.Point(30, 120);
            this.ovTXT_Nome.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Nome.MaxLength = 150;
            this.ovTXT_Nome.Multiline = false;
            this.ovTXT_Nome.Name = "ovTXT_Nome";
            this.ovTXT_Nome.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Nome.PasswordChar = false;
            this.ovTXT_Nome.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Nome.PlaceholderText = "";
            this.ovTXT_Nome.ReadOnly = false;
            this.ovTXT_Nome.Size = new System.Drawing.Size(876, 33);
            this.ovTXT_Nome.TabIndex = 2;
            this.ovTXT_Nome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // TXT_BancoNome
            // 
            this.TXT_BancoNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TXT_BancoNome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TXT_BancoNome.BorderColor = System.Drawing.Color.DarkGray;
            this.TXT_BancoNome.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.TXT_BancoNome.BorderRadius = 0;
            this.TXT_BancoNome.BorderSize = 1;
            this.TXT_BancoNome.Enabled = false;
            this.TXT_BancoNome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TXT_BancoNome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TXT_BancoNome.Location = new System.Drawing.Point(190, 188);
            this.TXT_BancoNome.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.TXT_BancoNome.MaxLength = 150;
            this.TXT_BancoNome.Multiline = false;
            this.TXT_BancoNome.Name = "TXT_BancoNome";
            this.TXT_BancoNome.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.TXT_BancoNome.PasswordChar = false;
            this.TXT_BancoNome.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TXT_BancoNome.PlaceholderText = "";
            this.TXT_BancoNome.ReadOnly = false;
            this.TXT_BancoNome.Size = new System.Drawing.Size(663, 33);
            this.TXT_BancoNome.TabIndex = 5;
            this.TXT_BancoNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // TXT_IDBanco
            // 
            this.TXT_IDBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TXT_IDBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TXT_IDBanco.BorderColor = System.Drawing.Color.DarkGray;
            this.TXT_IDBanco.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.TXT_IDBanco.BorderRadius = 0;
            this.TXT_IDBanco.BorderSize = 1;
            this.TXT_IDBanco.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TXT_IDBanco.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TXT_IDBanco.Location = new System.Drawing.Point(31, 188);
            this.TXT_IDBanco.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.TXT_IDBanco.MaxLength = 150;
            this.TXT_IDBanco.Multiline = false;
            this.TXT_IDBanco.Name = "TXT_IDBanco";
            this.TXT_IDBanco.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.TXT_IDBanco.PasswordChar = false;
            this.TXT_IDBanco.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TXT_IDBanco.PlaceholderText = "";
            this.TXT_IDBanco.ReadOnly = false;
            this.TXT_IDBanco.Size = new System.Drawing.Size(108, 33);
            this.TXT_IDBanco.TabIndex = 3;
            this.TXT_IDBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TXT_IDBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_IDBanco_KeyPress);
            this.TXT_IDBanco.Leave += new System.EventHandler(this.TXT_IDBanco_Leave);
            this.TXT_IDBanco.Validating += new System.ComponentModel.CancelEventHandler(this.TXT_IDBanco_Validating);
            // 
            // ovTXT_Agencia
            // 
            this.ovTXT_Agencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Agencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Agencia.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Agencia.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Agencia.BorderRadius = 0;
            this.ovTXT_Agencia.BorderSize = 1;
            this.ovTXT_Agencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Agencia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Agencia.Location = new System.Drawing.Point(30, 257);
            this.ovTXT_Agencia.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Agencia.MaxLength = 10;
            this.ovTXT_Agencia.Multiline = false;
            this.ovTXT_Agencia.Name = "ovTXT_Agencia";
            this.ovTXT_Agencia.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Agencia.PasswordChar = false;
            this.ovTXT_Agencia.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Agencia.PlaceholderText = "";
            this.ovTXT_Agencia.ReadOnly = false;
            this.ovTXT_Agencia.Size = new System.Drawing.Size(184, 33);
            this.ovTXT_Agencia.TabIndex = 7;
            this.ovTXT_Agencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Agencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_Agencia_KeyPress);
            this.ovTXT_Agencia.Validating += new System.ComponentModel.CancelEventHandler(this.ovTXT_Agencia_Validating);
            // 
            // ovTXT_Conta
            // 
            this.ovTXT_Conta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Conta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Conta.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Conta.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Conta.BorderRadius = 0;
            this.ovTXT_Conta.BorderSize = 1;
            this.ovTXT_Conta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Conta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Conta.Location = new System.Drawing.Point(31, 328);
            this.ovTXT_Conta.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Conta.MaxLength = 60;
            this.ovTXT_Conta.Multiline = false;
            this.ovTXT_Conta.Name = "ovTXT_Conta";
            this.ovTXT_Conta.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Conta.PasswordChar = false;
            this.ovTXT_Conta.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Conta.PlaceholderText = "";
            this.ovTXT_Conta.ReadOnly = false;
            this.ovTXT_Conta.Size = new System.Drawing.Size(184, 33);
            this.ovTXT_Conta.TabIndex = 9;
            this.ovTXT_Conta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Conta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_Conta_KeyPress);
            this.ovTXT_Conta.Validating += new System.ComponentModel.CancelEventHandler(this.ovTXT_Conta_Validating);
            // 
            // ovTXT_Operacao
            // 
            this.ovTXT_Operacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Operacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Operacao.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Operacao.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Operacao.BorderRadius = 0;
            this.ovTXT_Operacao.BorderSize = 1;
            this.ovTXT_Operacao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Operacao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Operacao.Location = new System.Drawing.Point(30, 407);
            this.ovTXT_Operacao.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Operacao.MaxLength = 150;
            this.ovTXT_Operacao.Multiline = false;
            this.ovTXT_Operacao.Name = "ovTXT_Operacao";
            this.ovTXT_Operacao.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Operacao.PasswordChar = false;
            this.ovTXT_Operacao.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Operacao.PlaceholderText = "";
            this.ovTXT_Operacao.ReadOnly = false;
            this.ovTXT_Operacao.Size = new System.Drawing.Size(313, 33);
            this.ovTXT_Operacao.TabIndex = 11;
            this.ovTXT_Operacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Operacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_Operacao_KeyPress);
            this.ovTXT_Operacao.Validating += new System.ComponentModel.CancelEventHandler(this.ovTXT_Operacao_Validating);
            // 
            // FCA_ContaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 692);
            this.Controls.Add(this.ovTXT_Operacao);
            this.Controls.Add(this.ovTXT_Conta);
            this.Controls.Add(this.ovTXT_Agencia);
            this.Controls.Add(this.TXT_IDBanco);
            this.Controls.Add(this.TXT_BancoNome);
            this.Controls.Add(this.ovTXT_Nome);
            this.Controls.Add(this.guna2Button7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ovTXT_Digito);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.ovTXT_DigitoAgencia);
            this.Controls.Add(this.ovBTN_Pesquisar);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ovCKB_Ativo);
            this.Controls.Add(this.ovCKB_CaixaInterno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovLBL_Centro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(933, 692);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(933, 692);
            this.Name = "FCA_ContaBancaria";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cadastro de Conta Bancária";
            this.Load += new System.EventHandler(this.FCA_ContaBancaria_Load);
            this.Shown += new System.EventHandler(this.FCA_ContaBancaria_Shown);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Digito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_DigitoAgencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ovLBL_Centro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ovCKB_CaixaInterno;
        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label24;
        public CustomControls.SyncControls.EditDecimalGuna2 ovTXT_DigitoAgencia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        public CustomControls.SyncControls.EditDecimalGuna2 ovTXT_Digito;
        private Guna.UI2.WinForms.Guna2Button guna2Button7;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Nome;
        private CustomControls.SyncControls.SyncTextBox TXT_BancoNome;
        private CustomControls.SyncControls.SyncTextBox TXT_IDBanco;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Agencia;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Conta;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Operacao;
    }
}