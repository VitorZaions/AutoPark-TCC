namespace AutoPark.Forms.Cadastro
{
    partial class FCAFIN_Saida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCAFIN_Saida));
            this.label8 = new System.Windows.Forms.Label();
            this.BTN_Cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Salvar = new Guna.UI2.WinForms.Guna2Button();
            this.ovTXT_Data = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_Veiculo = new CustomControls.SyncControls.SyncTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.BTN_BuscarVeiculo = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(27, 140);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 17);
            this.label8.TabIndex = 66;
            this.label8.Text = "* Data:";
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
            this.BTN_Cancelar.Location = new System.Drawing.Point(135, 222);
            this.BTN_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Cancelar.TabIndex = 2;
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
            this.BTN_Salvar.Location = new System.Drawing.Point(317, 222);
            this.BTN_Salvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(175, 40);
            this.BTN_Salvar.TabIndex = 3;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // ovTXT_Data
            // 
            this.ovTXT_Data.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.ovTXT_Data.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Data.Location = new System.Drawing.Point(27, 162);
            this.ovTXT_Data.MinimumSize = new System.Drawing.Size(0, 33);
            this.ovTXT_Data.Name = "ovTXT_Data";
            this.ovTXT_Data.Size = new System.Drawing.Size(465, 33);
            this.ovTXT_Data.TabIndex = 230;
            // 
            // ovTXT_Veiculo
            // 
            this.ovTXT_Veiculo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Veiculo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Veiculo.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Veiculo.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Veiculo.BorderRadius = 0;
            this.ovTXT_Veiculo.BorderSize = 1;
            this.ovTXT_Veiculo.Enabled = false;
            this.ovTXT_Veiculo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Veiculo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Veiculo.Location = new System.Drawing.Point(27, 92);
            this.ovTXT_Veiculo.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Veiculo.MaxLength = 32767;
            this.ovTXT_Veiculo.Multiline = false;
            this.ovTXT_Veiculo.Name = "ovTXT_Veiculo";
            this.ovTXT_Veiculo.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Veiculo.PasswordChar = false;
            this.ovTXT_Veiculo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Veiculo.PlaceholderText = "";
            this.ovTXT_Veiculo.ReadOnly = false;
            this.ovTXT_Veiculo.Size = new System.Drawing.Size(411, 33);
            this.ovTXT_Veiculo.TabIndex = 224;
            this.ovTXT_Veiculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(27, 70);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 17);
            this.label17.TabIndex = 227;
            this.label17.Text = "* Veiculo:";
            // 
            // BTN_BuscarVeiculo
            // 
            this.BTN_BuscarVeiculo.BorderColor = System.Drawing.Color.Silver;
            this.BTN_BuscarVeiculo.BorderThickness = 1;
            this.BTN_BuscarVeiculo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.BTN_BuscarVeiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_BuscarVeiculo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_BuscarVeiculo.Image = global::AutoPark.Properties.Resources.button_find;
            this.BTN_BuscarVeiculo.IndicateFocus = true;
            this.BTN_BuscarVeiculo.Location = new System.Drawing.Point(446, 92);
            this.BTN_BuscarVeiculo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTN_BuscarVeiculo.Name = "BTN_BuscarVeiculo";
            this.BTN_BuscarVeiculo.Size = new System.Drawing.Size(46, 33);
            this.BTN_BuscarVeiculo.TabIndex = 225;
            this.BTN_BuscarVeiculo.Click += new System.EventHandler(this.BTN_BuscarVeiculo_Click);
            // 
            // FCAFIN_Saida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 290);
            this.Controls.Add(this.ovTXT_Data);
            this.Controls.Add(this.BTN_Cancelar);
            this.Controls.Add(this.ovTXT_Veiculo);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.BTN_BuscarVeiculo);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(933, 880);
            this.MinimizeBox = false;
            this.Name = "FCAFIN_Saida";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Cadastro de Saída";
            this.Load += new System.EventHandler(this.FCAFIN_ContaReceber_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button BTN_Cancelar;
        private Guna.UI2.WinForms.Guna2Button BTN_Salvar;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Veiculo;
        private Label label17;
        private Guna.UI2.WinForms.Guna2Button BTN_BuscarVeiculo;
        private DateTimePicker ovTXT_Data;
    }
}