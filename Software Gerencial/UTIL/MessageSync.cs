using MetroFramework.Forms;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUTIL
{
    public partial class MessageSync : MetroForm
    {
        private string _NomeTela;
        private string _Descricao;
        private string _Color;
        private bool _ButtonCancelar;
        private bool _ForceDisableOthers;
        private bool _IsUpdating;
        private bool _IsAviso;
        private int _TipoTela;

        // Informações do modulo se necessário

        private static string _CaminhoModulo;

        public MessageSync(int TipoTela, string NomeTela, string Descricao, string Color, bool ButtonCancelar, bool ForceDisableOthers, bool IsUpdating, bool IsAviso)
        {
            _NomeTela = NomeTela;
            this.Text = _NomeTela;
            _Descricao = Descricao;
            _Color = Color;
            _ButtonCancelar = ButtonCancelar;
            _ForceDisableOthers = ForceDisableOthers;
            _IsUpdating = IsUpdating;
            _IsAviso = IsAviso;
            _TipoTela = TipoTela;
           
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    this.DialogResult = DialogResult.None;
                    Close();                    
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void MessageSync_Load(object sender, EventArgs e)
        {
            CheckColor();
            SetupHeader();
            SetupDesc();
            SetupButtons();
            
            if (_TipoTela == 1)
            {
                BTN_Confirmar.Text = "Sim";
                BTN_Cancelar.Text = "Não";
            }

        }

        private void CheckColor()
        {
            if (_Color == "green")
            {
                Style = MetroFramework.MetroColorStyle.Green;
                PB_Icone.Image = AutoUTIL.Properties.Resources.ok;
            }
            else if (_Color == "red")
            {
                Style = MetroFramework.MetroColorStyle.Red;
                PB_Icone.Image = AutoUTIL.Properties.Resources.error;
            }
            else if (_Color == "yellow")
            {
                Style = MetroFramework.MetroColorStyle.Yellow;
                PB_Icone.Image = AutoUTIL.Properties.Resources.warning;
            }
            else
            {
                HeaderBG_Default.Visible = true;
                PB_Icone.Image = AutoUTIL.Properties.Resources.information;
            }
        }

        private void SetupHeader()
        {
            LBL_Header.Text = _NomeTela;
        }

        private void SetupDesc()
        {
            int DescHeight = LBL_Desc.Height;
            LBL_Desc.Text = _Descricao;  
            this.Height = this.Height + (LBL_Desc.Height - DescHeight);
            LBL_Desc.Update();
        }

        private void SetupButtons()
        {
            if (_ButtonCancelar == false)
                BTN_Cancelar.Visible = false;
        }
                
        private void BTN_Confirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MessageSync_Activated(object sender, EventArgs e)
        {
            if (_ForceDisableOthers == true)
                DisableOtherForms();
        }

        private void DisableOtherForms()
        {
            Task CloseOtherForms = Task.Factory.StartNew(() =>
            {
                Form[] formsList = Application.OpenForms.Cast<Form>().Where(x => (x.Name != "MessageSync" && x.Name != "")).ToArray();
                foreach (Form openForm in formsList)
                {
                    openForm.Invoke((MethodInvoker)(() =>
                    {
                        //MessageBox.Show("Tela = " + openForm.Name);
                        openForm.Enabled = false;
                    }));
                }
            });
        }

        private void EnableOtherForms()
        {
            Task CloseOtherForms = Task.Factory.StartNew(() =>
            {
                Form[] formsList = Application.OpenForms.Cast<Form>().Where(x => (x.Name != "MessageSync" && x.Name != "")).ToArray();
                foreach (Form openForm in formsList)
                {
                    openForm.Invoke((MethodInvoker)(() =>
                    {
                        //MessageBox.Show("Tela = " + openForm.Name);
                        openForm.Enabled = true;
                    }));
                }
            });
        }

        private void MessageSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ForceDisableOthers == true)
                EnableOtherForms();
        }
    }
}
