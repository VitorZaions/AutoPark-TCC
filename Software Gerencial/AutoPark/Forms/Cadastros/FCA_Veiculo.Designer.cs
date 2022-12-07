
namespace AutoPark.Forms.Cadastro
{
    partial class FCA_Veiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Veiculo));
            this.label3 = new System.Windows.Forms.Label();
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.ovCMB_Pais = new CustomControls.SyncControls.SyncComboBox();
            this.ovTXT_Descricao = new CustomControls.SyncControls.SyncTextBox();
            this.TXT_UF = new CustomControls.SyncControls.SyncTextBox();
            this.CheckBox_Ativo = new System.Windows.Forms.CheckBox();
            this.ovTXT_Cliente = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_CodCliente = new CustomControls.SyncControls.SyncTextBox();
            this.LBL_Cliente = new System.Windows.Forms.Label();
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.ovCMB_Tipo = new CustomControls.SyncControls.SyncComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Limpar = new Guna.UI2.WinForms.Guna2Button();
            this.ovTXT_Placa = new CustomControls.SyncControls.SyncTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(27, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Placa:";
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.BackColor = System.Drawing.Color.White;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(27, 85);
            this.ovLBL_RazaoSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(81, 17);
            this.ovLBL_RazaoSocial.TabIndex = 3;
            this.ovLBL_RazaoSocial.Text = "* Descrição:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(550, 164);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 17);
            this.label19.TabIndex = 138;
            this.label19.Text = "* Pais:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(805, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 137;
            this.label2.Text = "* UF:";
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
            this.BTN_Salvar.TabIndex = 11;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.BTN_Salvar_Click);
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
            this.BTN_Cancelar.TabIndex = 10;
            this.BTN_Cancelar.Text = "Cancelar";
            this.BTN_Cancelar.Click += new System.EventHandler(this.BTN_Cancelar_Click);
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
            this.ovCMB_Pais.Location = new System.Drawing.Point(550, 187);
            this.ovCMB_Pais.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCMB_Pais.Name = "ovCMB_Pais";
            this.ovCMB_Pais.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ovCMB_Pais.Padding = new System.Windows.Forms.Padding(1);
            this.ovCMB_Pais.Size = new System.Drawing.Size(226, 33);
            this.ovCMB_Pais.TabIndex = 4;
            this.ovCMB_Pais.SelectedValueChanged += new System.EventHandler(this.ovCMB_Pais_SelectedValueChanged);
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Descricao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Descricao.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Descricao.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Descricao.BorderRadius = 0;
            this.ovTXT_Descricao.BorderSize = 1;
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Descricao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Descricao.Location = new System.Drawing.Point(30, 109);
            this.ovTXT_Descricao.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Descricao.MaxLength = 150;
            this.ovTXT_Descricao.Multiline = false;
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Descricao.PasswordChar = false;
            this.ovTXT_Descricao.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Descricao.PlaceholderText = "";
            this.ovTXT_Descricao.ReadOnly = false;
            this.ovTXT_Descricao.Size = new System.Drawing.Size(874, 33);
            this.ovTXT_Descricao.TabIndex = 0;
            this.ovTXT_Descricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.TXT_UF.Location = new System.Drawing.Point(805, 187);
            this.TXT_UF.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.TXT_UF.MaxLength = 2;
            this.TXT_UF.Multiline = false;
            this.TXT_UF.Name = "TXT_UF";
            this.TXT_UF.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.TXT_UF.PasswordChar = false;
            this.TXT_UF.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TXT_UF.PlaceholderText = "";
            this.TXT_UF.ReadOnly = false;
            this.TXT_UF.Size = new System.Drawing.Size(99, 33);
            this.TXT_UF.TabIndex = 5;
            this.TXT_UF.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TXT_UF.Enter += new System.EventHandler(this.TXT_UF_Enter);
            this.TXT_UF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_UF_KeyPress);
            this.TXT_UF.Leave += new System.EventHandler(this.TXT_UF_Leave);
            // 
            // CheckBox_Ativo
            // 
            this.CheckBox_Ativo.AutoSize = true;
            this.CheckBox_Ativo.Checked = true;
            this.CheckBox_Ativo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Ativo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox_Ativo.Location = new System.Drawing.Point(838, 73);
            this.CheckBox_Ativo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBox_Ativo.Name = "CheckBox_Ativo";
            this.CheckBox_Ativo.Size = new System.Drawing.Size(56, 21);
            this.CheckBox_Ativo.TabIndex = 1;
            this.CheckBox_Ativo.Text = "Ativo";
            this.CheckBox_Ativo.UseVisualStyleBackColor = true;
            // 
            // ovTXT_Cliente
            // 
            this.ovTXT_Cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Cliente.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Cliente.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Cliente.BorderRadius = 0;
            this.ovTXT_Cliente.BorderSize = 1;
            this.ovTXT_Cliente.Enabled = false;
            this.ovTXT_Cliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Cliente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Cliente.Location = new System.Drawing.Point(309, 265);
            this.ovTXT_Cliente.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Cliente.MaxLength = 150;
            this.ovTXT_Cliente.Multiline = false;
            this.ovTXT_Cliente.Name = "ovTXT_Cliente";
            this.ovTXT_Cliente.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Cliente.PasswordChar = false;
            this.ovTXT_Cliente.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Cliente.PlaceholderText = "";
            this.ovTXT_Cliente.ReadOnly = false;
            this.ovTXT_Cliente.Size = new System.Drawing.Size(541, 33);
            this.ovTXT_Cliente.TabIndex = 8;
            this.ovTXT_Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_CodCliente
            // 
            this.ovTXT_CodCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_CodCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_CodCliente.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_CodCliente.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_CodCliente.BorderRadius = 0;
            this.ovTXT_CodCliente.BorderSize = 1;
            this.ovTXT_CodCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_CodCliente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_CodCliente.Location = new System.Drawing.Point(30, 265);
            this.ovTXT_CodCliente.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_CodCliente.MaxLength = 150;
            this.ovTXT_CodCliente.Multiline = false;
            this.ovTXT_CodCliente.Name = "ovTXT_CodCliente";
            this.ovTXT_CodCliente.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_CodCliente.PasswordChar = false;
            this.ovTXT_CodCliente.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_CodCliente.PlaceholderText = "Documento";
            this.ovTXT_CodCliente.ReadOnly = false;
            this.ovTXT_CodCliente.Size = new System.Drawing.Size(217, 33);
            this.ovTXT_CodCliente.TabIndex = 6;
            this.ovTXT_CodCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_CodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_CodCliente_KeyPress);
            this.ovTXT_CodCliente.Leave += new System.EventHandler(this.ovTXT_CodCliente_Leave);
            // 
            // LBL_Cliente
            // 
            this.LBL_Cliente.AutoSize = true;
            this.LBL_Cliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBL_Cliente.Location = new System.Drawing.Point(30, 243);
            this.LBL_Cliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Cliente.Name = "LBL_Cliente";
            this.LBL_Cliente.Size = new System.Drawing.Size(50, 17);
            this.LBL_Cliente.TabIndex = 147;
            this.LBL_Cliente.Text = "Cliente:";
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
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(255, 265);
            this.ovBTN_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_Pesquisar.Name = "ovBTN_Pesquisar";
            this.ovBTN_Pesquisar.Size = new System.Drawing.Size(46, 33);
            this.ovBTN_Pesquisar.TabIndex = 7;
            this.ovBTN_Pesquisar.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // ovCMB_Tipo
            // 
            this.ovCMB_Tipo.BackColor = System.Drawing.Color.White;
            this.ovCMB_Tipo.BorderColor = System.Drawing.Color.DarkGray;
            this.ovCMB_Tipo.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCMB_Tipo.BorderSize = 1;
            this.ovCMB_Tipo.DropDownHeight = 106;
            this.ovCMB_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ovCMB_Tipo.DroppedDown = false;
            this.ovCMB_Tipo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCMB_Tipo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_Tipo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ovCMB_Tipo.Items.AddRange(new object[] {
            "Leve",
            "Pesado"});
            this.ovCMB_Tipo.ListBackColor = System.Drawing.Color.White;
            this.ovCMB_Tipo.ListTextColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_Tipo.Location = new System.Drawing.Point(276, 187);
            this.ovCMB_Tipo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCMB_Tipo.Name = "ovCMB_Tipo";
            this.ovCMB_Tipo.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ovCMB_Tipo.Padding = new System.Windows.Forms.Padding(1);
            this.ovCMB_Tipo.Size = new System.Drawing.Size(245, 33);
            this.ovCMB_Tipo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(276, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 149;
            this.label1.Text = "* Tipo:";
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
            this.BTN_Limpar.Location = new System.Drawing.Point(858, 265);
            this.BTN_Limpar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Limpar.Name = "BTN_Limpar";
            this.BTN_Limpar.Size = new System.Drawing.Size(46, 33);
            this.BTN_Limpar.TabIndex = 9;
            this.BTN_Limpar.Click += new System.EventHandler(this.BTN_Limpar_Click);
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
            this.ovTXT_Placa.Location = new System.Drawing.Point(30, 187);
            this.ovTXT_Placa.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Placa.MaxLength = 7;
            this.ovTXT_Placa.Multiline = false;
            this.ovTXT_Placa.Name = "ovTXT_Placa";
            this.ovTXT_Placa.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Placa.PasswordChar = false;
            this.ovTXT_Placa.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Placa.PlaceholderText = "";
            this.ovTXT_Placa.ReadOnly = false;
            this.ovTXT_Placa.Size = new System.Drawing.Size(217, 33);
            this.ovTXT_Placa.TabIndex = 2;
            this.ovTXT_Placa.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Placa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_Placa_KeyPress_1);
            this.ovTXT_Placa.Validating += new System.ComponentModel.CancelEventHandler(this.ovTXT_Placa_Validating_1);
            // 
            // FCA_Veiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 692);
            this.Controls.Add(this.ovTXT_Placa);
            this.Controls.Add(this.BTN_Limpar);
            this.Controls.Add(this.ovCMB_Tipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovTXT_Cliente);
            this.Controls.Add(this.ovTXT_CodCliente);
            this.Controls.Add(this.LBL_Cliente);
            this.Controls.Add(this.ovBTN_Pesquisar);
            this.Controls.Add(this.TXT_UF);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Controls.Add(this.ovCMB_Pais);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CheckBox_Ativo);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovLBL_RazaoSocial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FCA_Veiculo";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cadastro de Veículo";
            this.Load += new System.EventHandler(this.FCA_Veiculo_Load);
            this.Shown += new System.EventHandler(this.FCA_Veiculo_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private CustomControls.SyncControls.SyncComboBox ovCMB_Pais;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label2;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Descricao;
        private CustomControls.SyncControls.SyncTextBox TXT_UF;
        private CheckBox CheckBox_Ativo;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Cliente;
        private CustomControls.SyncControls.SyncTextBox ovTXT_CodCliente;
        private Label LBL_Cliente;
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private CustomControls.SyncControls.SyncComboBox ovCMB_Tipo;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button BTN_Limpar;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Placa;
    }
}