namespace AutoPark.Forms.Relatorios
{
    partial class REL_Entrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REL_Entrada));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ovCKB_OCR = new System.Windows.Forms.CheckBox();
            this.ovCKB_Normal = new System.Windows.Forms.CheckBox();
            this.ovTXT_Placa = new CustomControls.SyncControls.SyncTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ovCKB_Nulo = new System.Windows.Forms.CheckBox();
            this.ovCKB_Baixado = new System.Windows.Forms.CheckBox();
            this.ovCKB_Parcial = new System.Windows.Forms.CheckBox();
            this.ovCKB_Cancelado = new System.Windows.Forms.CheckBox();
            this.ovCKB_Aberto = new System.Windows.Forms.CheckBox();
            this.ovTXT_Codigo = new CustomControls.SyncControls.SyncTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ovTXT_Cliente = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_VencimentoFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_VencimentoInicio = new System.Windows.Forms.DateTimePicker();
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ovCKB_OCR);
            this.groupBox4.Controls.Add(this.ovCKB_Normal);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(273, 159);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(100, 107);
            this.groupBox4.TabIndex = 159;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tipo";
            // 
            // ovCKB_OCR
            // 
            this.ovCKB_OCR.AutoSize = true;
            this.ovCKB_OCR.Checked = true;
            this.ovCKB_OCR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ovCKB_OCR.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_OCR.Location = new System.Drawing.Point(14, 52);
            this.ovCKB_OCR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_OCR.Name = "ovCKB_OCR";
            this.ovCKB_OCR.Size = new System.Drawing.Size(53, 21);
            this.ovCKB_OCR.TabIndex = 1;
            this.ovCKB_OCR.Text = "OCR";
            this.ovCKB_OCR.UseVisualStyleBackColor = true;
            // 
            // ovCKB_Normal
            // 
            this.ovCKB_Normal.AutoSize = true;
            this.ovCKB_Normal.Checked = true;
            this.ovCKB_Normal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ovCKB_Normal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Normal.Location = new System.Drawing.Point(14, 23);
            this.ovCKB_Normal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Normal.Name = "ovCKB_Normal";
            this.ovCKB_Normal.Size = new System.Drawing.Size(71, 21);
            this.ovCKB_Normal.TabIndex = 0;
            this.ovCKB_Normal.Text = "Normal";
            this.ovCKB_Normal.UseVisualStyleBackColor = true;
            // 
            // ovTXT_Placa
            // 
            this.ovTXT_Placa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Placa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Placa.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Placa.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Placa.BorderRadius = 0;
            this.ovTXT_Placa.BorderSize = 1;
            this.ovTXT_Placa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Placa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Placa.Location = new System.Drawing.Point(160, 51);
            this.ovTXT_Placa.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Placa.MaxLength = 7;
            this.ovTXT_Placa.Multiline = false;
            this.ovTXT_Placa.Name = "ovTXT_Placa";
            this.ovTXT_Placa.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Placa.PasswordChar = false;
            this.ovTXT_Placa.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Placa.PlaceholderText = "";
            this.ovTXT_Placa.ReadOnly = false;
            this.ovTXT_Placa.Size = new System.Drawing.Size(165, 33);
            this.ovTXT_Placa.TabIndex = 153;
            this.ovTXT_Placa.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(160, 30);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 17);
            this.label12.TabIndex = 165;
            this.label12.Text = "Placa:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ovCKB_Nulo);
            this.groupBox2.Controls.Add(this.ovCKB_Baixado);
            this.groupBox2.Controls.Add(this.ovCKB_Parcial);
            this.groupBox2.Controls.Add(this.ovCKB_Cancelado);
            this.groupBox2.Controls.Add(this.ovCKB_Aberto);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(13, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 108);
            this.groupBox2.TabIndex = 158;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status Financeiro";
            // 
            // ovCKB_Nulo
            // 
            this.ovCKB_Nulo.AutoSize = true;
            this.ovCKB_Nulo.Checked = true;
            this.ovCKB_Nulo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ovCKB_Nulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Nulo.Location = new System.Drawing.Point(119, 50);
            this.ovCKB_Nulo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Nulo.Name = "ovCKB_Nulo";
            this.ovCKB_Nulo.Size = new System.Drawing.Size(55, 21);
            this.ovCKB_Nulo.TabIndex = 4;
            this.ovCKB_Nulo.Text = "Nulo";
            this.ovCKB_Nulo.UseVisualStyleBackColor = true;
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
            this.ovTXT_Codigo.Location = new System.Drawing.Point(13, 51);
            this.ovTXT_Codigo.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Codigo.MaxLength = 4;
            this.ovTXT_Codigo.Multiline = false;
            this.ovTXT_Codigo.Name = "ovTXT_Codigo";
            this.ovTXT_Codigo.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Codigo.PasswordChar = false;
            this.ovTXT_Codigo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Codigo.PlaceholderText = "";
            this.ovTXT_Codigo.ReadOnly = false;
            this.ovTXT_Codigo.Size = new System.Drawing.Size(121, 33);
            this.ovTXT_Codigo.TabIndex = 152;
            this.ovTXT_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(13, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 17);
            this.label8.TabIndex = 164;
            this.label8.Text = "Código:";
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
            this.ovTXT_Cliente.Location = new System.Drawing.Point(13, 118);
            this.ovTXT_Cliente.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Cliente.MaxLength = 150;
            this.ovTXT_Cliente.Multiline = false;
            this.ovTXT_Cliente.Name = "ovTXT_Cliente";
            this.ovTXT_Cliente.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Cliente.PasswordChar = false;
            this.ovTXT_Cliente.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Cliente.PlaceholderText = "Documento ou Nome";
            this.ovTXT_Cliente.ReadOnly = false;
            this.ovTXT_Cliente.Size = new System.Drawing.Size(624, 33);
            this.ovTXT_Cliente.TabIndex = 157;
            this.ovTXT_Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_VencimentoFim
            // 
            this.ovTXT_VencimentoFim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_VencimentoFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_VencimentoFim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_VencimentoFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_VencimentoFim.Location = new System.Drawing.Point(514, 51);
            this.ovTXT_VencimentoFim.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_VencimentoFim.Name = "ovTXT_VencimentoFim";
            this.ovTXT_VencimentoFim.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_VencimentoFim.TabIndex = 156;
            // 
            // ovTXT_VencimentoInicio
            // 
            this.ovTXT_VencimentoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_VencimentoInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_VencimentoInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_VencimentoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_VencimentoInicio.Location = new System.Drawing.Point(352, 51);
            this.ovTXT_VencimentoInicio.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_VencimentoInicio.Name = "ovTXT_VencimentoInicio";
            this.ovTXT_VencimentoInicio.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_VencimentoInicio.TabIndex = 154;
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
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(494, 366);
            this.ovBTN_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_Pesquisar.Name = "ovBTN_Pesquisar";
            this.ovBTN_Pesquisar.Size = new System.Drawing.Size(184, 40);
            this.ovBTN_Pesquisar.TabIndex = 161;
            this.ovBTN_Pesquisar.Text = "Gerar";
            this.ovBTN_Pesquisar.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(483, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 163;
            this.label5.Text = "Até";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(352, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 162;
            this.label1.Text = "Data:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 155;
            this.label2.Text = "Cliente:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.ovTXT_Codigo);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.ovTXT_VencimentoInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ovTXT_VencimentoFim);
            this.groupBox1.Controls.Add(this.ovTXT_Cliente);
            this.groupBox1.Controls.Add(this.ovTXT_Placa);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(23, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 286);
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
            this.BTN_Cancelar.Location = new System.Drawing.Point(311, 366);
            this.BTN_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Cancelar.TabIndex = 167;
            this.BTN_Cancelar.Text = "Cancelar";
            this.BTN_Cancelar.Click += new System.EventHandler(this.BTN_Cancelar_Click);
            // 
            // REL_Entrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 431);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.ovBTN_Pesquisar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "REL_Entrada";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Relatório de Entrada";
            this.Load += new System.EventHandler(this.REL_Entrada_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox4;
        private CheckBox ovCKB_OCR;
        private CheckBox ovCKB_Normal;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Placa;
        private Label label12;
        private GroupBox groupBox2;
        private CheckBox ovCKB_Nulo;
        private CheckBox ovCKB_Baixado;
        private CheckBox ovCKB_Parcial;
        private CheckBox ovCKB_Cancelado;
        private CheckBox ovCKB_Aberto;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Codigo;
        private Label label8;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Cliente;
        private DateTimePicker ovTXT_VencimentoFim;
        private DateTimePicker ovTXT_VencimentoInicio;
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private Label label5;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
    }
}