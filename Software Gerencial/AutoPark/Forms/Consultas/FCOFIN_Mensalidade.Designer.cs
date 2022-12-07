namespace AutoPark.Forms.Consultas
{
    partial class FCOFIN_Mensalidade
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCOFIN_Mensalidade));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ovTXT_Placa = new CustomControls.SyncControls.SyncTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ovCKB_Baixado = new System.Windows.Forms.CheckBox();
            this.ovCKB_Parcial = new System.Windows.Forms.CheckBox();
            this.ovCKB_Cancelado = new System.Windows.Forms.CheckBox();
            this.ovCKB_Aberto = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ovTXT_Codigo = new CustomControls.SyncControls.SyncTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ovTXT_Cliente = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_VencimentoFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_VencimentoInicio = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_EmissaoFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_EmissaoInicio = new System.Windows.Forms.DateTimePicker();
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.ovBTN_LimparFiltros = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_Remover = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Editar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Novo = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Selecionar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_RealizarLancamento = new Guna.UI2.WinForms.Guna2Button();
            this.ovGRD_Mensalidades = new Guna.UI2.WinForms.Guna2DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Mensalidades)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ovTXT_Placa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ovTXT_Codigo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ovTXT_Cliente);
            this.groupBox1.Controls.Add(this.ovTXT_VencimentoFim);
            this.groupBox1.Controls.Add(this.ovTXT_VencimentoInicio);
            this.groupBox1.Controls.Add(this.ovTXT_EmissaoFim);
            this.groupBox1.Controls.Add(this.ovTXT_EmissaoInicio);
            this.groupBox1.Controls.Add(this.ovBTN_Pesquisar);
            this.groupBox1.Controls.Add(this.ovBTN_LimparFiltros);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(27, 73);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1265, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de pesquisa";
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
            this.ovTXT_Placa.Location = new System.Drawing.Point(241, 54);
            this.ovTXT_Placa.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Placa.MaxLength = 7;
            this.ovTXT_Placa.Multiline = false;
            this.ovTXT_Placa.Name = "ovTXT_Placa";
            this.ovTXT_Placa.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Placa.PasswordChar = false;
            this.ovTXT_Placa.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Placa.PlaceholderText = "";
            this.ovTXT_Placa.ReadOnly = false;
            this.ovTXT_Placa.Size = new System.Drawing.Size(216, 33);
            this.ovTXT_Placa.TabIndex = 1;
            this.ovTXT_Placa.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(241, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 151;
            this.label3.Text = "Placa:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ovCKB_Baixado);
            this.groupBox2.Controls.Add(this.ovCKB_Parcial);
            this.groupBox2.Controls.Add(this.ovCKB_Cancelado);
            this.groupBox2.Controls.Add(this.ovCKB_Aberto);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(811, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 108);
            this.groupBox2.TabIndex = 7;
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
            this.label9.Location = new System.Drawing.Point(629, 63);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 15);
            this.label9.TabIndex = 149;
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
            this.ovTXT_Codigo.Location = new System.Drawing.Point(10, 54);
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
            this.ovTXT_Codigo.TabIndex = 0;
            this.ovTXT_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Codigo.Validating += new System.ComponentModel.CancelEventHandler(this.ovTXT_Codigo_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(10, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 17);
            this.label8.TabIndex = 148;
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
            this.ovTXT_Cliente.Location = new System.Drawing.Point(10, 121);
            this.ovTXT_Cliente.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Cliente.MaxLength = 150;
            this.ovTXT_Cliente.Multiline = false;
            this.ovTXT_Cliente.Name = "ovTXT_Cliente";
            this.ovTXT_Cliente.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Cliente.PasswordChar = false;
            this.ovTXT_Cliente.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Cliente.PlaceholderText = "Documento ou Nome";
            this.ovTXT_Cliente.ReadOnly = false;
            this.ovTXT_Cliente.Size = new System.Drawing.Size(447, 33);
            this.ovTXT_Cliente.TabIndex = 4;
            this.ovTXT_Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Cliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_Cliente_KeyPress);
            // 
            // ovTXT_VencimentoFim
            // 
            this.ovTXT_VencimentoFim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_VencimentoFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_VencimentoFim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_VencimentoFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_VencimentoFim.Location = new System.Drawing.Point(661, 121);
            this.ovTXT_VencimentoFim.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_VencimentoFim.Name = "ovTXT_VencimentoFim";
            this.ovTXT_VencimentoFim.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_VencimentoFim.TabIndex = 6;
            // 
            // ovTXT_VencimentoInicio
            // 
            this.ovTXT_VencimentoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_VencimentoInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_VencimentoInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_VencimentoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_VencimentoInicio.Location = new System.Drawing.Point(499, 121);
            this.ovTXT_VencimentoInicio.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_VencimentoInicio.Name = "ovTXT_VencimentoInicio";
            this.ovTXT_VencimentoInicio.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_VencimentoInicio.TabIndex = 5;
            // 
            // ovTXT_EmissaoFim
            // 
            this.ovTXT_EmissaoFim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_EmissaoFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_EmissaoFim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_EmissaoFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_EmissaoFim.Location = new System.Drawing.Point(661, 54);
            this.ovTXT_EmissaoFim.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_EmissaoFim.Name = "ovTXT_EmissaoFim";
            this.ovTXT_EmissaoFim.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_EmissaoFim.TabIndex = 3;
            // 
            // ovTXT_EmissaoInicio
            // 
            this.ovTXT_EmissaoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_EmissaoInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_EmissaoInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_EmissaoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ovTXT_EmissaoInicio.Location = new System.Drawing.Point(497, 54);
            this.ovTXT_EmissaoInicio.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_EmissaoInicio.Name = "ovTXT_EmissaoInicio";
            this.ovTXT_EmissaoInicio.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_EmissaoInicio.TabIndex = 2;
            // 
            // ovBTN_Pesquisar
            // 
            this.ovBTN_Pesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovBTN_Pesquisar.BorderColor = System.Drawing.Color.Silver;
            this.ovBTN_Pesquisar.BorderThickness = 1;
            this.ovBTN_Pesquisar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ovBTN_Pesquisar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovBTN_Pesquisar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovBTN_Pesquisar.Image = global::AutoPark.Properties.Resources.button_find;
            this.ovBTN_Pesquisar.ImageOffset = new System.Drawing.Point(-3, 0);
            this.ovBTN_Pesquisar.IndicateFocus = true;
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(1073, 110);
            this.ovBTN_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_Pesquisar.Name = "ovBTN_Pesquisar";
            this.ovBTN_Pesquisar.Size = new System.Drawing.Size(184, 46);
            this.ovBTN_Pesquisar.TabIndex = 9;
            this.ovBTN_Pesquisar.Text = "Pesquisar";
            this.ovBTN_Pesquisar.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // ovBTN_LimparFiltros
            // 
            this.ovBTN_LimparFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovBTN_LimparFiltros.BorderColor = System.Drawing.Color.Silver;
            this.ovBTN_LimparFiltros.BorderThickness = 1;
            this.ovBTN_LimparFiltros.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ovBTN_LimparFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovBTN_LimparFiltros.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovBTN_LimparFiltros.Image = global::AutoPark.Properties.Resources.button_limpar;
            this.ovBTN_LimparFiltros.ImageOffset = new System.Drawing.Point(-3, 0);
            this.ovBTN_LimparFiltros.IndicateFocus = true;
            this.ovBTN_LimparFiltros.Location = new System.Drawing.Point(1073, 52);
            this.ovBTN_LimparFiltros.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_LimparFiltros.Name = "ovBTN_LimparFiltros";
            this.ovBTN_LimparFiltros.Size = new System.Drawing.Size(184, 46);
            this.ovBTN_LimparFiltros.TabIndex = 8;
            this.ovBTN_LimparFiltros.Text = "Limpar";
            this.ovBTN_LimparFiltros.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(497, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 74;
            this.label7.Text = "Emissão:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(630, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 73;
            this.label5.Text = "Até";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(499, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 66;
            this.label1.Text = "Vencimento:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // BTN_Remover
            // 
            this.BTN_Remover.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Remover.BorderThickness = 1;
            this.BTN_Remover.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Remover.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Remover.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Remover.Image = global::AutoPark.Properties.Resources.button_remove;
            this.BTN_Remover.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_Remover.IndicateFocus = true;
            this.BTN_Remover.Location = new System.Drawing.Point(560, 3);
            this.BTN_Remover.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Remover.Name = "BTN_Remover";
            this.BTN_Remover.Size = new System.Drawing.Size(175, 40);
            this.BTN_Remover.TabIndex = 2;
            this.BTN_Remover.Text = "Remover";
            this.BTN_Remover.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // BTN_Editar
            // 
            this.BTN_Editar.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Editar.BorderThickness = 1;
            this.BTN_Editar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Editar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Editar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Editar.Image = global::AutoPark.Properties.Resources.button_edit;
            this.BTN_Editar.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_Editar.IndicateFocus = true;
            this.BTN_Editar.Location = new System.Drawing.Point(377, 3);
            this.BTN_Editar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Editar.Name = "BTN_Editar";
            this.BTN_Editar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Editar.TabIndex = 1;
            this.BTN_Editar.Text = "Editar";
            this.BTN_Editar.Click += new System.EventHandler(this.BTN_Editar_Click);
            // 
            // BTN_Novo
            // 
            this.BTN_Novo.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Novo.BorderThickness = 1;
            this.BTN_Novo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Novo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Novo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Novo.Image = global::AutoPark.Properties.Resources.button_newregister;
            this.BTN_Novo.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_Novo.IndicateFocus = true;
            this.BTN_Novo.Location = new System.Drawing.Point(194, 3);
            this.BTN_Novo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Novo.Name = "BTN_Novo";
            this.BTN_Novo.Size = new System.Drawing.Size(175, 40);
            this.BTN_Novo.TabIndex = 0;
            this.BTN_Novo.Text = "Novo";
            this.BTN_Novo.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.BTN_Selecionar);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Remover);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Editar);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Novo);
            this.flowLayoutPanel1.Controls.Add(this.BTN_RealizarLancamento);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(375, 703);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(922, 50);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // BTN_Selecionar
            // 
            this.BTN_Selecionar.BorderColor = System.Drawing.Color.Silver;
            this.BTN_Selecionar.BorderThickness = 1;
            this.BTN_Selecionar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_Selecionar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_Selecionar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_Selecionar.Image = global::AutoPark.Properties.Resources.button_selecionar;
            this.BTN_Selecionar.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_Selecionar.IndicateFocus = true;
            this.BTN_Selecionar.Location = new System.Drawing.Point(743, 3);
            this.BTN_Selecionar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Selecionar.Name = "BTN_Selecionar";
            this.BTN_Selecionar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Selecionar.TabIndex = 3;
            this.BTN_Selecionar.Text = "Selecionar";
            this.BTN_Selecionar.Visible = false;
            this.BTN_Selecionar.Click += new System.EventHandler(this.BTN_Selecionar_Click);
            // 
            // BTN_RealizarLancamento
            // 
            this.BTN_RealizarLancamento.BorderColor = System.Drawing.Color.Silver;
            this.BTN_RealizarLancamento.BorderThickness = 1;
            this.BTN_RealizarLancamento.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_RealizarLancamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_RealizarLancamento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_RealizarLancamento.Image = global::AutoPark.Properties.Resources.lancamentoconta;
            this.BTN_RealizarLancamento.ImageOffset = new System.Drawing.Point(-3, 0);
            this.BTN_RealizarLancamento.IndicateFocus = true;
            this.BTN_RealizarLancamento.Location = new System.Drawing.Point(11, 3);
            this.BTN_RealizarLancamento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_RealizarLancamento.Name = "BTN_RealizarLancamento";
            this.BTN_RealizarLancamento.Size = new System.Drawing.Size(175, 40);
            this.BTN_RealizarLancamento.TabIndex = 5;
            this.BTN_RealizarLancamento.Text = "Realizar Lançamento";
            this.BTN_RealizarLancamento.Click += new System.EventHandler(this.BTN_RealizarLancamento_Click);
            // 
            // ovGRD_Mensalidades
            // 
            this.ovGRD_Mensalidades.AllowUserToAddRows = false;
            this.ovGRD_Mensalidades.AllowUserToDeleteRows = false;
            this.ovGRD_Mensalidades.AllowUserToResizeColumns = false;
            this.ovGRD_Mensalidades.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ovGRD_Mensalidades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Mensalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Mensalidades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ovGRD_Mensalidades.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ovGRD_Mensalidades.DefaultCellStyle = dataGridViewCellStyle3;
            this.ovGRD_Mensalidades.GridColor = System.Drawing.Color.WhiteSmoke;
            this.ovGRD_Mensalidades.Location = new System.Drawing.Point(27, 252);
            this.ovGRD_Mensalidades.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovGRD_Mensalidades.MultiSelect = false;
            this.ovGRD_Mensalidades.Name = "ovGRD_Mensalidades";
            this.ovGRD_Mensalidades.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Mensalidades.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ovGRD_Mensalidades.RowHeadersVisible = false;
            this.ovGRD_Mensalidades.RowTemplate.Height = 24;
            this.ovGRD_Mensalidades.Size = new System.Drawing.Size(1265, 356);
            this.ovGRD_Mensalidades.TabIndex = 1;
            this.ovGRD_Mensalidades.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.ovGRD_Mensalidades.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.ovGRD_Mensalidades.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.ovGRD_Mensalidades.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.ovGRD_Mensalidades.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.ovGRD_Mensalidades.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.ovGRD_Mensalidades.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke;
            this.ovGRD_Mensalidades.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ovGRD_Mensalidades.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ovGRD_Mensalidades.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovGRD_Mensalidades.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ovGRD_Mensalidades.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ovGRD_Mensalidades.ThemeStyle.HeaderStyle.Height = 30;
            this.ovGRD_Mensalidades.ThemeStyle.ReadOnly = true;
            this.ovGRD_Mensalidades.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.ovGRD_Mensalidades.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ovGRD_Mensalidades.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovGRD_Mensalidades.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ovGRD_Mensalidades.ThemeStyle.RowsStyle.Height = 24;
            this.ovGRD_Mensalidades.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ovGRD_Mensalidades.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.ovGRD_Mensalidades.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Contas_CellDoubleClick);
            this.ovGRD_Mensalidades.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ovGRD_Contas_CellFormatting);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.panel5);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(27, 614);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1265, 66);
            this.groupBox3.TabIndex = 187;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Legenda";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(222)))), ((int)(((byte)(116)))));
            this.panel5.Location = new System.Drawing.Point(295, 32);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(14, 14);
            this.panel5.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(312, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "[Status] - Baixado";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(140)))), ((int)(((byte)(222)))));
            this.panel4.Location = new System.Drawing.Point(158, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(14, 14);
            this.panel4.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(175, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "[Status] - Parcial";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(195)))), ((int)(((byte)(222)))));
            this.panel2.Location = new System.Drawing.Point(23, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(14, 14);
            this.panel2.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(40, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "[Status] - Aberto";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.panel3.Location = new System.Drawing.Point(584, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(14, 14);
            this.panel3.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(600, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "[Data Vencimento] - Vencido";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(183)))), ((int)(((byte)(106)))));
            this.panel1.Location = new System.Drawing.Point(433, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 14);
            this.panel1.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(450, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "[Status] - Cancelado";
            // 
            // FCOFIN_Mensalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 773);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ovGRD_Mensalidades);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1319, 773);
            this.Name = "FCOFIN_Mensalidade";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Consulta de Mensalidade";
            this.Load += new System.EventHandler(this.FCOFIN_ContaReceber_Load);
            this.Shown += new System.EventHandler(this.FCOFIN_ContaReceber_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Mensalidades)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button BTN_Remover;
        private Guna.UI2.WinForms.Guna2Button BTN_Editar;
        private Guna.UI2.WinForms.Guna2Button BTN_Novo;
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private Guna.UI2.WinForms.Guna2Button ovBTN_LimparFiltros;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button BTN_Selecionar;
        private Guna.UI2.WinForms.Guna2DataGridView ovGRD_Mensalidades;
        private System.Windows.Forms.DateTimePicker ovTXT_VencimentoFim;
        private System.Windows.Forms.DateTimePicker ovTXT_VencimentoInicio;
        private System.Windows.Forms.DateTimePicker ovTXT_EmissaoFim;
        private System.Windows.Forms.DateTimePicker ovTXT_EmissaoInicio;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Cliente;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Codigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ovCKB_Baixado;
        private System.Windows.Forms.CheckBox ovCKB_Parcial;
        private System.Windows.Forms.CheckBox ovCKB_Cancelado;
        private System.Windows.Forms.CheckBox ovCKB_Aberto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2Button BTN_RealizarLancamento;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Placa;
        private Label label3;
    }
}