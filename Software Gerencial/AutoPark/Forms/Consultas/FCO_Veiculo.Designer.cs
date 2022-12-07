namespace AutoPark.Forms.Consultas
{
    partial class FCO_Veiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCO_Veiculo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ovTXT_Placa = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Descricao = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Cliente = new CustomControls.SyncControls.SyncTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Checkbox_Leve = new System.Windows.Forms.CheckBox();
            this.Checkbox_Pesado = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CheckBox_Ativo = new System.Windows.Forms.CheckBox();
            this.CheckBox_Inativo = new System.Windows.Forms.CheckBox();
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.ovBTN_LimparFiltros = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_Remover = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Editar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Novo = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Selecionar = new Guna.UI2.WinForms.Guna2Button();
            this.ovGRD_Veiculos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Veiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ovTXT_Placa);
            this.groupBox1.Controls.Add(this.ovTXT_Descricao);
            this.groupBox1.Controls.Add(this.ovTXT_Cliente);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.ovBTN_Pesquisar);
            this.groupBox1.Controls.Add(this.ovBTN_LimparFiltros);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(27, 73);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(883, 156);
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
            this.ovTXT_Placa.Location = new System.Drawing.Point(307, 109);
            this.ovTXT_Placa.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Placa.MaxLength = 7;
            this.ovTXT_Placa.Multiline = false;
            this.ovTXT_Placa.Name = "ovTXT_Placa";
            this.ovTXT_Placa.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Placa.PasswordChar = false;
            this.ovTXT_Placa.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Placa.PlaceholderText = "";
            this.ovTXT_Placa.ReadOnly = false;
            this.ovTXT_Placa.Size = new System.Drawing.Size(125, 33);
            this.ovTXT_Placa.TabIndex = 3;
            this.ovTXT_Placa.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Placa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.syncTextBox1_KeyPress);
            this.ovTXT_Placa.Validating += new System.ComponentModel.CancelEventHandler(this.syncTextBox1_Validating);
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Descricao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Descricao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Descricao.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Descricao.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Descricao.BorderRadius = 0;
            this.ovTXT_Descricao.BorderSize = 1;
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Descricao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Descricao.Location = new System.Drawing.Point(13, 109);
            this.ovTXT_Descricao.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Descricao.MaxLength = 150;
            this.ovTXT_Descricao.Multiline = false;
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Descricao.PasswordChar = false;
            this.ovTXT_Descricao.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Descricao.PlaceholderText = "";
            this.ovTXT_Descricao.ReadOnly = false;
            this.ovTXT_Descricao.Size = new System.Drawing.Size(271, 33);
            this.ovTXT_Descricao.TabIndex = 2;
            this.ovTXT_Descricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Descricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_RazaoSocial_KeyPress);
            // 
            // ovTXT_Cliente
            // 
            this.ovTXT_Cliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Cliente.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Cliente.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Cliente.BorderRadius = 0;
            this.ovTXT_Cliente.BorderSize = 1;
            this.ovTXT_Cliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Cliente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Cliente.Location = new System.Drawing.Point(454, 109);
            this.ovTXT_Cliente.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Cliente.MaxLength = 150;
            this.ovTXT_Cliente.Multiline = false;
            this.ovTXT_Cliente.Name = "ovTXT_Cliente";
            this.ovTXT_Cliente.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Cliente.PasswordChar = false;
            this.ovTXT_Cliente.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Cliente.PlaceholderText = "Documento/Nome";
            this.ovTXT_Cliente.ReadOnly = false;
            this.ovTXT_Cliente.Size = new System.Drawing.Size(211, 33);
            this.ovTXT_Cliente.TabIndex = 4;
            this.ovTXT_Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Cliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_CPFCNPJ_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Checkbox_Leve);
            this.groupBox3.Controls.Add(this.Checkbox_Pesado);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(183, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 62);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo";
            // 
            // Checkbox_Leve
            // 
            this.Checkbox_Leve.AutoSize = true;
            this.Checkbox_Leve.Checked = true;
            this.Checkbox_Leve.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Checkbox_Leve.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Checkbox_Leve.Location = new System.Drawing.Point(15, 27);
            this.Checkbox_Leve.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Checkbox_Leve.Name = "Checkbox_Leve";
            this.Checkbox_Leve.Size = new System.Drawing.Size(53, 21);
            this.Checkbox_Leve.TabIndex = 0;
            this.Checkbox_Leve.Text = "Leve";
            this.Checkbox_Leve.UseVisualStyleBackColor = true;
            // 
            // Checkbox_Pesado
            // 
            this.Checkbox_Pesado.AutoSize = true;
            this.Checkbox_Pesado.Checked = true;
            this.Checkbox_Pesado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Checkbox_Pesado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Checkbox_Pesado.Location = new System.Drawing.Point(80, 28);
            this.Checkbox_Pesado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Checkbox_Pesado.Name = "Checkbox_Pesado";
            this.Checkbox_Pesado.Size = new System.Drawing.Size(70, 21);
            this.Checkbox_Pesado.TabIndex = 1;
            this.Checkbox_Pesado.Text = "Pesado";
            this.Checkbox_Pesado.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CheckBox_Ativo);
            this.groupBox2.Controls.Add(this.CheckBox_Inativo);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(13, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 62);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // CheckBox_Ativo
            // 
            this.CheckBox_Ativo.AutoSize = true;
            this.CheckBox_Ativo.Checked = true;
            this.CheckBox_Ativo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Ativo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox_Ativo.Location = new System.Drawing.Point(14, 27);
            this.CheckBox_Ativo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBox_Ativo.Name = "CheckBox_Ativo";
            this.CheckBox_Ativo.Size = new System.Drawing.Size(56, 21);
            this.CheckBox_Ativo.TabIndex = 0;
            this.CheckBox_Ativo.Text = "Ativo";
            this.CheckBox_Ativo.UseVisualStyleBackColor = true;
            // 
            // CheckBox_Inativo
            // 
            this.CheckBox_Inativo.AutoSize = true;
            this.CheckBox_Inativo.Checked = true;
            this.CheckBox_Inativo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Inativo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox_Inativo.Location = new System.Drawing.Point(78, 27);
            this.CheckBox_Inativo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBox_Inativo.Name = "CheckBox_Inativo";
            this.CheckBox_Inativo.Size = new System.Drawing.Size(65, 21);
            this.CheckBox_Inativo.TabIndex = 1;
            this.CheckBox_Inativo.Text = "Inativo";
            this.CheckBox_Inativo.UseVisualStyleBackColor = true;
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
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(691, 102);
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
            this.ovBTN_LimparFiltros.Location = new System.Drawing.Point(691, 55);
            this.ovBTN_LimparFiltros.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_LimparFiltros.Name = "ovBTN_LimparFiltros";
            this.ovBTN_LimparFiltros.Size = new System.Drawing.Size(175, 40);
            this.ovBTN_LimparFiltros.TabIndex = 5;
            this.ovBTN_LimparFiltros.Text = "Limpar";
            this.ovBTN_LimparFiltros.Click += new System.EventHandler(this.ovBTN_LimparFiltros_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(307, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 57;
            this.label4.Text = "Placa:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(13, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 55;
            this.label6.Text = "Descrição:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(454, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "Cliente:";
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.BTN_Selecionar);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Remover);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Editar);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Novo);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(176, 622);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(734, 50);
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
            this.BTN_Selecionar.Location = new System.Drawing.Point(555, 3);
            this.BTN_Selecionar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Selecionar.Name = "BTN_Selecionar";
            this.BTN_Selecionar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Selecionar.TabIndex = 3;
            this.BTN_Selecionar.Text = "Selecionar";
            this.BTN_Selecionar.Visible = false;
            this.BTN_Selecionar.Click += new System.EventHandler(this.BTN_Selecionar_Click);
            // 
            // ovGRD_Veiculos
            // 
            this.ovGRD_Veiculos.AllowUserToAddRows = false;
            this.ovGRD_Veiculos.AllowUserToDeleteRows = false;
            this.ovGRD_Veiculos.AllowUserToResizeColumns = false;
            this.ovGRD_Veiculos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ovGRD_Veiculos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Veiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Veiculos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ovGRD_Veiculos.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ovGRD_Veiculos.DefaultCellStyle = dataGridViewCellStyle3;
            this.ovGRD_Veiculos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.ovGRD_Veiculos.Location = new System.Drawing.Point(27, 235);
            this.ovGRD_Veiculos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovGRD_Veiculos.MultiSelect = false;
            this.ovGRD_Veiculos.Name = "ovGRD_Veiculos";
            this.ovGRD_Veiculos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Veiculos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ovGRD_Veiculos.RowHeadersVisible = false;
            this.ovGRD_Veiculos.RowHeadersWidth = 47;
            this.ovGRD_Veiculos.RowTemplate.Height = 24;
            this.ovGRD_Veiculos.Size = new System.Drawing.Size(880, 376);
            this.ovGRD_Veiculos.TabIndex = 1;
            this.ovGRD_Veiculos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.ovGRD_Veiculos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.ovGRD_Veiculos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.ovGRD_Veiculos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.ovGRD_Veiculos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.ovGRD_Veiculos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.ovGRD_Veiculos.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke;
            this.ovGRD_Veiculos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ovGRD_Veiculos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ovGRD_Veiculos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovGRD_Veiculos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ovGRD_Veiculos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ovGRD_Veiculos.ThemeStyle.HeaderStyle.Height = 30;
            this.ovGRD_Veiculos.ThemeStyle.ReadOnly = true;
            this.ovGRD_Veiculos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.ovGRD_Veiculos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ovGRD_Veiculos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovGRD_Veiculos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ovGRD_Veiculos.ThemeStyle.RowsStyle.Height = 24;
            this.ovGRD_Veiculos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ovGRD_Veiculos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.ovGRD_Veiculos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Transportadora_CellDoubleClick);
            this.ovGRD_Veiculos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ovGRD_Transportadora_CellFormatting);
            // 
            // FCO_Veiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 692);
            this.Controls.Add(this.ovGRD_Veiculos);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(933, 692);
            this.Name = "FCO_Veiculo";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Consulta de Veículo";
            this.Load += new System.EventHandler(this.FCO_Transportadora_Load);
            this.Shown += new System.EventHandler(this.FCO_Transportadora_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Veiculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private Guna.UI2.WinForms.Guna2Button ovBTN_LimparFiltros;
        private Guna.UI2.WinForms.Guna2Button BTN_Remover;
        private Guna.UI2.WinForms.Guna2Button BTN_Editar;
        private Guna.UI2.WinForms.Guna2Button BTN_Novo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button BTN_Selecionar;
        private Guna.UI2.WinForms.Guna2DataGridView ovGRD_Veiculos;
        private System.Windows.Forms.CheckBox CheckBox_Inativo;
        private System.Windows.Forms.CheckBox CheckBox_Ativo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox Checkbox_Leve;
        private System.Windows.Forms.CheckBox Checkbox_Pesado;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Descricao;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Cliente;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Placa;
    }
}