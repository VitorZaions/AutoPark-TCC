namespace AutoPark.Forms.Relatorios
{
    partial class REL_ContaPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REL_ContaPagar));
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ovCKB_Baixado = new System.Windows.Forms.CheckBox();
            this.ovCKB_Parcial = new System.Windows.Forms.CheckBox();
            this.ovCKB_Cancelado = new System.Windows.Forms.CheckBox();
            this.ovCKB_Aberto = new System.Windows.Forms.CheckBox();
            this.ovTXT_Codigo = new CustomControls.SyncControls.SyncTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ovTXT_Complemento = new CustomControls.SyncControls.SyncTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ovTXT_Origem = new CustomControls.SyncControls.SyncTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Fornecedor = new CustomControls.SyncControls.SyncTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ovTXT_VencimentoFim = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.ovTXT_VencimentoInicio = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.ovTXT_EmissaoFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_EmissaoInicio = new System.Windows.Forms.DateTimePicker();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
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
            this.groupBox1.Controls.Add(this.ovTXT_Codigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ovTXT_Complemento);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.ovTXT_Origem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ovTXT_Fornecedor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ovTXT_VencimentoFim);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ovTXT_VencimentoInicio);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ovTXT_EmissaoFim);
            this.groupBox1.Controls.Add(this.ovTXT_EmissaoInicio);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(23, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 286);
            this.groupBox1.TabIndex = 166;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ovCKB_Baixado);
            this.groupBox2.Controls.Add(this.ovCKB_Parcial);
            this.groupBox2.Controls.Add(this.ovCKB_Cancelado);
            this.groupBox2.Controls.Add(this.ovCKB_Aberto);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(18, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 80);
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
            this.ovCKB_Baixado.Location = new System.Drawing.Point(16, 49);
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
            this.ovCKB_Parcial.Location = new System.Drawing.Point(125, 22);
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
            this.ovCKB_Cancelado.Location = new System.Drawing.Point(125, 49);
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
            this.ovCKB_Aberto.Location = new System.Drawing.Point(16, 22);
            this.ovCKB_Aberto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Aberto.Name = "ovCKB_Aberto";
            this.ovCKB_Aberto.Size = new System.Drawing.Size(67, 21);
            this.ovCKB_Aberto.TabIndex = 0;
            this.ovCKB_Aberto.Text = "Aberto";
            this.ovCKB_Aberto.UseVisualStyleBackColor = true;
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
            this.ovTXT_Codigo.Location = new System.Drawing.Point(18, 54);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(18, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 186;
            this.label2.Text = "Código:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(239, 32);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 17);
            this.label14.TabIndex = 171;
            this.label14.Text = "Fornecedor:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(18, 100);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 17);
            this.label12.TabIndex = 180;
            this.label12.Text = "Origem:";
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
            this.ovTXT_Complemento.Location = new System.Drawing.Point(239, 122);
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
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(239, 100);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 17);
            this.label11.TabIndex = 181;
            this.label11.Text = "Complemento:";
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
            this.ovTXT_Origem.Location = new System.Drawing.Point(18, 122);
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(503, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 182;
            this.label1.Text = "Vencimento:";
            // 
            // ovTXT_Fornecedor
            // 
            this.ovTXT_Fornecedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Fornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Fornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Fornecedor.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Fornecedor.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Fornecedor.BorderRadius = 0;
            this.ovTXT_Fornecedor.BorderSize = 1;
            this.ovTXT_Fornecedor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Fornecedor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Fornecedor.Location = new System.Drawing.Point(239, 54);
            this.ovTXT_Fornecedor.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Fornecedor.MaxLength = 200;
            this.ovTXT_Fornecedor.Multiline = false;
            this.ovTXT_Fornecedor.Name = "ovTXT_Fornecedor";
            this.ovTXT_Fornecedor.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Fornecedor.PasswordChar = false;
            this.ovTXT_Fornecedor.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Fornecedor.PlaceholderText = "Documento ou Nome";
            this.ovTXT_Fornecedor.ReadOnly = false;
            this.ovTXT_Fornecedor.Size = new System.Drawing.Size(239, 33);
            this.ovTXT_Fornecedor.TabIndex = 169;
            this.ovTXT_Fornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(635, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 183;
            this.label5.Text = "Até";
            // 
            // ovTXT_VencimentoFim
            // 
            this.ovTXT_VencimentoFim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_VencimentoFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_VencimentoFim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_VencimentoFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_VencimentoFim.Location = new System.Drawing.Point(667, 120);
            this.ovTXT_VencimentoFim.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_VencimentoFim.Name = "ovTXT_VencimentoFim";
            this.ovTXT_VencimentoFim.Size = new System.Drawing.Size(126, 33);
            this.ovTXT_VencimentoFim.TabIndex = 176;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(503, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 184;
            this.label7.Text = "Emissão:";
            // 
            // ovTXT_VencimentoInicio
            // 
            this.ovTXT_VencimentoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_VencimentoInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_VencimentoInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_VencimentoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_VencimentoInicio.Location = new System.Drawing.Point(503, 122);
            this.ovTXT_VencimentoInicio.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_VencimentoInicio.Name = "ovTXT_VencimentoInicio";
            this.ovTXT_VencimentoInicio.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_VencimentoInicio.TabIndex = 175;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(635, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 15);
            this.label6.TabIndex = 185;
            this.label6.Text = "Até";
            // 
            // ovTXT_EmissaoFim
            // 
            this.ovTXT_EmissaoFim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_EmissaoFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_EmissaoFim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_EmissaoFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_EmissaoFim.Location = new System.Drawing.Point(667, 54);
            this.ovTXT_EmissaoFim.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_EmissaoFim.Name = "ovTXT_EmissaoFim";
            this.ovTXT_EmissaoFim.Size = new System.Drawing.Size(126, 33);
            this.ovTXT_EmissaoFim.TabIndex = 172;
            // 
            // ovTXT_EmissaoInicio
            // 
            this.ovTXT_EmissaoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_EmissaoInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_EmissaoInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_EmissaoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_EmissaoInicio.Location = new System.Drawing.Point(503, 54);
            this.ovTXT_EmissaoInicio.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_EmissaoInicio.Name = "ovTXT_EmissaoInicio";
            this.ovTXT_EmissaoInicio.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_EmissaoInicio.TabIndex = 170;
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
            // REL_ContaPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 431);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.ovBTN_Pesquisar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "REL_ContaPagar";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Relatório de Contas a  Pagar";
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
        private CustomControls.SyncControls.SyncTextBox ovTXT_Codigo;
        private Label label2;
        private Label label14;
        private Label label12;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Complemento;
        private Label label11;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Origem;
        private Label label1;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Fornecedor;
        private Label label5;
        private DateTimePicker ovTXT_VencimentoFim;
        private Label label7;
        private DateTimePicker ovTXT_VencimentoInicio;
        private Label label6;
        private DateTimePicker ovTXT_EmissaoFim;
        private DateTimePicker ovTXT_EmissaoInicio;
    }
}