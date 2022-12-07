using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoUTIL;
using MetroFramework.Forms;
using Microsoft.Win32;
using Utils;

namespace AutoPark
{
    public partial class Login : Form
    {
        // Tentativas de Login
        int TentativasLogin = 0;

        public Usuario Logado = null;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LembrarLoginLoad();
        }

        private void LembrarLoginLoad()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\AutoPark", true);
                if (key != null && key.GetValue("Login") != null)
                {
                    ovTXT_Login.Text = key.GetValue("Login").ToString();
                    ovCKB_Lembrar.Checked = true;
                    key.Close();
                    ovTXT_Senha.Focus();
                    ovTXT_Senha.Select();
                }
            }
            catch
            {
                ovTXT_StatusLogin.ForeColor = System.Drawing.Color.Crimson;
                ovTXT_StatusLogin.Text = "Não foi possível obter o login salvo.";
            }
        }
        private void BTN_Login_Click(object sender, EventArgs e)
        {

        }

        private void Logar()
        {
            if (string.IsNullOrEmpty(ovTXT_Login.Text.Trim()))
            {
                ovTXT_StatusLogin.Text = "Informe o Login.";
                ovTXT_Login.Select();
                return;
            }

            if (string.IsNullOrEmpty(ovTXT_Senha.Text.Trim()))
            {
                ovTXT_StatusLogin.Text = "Informe a Senha.";
                ovTXT_Senha.Select();
                return;
            }

            ovTXT_StatusLogin.Text = "";

            Logado = FuncoesUsuario.GetUsuarioRoot(ovTXT_Login.Text, SyncUtil.RetornarMD5(ovTXT_Senha.Text));
            if (Logado != null)
            {
                if (ovCKB_Lembrar.Checked == true)
                {
                    LembrarLoginAdd(Logado.Login);
                }
                else
                {
                    LembrarLoginRemove();
                }
                Close();
            }
            else
            {
                Logado = FuncoesUsuario.GetUsuarioPorLoginESenha(ovTXT_Login.Text, SyncUtil.RetornarMD5(ovTXT_Senha.Text));
                if (Logado == null)
                {
                    if (TentativasLogin == 5)
                    {
                        SyncMessager.CreateMessage(0, "Login", "Tentativas de login excedidas, por isso, o programa será fechado.", "red", false, true);
                        Environment.Exit(Environment.ExitCode);
                    }
                    TentativasLogin++;
                    ovTXT_StatusLogin.Text = "Login ou Senha Incorreto(s). Verifique!";
                    Logado = null;
                    return;
                }
                else
                {
                    if (ovCKB_Lembrar.Checked == true)
                    {
                        LembrarLoginAdd(Logado.Login);
                    }
                    else
                    {
                        LembrarLoginRemove();
                    }
                    Close();
                }
            }
        }

        private void LembrarLoginAdd(string Usuario)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\AutoPark", true);

                if (key == null)
                    key = Registry.CurrentUser.CreateSubKey(@"Software\AutoPark");

                key.SetValue("Login", Usuario);
                key.Close();
            }
            catch
            {
                ovTXT_StatusLogin.ForeColor = System.Drawing.Color.Crimson;
                ovTXT_StatusLogin.Text = "Não foi possível salvar o login.";
            }
        }

        private void LembrarLoginRemove()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\AutoPark", true);

                if (key != null && key.GetValue("LembrarLogin") != null && key.GetValue("Login") != null)
                {
                    key.DeleteSubKey("Login");
                    key.Close();
                }
            }
            catch
            {
                ovTXT_StatusLogin.ForeColor = System.Drawing.Color.Crimson;
                ovTXT_StatusLogin.Text = "Não foi possível excluir o login salvo.";
            }
        }

        private void Logar_BTN_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void ovTXT_Senha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Logar();
            }
        }
    }
}
