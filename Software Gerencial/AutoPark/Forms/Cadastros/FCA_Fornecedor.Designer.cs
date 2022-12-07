namespace AutoPark.Forms.Cadastro
{
    partial class FCA_Fornecedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Fornecedor));
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.ovLBL_CNPJCPF = new System.Windows.Forms.Label();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.ovTXT_CNPJCPF = new CustomControls.SyncControls.SyncMaskedTextBox();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.GeralTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.ovCMB_TipoDocumento = new CustomControls.SyncControls.SyncComboBox();
            this.ovTXT_RazaoSocial = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_InscricaoEstadual = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_NomeFantasia = new CustomControls.SyncControls.SyncTextBox();
            this.LBL_NomeFantasia = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EnderecoTab = new System.Windows.Forms.TabPage();
            this.TXT_MunicipioDescricao = new CustomControls.SyncControls.SyncTextBox();
            this.TXT_IDMunicipio = new CustomControls.SyncControls.SyncTextBox();
            this.TXT_UF = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Logradouro = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Complemento = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Numero = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Bairro = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Cep = new CustomControls.SyncControls.SyncMaskedTextBox();
            this.ovCMB_Pais = new CustomControls.SyncControls.SyncComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ContatoTab = new System.Windows.Forms.TabPage();
            this.ovTXT_Contato_EmailAlternativo = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Contato_Email = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Contato_Celular = new CustomControls.SyncControls.SyncMaskedTextBox();
            this.ovTXT_Contato_Telefone = new CustomControls.SyncControls.SyncMaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.guna2TabControl1.SuspendLayout();
            this.GeralTab.SuspendLayout();
            this.EnderecoTab.SuspendLayout();
            this.ContatoTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.BackColor = System.Drawing.Color.White;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(177, 12);
            this.ovLBL_RazaoSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(149, 17);
            this.ovLBL_RazaoSocial.TabIndex = 69;
            this.ovLBL_RazaoSocial.Text = "* Nome / Razão Social:";
            // 
            // ovLBL_CNPJCPF
            // 
            this.ovLBL_CNPJCPF.AutoSize = true;
            this.ovLBL_CNPJCPF.BackColor = System.Drawing.Color.White;
            this.ovLBL_CNPJCPF.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovLBL_CNPJCPF.Location = new System.Drawing.Point(1, 82);
            this.ovLBL_CNPJCPF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ovLBL_CNPJCPF.Name = "ovLBL_CNPJCPF";
            this.ovLBL_CNPJCPF.Size = new System.Drawing.Size(53, 17);
            this.ovLBL_CNPJCPF.TabIndex = 74;
            this.ovLBL_CNPJCPF.Text = "* CNPJ:";
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
            this.BTN_Cancelar.TabIndex = 1;
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
            this.BTN_Salvar.TabIndex = 2;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // ovTXT_CNPJCPF
            // 
            this.ovTXT_CNPJCPF.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_CNPJCPF.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovTXT_CNPJCPF.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_CNPJCPF.Location = new System.Drawing.Point(5, 106);
            this.ovTXT_CNPJCPF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovTXT_CNPJCPF.Mask = "00,000,000/0000-00";
            this.ovTXT_CNPJCPF.Name = "ovTXT_CNPJCPF";
            this.ovTXT_CNPJCPF.PasswordChar = '\0';
            this.ovTXT_CNPJCPF.Size = new System.Drawing.Size(408, 33);
            this.ovTXT_CNPJCPF.TabIndex = 2;
            this.ovTXT_CNPJCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_CNPJCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.GeralTab);
            this.guna2TabControl1.Controls.Add(this.EnderecoTab);
            this.guna2TabControl1.Controls.Add(this.ContatoTab);
            this.guna2TabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(115, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(27, 73);
            this.guna2TabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(880, 541);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.Gray;
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.DarkGray;
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(115, 40);
            this.guna2TabControl1.TabIndex = 0;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // GeralTab
            // 
            this.GeralTab.BackColor = System.Drawing.Color.White;
            this.GeralTab.Controls.Add(this.label4);
            this.GeralTab.Controls.Add(this.ovCMB_TipoDocumento);
            this.GeralTab.Controls.Add(this.ovTXT_RazaoSocial);
            this.GeralTab.Controls.Add(this.ovTXT_InscricaoEstadual);
            this.GeralTab.Controls.Add(this.ovTXT_NomeFantasia);
            this.GeralTab.Controls.Add(this.LBL_NomeFantasia);
            this.GeralTab.Controls.Add(this.label3);
            this.GeralTab.Controls.Add(this.ovTXT_CNPJCPF);
            this.GeralTab.Controls.Add(this.ovLBL_CNPJCPF);
            this.GeralTab.Controls.Add(this.ovLBL_RazaoSocial);
            this.GeralTab.Location = new System.Drawing.Point(4, 44);
            this.GeralTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GeralTab.Name = "GeralTab";
            this.GeralTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GeralTab.Size = new System.Drawing.Size(872, 493);
            this.GeralTab.TabIndex = 0;
            this.GeralTab.Text = "Geral";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(5, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 17);
            this.label4.TabIndex = 82;
            this.label4.Text = "* Tipo de Documento:";
            // 
            // ovCMB_TipoDocumento
            // 
            this.ovCMB_TipoDocumento.BackColor = System.Drawing.Color.White;
            this.ovCMB_TipoDocumento.BorderColor = System.Drawing.Color.DarkGray;
            this.ovCMB_TipoDocumento.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCMB_TipoDocumento.BorderSize = 1;
            this.ovCMB_TipoDocumento.DropDownHeight = 106;
            this.ovCMB_TipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ovCMB_TipoDocumento.DroppedDown = false;
            this.ovCMB_TipoDocumento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCMB_TipoDocumento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_TipoDocumento.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ovCMB_TipoDocumento.Items.AddRange(new object[] {
            "CNPJ",
            "CPF"});
            this.ovCMB_TipoDocumento.ListBackColor = System.Drawing.Color.White;
            this.ovCMB_TipoDocumento.ListTextColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_TipoDocumento.Location = new System.Drawing.Point(5, 34);
            this.ovCMB_TipoDocumento.Name = "ovCMB_TipoDocumento";
            this.ovCMB_TipoDocumento.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ovCMB_TipoDocumento.Padding = new System.Windows.Forms.Padding(1);
            this.ovCMB_TipoDocumento.Size = new System.Drawing.Size(145, 33);
            this.ovCMB_TipoDocumento.TabIndex = 83;
            this.ovCMB_TipoDocumento.SelectedIndexChanged += new System.EventHandler(this.ovCMB_TipoDocumento_SelectedIndexChanged);
            // 
            // ovTXT_RazaoSocial
            // 
            this.ovTXT_RazaoSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_RazaoSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_RazaoSocial.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_RazaoSocial.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_RazaoSocial.BorderRadius = 0;
            this.ovTXT_RazaoSocial.BorderSize = 1;
            this.ovTXT_RazaoSocial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_RazaoSocial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_RazaoSocial.Location = new System.Drawing.Point(177, 34);
            this.ovTXT_RazaoSocial.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_RazaoSocial.MaxLength = 60;
            this.ovTXT_RazaoSocial.Multiline = false;
            this.ovTXT_RazaoSocial.Name = "ovTXT_RazaoSocial";
            this.ovTXT_RazaoSocial.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_RazaoSocial.PasswordChar = false;
            this.ovTXT_RazaoSocial.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_RazaoSocial.PlaceholderText = "";
            this.ovTXT_RazaoSocial.ReadOnly = false;
            this.ovTXT_RazaoSocial.Size = new System.Drawing.Size(689, 33);
            this.ovTXT_RazaoSocial.TabIndex = 1;
            this.ovTXT_RazaoSocial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_InscricaoEstadual
            // 
            this.ovTXT_InscricaoEstadual.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_InscricaoEstadual.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_InscricaoEstadual.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_InscricaoEstadual.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_InscricaoEstadual.BorderRadius = 0;
            this.ovTXT_InscricaoEstadual.BorderSize = 1;
            this.ovTXT_InscricaoEstadual.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_InscricaoEstadual.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_InscricaoEstadual.Location = new System.Drawing.Point(440, 106);
            this.ovTXT_InscricaoEstadual.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_InscricaoEstadual.MaxLength = 9;
            this.ovTXT_InscricaoEstadual.Multiline = false;
            this.ovTXT_InscricaoEstadual.Name = "ovTXT_InscricaoEstadual";
            this.ovTXT_InscricaoEstadual.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_InscricaoEstadual.PasswordChar = false;
            this.ovTXT_InscricaoEstadual.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_InscricaoEstadual.PlaceholderText = "";
            this.ovTXT_InscricaoEstadual.ReadOnly = false;
            this.ovTXT_InscricaoEstadual.Size = new System.Drawing.Size(426, 33);
            this.ovTXT_InscricaoEstadual.TabIndex = 3;
            this.ovTXT_InscricaoEstadual.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_InscricaoEstadual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_InscricaoEstadual_KeyPress);
            this.ovTXT_InscricaoEstadual.Validating += new System.ComponentModel.CancelEventHandler(this.ovTXT_InscricaoEstadual_Validating);
            // 
            // ovTXT_NomeFantasia
            // 
            this.ovTXT_NomeFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_NomeFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_NomeFantasia.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_NomeFantasia.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_NomeFantasia.BorderRadius = 0;
            this.ovTXT_NomeFantasia.BorderSize = 1;
            this.ovTXT_NomeFantasia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_NomeFantasia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_NomeFantasia.Location = new System.Drawing.Point(5, 186);
            this.ovTXT_NomeFantasia.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_NomeFantasia.MaxLength = 55;
            this.ovTXT_NomeFantasia.Multiline = false;
            this.ovTXT_NomeFantasia.Name = "ovTXT_NomeFantasia";
            this.ovTXT_NomeFantasia.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_NomeFantasia.PasswordChar = false;
            this.ovTXT_NomeFantasia.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_NomeFantasia.PlaceholderText = "";
            this.ovTXT_NomeFantasia.ReadOnly = false;
            this.ovTXT_NomeFantasia.Size = new System.Drawing.Size(407, 33);
            this.ovTXT_NomeFantasia.TabIndex = 4;
            this.ovTXT_NomeFantasia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // LBL_NomeFantasia
            // 
            this.LBL_NomeFantasia.AutoSize = true;
            this.LBL_NomeFantasia.BackColor = System.Drawing.Color.White;
            this.LBL_NomeFantasia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBL_NomeFantasia.Location = new System.Drawing.Point(2, 163);
            this.LBL_NomeFantasia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_NomeFantasia.Name = "LBL_NomeFantasia";
            this.LBL_NomeFantasia.Size = new System.Drawing.Size(93, 17);
            this.LBL_NomeFantasia.TabIndex = 81;
            this.LBL_NomeFantasia.Text = "Nome fantasia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(436, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 77;
            this.label3.Text = "Inscrição Estadual:";
            // 
            // EnderecoTab
            // 
            this.EnderecoTab.BackColor = System.Drawing.Color.White;
            this.EnderecoTab.Controls.Add(this.TXT_MunicipioDescricao);
            this.EnderecoTab.Controls.Add(this.TXT_IDMunicipio);
            this.EnderecoTab.Controls.Add(this.TXT_UF);
            this.EnderecoTab.Controls.Add(this.ovTXT_Logradouro);
            this.EnderecoTab.Controls.Add(this.ovTXT_Complemento);
            this.EnderecoTab.Controls.Add(this.ovTXT_Numero);
            this.EnderecoTab.Controls.Add(this.ovTXT_Bairro);
            this.EnderecoTab.Controls.Add(this.ovTXT_Cep);
            this.EnderecoTab.Controls.Add(this.ovCMB_Pais);
            this.EnderecoTab.Controls.Add(this.label19);
            this.EnderecoTab.Controls.Add(this.label7);
            this.EnderecoTab.Controls.Add(this.label8);
            this.EnderecoTab.Controls.Add(this.ovBTN_Pesquisar);
            this.EnderecoTab.Controls.Add(this.label9);
            this.EnderecoTab.Controls.Add(this.label13);
            this.EnderecoTab.Controls.Add(this.guna2Button1);
            this.EnderecoTab.Controls.Add(this.label20);
            this.EnderecoTab.Controls.Add(this.label10);
            this.EnderecoTab.Controls.Add(this.label11);
            this.EnderecoTab.Location = new System.Drawing.Point(4, 44);
            this.EnderecoTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EnderecoTab.Name = "EnderecoTab";
            this.EnderecoTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EnderecoTab.Size = new System.Drawing.Size(872, 493);
            this.EnderecoTab.TabIndex = 1;
            this.EnderecoTab.Text = "Endereço";
            // 
            // TXT_MunicipioDescricao
            // 
            this.TXT_MunicipioDescricao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TXT_MunicipioDescricao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TXT_MunicipioDescricao.BorderColor = System.Drawing.Color.DarkGray;
            this.TXT_MunicipioDescricao.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.TXT_MunicipioDescricao.BorderRadius = 0;
            this.TXT_MunicipioDescricao.BorderSize = 1;
            this.TXT_MunicipioDescricao.Enabled = false;
            this.TXT_MunicipioDescricao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TXT_MunicipioDescricao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TXT_MunicipioDescricao.Location = new System.Drawing.Point(593, 29);
            this.TXT_MunicipioDescricao.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.TXT_MunicipioDescricao.MaxLength = 50;
            this.TXT_MunicipioDescricao.Multiline = false;
            this.TXT_MunicipioDescricao.Name = "TXT_MunicipioDescricao";
            this.TXT_MunicipioDescricao.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.TXT_MunicipioDescricao.PasswordChar = false;
            this.TXT_MunicipioDescricao.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TXT_MunicipioDescricao.PlaceholderText = "";
            this.TXT_MunicipioDescricao.ReadOnly = false;
            this.TXT_MunicipioDescricao.Size = new System.Drawing.Size(273, 33);
            this.TXT_MunicipioDescricao.TabIndex = 4;
            this.TXT_MunicipioDescricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // TXT_IDMunicipio
            // 
            this.TXT_IDMunicipio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TXT_IDMunicipio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TXT_IDMunicipio.BorderColor = System.Drawing.Color.DarkGray;
            this.TXT_IDMunicipio.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.TXT_IDMunicipio.BorderRadius = 0;
            this.TXT_IDMunicipio.BorderSize = 1;
            this.TXT_IDMunicipio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TXT_IDMunicipio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TXT_IDMunicipio.Location = new System.Drawing.Point(444, 29);
            this.TXT_IDMunicipio.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.TXT_IDMunicipio.MaxLength = 18;
            this.TXT_IDMunicipio.Multiline = false;
            this.TXT_IDMunicipio.Name = "TXT_IDMunicipio";
            this.TXT_IDMunicipio.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.TXT_IDMunicipio.PasswordChar = false;
            this.TXT_IDMunicipio.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TXT_IDMunicipio.PlaceholderText = "C.IBGE";
            this.TXT_IDMunicipio.ReadOnly = false;
            this.TXT_IDMunicipio.Size = new System.Drawing.Size(98, 33);
            this.TXT_IDMunicipio.TabIndex = 2;
            this.TXT_IDMunicipio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TXT_IDMunicipio.Enter += new System.EventHandler(this.TXT_IDMunicipio_Enter);
            this.TXT_IDMunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_IDMunicipio_KeyPress);
            this.TXT_IDMunicipio.Leave += new System.EventHandler(this.TXT_IDMunicipio_Leave);
            this.TXT_IDMunicipio.Validating += new System.ComponentModel.CancelEventHandler(this.TXT_IDMunicipio_Validating);
            // 
            // TXT_UF
            // 
            this.TXT_UF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TXT_UF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TXT_UF.BorderColor = System.Drawing.Color.DarkGray;
            this.TXT_UF.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.TXT_UF.BorderRadius = 0;
            this.TXT_UF.BorderSize = 1;
            this.TXT_UF.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TXT_UF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TXT_UF.Location = new System.Drawing.Point(271, 29);
            this.TXT_UF.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.TXT_UF.MaxLength = 2;
            this.TXT_UF.Multiline = false;
            this.TXT_UF.Name = "TXT_UF";
            this.TXT_UF.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.TXT_UF.PasswordChar = false;
            this.TXT_UF.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TXT_UF.PlaceholderText = "";
            this.TXT_UF.ReadOnly = false;
            this.TXT_UF.Size = new System.Drawing.Size(152, 33);
            this.TXT_UF.TabIndex = 1;
            this.TXT_UF.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TXT_UF.Enter += new System.EventHandler(this.TXT_UF_Enter);
            this.TXT_UF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_UF_KeyPress);
            this.TXT_UF.Leave += new System.EventHandler(this.TXT_UF_Leave);
            // 
            // ovTXT_Logradouro
            // 
            this.ovTXT_Logradouro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Logradouro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Logradouro.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Logradouro.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Logradouro.BorderRadius = 0;
            this.ovTXT_Logradouro.BorderSize = 1;
            this.ovTXT_Logradouro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Logradouro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Logradouro.Location = new System.Drawing.Point(444, 105);
            this.ovTXT_Logradouro.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Logradouro.MaxLength = 150;
            this.ovTXT_Logradouro.Multiline = false;
            this.ovTXT_Logradouro.Name = "ovTXT_Logradouro";
            this.ovTXT_Logradouro.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Logradouro.PasswordChar = false;
            this.ovTXT_Logradouro.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Logradouro.PlaceholderText = "";
            this.ovTXT_Logradouro.ReadOnly = false;
            this.ovTXT_Logradouro.Size = new System.Drawing.Size(422, 33);
            this.ovTXT_Logradouro.TabIndex = 6;
            this.ovTXT_Logradouro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Complemento
            // 
            this.ovTXT_Complemento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Complemento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Complemento.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Complemento.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Complemento.BorderRadius = 0;
            this.ovTXT_Complemento.BorderSize = 1;
            this.ovTXT_Complemento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Complemento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Complemento.Location = new System.Drawing.Point(444, 172);
            this.ovTXT_Complemento.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Complemento.MaxLength = 150;
            this.ovTXT_Complemento.Multiline = false;
            this.ovTXT_Complemento.Name = "ovTXT_Complemento";
            this.ovTXT_Complemento.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Complemento.PasswordChar = false;
            this.ovTXT_Complemento.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Complemento.PlaceholderText = "";
            this.ovTXT_Complemento.ReadOnly = false;
            this.ovTXT_Complemento.Size = new System.Drawing.Size(422, 33);
            this.ovTXT_Complemento.TabIndex = 9;
            this.ovTXT_Complemento.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.ovTXT_Numero.Location = new System.Drawing.Point(317, 172);
            this.ovTXT_Numero.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Numero.MaxLength = 6;
            this.ovTXT_Numero.Multiline = false;
            this.ovTXT_Numero.Name = "ovTXT_Numero";
            this.ovTXT_Numero.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Numero.PasswordChar = false;
            this.ovTXT_Numero.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Numero.PlaceholderText = "";
            this.ovTXT_Numero.ReadOnly = false;
            this.ovTXT_Numero.Size = new System.Drawing.Size(106, 33);
            this.ovTXT_Numero.TabIndex = 8;
            this.ovTXT_Numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Numero.Validating += new System.ComponentModel.CancelEventHandler(this.ovTXT_Numero_Validating);
            // 
            // ovTXT_Bairro
            // 
            this.ovTXT_Bairro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Bairro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Bairro.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Bairro.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Bairro.BorderRadius = 0;
            this.ovTXT_Bairro.BorderSize = 1;
            this.ovTXT_Bairro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Bairro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Bairro.Location = new System.Drawing.Point(5, 172);
            this.ovTXT_Bairro.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Bairro.MaxLength = 150;
            this.ovTXT_Bairro.Multiline = false;
            this.ovTXT_Bairro.Name = "ovTXT_Bairro";
            this.ovTXT_Bairro.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Bairro.PasswordChar = false;
            this.ovTXT_Bairro.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Bairro.PlaceholderText = "";
            this.ovTXT_Bairro.ReadOnly = false;
            this.ovTXT_Bairro.Size = new System.Drawing.Size(291, 33);
            this.ovTXT_Bairro.TabIndex = 7;
            this.ovTXT_Bairro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Cep
            // 
            this.ovTXT_Cep.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Cep.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovTXT_Cep.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_Cep.Location = new System.Drawing.Point(5, 105);
            this.ovTXT_Cep.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovTXT_Cep.Mask = "00000-000";
            this.ovTXT_Cep.Name = "ovTXT_Cep";
            this.ovTXT_Cep.PasswordChar = '\0';
            this.ovTXT_Cep.Size = new System.Drawing.Size(418, 33);
            this.ovTXT_Cep.TabIndex = 5;
            this.ovTXT_Cep.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Cep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // ovCMB_Pais
            // 
            this.ovCMB_Pais.BackColor = System.Drawing.Color.White;
            this.ovCMB_Pais.BorderColor = System.Drawing.Color.DarkGray;
            this.ovCMB_Pais.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCMB_Pais.BorderSize = 1;
            this.ovCMB_Pais.DropDownHeight = 106;
            this.ovCMB_Pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ovCMB_Pais.DroppedDown = false;
            this.ovCMB_Pais.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCMB_Pais.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_Pais.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ovCMB_Pais.ListBackColor = System.Drawing.Color.White;
            this.ovCMB_Pais.ListTextColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_Pais.Location = new System.Drawing.Point(5, 29);
            this.ovCMB_Pais.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCMB_Pais.Name = "ovCMB_Pais";
            this.ovCMB_Pais.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ovCMB_Pais.Padding = new System.Windows.Forms.Padding(1);
            this.ovCMB_Pais.Size = new System.Drawing.Size(258, 33);
            this.ovCMB_Pais.TabIndex = 0;
            this.ovCMB_Pais.SelectedValueChanged += new System.EventHandler(this.ovCMB_Pais_SelectedValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(1, 6);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 17);
            this.label19.TabIndex = 61;
            this.label19.Text = "Pais:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(313, 150);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Nº:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(440, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "Logradouro:";
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
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(550, 29);
            this.ovBTN_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_Pesquisar.Name = "ovBTN_Pesquisar";
            this.ovBTN_Pesquisar.Size = new System.Drawing.Size(35, 33);
            this.ovBTN_Pesquisar.TabIndex = 3;
            this.ovBTN_Pesquisar.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(440, 150);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 33;
            this.label9.Text = "Complemento:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(267, 6);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 17);
            this.label13.TabIndex = 41;
            this.label13.Text = "UF:";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2Button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2Button1.Image = global::AutoPark.Properties.Resources.button_find;
            this.guna2Button1.ImageOffset = new System.Drawing.Point(-3, 0);
            this.guna2Button1.ImageSize = new System.Drawing.Size(15, 15);
            this.guna2Button1.IndicateFocus = true;
            this.guna2Button1.Location = new System.Drawing.Point(288, 75);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(134, 25);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.TabStop = false;
            this.guna2Button1.Text = "Localizar CEP";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(439, 6);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 17);
            this.label20.TabIndex = 62;
            this.label20.Text = "Município:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(1, 150);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "Bairro:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(1, 81);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 17);
            this.label11.TabIndex = 66;
            this.label11.Text = "CEP:";
            // 
            // ContatoTab
            // 
            this.ContatoTab.BackColor = System.Drawing.Color.White;
            this.ContatoTab.Controls.Add(this.ovTXT_Contato_EmailAlternativo);
            this.ContatoTab.Controls.Add(this.ovTXT_Contato_Email);
            this.ContatoTab.Controls.Add(this.ovTXT_Contato_Celular);
            this.ContatoTab.Controls.Add(this.ovTXT_Contato_Telefone);
            this.ContatoTab.Controls.Add(this.label17);
            this.ContatoTab.Controls.Add(this.label15);
            this.ContatoTab.Controls.Add(this.label16);
            this.ContatoTab.Controls.Add(this.label21);
            this.ContatoTab.Location = new System.Drawing.Point(4, 44);
            this.ContatoTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ContatoTab.Name = "ContatoTab";
            this.ContatoTab.Size = new System.Drawing.Size(872, 493);
            this.ContatoTab.TabIndex = 2;
            this.ContatoTab.Text = "Contato";
            // 
            // ovTXT_Contato_EmailAlternativo
            // 
            this.ovTXT_Contato_EmailAlternativo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Contato_EmailAlternativo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Contato_EmailAlternativo.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Contato_EmailAlternativo.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Contato_EmailAlternativo.BorderRadius = 0;
            this.ovTXT_Contato_EmailAlternativo.BorderSize = 1;
            this.ovTXT_Contato_EmailAlternativo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Contato_EmailAlternativo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Contato_EmailAlternativo.Location = new System.Drawing.Point(444, 100);
            this.ovTXT_Contato_EmailAlternativo.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Contato_EmailAlternativo.MaxLength = 1000;
            this.ovTXT_Contato_EmailAlternativo.Multiline = false;
            this.ovTXT_Contato_EmailAlternativo.Name = "ovTXT_Contato_EmailAlternativo";
            this.ovTXT_Contato_EmailAlternativo.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Contato_EmailAlternativo.PasswordChar = false;
            this.ovTXT_Contato_EmailAlternativo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Contato_EmailAlternativo.PlaceholderText = "";
            this.ovTXT_Contato_EmailAlternativo.ReadOnly = false;
            this.ovTXT_Contato_EmailAlternativo.Size = new System.Drawing.Size(422, 33);
            this.ovTXT_Contato_EmailAlternativo.TabIndex = 3;
            this.ovTXT_Contato_EmailAlternativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Contato_Email
            // 
            this.ovTXT_Contato_Email.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Contato_Email.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Contato_Email.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Contato_Email.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Contato_Email.BorderRadius = 0;
            this.ovTXT_Contato_Email.BorderSize = 1;
            this.ovTXT_Contato_Email.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Contato_Email.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Contato_Email.Location = new System.Drawing.Point(5, 100);
            this.ovTXT_Contato_Email.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Contato_Email.MaxLength = 1000;
            this.ovTXT_Contato_Email.Multiline = false;
            this.ovTXT_Contato_Email.Name = "ovTXT_Contato_Email";
            this.ovTXT_Contato_Email.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Contato_Email.PasswordChar = false;
            this.ovTXT_Contato_Email.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Contato_Email.PlaceholderText = "";
            this.ovTXT_Contato_Email.ReadOnly = false;
            this.ovTXT_Contato_Email.Size = new System.Drawing.Size(418, 33);
            this.ovTXT_Contato_Email.TabIndex = 2;
            this.ovTXT_Contato_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Contato_Celular
            // 
            this.ovTXT_Contato_Celular.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Contato_Celular.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovTXT_Contato_Celular.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_Contato_Celular.Location = new System.Drawing.Point(444, 29);
            this.ovTXT_Contato_Celular.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovTXT_Contato_Celular.Mask = "(00) 00000-0000";
            this.ovTXT_Contato_Celular.Name = "ovTXT_Contato_Celular";
            this.ovTXT_Contato_Celular.PasswordChar = '\0';
            this.ovTXT_Contato_Celular.Size = new System.Drawing.Size(422, 33);
            this.ovTXT_Contato_Celular.TabIndex = 1;
            this.ovTXT_Contato_Celular.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Contato_Celular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // ovTXT_Contato_Telefone
            // 
            this.ovTXT_Contato_Telefone.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Contato_Telefone.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovTXT_Contato_Telefone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_Contato_Telefone.Location = new System.Drawing.Point(5, 29);
            this.ovTXT_Contato_Telefone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovTXT_Contato_Telefone.Mask = "(00) 0000-0000";
            this.ovTXT_Contato_Telefone.Name = "ovTXT_Contato_Telefone";
            this.ovTXT_Contato_Telefone.PasswordChar = '\0';
            this.ovTXT_Contato_Telefone.Size = new System.Drawing.Size(418, 33);
            this.ovTXT_Contato_Telefone.TabIndex = 0;
            this.ovTXT_Contato_Telefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Contato_Telefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(441, 78);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 17);
            this.label17.TabIndex = 40;
            this.label17.Text = "E-mail Alt:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(1, 7);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 17);
            this.label15.TabIndex = 38;
            this.label15.Text = "Telefone:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(2, 80);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 17);
            this.label16.TabIndex = 39;
            this.label16.Text = "E-mail:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(441, 7);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(51, 17);
            this.label21.TabIndex = 36;
            this.label21.Text = "Celular:";
            // 
            // FCA_Fornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 692);
            this.Controls.Add(this.guna2TabControl1);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Salvar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(933, 692);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(933, 692);
            this.Name = "FCA_Fornecedor";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cadastro de Fornecedor";
            this.Load += new System.EventHandler(this.FCA_Fornecedor_Load);
            this.Shown += new System.EventHandler(this.FCA_Fornecedor_Shown);
            this.guna2TabControl1.ResumeLayout(false);
            this.GeralTab.ResumeLayout(false);
            this.GeralTab.PerformLayout();
            this.EnderecoTab.ResumeLayout(false);
            this.EnderecoTab.PerformLayout();
            this.ContatoTab.ResumeLayout(false);
            this.ContatoTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private System.Windows.Forms.Label ovLBL_CNPJCPF;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private CustomControls.SyncControls.SyncMaskedTextBox ovTXT_CNPJCPF;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage GeralTab;
        private System.Windows.Forms.TabPage EnderecoTab;
        private CustomControls.SyncControls.SyncMaskedTextBox ovTXT_Cep;
        private CustomControls.SyncControls.SyncComboBox ovCMB_Pais;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage ContatoTab;
        private CustomControls.SyncControls.SyncMaskedTextBox ovTXT_Contato_Celular;
        private CustomControls.SyncControls.SyncMaskedTextBox ovTXT_Contato_Telefone;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBL_NomeFantasia;
        private CustomControls.SyncControls.SyncTextBox ovTXT_RazaoSocial;
        private CustomControls.SyncControls.SyncTextBox ovTXT_InscricaoEstadual;
        private CustomControls.SyncControls.SyncTextBox ovTXT_NomeFantasia;
        private CustomControls.SyncControls.SyncTextBox TXT_MunicipioDescricao;
        private CustomControls.SyncControls.SyncTextBox TXT_IDMunicipio;
        private CustomControls.SyncControls.SyncTextBox TXT_UF;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Logradouro;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Complemento;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Numero;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Bairro;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Contato_EmailAlternativo;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Contato_Email;
        private System.Windows.Forms.Label label4;
        private CustomControls.SyncControls.SyncComboBox ovCMB_TipoDocumento;
    }
}