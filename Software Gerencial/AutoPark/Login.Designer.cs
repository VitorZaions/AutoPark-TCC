namespace AutoPark
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PB_Login_PG = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_Senha = new CustomControls.SyncControls.SyncTextBox();
            this.ovTXT_Login = new CustomControls.SyncControls.SyncTextBox();
            this.Logar_BTN = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ovCKB_Lembrar = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.LembrarLogin_LBL = new System.Windows.Forms.Label();
            this.Minimize_Button = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Close_Button = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.ovTXT_StatusLogin = new System.Windows.Forms.Label();
            this.Welcome_LBL = new System.Windows.Forms.Label();
            this.Login_LBL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.nav_header = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Nav_Login = new System.Windows.Forms.Panel();
            this.guna2DragControl4 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ShadowForm2 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Login_PG)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AutoPark.Properties.Resources.login_user;
            this.pictureBox1.Location = new System.Drawing.Point(61, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 155);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // PB_Login_PG
            // 
            this.PB_Login_PG.Image = global::AutoPark.Properties.Resources.bg_login1;
            this.PB_Login_PG.Location = new System.Drawing.Point(385, 0);
            this.PB_Login_PG.Name = "PB_Login_PG";
            this.PB_Login_PG.Size = new System.Drawing.Size(406, 513);
            this.PB_Login_PG.TabIndex = 2;
            this.PB_Login_PG.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha:";
            // 
            // ovTXT_Senha
            // 
            this.ovTXT_Senha.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Senha.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Senha.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Senha.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Senha.BorderRadius = 0;
            this.ovTXT_Senha.BorderSize = 1;
            this.ovTXT_Senha.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Senha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Senha.Location = new System.Drawing.Point(61, 333);
            this.ovTXT_Senha.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Senha.MaxLength = 50;
            this.ovTXT_Senha.Multiline = false;
            this.ovTXT_Senha.Name = "ovTXT_Senha";
            this.ovTXT_Senha.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Senha.PasswordChar = true;
            this.ovTXT_Senha.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Senha.PlaceholderText = "";
            this.ovTXT_Senha.ReadOnly = false;
            this.ovTXT_Senha.Size = new System.Drawing.Size(257, 33);
            this.ovTXT_Senha.TabIndex = 9;
            this.ovTXT_Senha.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ovTXT_Senha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ovTXT_Senha_KeyPress);
            // 
            // ovTXT_Login
            // 
            this.ovTXT_Login.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ovTXT_Login.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ovTXT_Login.BorderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Login.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.ovTXT_Login.BorderRadius = 0;
            this.ovTXT_Login.BorderSize = 1;
            this.ovTXT_Login.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_Login.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovTXT_Login.Location = new System.Drawing.Point(61, 271);
            this.ovTXT_Login.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.ovTXT_Login.MaxLength = 50;
            this.ovTXT_Login.Multiline = false;
            this.ovTXT_Login.Name = "ovTXT_Login";
            this.ovTXT_Login.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.ovTXT_Login.PasswordChar = false;
            this.ovTXT_Login.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ovTXT_Login.PlaceholderText = "";
            this.ovTXT_Login.ReadOnly = false;
            this.ovTXT_Login.Size = new System.Drawing.Size(257, 33);
            this.ovTXT_Login.TabIndex = 8;
            this.ovTXT_Login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Logar_BTN
            // 
            this.Logar_BTN.BorderRadius = 20;
            this.Logar_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Logar_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Logar_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Logar_BTN.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Logar_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Logar_BTN.FillColor = System.Drawing.Color.MediumPurple;
            this.Logar_BTN.FillColor2 = System.Drawing.Color.MediumSlateBlue;
            this.Logar_BTN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Logar_BTN.ForeColor = System.Drawing.Color.White;
            this.Logar_BTN.Location = new System.Drawing.Point(92, 432);
            this.Logar_BTN.Name = "Logar_BTN";
            this.Logar_BTN.Size = new System.Drawing.Size(180, 45);
            this.Logar_BTN.TabIndex = 10;
            this.Logar_BTN.Text = "Logar";
            this.Logar_BTN.Click += new System.EventHandler(this.Logar_BTN_Click);
            // 
            // ovCKB_Lembrar
            // 
            this.ovCKB_Lembrar.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCKB_Lembrar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ovCKB_Lembrar.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.ovCKB_Lembrar.CheckedState.InnerColor = System.Drawing.Color.White;
            this.ovCKB_Lembrar.Location = new System.Drawing.Point(63, 393);
            this.ovCKB_Lembrar.Name = "ovCKB_Lembrar";
            this.ovCKB_Lembrar.Size = new System.Drawing.Size(35, 20);
            this.ovCKB_Lembrar.TabIndex = 43;
            this.ovCKB_Lembrar.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ovCKB_Lembrar.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ovCKB_Lembrar.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.ovCKB_Lembrar.UncheckedState.InnerColor = System.Drawing.Color.White;
            // 
            // LembrarLogin_LBL
            // 
            this.LembrarLogin_LBL.AutoSize = true;
            this.LembrarLogin_LBL.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LembrarLogin_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LembrarLogin_LBL.Location = new System.Drawing.Point(103, 397);
            this.LembrarLogin_LBL.Name = "LembrarLogin_LBL";
            this.LembrarLogin_LBL.Size = new System.Drawing.Size(83, 13);
            this.LembrarLogin_LBL.TabIndex = 44;
            this.LembrarLogin_LBL.Text = "Lembrar login?";
            // 
            // Minimize_Button
            // 
            this.Minimize_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimize_Button.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.Minimize_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(43)))));
            this.Minimize_Button.IconColor = System.Drawing.Color.White;
            this.Minimize_Button.Location = new System.Drawing.Point(705, 13);
            this.Minimize_Button.Name = "Minimize_Button";
            this.Minimize_Button.Size = new System.Drawing.Size(35, 28);
            this.Minimize_Button.TabIndex = 48;
            // 
            // Close_Button
            // 
            this.Close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(43)))));
            this.Close_Button.HoverState.FillColor = System.Drawing.Color.Red;
            this.Close_Button.IconColor = System.Drawing.Color.White;
            this.Close_Button.Location = new System.Drawing.Point(746, 13);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(35, 28);
            this.Close_Button.TabIndex = 47;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.PB_Login_PG;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // ovTXT_StatusLogin
            // 
            this.ovTXT_StatusLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ovTXT_StatusLogin.ForeColor = System.Drawing.Color.Red;
            this.ovTXT_StatusLogin.Location = new System.Drawing.Point(61, 371);
            this.ovTXT_StatusLogin.Name = "ovTXT_StatusLogin";
            this.ovTXT_StatusLogin.Size = new System.Drawing.Size(257, 16);
            this.ovTXT_StatusLogin.TabIndex = 50;
            // 
            // Welcome_LBL
            // 
            this.Welcome_LBL.AutoSize = true;
            this.Welcome_LBL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Welcome_LBL.Location = new System.Drawing.Point(66, 57);
            this.Welcome_LBL.Name = "Welcome_LBL";
            this.Welcome_LBL.Size = new System.Drawing.Size(207, 15);
            this.Welcome_LBL.TabIndex = 54;
            this.Welcome_LBL.Text = "Faça o login com seu usuário e senha.";
            // 
            // Login_LBL
            // 
            this.Login_LBL.BackColor = System.Drawing.Color.Transparent;
            this.Login_LBL.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Login_LBL.IsSelectionEnabled = false;
            this.Login_LBL.Location = new System.Drawing.Point(66, 15);
            this.Login_LBL.Name = "Login_LBL";
            this.Login_LBL.Size = new System.Drawing.Size(70, 39);
            this.Login_LBL.TabIndex = 53;
            this.Login_LBL.Text = "Login";
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // nav_header
            // 
            this.nav_header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nav_header.BackColor = System.Drawing.Color.MediumVioletRed;
            this.nav_header.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(214)))), ((int)(((byte)(62)))));
            this.nav_header.FillColor2 = System.Drawing.Color.MediumSlateBlue;
            this.nav_header.Location = new System.Drawing.Point(0, 0);
            this.nav_header.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nav_header.Name = "nav_header";
            this.nav_header.Size = new System.Drawing.Size(790, 6);
            this.nav_header.TabIndex = 60;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.TargetControl = this.nav_header;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // guna2DragControl3
            // 
            this.guna2DragControl3.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl3.TargetControl = this.Nav_Login;
            this.guna2DragControl3.UseTransparentDrag = true;
            // 
            // Nav_Login
            // 
            this.Nav_Login.BackColor = System.Drawing.Color.Transparent;
            this.Nav_Login.Location = new System.Drawing.Point(0, 3);
            this.Nav_Login.Name = "Nav_Login";
            this.Nav_Login.Size = new System.Drawing.Size(388, 51);
            this.Nav_Login.TabIndex = 61;
            // 
            // guna2DragControl4
            // 
            this.guna2DragControl4.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl4.TargetControl = this.Login_LBL;
            this.guna2DragControl4.UseTransparentDrag = true;
            // 
            // guna2ShadowForm2
            // 
            this.guna2ShadowForm2.TargetForm = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(790, 513);
            this.ControlBox = false;
            this.Controls.Add(this.nav_header);
            this.Controls.Add(this.Welcome_LBL);
            this.Controls.Add(this.Login_LBL);
            this.Controls.Add(this.ovTXT_StatusLogin);
            this.Controls.Add(this.Minimize_Button);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.ovCKB_Lembrar);
            this.Controls.Add(this.LembrarLogin_LBL);
            this.Controls.Add(this.ovTXT_Senha);
            this.Controls.Add(this.ovTXT_Login);
            this.Controls.Add(this.Logar_BTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PB_Login_PG);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Nav_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Login_PG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox PB_Login_PG;
        private Label label1;
        private Label label2;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Senha;
        private CustomControls.SyncControls.SyncTextBox ovTXT_Login;
        private Guna.UI2.WinForms.Guna2GradientButton Logar_BTN;
        private Guna.UI2.WinForms.Guna2ToggleSwitch ovCKB_Lembrar;
        private Label LembrarLogin_LBL;
        private Guna.UI2.WinForms.Guna2ControlBox Minimize_Button;
        private Guna.UI2.WinForms.Guna2ControlBox Close_Button;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Label ovTXT_StatusLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel Login_LBL;
        private Label Welcome_LBL;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2GradientPanel nav_header;
        private Panel Nav_Login;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl3;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl4;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm2;
    }
}