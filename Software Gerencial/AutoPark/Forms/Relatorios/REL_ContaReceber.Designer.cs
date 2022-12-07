namespace AutoPark.Forms.Relatorios
{
    partial class REL_ContaReceber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REL_ContaReceber));
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ovCKB_Baixado = new System.Windows.Forms.CheckBox();
            this.ovCKB_Parcial = new System.Windows.Forms.CheckBox();
            this.ovCKB_Cancelado = new System.Windows.Forms.CheckBox();
            this.ovCKB_Aberto = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ovTXT_Codigo = new CustomControls.SyncControls.SyncTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ovTXT_Complemento = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Origem = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Cliente = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_VencimentoFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_VencimentoInicio = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_EmissaoFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_EmissaoInicio = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ovBTN_Pesquisar
            // 
            this.ovBTN_Pesquisar.BorderColor = System.Drawing.Color.Silver;
            this.ovBTN_Pesquisar.BorderThickness = 1;
            this.ovBTN_Pesquisar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ovBTN_Pesquisar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovBTN_Pesquisar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovBTN_Pesquisar.Image = global::AutoPark.Properties.Resources.rel;
            this.ovBTN_Pesquisar.ImageOffset = new System.Drawing.Point(-3, 0);
            this.ovBTN_Pesquisar.IndicateFocus = true;
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(655, 368);
            this.ovBTN_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_Pesquisar.Name = "ovBTN_Pesquisar";
            this.ovBTN_Pesquisar.Size = new System.Drawing.Size(184, 40);
            this.ovBTN_Pesquisar.TabIndex = 161;
            this.ovBTN_Pesquisar.Text = "Gerar";
            this.ovBTN_Pesquisar.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ovTXT_Codigo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ovTXT_Complemento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ovTXT_Origem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ovTXT_Cliente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ovTXT_VencimentoFim);
            this.groupBox1.Controls.Add(this.ovTXT_EmissaoInicio);
            this.groupBox1.Controls.Add(this.ovTXT_VencimentoInicio);
            this.groupBox1.Controls.Add(this.ovTXT_EmissaoFim);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(23, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 299);
            this.groupBox1.TabIndex = 166;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
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
            this.BTN_Cancelar.Location = new System.Drawing.Point(472, 368);
            this.BTN_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Cancelar.TabIndex = 167;
            this.BTN_Cancelar.Text = "Cancelar";
            this.BTN_Cancelar.Click += new System.EventHandler(this.BTN_Cancelar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ovCKB_Baixado);
            this.groupBox2.Controls.Add(this.ovCKB_Parcial);
            this.groupBox2.Controls.Add(this.ovCKB_Cancelado);
            this.groupBox2.Controls.Add(this.ovCKB_Aberto);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(17, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 108);
            this.groupBox2.TabIndex = 177;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // ovCKB_Baixado
            // 
            this.ovCKB_Baixado.AutoSize = true;
            this.ovCKB_Baixado.BackColor = System.Drawing.Color.White;
            this.ovCKB_Baixado.Checked = true;
            this.ovCKB_Baixado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ovCKB_Baixado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Baixado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovCKB_Baixado.Location = new System.Drawing.Point(16, 50);
            this.ovCKB_Baixado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Baixado.Name = "ovCKB_Baixado";
            this.ovCKB_Baixado.Size = new System.Drawing.Size(73, 21);
            this.ovCKB_Baixado.TabIndex = 1;
            this.ovCKB_Baixado.Text = "Baixado";
            this.ovCKB_Baixado.UseVisualStyleBackColor = false;
            // 
            // ovCKB_Parcial
            // 
            this.ovCKB_Parcial.AutoSize = true;
            this.ovCKB_Parcial.Checked = true;
            this.ovCKB_Parcial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ovCKB_Parcial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Parcial.Location = new System.Drawing.Point(16, 77);
            this.ovCKB_Parcial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Parcial.Name = "ovCKB_Parcial";
            this.ovCKB_Parcial.Size = new System.Drawing.Size(65, 21);
            this.ovCKB_Parcial.TabIndex = 2;
            this.ovCKB_Parcial.Text = "Parcial";
            this.ovCKB_Parcial.UseVisualStyleBackColor = true;
            // 
            // ovCKB_Cancelado
            // 
            this.ovCKB_Cancelado.AutoSize = true;
            this.ovCKB_Cancelado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Cancelado.Location = new System.Drawing.Point(119, 24);
            this.ovCKB_Cancelado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Cancelado.Name = "ovCKB_Cancelado";
            this.ovCKB_Cancelado.Size = new System.Drawing.Size(88, 21);
            this.ovCKB_Cancelado.TabIndex = 3;
            this.ovCKB_Cancelado.Text = "Cancelado";
            this.ovCKB_Cancelado.UseVisualStyleBackColor = true;
            // 
            // ovCKB_Aberto
            // 
            this.ovCKB_Aberto.AutoSize = true;
            this.ovCKB_Aberto.Checked = true;
            this.ovCKB_Aberto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ovCKB_Aberto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Aberto.Location = new System.Drawing.Point(16, 23);
            this.ovCKB_Aberto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Aberto.Name = "ovCKB_Aberto";
            this.ovCKB_Aberto.Size = new System.Drawing.Size(67, 21);
            this.ovCKB_Aberto.TabIndex = 0;
            this.ovCKB_Aberto.Text = "Aberto";
            this.ovCKB_Aberto.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(636, 61);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 15);
            this.label9.TabIndex = 184;
            this.label9.Text = "Até";
            // 
            // ovTXT_Codigo
            // 
            this.ovTXT_Codigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Codigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Codigo.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Codigo.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Codigo.BorderRadius = 0;
            this.ovTXT_Codigo.BorderSize = 1;
            this.ovTXT_Codigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Codigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Codigo.Location = new System.Drawing.Point(17, 52);
            this.ovTXT_Codigo.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Codigo.MaxLength = 4;
            this.ovTXT_Codigo.Multiline = false;
            this.ovTXT_Codigo.Name = "ovTXT_Codigo";
            this.ovTXT_Codigo.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Codigo.PasswordChar = false;
            this.ovTXT_Codigo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Codigo.PlaceholderText = "";
            this.ovTXT_Codigo.ReadOnly = false;
            this.ovTXT_Codigo.Size = new System.Drawing.Size(197, 33);
            this.ovTXT_Codigo.TabIndex = 168;
            this.ovTXT_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(17, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 17);
            this.label8.TabIndex = 183;
            this.label8.Text = "Código:";
            // 
            // ovTXT_Complemento
            // 
            this.ovTXT_Complemento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Complemento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Complemento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Complemento.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Complemento.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Complemento.BorderRadius = 0;
            this.ovTXT_Complemento.BorderSize = 1;
            this.ovTXT_Complemento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Complemento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Complemento.Location = new System.Drawing.Point(239, 120);
            this.ovTXT_Complemento.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Complemento.MaxLength = 100;
            this.ovTXT_Complemento.Multiline = false;
            this.ovTXT_Complemento.Name = "ovTXT_Complemento";
            this.ovTXT_Complemento.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Complemento.PasswordChar = false;
            this.ovTXT_Complemento.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Complemento.PlaceholderText = "";
            this.ovTXT_Complemento.ReadOnly = false;
            this.ovTXT_Complemento.Size = new System.Drawing.Size(239, 33);
            this.ovTXT_Complemento.TabIndex = 174;
            this.ovTXT_Complemento.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Origem
            // 
            this.ovTXT_Origem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Origem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Origem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Origem.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Origem.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Origem.BorderRadius = 0;
            this.ovTXT_Origem.BorderSize = 1;
            this.ovTXT_Origem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Origem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Origem.Location = new System.Drawing.Point(17, 120);
            this.ovTXT_Origem.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Origem.MaxLength = 100;
            this.ovTXT_Origem.Multiline = false;
            this.ovTXT_Origem.Name = "ovTXT_Origem";
            this.ovTXT_Origem.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Origem.PasswordChar = false;
            this.ovTXT_Origem.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Origem.PlaceholderText = "";
            this.ovTXT_Origem.ReadOnly = false;
            this.ovTXT_Origem.Size = new System.Drawing.Size(197, 33);
            this.ovTXT_Origem.TabIndex = 173;
            this.ovTXT_Origem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Cliente
            // 
            this.ovTXT_Cliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Cliente.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Cliente.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Cliente.BorderRadius = 0;
            this.ovTXT_Cliente.BorderSize = 1;
            this.ovTXT_Cliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Cliente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Cliente.Location = new System.Drawing.Point(239, 52);
            this.ovTXT_Cliente.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Cliente.MaxLength = 150;
            this.ovTXT_Cliente.Multiline = false;
            this.ovTXT_Cliente.Name = "ovTXT_Cliente";
            this.ovTXT_Cliente.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Cliente.PasswordChar = false;
            this.ovTXT_Cliente.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Cliente.PlaceholderText = "Documento ou Nome";
            this.ovTXT_Cliente.ReadOnly = false;
            this.ovTXT_Cliente.Size = new System.Drawing.Size(239, 33);
            this.ovTXT_Cliente.TabIndex = 169;
            this.ovTXT_Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_VencimentoFim
            // 
            this.ovTXT_VencimentoFim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_VencimentoFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_VencimentoFim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_VencimentoFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_VencimentoFim.Location = new System.Drawing.Point(668, 119);
            this.ovTXT_VencimentoFim.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_VencimentoFim.Name = "ovTXT_VencimentoFim";
            this.ovTXT_VencimentoFim.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_VencimentoFim.TabIndex = 176;
            // 
            // ovTXT_VencimentoInicio
            // 
            this.ovTXT_VencimentoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_VencimentoInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_VencimentoInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_VencimentoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_VencimentoInicio.Location = new System.Drawing.Point(506, 119);
            this.ovTXT_VencimentoInicio.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_VencimentoInicio.Name = "ovTXT_VencimentoInicio";
            this.ovTXT_VencimentoInicio.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_VencimentoInicio.TabIndex = 175;
            // 
            // ovTXT_EmissaoFim
            // 
            this.ovTXT_EmissaoFim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_EmissaoFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_EmissaoFim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_EmissaoFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_EmissaoFim.Location = new System.Drawing.Point(668, 52);
            this.ovTXT_EmissaoFim.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_EmissaoFim.Name = "ovTXT_EmissaoFim";
            this.ovTXT_EmissaoFim.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_EmissaoFim.TabIndex = 172;
            // 
            // ovTXT_EmissaoInicio
            // 
            this.ovTXT_EmissaoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_EmissaoInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_EmissaoInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_EmissaoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_EmissaoInicio.Location = new System.Drawing.Point(504, 52);
            this.ovTXT_EmissaoInicio.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_EmissaoInicio.Name = "ovTXT_EmissaoInicio";
            this.ovTXT_EmissaoInicio.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_EmissaoInicio.TabIndex = 171;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(504, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 182;
            this.label7.Text = "Emissão:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(637, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 181;
            this.label5.Text = "Até";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(240, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 180;
            this.label4.Text = "Complemento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(17, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 179;
            this.label3.Text = "Origem:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(506, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 178;
            this.label1.Text = "Vencimento:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(239, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 170;
            this.label2.Text = "Cliente:";
            // 
            // REL_ContaReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 431);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.ovBTN_Pesquisar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "REL_ContaReceber";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Relatório de Contas a Receber";
            this.Load += new System.EventHandler(this.REL_Entrada_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private GroupBox groupBox2;
        private CheckBox ovCKB_Baixado;
        private CheckBox ovCKB_Parcial;
        private CheckBox ovCKB_Cancelado;
        private CheckBox ovCKB_Aberto;
        private Label label8;
        private Label label9;
        private Label label2;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Codigo;
        private Label label1;
        private Label label3;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Complemento;
        private Label label4;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Origem;
        private Label label5;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Cliente;
        private Label label7;
        private DateTimePicker ovTXT_VencimentoFim;
        private DateTimePicker ovTXT_EmissaoInicio;
        private DateTimePicker ovTXT_VencimentoInicio;
        private DateTimePicker ovTXT_EmissaoFim;
    }
}