namespace AutoPark.Forms.Cadastro
{
    partial class FCA_CentroCusto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_CentroCusto));
            this.label3 = new System.Windows.Forms.Label();
            this.ovLBL_Centro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ovCMB_CentroCustoSuperior = new CustomControls.SyncControls.SyncComboBox();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Limpar = new Guna.UI2.WinForms.Guna2Button();
            this.ovBTN_Pesquisar = new Guna.UI2.WinForms.Guna2Button();
            this.ovTXT_Centro = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Descricao = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Obs = new CustomControls.SyncControls.SyncTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(27, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "* Descrição:";
            // 
            // ovLBL_Centro
            // 
            this.ovLBL_Centro.AutoSize = true;
            this.ovLBL_Centro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovLBL_Centro.Location = new System.Drawing.Point(27, 87);
            this.ovLBL_Centro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ovLBL_Centro.Name = "ovLBL_Centro";
            this.ovLBL_Centro.Size = new System.Drawing.Size(63, 17);
            this.ovLBL_Centro.TabIndex = 16;
            this.ovLBL_Centro.Text = "* Centro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 300);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Observação:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(27, 226);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 50;
            this.label4.Text = "Centro C. Sup.:";
            // 
            // ovCMB_CentroCustoSuperior
            // 
            this.ovCMB_CentroCustoSuperior.BackColor = System.Drawing.Color.White;
            this.ovCMB_CentroCustoSuperior.BorderColor = System.Drawing.Color.DarkGray;
            this.ovCMB_CentroCustoSuperior.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCMB_CentroCustoSuperior.BorderSize = 1;
            this.ovCMB_CentroCustoSuperior.DropDownHeight = 106;
            this.ovCMB_CentroCustoSuperior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ovCMB_CentroCustoSuperior.DroppedDown = false;
            this.ovCMB_CentroCustoSuperior.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovCMB_CentroCustoSuperior.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_CentroCustoSuperior.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ovCMB_CentroCustoSuperior.ListBackColor = System.Drawing.Color.White;
            this.ovCMB_CentroCustoSuperior.ListTextColor = System.Drawing.SystemColors.ControlText;
            this.ovCMB_CentroCustoSuperior.Location = new System.Drawing.Point(30, 248);
            this.ovCMB_CentroCustoSuperior.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovCMB_CentroCustoSuperior.Name = "ovCMB_CentroCustoSuperior";
            this.ovCMB_CentroCustoSuperior.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ovCMB_CentroCustoSuperior.Padding = new System.Windows.Forms.Padding(1);
            this.ovCMB_CentroCustoSuperior.Size = new System.Drawing.Size(769, 33);
            this.ovCMB_CentroCustoSuperior.TabIndex = 2;
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
            this.BTN_Cancelar.TabIndex = 6;
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
            this.BTN_Salvar.TabIndex = 7;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.metroButton4_Click);
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
            this.BTN_Limpar.Location = new System.Drawing.Point(860, 248);
            this.BTN_Limpar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Limpar.Name = "BTN_Limpar";
            this.BTN_Limpar.Size = new System.Drawing.Size(46, 33);
            this.BTN_Limpar.TabIndex = 4;
            this.BTN_Limpar.Click += new System.EventHandler(this.BTN_Limpar_Click);
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
            this.ovBTN_Pesquisar.Location = new System.Drawing.Point(807, 248);
            this.ovBTN_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovBTN_Pesquisar.Name = "ovBTN_Pesquisar";
            this.ovBTN_Pesquisar.Size = new System.Drawing.Size(46, 33);
            this.ovBTN_Pesquisar.TabIndex = 3;
            this.ovBTN_Pesquisar.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // ovTXT_Centro
            // 
            this.ovTXT_Centro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Centro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Centro.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Centro.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Centro.BorderRadius = 0;
            this.ovTXT_Centro.BorderSize = 1;
            this.ovTXT_Centro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Centro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Centro.Location = new System.Drawing.Point(30, 114);
            this.ovTXT_Centro.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Centro.MaxLength = 150;
            this.ovTXT_Centro.Multiline = false;
            this.ovTXT_Centro.Name = "ovTXT_Centro";
            this.ovTXT_Centro.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Centro.PasswordChar = false;
            this.ovTXT_Centro.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Centro.PlaceholderText = "";
            this.ovTXT_Centro.ReadOnly = false;
            this.ovTXT_Centro.Size = new System.Drawing.Size(875, 33);
            this.ovTXT_Centro.TabIndex = 0;
            this.ovTXT_Centro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.ovTXT_Descricao.Location = new System.Drawing.Point(30, 184);
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
            this.ovTXT_Descricao.TabIndex = 1;
            this.ovTXT_Descricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Obs
            // 
            this.ovTXT_Obs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Obs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Obs.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Obs.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Obs.BorderRadius = 0;
            this.ovTXT_Obs.BorderSize = 1;
            this.ovTXT_Obs.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Obs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Obs.Location = new System.Drawing.Point(30, 327);
            this.ovTXT_Obs.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Obs.MaxLength = 150;
            this.ovTXT_Obs.Multiline = true;
            this.ovTXT_Obs.Name = "ovTXT_Obs";
            this.ovTXT_Obs.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Obs.PasswordChar = false;
            this.ovTXT_Obs.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Obs.PlaceholderText = "";
            this.ovTXT_Obs.ReadOnly = false;
            this.ovTXT_Obs.Size = new System.Drawing.Size(875, 283);
            this.ovTXT_Obs.TabIndex = 5;
            this.ovTXT_Obs.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // FCA_CentroCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 692);
            this.Controls.Add(this.ovTXT_Obs);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Controls.Add(this.ovTXT_Centro);
            this.Controls.Add(this.BTN_Limpar);
            this.Controls.Add(this.ovBTN_Pesquisar);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.ovCMB_CentroCustoSuperior);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovLBL_Centro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(933, 692);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(933, 692);
            this.Name = "FCA_CentroCusto";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cadastro de Centro de Custo";
            this.Load += new System.EventHandler(this.FCA_CentroCusto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ovLBL_Centro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private CustomControls.SyncControls.SyncComboBox ovCMB_CentroCustoSuperior;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private Guna.UI2.WinForms.Guna2Button BTN_Limpar;
        private Guna.UI2.WinForms.Guna2Button ovBTN_Pesquisar;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Centro;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Descricao;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Obs;
    }
}