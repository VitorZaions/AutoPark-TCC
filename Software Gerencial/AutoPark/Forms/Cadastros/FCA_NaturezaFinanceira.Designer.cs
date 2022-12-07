namespace AutoPark.Forms.Cadastro
{
    partial class FCA_NaturezaFinanceira
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_NaturezaFinanceira));
            this.label3 = new System.Windows.Forms.Label();
            this.ovCKB_Despesa = new System.Windows.Forms.RadioButton();
            this.ovCKB_Receita = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.ovCMB_NaturezaSuperior = new CustomControls.SyncControls.SyncComboBox();
            this.BTN_Limpar = new Guna.UI2.WinForms.Guna2Button();
            this.ovTXT_Descricao = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Aplicacao = new CustomControls.SyncControls.SyncTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(27, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "* Descrição:";
            // 
            // ovCKB_Despesa
            // 
            this.ovCKB_Despesa.AutoSize = true;
            this.ovCKB_Despesa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Despesa.Location = new System.Drawing.Point(808, 82);
            this.ovCKB_Despesa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Despesa.Name = "ovCKB_Despesa";
            this.ovCKB_Despesa.Size = new System.Drawing.Size(76, 21);
            this.ovCKB_Despesa.TabIndex = 1;
            this.ovCKB_Despesa.TabStop = true;
            this.ovCKB_Despesa.Text = "Despesa";
            this.ovCKB_Despesa.UseVisualStyleBackColor = true;
            // 
            // ovCKB_Receita
            // 
            this.ovCKB_Receita.AutoSize = true;
            this.ovCKB_Receita.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCKB_Receita.Location = new System.Drawing.Point(721, 82);
            this.ovCKB_Receita.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCKB_Receita.Name = "ovCKB_Receita";
            this.ovCKB_Receita.Size = new System.Drawing.Size(68, 21);
            this.ovCKB_Receita.TabIndex = 0;
            this.ovCKB_Receita.TabStop = true;
            this.ovCKB_Receita.Text = "Receita";
            this.ovCKB_Receita.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 227);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "Aplicação:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(671, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tipo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(27, 156);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 47;
            this.label4.Text = "Natureza Sup.:";
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
            this.BTN_Cancelar.TabIndex = 7;
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
            this.BTN_Salvar.Location = new System.Drawing.Point(730, 625);
            this.BTN_Salvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Salvar.TabIndex = 8;
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
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(806, 178);
            this.ovBTN_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_Pesquisar.Name = "ovBTN_Pesquisar";
            this.ovBTN_Pesquisar.Size = new System.Drawing.Size(46, 33);
            this.ovBTN_Pesquisar.TabIndex = 4;
            this.ovBTN_Pesquisar.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // ovCMB_NaturezaSuperior
            // 
            this.ovCMB_NaturezaSuperior.BackColor = System.Drawing.Color.White;
            this.ovCMB_NaturezaSuperior.BorderColor = System.Drawing.Color.DarkGray;
            this.ovCMB_NaturezaSuperior.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCMB_NaturezaSuperior.BorderSize = 1;
            this.ovCMB_NaturezaSuperior.DropDownHeight = 106;
            this.ovCMB_NaturezaSuperior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ovCMB_NaturezaSuperior.DroppedDown = false;
            this.ovCMB_NaturezaSuperior.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCMB_NaturezaSuperior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ovCMB_NaturezaSuperior.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ovCMB_NaturezaSuperior.ListBackColor = System.Drawing.Color.White;
            this.ovCMB_NaturezaSuperior.ListTextColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_NaturezaSuperior.Location = new System.Drawing.Point(29, 178);
            this.ovCMB_NaturezaSuperior.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCMB_NaturezaSuperior.Name = "ovCMB_NaturezaSuperior";
            this.ovCMB_NaturezaSuperior.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ovCMB_NaturezaSuperior.Padding = new System.Windows.Forms.Padding(1);
            this.ovCMB_NaturezaSuperior.Size = new System.Drawing.Size(768, 33);
            this.ovCMB_NaturezaSuperior.TabIndex = 3;
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
            this.BTN_Limpar.Location = new System.Drawing.Point(859, 178);
            this.BTN_Limpar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Limpar.Name = "BTN_Limpar";
            this.BTN_Limpar.Size = new System.Drawing.Size(46, 33);
            this.BTN_Limpar.TabIndex = 5;
            this.BTN_Limpar.Click += new System.EventHandler(this.BTN_Limpar_Click);
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
            this.ovTXT_Descricao.Location = new System.Drawing.Point(29, 114);
            this.ovTXT_Descricao.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Descricao.MaxLength = 150;
            this.ovTXT_Descricao.Multiline = false;
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Descricao.PasswordChar = false;
            this.ovTXT_Descricao.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Descricao.PlaceholderText = "";
            this.ovTXT_Descricao.ReadOnly = false;
            this.ovTXT_Descricao.Size = new System.Drawing.Size(875, 33);
            this.ovTXT_Descricao.TabIndex = 2;
            this.ovTXT_Descricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Aplicacao
            // 
            this.ovTXT_Aplicacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Aplicacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Aplicacao.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Aplicacao.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Aplicacao.BorderRadius = 0;
            this.ovTXT_Aplicacao.BorderSize = 1;
            this.ovTXT_Aplicacao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Aplicacao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Aplicacao.Location = new System.Drawing.Point(29, 254);
            this.ovTXT_Aplicacao.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Aplicacao.MaxLength = 150;
            this.ovTXT_Aplicacao.Multiline = true;
            this.ovTXT_Aplicacao.Name = "ovTXT_Aplicacao";
            this.ovTXT_Aplicacao.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Aplicacao.PasswordChar = false;
            this.ovTXT_Aplicacao.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Aplicacao.PlaceholderText = "";
            this.ovTXT_Aplicacao.ReadOnly = false;
            this.ovTXT_Aplicacao.Size = new System.Drawing.Size(875, 360);
            this.ovTXT_Aplicacao.TabIndex = 6;
            this.ovTXT_Aplicacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // FCA_NaturezaFinanceira
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 692);
            this.Controls.Add(this.ovTXT_Aplicacao);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Controls.Add(this.BTN_Limpar);
            this.Controls.Add(this.ovCMB_NaturezaSuperior);
            this.Controls.Add(this.ovBTN_Pesquisar);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovCKB_Despesa);
            this.Controls.Add(this.ovCKB_Receita);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(933, 692);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(933, 692);
            this.Name = "FCA_NaturezaFinanceira";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cadastro de Natureza Financeira";
            this.Load += new System.EventHandler(this.FCA_NaturezaFinanceira_Load);
            this.Shown += new System.EventHandler(this.FCA_NaturezaFinanceira_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton ovCKB_Despesa;
        private System.Windows.Forms.RadioButton ovCKB_Receita;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private CustomControls.SyncControls.SyncComboBox ovCMB_NaturezaSuperior;
        private Guna.UI2.WinForms.Guna2Button BTN_Limpar;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Descricao;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Aplicacao;
    }
}