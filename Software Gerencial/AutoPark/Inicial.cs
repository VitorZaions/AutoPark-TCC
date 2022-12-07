using AutoController.Funcoes;
using AutoDAO.Entidades;
using AutoPark.Forms.Cadastro;
using AutoPark.Forms.Configuracoes;
using AutoPark.Forms.Consultas;
using AutoPark.Forms.Controle;
using AutoPark.Forms.Relatorios;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro.Financeiro;
using System.Windows.Forms;
using Utils;

namespace AutoPark
{
    public partial class Inicial : MetroForm
    {
        string NOME_TELA = "Painel Inicial";
        public Inicial()
        {
            InitializeComponent();
            CarregaInformacoesContexto();
            AtualizarContexto();
            UpdateEmitente();
        }

        private void UpdateEmitente()
        {
            Emitente _Emitente = FuncoesEmitente.GetEmitente();

            if (_Emitente != null)
            {
                if (_Emitente.Logomarca != null)
                {
                    using (var ms = new MemoryStream(_Emitente.Logomarca))
                        PB_BackLogo.Image = SyncUtil.SetAlpha(new Bitmap(Image.FromStream(ms)), 220);
                }
                else
                {
                    PB_BackLogo.Image = SyncUtil.SetAlpha(AutoPark.Properties.Resources.auto_park, 220);
                }
            }
            else
            {
                PB_BackLogo.Image = SyncUtil.SetAlpha(AutoPark.Properties.Resources.auto_park, 220);
            }
        }

        private void CarregaInformacoesContexto()
        {
            string login = Contexto.USUARIOLOGADO.Login;

            if (login.Length > 17)
            {
                login = login.Remove(login.Length - 2);
                login.Insert(15, "..");
            }

            LBL_Username.Text = login;

            string nome = Contexto.USUARIOLOGADO.Nome;

            if (nome.Length > 17)
            {
                nome = nome.Remove(nome.Length - 2);
                nome.Insert(15, "..");
            }
            LBL_Nome.Text = nome;
            LBL_Versao.Text = "AutoPark - " + Contexto.VERSAO;
        }

        public async void AtualizarContexto()
        {
            var t = await Task.Factory.StartNew(async delegate
            {
                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1))
                          .ContinueWith(task =>
                          {
                              DateTime d = DateTime.Now;
                              String DateString = d.ToString("dd-MM-yyyy"); // retorna 2019-03-01
                              string hora = Convert.ToString(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                              this?.Invoke((MethodInvoker)(() => { LBL_Now.Text = DateString + " " + hora; }));
                          });
                }
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (Contexto.USUARIOLOGADO.Root == 0)
            {
                VerificaPermissaoItensMenu();
                // ovTXT_PerfilUsuario.Text = Contexto.USUARIOLOGADO.PerfilAcesso;
            }
            else
            {
                Contexto.USUARIOLOGADO.PerfilAcesso = "ROOT";
                //ovTXT_PerfilUsuario.Text = "ROOT";
            }
        }

        private void DesabilitarTodosItensMenu()
        {
            agendaDeContatosToolStripMenuItem.Visible = false;
            clienteToolStripMenuItem.Visible = false;
            eMITENTEToolStripMenuItem1.Visible = false;
            cENTRODECUSTOToolStripMenuItem.Visible = false;
            nATUREZAToolStripMenuItem.Visible = false;
            cONTABANCÁRIAToolStripMenuItem.Visible = false;
            formaDePagamentoToolStripMenuItem.Visible = false;
            perfilDeAcessoToolStripMenuItem1.Visible = false;
            uSUÁRIOToolStripMenuItem1.Visible = false;
            veículoToolStripMenuItem.Visible = false;

            cancelaToolStripMenuItem.Visible = false;
            entradaToolStripMenuItem.Visible = false;
            saídaToolStripMenuItem.Visible = false;
            cTASRECEBERToolStripMenuItem.Visible = false;
            cTASPAGARToolStripMenuItem.Visible = false;
            mensalidadesToolStripMenuItem.Visible = false;

            contasAPagarToolStripMenuItem.Visible = false;
            contasAReceberToolStripMenuItem.Visible = false;

            EntradasToolStripMenuItem.Visible = false;
            saídaToolStripMenuItem1.Visible = false;

            geralToolStripMenuItem1.Visible = false;
            geralToolStripMenuItem3.Visible = false;
            geralToolStripMenuItem.Visible = false;
            fornecedorToolStripMenuItem.Visible = false;
            talonárioToolStripMenuItem.Visible = false;
        }

        private void VerificaPermissaoItensMenu()
        {
            DesabilitarTodosItensMenu();

            foreach (ItemMenu Item in Contexto.ITENSMENU)
            {
                switch (Convert.ToInt32(Item.IDItemMenu))
                {
                    case 0:
                        cancelaToolStripMenuItem.Visible = true;
                        break;
                    case 1:
                        uSUÁRIOToolStripMenuItem1.Visible = true;
                        break;
                    case 2:
                        veículoToolStripMenuItem.Visible = true;
                        break;
                    case 3:
                        cTASPAGARToolStripMenuItem.Visible = true;
                        break;
                    case 4:
                        cTASRECEBERToolStripMenuItem.Visible = true;
                        break;
                    case 5:
                        mensalidadesToolStripMenuItem.Visible = true;
                        break;
                    case 6:
                        cENTRODECUSTOToolStripMenuItem.Visible = true;
                        break;
                    case 7:
                        nATUREZAToolStripMenuItem.Visible = true;
                        break;
                    case 8:
                        cONTABANCÁRIAToolStripMenuItem.Visible = true;
                        break;
                    case 9:
                        formaDePagamentoToolStripMenuItem.Visible = true;
                        break;
                    case 10:
                        perfilDeAcessoToolStripMenuItem1.Visible = true;
                        break;
                    case 11:
                        agendaDeContatosToolStripMenuItem.Visible = true;
                        break;
                    case 12:
                        eMITENTEToolStripMenuItem1.Visible = true;
                        break;
                    case 13:
                        entradaToolStripMenuItem.Visible = true;
                        break;
                    case 14:
                        saídaToolStripMenuItem.Visible = true;
                        break;
                    case 17:
                        contasAPagarToolStripMenuItem.Visible = true;
                        break;
                    case 18:
                        contasAReceberToolStripMenuItem.Visible = true;
                        break;
                    case 21:
                        atualizadorToolStripMenuItem.Visible = true;
                        break;
                    case 22:
                        geralToolStripMenuItem3.Visible = true;
                        break;
                    case 23:
                        servidorToolStripMenuItem.Visible = true;
                        break;
                    case 24:
                        eMITENTEToolStripMenuItem1.Visible = true;
                        break;
                    case 25:
                        clienteToolStripMenuItem.Visible = true;
                        break;
                    case 26:
                        fornecedorToolStripMenuItem.Visible = true;
                        break;
                    case 27:
                        talonárioToolStripMenuItem.Visible = true;
                        break;
                    case 28:
                        EntradasToolStripMenuItem.Visible = true;
                        break;
                    case 29:
                        saídaToolStripMenuItem1.Visible = true;
                        break;

                }
            }

            if(cENTRODECUSTOToolStripMenuItem.Visible == false && nATUREZAToolStripMenuItem.Visible == false && cONTABANCÁRIAToolStripMenuItem.Visible == false && formaDePagamentoToolStripMenuItem.Visible == false && talonárioToolStripMenuItem.Visible == false)
            {
                fINANCEIROToolStripMenuItem.Visible = false;
            }

            if(perfilDeAcessoToolStripMenuItem1.Visible == false && uSUÁRIOToolStripMenuItem1.Visible == false)
            {
                perfilDeAcessoToolStripMenuItem.Visible = false;
            }

            if(geralToolStripMenuItem1.Visible == false)
            {
                atualizadorToolStripMenuItem.Visible = false;
            }

            if(geralToolStripMenuItem.Visible == false)
            {
                servidorToolStripMenuItem.Visible = false;
            }

        }


        private void geralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCONFIG_ServidorGeral().ShowDialog(this);
        }

        private void geralToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FCONFIG_CancelaGeral().ShowDialog(this);
        }

        private void cancelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCL_Cancela().ShowDialog(this);
        }

        private void BAtalho_PDV_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 0) != null)
                {
                    Perm = true;
                }
            }
            else
            {
                Perm = true;
            }

            if (Perm == true)
            {
                new FCL_Cancela().ShowDialog(this);
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Oops, sem permissão para o controle de cancela.", "yellow", false, false);
            }
        }

        private void perfilDeAcessoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FCO_PerfilAcesso(false).ShowDialog(this);
        }

        private void uSUÁRIOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FCO_Usuario(false, -1).ShowDialog(this);
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_Veiculo(false).ShowDialog(this);
        }

        private void eMITENTEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FCA_Empresa().ShowDialog(this);
        }

        private void cENTRODECUSTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_CentroCusto(false, -1).ShowDialog(this);
        }

        private void nATUREZAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_NaturezaFinanceira(false, -1).ShowDialog(this);
        }

        private void cONTABANCÁRIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_ContaBancaria(false).ShowDialog(this);
        }

        private void formaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_FormaDePagamento(false).ShowDialog(this);
        }

        private void agendaDeContatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_AgendaContato(false).ShowDialog(this);
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_Cliente(false).ShowDialog(this);
        }

        private void cTASRECEBERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCOFIN_ContaReceber(false).ShowDialog(this);
        }

        private void cTASPAGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCOFIN_ContaPagar(false).ShowDialog(this);
        }

        private void BAtalho_Caixa_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 2) != null)
                {
                    Perm = true;
                }
            }
            else
            {
                Perm = true;
            }

            if (Perm == true)
            {
                new FCO_Veiculo(false).ShowDialog(this);
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }                        
        }

        private void BAtalho_Cliente_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 25) != null)
                {
                    Perm = true;
                }
            }
            else
            {
                Perm = true;
            }

            if (Perm == true)
            {
                new FCO_Cliente(false).ShowDialog(this);
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }
        }

        private void BAtalho_Receber_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 4) != null)
                {
                    Perm = true;
                }
            }
            else
            {
                Perm = true;
            }

            if (Perm == true)
            {
                new FCOFIN_ContaReceber(false).ShowDialog(this);
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }
        }

        private void BAtalho_Pagar_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 3) != null)
                {
                    Perm = true;
                }
            }
            else
            {
                Perm = true;
            }

            if (Perm == true)
            {
                new FCOFIN_ContaPagar(false).ShowDialog(this);
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }                        
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_Fornecedor(false).ShowDialog(this);
        }

        private void talonárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_Talonario(false, -1).ShowDialog(this);
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 5) != null)
                {
                    Perm = true;
                }
            }
            else
            {
                Perm = true;
            }

            if (Perm == true)
            {
                new FCOFIN_Mensalidade(false).ShowDialog(this);
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }

        }

        private void mensalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCOFIN_Mensalidade(false).ShowDialog(this);
        }

        private void geralToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new FCONFIG_Geral().ShowDialog(this);
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 13) != null)
                {
                    Perm = true;
                }
            }
            else
            {
                Perm = true;
            }

            if (Perm == true)
            {
                new FCOFIN_Entrada(false).ShowDialog(this);
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }

        }

        private void entradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCOFIN_Entrada(false).ShowDialog(this);
        }

        private void saídaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCOFIN_Saida(false).ShowDialog(this);
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {            
            bool Perm = false;
            if (Contexto.USUARIOLOGADO.Root != 1)
            {
                if (Contexto.ITENSMENU.Find(x => x.IDItemMenu == 14) != null)
                {
                    Perm = true;
                }
            }
            else
            {
                Perm = true;
            }

            if (Perm == true)
            {
                new FCOFIN_Saida(false).ShowDialog(this);
            }
            else
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Oops, sem permissão para realizar um novo cadastro.", "yellow", false, false);
            }

        }

        private void EntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new REL_Entrada().ShowDialog(this);            
        }

        private void saídaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new REL_Saida().ShowDialog(this);
        }

        private void contasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new REL_ContaPagar().ShowDialog(this);
        }

        private void contasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new REL_ContaReceber().ShowDialog(this);
        }

        private void sOBREToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Sobre().ShowDialog(this);
        }
    }
}