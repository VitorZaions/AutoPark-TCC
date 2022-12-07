namespace AutoPark.Forms.Cadastro
{
    partial class FCA_PerfilAcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_PerfilAcesso));
            this.label3 = new System.Windows.Forms.Label();
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.ovCKD_ItensMenu = new System.Windows.Forms.CheckedListBox();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.IdentificacaoTab = new System.Windows.Forms.TabPage();
            this.ovTXT_Descricao = new CustomControls.SyncControls.SyncTextBox();
            this.ItensMenuTab = new System.Windows.Forms.TabPage();
            this.guna2TabControl1.SuspendLayout();
            this.IdentificacaoTab.SuspendLayout();
            this.ItensMenuTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(2, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Descrição:";
            // 
            // ovCKB_Ativo
            // 
            this.ovCKB_Ativo.AutoSize = true;
            this.ovCKB_Ativo.BackColor = System.Drawing.Color.White;
            this.ovCKB_Ativo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Ativo.Location = new System.Drawing.Point(798, 7);
            this.ovCKB_Ativo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Ativo.Name = "ovCKB_Ativo";
            this.ovCKB_Ativo.Size = new System.Drawing.Size(56, 21);
            this.ovCKB_Ativo.TabIndex = 0;
            this.ovCKB_Ativo.Text = "Ativo";
            this.ovCKB_Ativo.UseVisualStyleBackColor = false;
            // 
            // ovCKD_ItensMenu
            // 
            this.ovCKD_ItensMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovCKD_ItensMenu.CheckOnClick = true;
            this.ovCKD_ItensMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKD_ItensMenu.FormattingEnabled = true;
            this.ovCKD_ItensMenu.Location = new System.Drawing.Point(6, 7);
            this.ovCKD_ItensMenu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKD_ItensMenu.Name = "ovCKD_ItensMenu";
            this.ovCKD_ItensMenu.Size = new System.Drawing.Size(861, 480);
            this.ovCKD_ItensMenu.TabIndex = 0;
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
            this.BTN_Cancelar.Click += new System.EventHandler(this.ovBTN_Cancelar_Click);
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
            this.BTN_Salvar.Click += new System.EventHandler(this.ovBTN_Salvar_Click);
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.IdentificacaoTab);
            this.guna2TabControl1.Controls.Add(this.ItensMenuTab);
            this.guna2TabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(115, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(27, 73);
            this.guna2TabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(880, 546);
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
            // IdentificacaoTab
            // 
            this.IdentificacaoTab.BackColor = System.Drawing.Color.White;
            this.IdentificacaoTab.Controls.Add(this.ovTXT_Descricao);
            this.IdentificacaoTab.Controls.Add(this.label3);
            this.IdentificacaoTab.Controls.Add(this.ovCKB_Ativo);
            this.IdentificacaoTab.Location = new System.Drawing.Point(4, 44);
            this.IdentificacaoTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.IdentificacaoTab.Name = "IdentificacaoTab";
            this.IdentificacaoTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.IdentificacaoTab.Size = new System.Drawing.Size(872, 498);
            this.IdentificacaoTab.TabIndex = 0;
            this.IdentificacaoTab.Text = "Identificação";
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
            this.ovTXT_Descricao.Location = new System.Drawing.Point(5, 35);
            this.ovTXT_Descricao.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Descricao.MaxLength = 150;
            this.ovTXT_Descricao.Multiline = false;
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Descricao.PasswordChar = false;
            this.ovTXT_Descricao.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Descricao.PlaceholderText = "";
            this.ovTXT_Descricao.ReadOnly = false;
            this.ovTXT_Descricao.Size = new System.Drawing.Size(859, 33);
            this.ovTXT_Descricao.TabIndex = 1;
            this.ovTXT_Descricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ItensMenuTab
            // 
            this.ItensMenuTab.BackColor = System.Drawing.Color.White;
            this.ItensMenuTab.Controls.Add(this.ovCKD_ItensMenu);
            this.ItensMenuTab.Location = new System.Drawing.Point(4, 44);
            this.ItensMenuTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ItensMenuTab.Name = "ItensMenuTab";
            this.ItensMenuTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ItensMenuTab.Size = new System.Drawing.Size(872, 498);
            this.ItensMenuTab.TabIndex = 1;
            this.ItensMenuTab.Text = "Itens Menu";
            // 
            // FCA_PerfilAcesso
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
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(933, 692);
            this.Name = "FCA_PerfilAcesso";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cadastro de Perfil de Acesso";
            this.Load += new System.EventHandler(this.FCA_PerfilAcesso_Load);
            this.guna2TabControl1.ResumeLayout(false);
            this.IdentificacaoTab.ResumeLayout(false);
            this.IdentificacaoTab.PerformLayout();
            this.ItensMenuTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox ovCKD_ItensMenu;
        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage IdentificacaoTab;
        private System.Windows.Forms.TabPage ItensMenuTab;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Descricao;
    }
}