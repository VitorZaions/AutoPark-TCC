namespace AutoPark.Forms.Consultas
{
    partial class FCO_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCO_Cliente));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ovTXT_CPFCNPJ = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_RazaoSocial = new CustomControls.SyncControls.SyncTextBox();
            this.CheckBox_Inativo = new System.Windows.Forms.CheckBox();
            this.CheckBox_Ativo = new System.Windows.Forms.CheckBox();
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.ovBTN_LimparFiltros = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Remover = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Editar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Novo = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Selecionar = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ovGRD_Clientes = new Guna.UI2.WinForms.Guna2DataGridView();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ovTXT_CPFCNPJ);
            this.groupBox1.Controls.Add(this.ovTXT_RazaoSocial);
            this.groupBox1.Controls.Add(this.CheckBox_Inativo);
            this.groupBox1.Controls.Add(this.CheckBox_Ativo);
            this.groupBox1.Controls.Add(this.ovBTN_Pesquisar);
            this.groupBox1.Controls.Add(this.ovBTN_LimparFiltros);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(27, 73);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(891, 137);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de pesquisa";
            // 
            // ovTXT_CPFCNPJ
            // 
            this.ovTXT_CPFCNPJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_CPFCNPJ.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_CPFCNPJ.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_CPFCNPJ.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_CPFCNPJ.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_CPFCNPJ.BorderRadius = 0;
            this.ovTXT_CPFCNPJ.BorderSize = 1;
            this.ovTXT_CPFCNPJ.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_CPFCNPJ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_CPFCNPJ.Location = new System.Drawing.Point(410, 83);
            this.ovTXT_CPFCNPJ.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_CPFCNPJ.MaxLength = 14;
            this.ovTXT_CPFCNPJ.Multiline = false;
            this.ovTXT_CPFCNPJ.Name = "ovTXT_CPFCNPJ";
            this.ovTXT_CPFCNPJ.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_CPFCNPJ.PasswordChar = false;
            this.ovTXT_CPFCNPJ.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_CPFCNPJ.PlaceholderText = "";
            this.ovTXT_CPFCNPJ.ReadOnly = false;
            this.ovTXT_CPFCNPJ.Size = new System.Drawing.Size(237, 33);
            this.ovTXT_CPFCNPJ.TabIndex = 4;
            this.ovTXT_CPFCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_CPFCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2TextBox1_KeyPress);
            this.ovTXT_CPFCNPJ.Validating += new System.ComponentModel.CancelEventHandler(this.ovTXT_CPFCNPJ_Validating);
            // 
            // ovTXT_RazaoSocial
            // 
            this.ovTXT_RazaoSocial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_RazaoSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_RazaoSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_RazaoSocial.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_RazaoSocial.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_RazaoSocial.BorderRadius = 0;
            this.ovTXT_RazaoSocial.BorderSize = 1;
            this.ovTXT_RazaoSocial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_RazaoSocial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_RazaoSocial.Location = new System.Drawing.Point(19, 83);
            this.ovTXT_RazaoSocial.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_RazaoSocial.MaxLength = 150;
            this.ovTXT_RazaoSocial.Multiline = false;
            this.ovTXT_RazaoSocial.Name = "ovTXT_RazaoSocial";
            this.ovTXT_RazaoSocial.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_RazaoSocial.PasswordChar = false;
            this.ovTXT_RazaoSocial.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_RazaoSocial.PlaceholderText = "";
            this.ovTXT_RazaoSocial.ReadOnly = false;
            this.ovTXT_RazaoSocial.Size = new System.Drawing.Size(363, 33);
            this.ovTXT_RazaoSocial.TabIndex = 2;
            this.ovTXT_RazaoSocial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_RazaoSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_RazaoSocial_KeyPress);
            // 
            // CheckBox_Inativo
            // 
            this.CheckBox_Inativo.AutoSize = true;
            this.CheckBox_Inativo.Checked = true;
            this.CheckBox_Inativo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Inativo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox_Inativo.Location = new System.Drawing.Point(91, 28);
            this.CheckBox_Inativo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBox_Inativo.Name = "CheckBox_Inativo";
            this.CheckBox_Inativo.Size = new System.Drawing.Size(65, 21);
            this.CheckBox_Inativo.TabIndex = 1;
            this.CheckBox_Inativo.Text = "Inativo";
            this.CheckBox_Inativo.UseVisualStyleBackColor = true;
            // 
            // CheckBox_Ativo
            // 
            this.CheckBox_Ativo.AutoSize = true;
            this.CheckBox_Ativo.Checked = true;
            this.CheckBox_Ativo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Ativo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox_Ativo.Location = new System.Drawing.Point(19, 28);
            this.CheckBox_Ativo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBox_Ativo.Name = "CheckBox_Ativo";
            this.CheckBox_Ativo.Size = new System.Drawing.Size(56, 21);
            this.CheckBox_Ativo.TabIndex = 0;
            this.CheckBox_Ativo.Text = "Ativo";
            this.CheckBox_Ativo.UseVisualStyleBackColor = true;
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
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(699, 78);
            this.ovBTN_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_Pesquisar.Name = "ovBTN_Pesquisar";
            this.ovBTN_Pesquisar.Size = new System.Drawing.Size(175, 40);
            this.ovBTN_Pesquisar.TabIndex = 6;
            this.ovBTN_Pesquisar.Text = "Pesquisar";
            this.ovBTN_Pesquisar.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
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
            this.ovBTN_LimparFiltros.Location = new System.Drawing.Point(699, 30);
            this.ovBTN_LimparFiltros.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_LimparFiltros.Name = "ovBTN_LimparFiltros";
            this.ovBTN_LimparFiltros.Size = new System.Drawing.Size(175, 40);
            this.ovBTN_LimparFiltros.TabIndex = 5;
            this.ovBTN_LimparFiltros.Text = "Limpar";
            this.ovBTN_LimparFiltros.Click += new System.EventHandler(this.ovBTN_LimparFiltros_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(410, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPF/CNPJ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome/Razão Social:";
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
            this.BTN_Remover.Location = new System.Drawing.Point(372, 3);
            this.BTN_Remover.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Remover.Name = "BTN_Remover";
            this.BTN_Remover.Size = new System.Drawing.Size(175, 40);
            this.BTN_Remover.TabIndex = 2;
            this.BTN_Remover.Text = "Remover";
            this.BTN_Remover.Click += new System.EventHandler(this.ovBTN_Excluir_Click);
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
            this.BTN_Editar.Location = new System.Drawing.Point(189, 3);
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
            this.BTN_Novo.Location = new System.Drawing.Point(6, 3);
            this.BTN_Novo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Novo.Name = "BTN_Novo";
            this.BTN_Novo.Size = new System.Drawing.Size(175, 40);
            this.BTN_Novo.TabIndex = 0;
            this.BTN_Novo.Text = "Novo";
            this.BTN_Novo.Click += new System.EventHandler(this.ovBTN_Novo_Click);
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
            this.BTN_Selecionar.Location = new System.Drawing.Point(555, 3);
            this.BTN_Selecionar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Selecionar.Name = "BTN_Selecionar";
            this.BTN_Selecionar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Selecionar.TabIndex = 3;
            this.BTN_Selecionar.Text = "Selecionar";
            this.BTN_Selecionar.Visible = false;
            this.BTN_Selecionar.Click += new System.EventHandler(this.BTN_Selecionar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.BTN_Selecionar);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Remover);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Editar);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Novo);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(184, 677);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(734, 50);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // ovGRD_Clientes
            // 
            this.ovGRD_Clientes.AllowUserToAddRows = false;
            this.ovGRD_Clientes.AllowUserToDeleteRows = false;
            this.ovGRD_Clientes.AllowUserToResizeColumns = false;
            this.ovGRD_Clientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ovGRD_Clientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Clientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Clientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ovGRD_Clientes.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ovGRD_Clientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.ovGRD_Clientes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.ovGRD_Clientes.Location = new System.Drawing.Point(27, 217);
            this.ovGRD_Clientes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovGRD_Clientes.MultiSelect = false;
            this.ovGRD_Clientes.Name = "ovGRD_Clientes";
            this.ovGRD_Clientes.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Clientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ovGRD_Clientes.RowHeadersVisible = false;
            this.ovGRD_Clientes.RowTemplate.Height = 24;
            this.ovGRD_Clientes.Size = new System.Drawing.Size(891, 446);
            this.ovGRD_Clientes.TabIndex = 1;
            this.ovGRD_Clientes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.ovGRD_Clientes.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.ovGRD_Clientes.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.ovGRD_Clientes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.ovGRD_Clientes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.ovGRD_Clientes.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.ovGRD_Clientes.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke;
            this.ovGRD_Clientes.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ovGRD_Clientes.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ovGRD_Clientes.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovGRD_Clientes.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ovGRD_Clientes.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ovGRD_Clientes.ThemeStyle.HeaderStyle.Height = 30;
            this.ovGRD_Clientes.ThemeStyle.ReadOnly = true;
            this.ovGRD_Clientes.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.ovGRD_Clientes.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ovGRD_Clientes.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovGRD_Clientes.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ovGRD_Clientes.ThemeStyle.RowsStyle.Height = 24;
            this.ovGRD_Clientes.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ovGRD_Clientes.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.ovGRD_Clientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Clientes_CellDoubleClick);
            this.ovGRD_Clientes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ovGRD_Clientes_CellFormatting);
            // 
            // FCO_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 750);
            this.Controls.Add(this.ovGRD_Clientes);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(945, 750);
            this.Name = "FCO_Cliente";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Consulta de Cliente";
            this.Load += new System.EventHandler(this.FCO_Cliente_Load);
            this.Shown += new System.EventHandler(this.FCO_Cliente_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Clientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button BTN_Remover;
        private Guna.UI2.WinForms.Guna2Button BTN_Editar;
        private Guna.UI2.WinForms.Guna2Button BTN_Novo;
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private Guna.UI2.WinForms.Guna2Button ovBTN_LimparFiltros;
        private Guna.UI2.WinForms.Guna2Button BTN_Selecionar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView ovGRD_Clientes;
        private System.Windows.Forms.CheckBox CheckBox_Ativo;
        private System.Windows.Forms.CheckBox CheckBox_Inativo;
        private CustomControls.SyncControls.SyncTextBox ovTXT_CPFCNPJ;
        private CustomControls.SyncControls.SyncTextBox ovTXT_RazaoSocial;
    }
}