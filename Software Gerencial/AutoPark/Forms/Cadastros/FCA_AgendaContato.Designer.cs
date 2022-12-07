
namespace AutoPark.Forms.Cadastro
{
    partial class FCA_AgendaContato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_AgendaContato));
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.ovLBL_CNPJCPF = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Telefone = new CustomControls.SyncControls.SyncMaskedTextBox();
            this.ovTXT_Celular = new CustomControls.SyncControls.SyncMaskedTextBox();
            this.ovTXT_Codigo = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Nome = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Email = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Obs = new CustomControls.SyncControls.SyncTextBox();
            this.SuspendLayout();
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.BackColor = System.Drawing.Color.White;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(170, 69);
            this.ovLBL_RazaoSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(55, 17);
            this.ovLBL_RazaoSocial.TabIndex = 80;
            this.ovLBL_RazaoSocial.Text = "* Nome";
            // 
            // ovLBL_CNPJCPF
            // 
            this.ovLBL_CNPJCPF.AutoSize = true;
            this.ovLBL_CNPJCPF.BackColor = System.Drawing.Color.White;
            this.ovLBL_CNPJCPF.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovLBL_CNPJCPF.Location = new System.Drawing.Point(24, 134);
            this.ovLBL_CNPJCPF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ovLBL_CNPJCPF.Name = "ovLBL_CNPJCPF";
            this.ovLBL_CNPJCPF.Size = new System.Drawing.Size(60, 17);
            this.ovLBL_CNPJCPF.TabIndex = 81;
            this.ovLBL_CNPJCPF.Text = "Telefone:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(27, 69);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 17);
            this.label18.TabIndex = 82;
            this.label18.Text = "* Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(480, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 91;
            this.label1.Text = "Celular:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 93;
            this.label2.Text = "E-mail:";
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
            this.BTN_Cancelar.Location = new System.Drawing.Point(545, 626);
            this.BTN_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Cancelar.TabIndex = 6;
            this.BTN_Cancelar.Text = "Cancelar";
            this.BTN_Cancelar.Click += new System.EventHandler(this.BTN_Cancelar_Click);
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
            this.BTN_Salvar.Location = new System.Drawing.Point(727, 626);
            this.BTN_Salvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Salvar.TabIndex = 7;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.BTN_Salvar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 278);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 95;
            this.label3.Text = "Observação:";
            // 
            // ovTXT_Telefone
            // 
            this.ovTXT_Telefone.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Telefone.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovTXT_Telefone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_Telefone.Location = new System.Drawing.Point(27, 157);
            this.ovTXT_Telefone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovTXT_Telefone.Mask = "(00) 0000-0000";
            this.ovTXT_Telefone.Name = "ovTXT_Telefone";
            this.ovTXT_Telefone.PasswordChar = '\0';
            this.ovTXT_Telefone.Size = new System.Drawing.Size(422, 35);
            this.ovTXT_Telefone.TabIndex = 2;
            this.ovTXT_Telefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Telefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // ovTXT_Celular
            // 
            this.ovTXT_Celular.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Celular.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovTXT_Celular.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ovTXT_Celular.Location = new System.Drawing.Point(480, 157);
            this.ovTXT_Celular.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ovTXT_Celular.Mask = "(00) 00000-0000";
            this.ovTXT_Celular.Name = "ovTXT_Celular";
            this.ovTXT_Celular.PasswordChar = '\0';
            this.ovTXT_Celular.Size = new System.Drawing.Size(422, 35);
            this.ovTXT_Celular.TabIndex = 3;
            this.ovTXT_Celular.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Celular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // ovTXT_Codigo
            // 
            this.ovTXT_Codigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Codigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Codigo.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Codigo.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Codigo.BorderRadius = 0;
            this.ovTXT_Codigo.BorderSize = 1;
            this.ovTXT_Codigo.Enabled = false;
            this.ovTXT_Codigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Codigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Codigo.Location = new System.Drawing.Point(27, 91);
            this.ovTXT_Codigo.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Codigo.MaxLength = 32767;
            this.ovTXT_Codigo.Multiline = false;
            this.ovTXT_Codigo.Name = "ovTXT_Codigo";
            this.ovTXT_Codigo.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Codigo.PasswordChar = false;
            this.ovTXT_Codigo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Codigo.PlaceholderText = "";
            this.ovTXT_Codigo.ReadOnly = false;
            this.ovTXT_Codigo.Size = new System.Drawing.Size(116, 33);
            this.ovTXT_Codigo.TabIndex = 0;
            this.ovTXT_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Nome
            // 
            this.ovTXT_Nome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Nome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Nome.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Nome.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Nome.BorderRadius = 0;
            this.ovTXT_Nome.BorderSize = 1;
            this.ovTXT_Nome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Nome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Nome.Location = new System.Drawing.Point(170, 91);
            this.ovTXT_Nome.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Nome.MaxLength = 150;
            this.ovTXT_Nome.Multiline = false;
            this.ovTXT_Nome.Name = "ovTXT_Nome";
            this.ovTXT_Nome.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Nome.PasswordChar = false;
            this.ovTXT_Nome.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Nome.PlaceholderText = "";
            this.ovTXT_Nome.ReadOnly = false;
            this.ovTXT_Nome.Size = new System.Drawing.Size(732, 33);
            this.ovTXT_Nome.TabIndex = 1;
            this.ovTXT_Nome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ovTXT_Email
            // 
            this.ovTXT_Email.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Email.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Email.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Email.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Email.BorderRadius = 0;
            this.ovTXT_Email.BorderSize = 1;
            this.ovTXT_Email.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Email.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Email.Location = new System.Drawing.Point(27, 231);
            this.ovTXT_Email.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Email.MaxLength = 1000;
            this.ovTXT_Email.Multiline = false;
            this.ovTXT_Email.Name = "ovTXT_Email";
            this.ovTXT_Email.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Email.PasswordChar = false;
            this.ovTXT_Email.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Email.PlaceholderText = "";
            this.ovTXT_Email.ReadOnly = false;
            this.ovTXT_Email.Size = new System.Drawing.Size(871, 33);
            this.ovTXT_Email.TabIndex = 4;
            this.ovTXT_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.ovTXT_Obs.Location = new System.Drawing.Point(27, 303);
            this.ovTXT_Obs.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Obs.MaxLength = 1000;
            this.ovTXT_Obs.Multiline = true;
            this.ovTXT_Obs.Name = "ovTXT_Obs";
            this.ovTXT_Obs.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Obs.PasswordChar = false;
            this.ovTXT_Obs.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Obs.PlaceholderText = "";
            this.ovTXT_Obs.ReadOnly = false;
            this.ovTXT_Obs.Size = new System.Drawing.Size(871, 300);
            this.ovTXT_Obs.TabIndex = 5;
            this.ovTXT_Obs.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // FCA_AgendaContato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 692);
            this.Controls.Add(this.ovTXT_Obs);
            this.Controls.Add(this.ovTXT_Email);
            this.Controls.Add(this.ovTXT_Nome);
            this.Controls.Add(this.ovTXT_Codigo);
            this.Controls.Add(this.ovTXT_Celular);
            this.Controls.Add(this.ovTXT_Telefone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.ovLBL_RazaoSocial);
            this.Controls.Add(this.ovLBL_CNPJCPF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FCA_AgendaContato";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cadastro de Contato";
            this.Load += new System.EventHandler(this.FCA_AgendaContato_Load);
            this.Shown += new System.EventHandler(this.FCA_AgendaContato_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private System.Windows.Forms.Label ovLBL_CNPJCPF;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomControls.SyncControls.SyncMaskedTextBox ovTXT_Telefone;
        private CustomControls.SyncControls.SyncMaskedTextBox ovTXT_Celular;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Codigo;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Nome;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Email;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Obs;
    }
}