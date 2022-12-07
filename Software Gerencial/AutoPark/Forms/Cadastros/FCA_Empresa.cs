using AutoController.Funcoes;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using AutoUTIL;
using MetroFramework.Forms;
using Newtonsoft.Json;
//using Nancy.Json;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_Empresa : MetroForm
    {
        private decimal LastDocument = 0;
        private string NOME_TELA = "Cadastro da Empresa";       
        private int UltimoSelecionado = -1;
        private Emitente _Emitente = null;
        private Endereco _Endereco = null;
        private Contato _Contato = null;
        private Municipio _Municipio = null;
        private List<Pais> _Paises = null;
        private UnidadeFederativa _SelectedUnidadeFederativa = null;
        private List<UnidadeFederativa> _UnidadesFederativas = null;

        public FCA_Empresa()
        {
            InitializeComponent();

            _Paises = new List<Pais>();
            Pais Brasil = FuncoesPais.GetPais(1058);
            _Paises.Add(Brasil);

            ovCMB_Pais.DataSource = _Paises;
            ovCMB_Pais.DisplayMember = "descricao";
            ovCMB_Pais.ValueMember = "idpais";
            LastDocument = 0;

            _Emitente = FuncoesEmitente.GetEmitente();

            if (_Emitente != null)
            {
                _Endereco = FuncoesEndereco.GetEndereco(_Emitente.IDEndereco);
                _Contato = FuncoesContato.GetContato(_Emitente.IDContato);
            }
            else
            {
                _Emitente = new Emitente();
                _Endereco = new Endereco();
                _Contato = new Contato();
            }

            PreencheTela();
        }

        public static string BuscarArquivo(string titulo, string extensaoPadrao, string filtro, string arquivoPadrao = null)
        {
            var dlg = new OpenFileDialog
            {
                Title = titulo,
                FileName = arquivoPadrao,
                DefaultExt = extensaoPadrao,
                Filter = filtro
            };
            dlg.ShowDialog();
            return dlg.FileName;
        }
               

        private void ovBTN_LimparLogomarca_Click(object sender, EventArgs e)
        {
            ovTXT_NomeArquivoLogomarca.Text = string.Empty;
            ovPB_Logotipo.Image = null;
            _Emitente.Logomarca = null;
            _Emitente.NomeLogomarca = null;
        }

        private void ovBTN_ProcurarLogomarca_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "*.png|*.png";
            openFileDialog1.Title = "Imagens (*.png)";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                FileInfo FileInfoIMG = new FileInfo(openFileDialog1.FileName);

                if (FileInfoIMG.Length > 10485760)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "O tamanho da imagem não pode ser maior que 10MB.", "yellow", false, false);
                    return;
                }

                Image Image = Bitmap.FromFile(openFileDialog1.FileName);
                var imageHeight = Image.Height;
                var imageWidth = Image.Width;

                if (imageHeight < 256 || imageWidth < 256)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "A imagem deve conter no mínimo 256px x 256px.", "yellow", false, false);
                    return;
                }

                ovTXT_NomeArquivoLogomarca.Text = openFileDialog1.SafeFileName;
                ovPB_Logotipo.Image = Image;

                _Emitente.NomeLogomarca = openFileDialog1.SafeFileName;
                _Emitente.Logomarca = File.ReadAllBytes(openFileDialog1.FileName);
            }
        }

        private void LimparSelecaoCombosEndereco(int Modo)
        {
            switch (Modo)
            {
                case 0:
                    TXT_UF.Text = null;
                    _SelectedUnidadeFederativa = null;
                    _Municipio = null;
                    TXT_IDMunicipio.Text = null;
                    TXT_MunicipioDescricao.Text = null;
                    break;
                case 1:
                    _Municipio = null;
                    TXT_MunicipioDescricao.Text = null;
                    TXT_IDMunicipio.Text = null;
                    break;
            }
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PreencheTela()
        {

            ovTXT_CNPJ.Text = _Emitente.CNPJ;
            ovTXT_NomeFantasia.Text = _Emitente.NomeFantasia;
            ovTXT_RazaoSocial.Text = _Emitente.RazaoSocial;            

            ovTXT_Site.Text = _Emitente.Site;
            ovTXT_Facebook.Text = _Emitente.Facebook;
            ovTXT_Instagram.Text = _Emitente.Instagram;

            /* Endereço */

            if (_Endereco != null)
            {
                ovTXT_Logradouro.Text = _Endereco.Logradouro;
                ovTXT_Numero.Text = _Endereco.Numero.HasValue ? _Endereco.Numero.Value.ToString() : string.Empty;
                ovTXT_Cep.Text = _Endereco.Cep != null ? _Endereco.Cep : string.Empty;
                ovTXT_Complemento.Text = _Endereco.Complemento;
                ovTXT_Bairro.Text = _Endereco.Bairro;
            }


            //Contato
            if (_Contato != null)
            {
                ovTXT_Contato_Telefone.Text = _Contato.Telefone;
                ovTXT_Contato_Celular.Text = _Contato.Celular;
                ovTXT_Contato_Email.Text = _Contato.Email;
                ovTXT_Contato_EmailAlternativo.Text = _Contato.EmailAlternativo;
            }

            if (_Endereco.IDPais.HasValue)
            {
               // _Paises = null;
               // Pais Brasil = FuncoesPais.GetPais(1058);
               // _Paises.Add(Brasil);
                ovCMB_Pais.SelectedItem = _Paises.Where(o => o.IDPais == _Endereco.IDPais.Value).FirstOrDefault();

                if (_Endereco.IDUnidadeFederativa != null)
                {
                    List<UnidadeFederativa> _Unidades = FuncoesUF.GetUnidadesFederativa(_Endereco.IDPais.Value);
                    _SelectedUnidadeFederativa = _Unidades.Where(o => o.IDUnidadeFederativa == _Endereco.IDUnidadeFederativa).FirstOrDefault();
                    TXT_UF.Text = _SelectedUnidadeFederativa.Sigla;

                    if (_Endereco.IDMunicipio != null)
                    {
                        List<Municipio> _Municipios = FuncoesMunicipio.GetMunicipios(_Endereco.IDUnidadeFederativa.Value);
                        _Municipio = _Municipios.Where(o => o.IDMunicipio == _Endereco.IDMunicipio).FirstOrDefault();
                        TXT_MunicipioDescricao.Text = _Municipio.Descricao;
                        TXT_IDMunicipio.Text = _Municipio.CodigoIBGE;
                    }
                }
            }

            /* Aba Logomarca */
            if (_Emitente.Logomarca != null)
            {
                ovTXT_NomeArquivoLogomarca.Text = _Emitente.NomeLogomarca;
                using (var ms = new MemoryStream(_Emitente.Logomarca))
                    ovPB_Logotipo.Image = Image.FromStream(ms);
            }
            else
            {
                ovPB_Logotipo.Image = null;
                ovTXT_NomeArquivoLogomarca.Text = string.Empty;
            }

        }

        private bool ValidouDados()
        {
            if (string.IsNullOrEmpty(ovTXT_CNPJ.Text.Trim()))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe o CNPJ.", "yellow", false, false);
                ovTXT_CNPJ.Focus();
                return false;
            }

            if (ovTXT_CNPJ.Text.Length < 14)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe um CNPJ válido, com 14 dígitos.", "yellow", false, false);
                ovTXT_CNPJ.Focus();
                return false;
            }

            if (!SyncUtil.IsValidCNPJCPF(ovTXT_CNPJ.Text))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe um CNPJ válido.", "yellow", false, false);
                ovTXT_CNPJ.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_RazaoSocial.Text.Trim()))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe a Razão Social.", "yellow", false, false);
                ovTXT_RazaoSocial.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_NomeFantasia.Text.Trim()))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe um Nome Fantasia.", "yellow", false, false);
                ovTXT_NomeFantasia.Focus();
                return false;
            }
              

            // Endereço
            if (ovCMB_Pais.SelectedItem == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o País.", "yellow", false, false);
                ovCMB_Pais.Focus();
                return false;
            }

            if (_SelectedUnidadeFederativa == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o UF.", "yellow", false, false);
                TXT_UF.Focus();
                return false;
            }

            if (_Municipio == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Município.", "yellow", false, false);
                TXT_IDMunicipio.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_Logradouro.Text.Trim()))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe o Logradouro.", "yellow", false, false);
                ovTXT_Logradouro.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_Bairro.Text.Trim()))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe o Bairro.", "yellow", false, false);
                ovTXT_Bairro.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_Numero.Text.Trim()))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe o Número.", "yellow", false, false);
                ovTXT_Numero.Focus();
                return false;
            }

            if (ovTXT_Cep.Text != "")
            {
                if (ovTXT_Cep.Text.Length < 8)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Informe um CEP válido, com 8 dígitos.", "yellow", false, false);
                    ovTXT_Cep.Focus();
                    return false;
                }
            }

            if ((ovTXT_Contato_Telefone.Text == "" || ovTXT_Contato_Telefone.Text == null) && (ovTXT_Contato_Celular.Text == "" || ovTXT_Contato_Celular.Text == null))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Insira pelo menos um Telefone ou Celular.", "yellow", false, false);
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[2];
                guna2TabControl1.SelectedIndex = 2;
                ovTXT_Contato_Telefone.Focus();
                return false;
            }


            if (ovTXT_Contato_Telefone.Text != "")
            {
                if (ovTXT_Contato_Telefone.Text.Length < 10)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Insira um telefone válido, com pelo menos 10 digitos.", "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[2];
                    guna2TabControl1.SelectedIndex = 2;
                    ovTXT_Contato_Telefone.Focus();
                    return false;
                }
            }

            // Verificar telefone e celular

            if (ovTXT_Contato_Celular.Text != "")
            {
                if (ovTXT_Contato_Celular.Text.Length < 11)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Insira um celular válido, com pelo menos 11 digitos.", "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[2];
                    guna2TabControl1.SelectedIndex = 2;
                    ovTXT_Contato_Celular.Focus();
                    return false;
                }
            }

            // Quando email inserido, verifica se é um email válido.
            if (ovTXT_Contato_Email.Text != "")
            {
                if (!SyncUtil.IsValidEmail(ovTXT_Contato_Email.Text))
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Insira um e-mail válido.", "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[2];
                    guna2TabControl1.SelectedIndex = 2;
                    ovTXT_Contato_Email.Focus();
                    return false;
                }
            }

            if (ovTXT_Contato_EmailAlternativo.Text != "")
            {
                if (!SyncUtil.IsValidEmail(ovTXT_Contato_EmailAlternativo.Text))
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Insira um e-mail alternativo válido.", "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[2];
                    guna2TabControl1.SelectedIndex = 2;
                    ovTXT_Contato_EmailAlternativo.Focus();
                    return false;
                }
            }

            return true;
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {

                ovTXT_CNPJ.Text = ovTXT_CNPJ.Text.Trim();
                ovTXT_RazaoSocial.Text = ovTXT_RazaoSocial.Text.Trim();
                ovTXT_NomeFantasia.Text = ovTXT_NomeFantasia.Text.Trim();
                ovTXT_Logradouro.Text = ovTXT_Logradouro.Text.Trim();
                ovTXT_Numero.Text = ovTXT_Numero.Text.Trim();
                ovTXT_Cep.Text = ovTXT_Cep.Text.Trim();
                ovTXT_Complemento.Text = ovTXT_Complemento.Text.Trim();
                ovTXT_Bairro.Text = ovTXT_Bairro.Text.Trim();
                ovTXT_Contato_Email.Text.Trim();
                ovTXT_Contato_EmailAlternativo.Text.Trim();

                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                TipoOperacao OpEmitente = TipoOperacao.UPDATE;
                TipoOperacao OpEndereco = TipoOperacao.UPDATE;
                TipoOperacao TOContato = TipoOperacao.UPDATE;

                /* Endereço */
                _Endereco.Logradouro = ovTXT_Logradouro.Text;
                _Endereco.Numero = null;
                if (!string.IsNullOrEmpty(ovTXT_Numero.Text))
                    _Endereco.Numero = Convert.ToDecimal(ovTXT_Numero.Text);

                _Endereco.Complemento = ovTXT_Complemento.Text;
                _Endereco.Bairro = ovTXT_Bairro.Text;

                _Endereco.Cep = null;
                if (!string.IsNullOrEmpty(SyncUtil.SomenteNumeros(ovTXT_Cep.Text)))
                    _Endereco.Cep = SyncUtil.SomenteNumeros(ovTXT_Cep.Text);

                if (ovCMB_Pais.SelectedItem != null)
                    _Endereco.IDPais = ((Pais)ovCMB_Pais.SelectedItem).IDPais;

                if (_SelectedUnidadeFederativa != null)
                    _Endereco.IDUnidadeFederativa = _SelectedUnidadeFederativa.IDUnidadeFederativa;

                if (_Municipio != null)
                    _Endereco.IDMunicipio = _Municipio.IDMunicipio;

                // aqui gravar

                if (_Endereco.IDEndereco == -1)
                {
                    _Endereco.IDEndereco = Sequence.GetNextID("ENDERECO", "IDENDERECO");
                    OpEndereco = TipoOperacao.INSERT;
                }

                if (_Emitente.IDContato == -1)
                {
                    TOContato = TipoOperacao.INSERT;
                    _Emitente.IDContato = Sequence.GetNextID("CONTATO", "IDCONTATO");
                }

                /* Emitente */
                if (_Emitente.IDEmitente == -1)
                {
                    _Emitente.IDEmitente = Sequence.GetNextID("EMITENTE", "IDEMITENTE");
                    OpEmitente = TipoOperacao.INSERT;
                }

                _Emitente.CNPJ = SyncUtil.SomenteNumeros(ovTXT_CNPJ.Text);
                _Emitente.NomeFantasia = ovTXT_NomeFantasia.Text;

                ///////////////////// [PARTE FISCAL] /////////////////////

                _Emitente.RazaoSocial = ovTXT_RazaoSocial.Text;
                _Emitente.Site = (ovTXT_Site.Text.Trim()).ToLower();
                _Emitente.Facebook = ovTXT_Facebook.Text.Trim();
                _Emitente.Instagram = ovTXT_Instagram.Text.Trim();
                _Emitente.IDEndereco = _Endereco.IDEndereco;
                _Emitente.IDContato = _Contato.IDContato;

                /* AbaContato */
                _Contato.IDContato = _Emitente.IDContato;
                _Contato.Email = ovTXT_Contato_Email.Text;
                _Contato.EmailAlternativo = ovTXT_Contato_EmailAlternativo.Text;
                _Contato.Telefone = SyncUtil.SomenteNumeros(ovTXT_Contato_Telefone.Text);
                _Contato.Celular = SyncUtil.SomenteNumeros(ovTXT_Contato_Celular.Text);

                if (!FuncoesEndereco.Salvar(_Endereco, OpEndereco))
                    throw new Exception("Não foi possível salvar o Endereço.");

                if (!FuncoesContato.Salvar(_Contato, TOContato))
                    throw new Exception("Não foi possível salvar o Contato.");

                if (!FuncoesEmitente.SalvarEmitente(_Emitente, OpEmitente))
                    throw new Exception("Não foi possível salvar o Emitente.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;
                ovTXT_Site.Text = (ovTXT_Site.Text.Trim()).ToLower();

                SyncMessager.CreateMessage(0, NOME_TELA, "Emitente salvo com sucesso!", "green", false, false);
            }
            catch (Exception Ex)
            {
                if (InTransaction)
                    PDVControlador.Rollback();
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();
                SyncMessager.CreateMessage(0, NOME_TELA, Ex.Message, "red", false, false);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ovTXT_Cep.Text.Trim();
            if (ovTXT_Cep.Text != string.Empty)
            {
                if (ovCMB_Pais.SelectedItem == null)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o país.", "yellow", false, false);
                    return;
                }
                GetJsonUrl(ovTXT_Cep.Text);
            }
            else
            {
               SyncMessager.CreateMessage(0, NOME_TELA, "Insira um CEP.", "yellow", false, false);
            }
        }

        private async void GetJsonUrl(string Cep)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(string.Format("https://viacep.com.br/ws/{0}/json/", SyncUtil.SomenteNumeros(Cep)));

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                SetarCEP(responseBody);
            }
            catch
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Cep não encontrado.", "yellow", false, false);
            }
        }

        private void SetarCEP(string Resultado)
        {
            try
            {
                LocalizacaoCep CEPLocalizado = JsonConvert.DeserializeObject<LocalizacaoCep>(Resultado);
                ovTXT_Logradouro.Text = CEPLocalizado.logradouro;
                ovTXT_Bairro.Text = CEPLocalizado.bairro;

                List<UnidadeFederativa> Unidades = FuncoesUF.GetUnidadesFederativa(((Pais)ovCMB_Pais.SelectedItem).IDPais);
                _SelectedUnidadeFederativa = Unidades.Where(o => o.Sigla.ToUpper().Equals(CEPLocalizado.uf)).FirstOrDefault();
                TXT_UF.Text = _SelectedUnidadeFederativa.Sigla;

                List<Municipio> _Municipios = FuncoesMunicipio.GetMunicipios(_SelectedUnidadeFederativa.IDUnidadeFederativa);
                _Municipio = _Municipios.Where(o => o.CodigoIBGE != null && o.CodigoIBGE.Equals(CEPLocalizado.ibge)).FirstOrDefault();
                TXT_MunicipioDescricao.Text = _Municipio.Descricao;
                TXT_IDMunicipio.Text = _Municipio.CodigoIBGE;
            }
            catch (Exception Ex)
            {
               SyncMessager.CreateMessage(0, NOME_TELA, "Cep não encontrado.", "yellow", false, false);
            }
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage5_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    if (SyncMessager.CreateMessage(0, NOME_TELA, "Deseja sair?", "yellow", true, false) == DialogResult.OK)
                    {
                        Close();
                    }
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void FCA_Emitente_Load(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
            guna2TabControl1.SelectedIndex = 0;
        }

        private void metroTabPage40_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage7_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void ovTXT_Telefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void ovTXT_Telefone_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ovTXT_Cep_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ovTXT_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ovTXT_CNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ovTXT_InscricaoEstadual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
        private void ovCMB_Pais_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TXT_UF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TXT_IDMunicipio.Focus();
            }
        }

        private void TXT_UF_Enter(object sender, EventArgs e)
        {
            if (ovCMB_Pais.SelectedItem == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe o País.", "yellow", false, false);
                ovCMB_Pais.Focus();
                return;
            }
        }

        private void TXT_UF_Leave(object sender, EventArgs e)
        {
            if (TXT_UF.Text != string.Empty)
            {
                _UnidadesFederativas = FuncoesUF.GetUnidadesFederativa(((Pais)ovCMB_Pais.SelectedItem).IDPais);
                TXT_UF.Text = (TXT_UF.Text).ToUpper();
                _SelectedUnidadeFederativa = _UnidadesFederativas.Find(x => x.Sigla == TXT_UF.Text);

                if (_SelectedUnidadeFederativa == null)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "UF Inexistente, insira uma UF válida.", "yellow", false, false);
                    TXT_UF.Text = null;
                    TXT_UF.Focus();
                }
            }
            else
            {
                _SelectedUnidadeFederativa = null;
            }
        }

        private void TXT_IDMunicipio_Enter(object sender, EventArgs e)
        {
            if (_SelectedUnidadeFederativa == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe a UF.", "yellow", false, false);
                TXT_UF.Focus();
                return;
            }
        }

        private void TXT_IDMunicipio_Leave(object sender, EventArgs e)
        {
            if (TXT_IDMunicipio.Text != string.Empty)
            {
                _Municipio = FuncoesMunicipio.GetMunicipioPorCodigo(Convert.ToDecimal(TXT_IDMunicipio.Text));

                if (_Municipio == null)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Município Inexistente, insira uma Município válido.", "yellow", false, false);
                    TXT_IDMunicipio.Text = null;
                    TXT_MunicipioDescricao.Text = null;
                    TXT_IDMunicipio.Focus();
                }
                else
                {
                    TXT_MunicipioDescricao.Text = _Municipio.Descricao;
                }
            }
            else
            {
                _Municipio = null;
            }
        }

        private void TXT_IDMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ovTXT_Cep.Focus();
            }
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            if (_SelectedUnidadeFederativa == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione uma UF antes de selecionar o município.", "yellow", false, false);
                TXT_UF.Text = null;
                TXT_UF.Focus();
                return;
            }

            AutoPark.Forms.Seletores.SeletorMunicipio SeletorMunicipio = new AutoPark.Forms.Seletores.SeletorMunicipio(_SelectedUnidadeFederativa.IDUnidadeFederativa);
            SeletorMunicipio.ShowDialog(this);

            if (SeletorMunicipio.DRMunicipio == null)
                return;

            DataRow DrSelecionada = SeletorMunicipio.DRMunicipio;
            _Municipio = FuncoesMunicipio.GetMunicipioPorCodigo(Convert.ToDecimal(DrSelecionada["CODIGOIBGE"]));
            TXT_MunicipioDescricao.Text = _Municipio.Descricao;
            TXT_IDMunicipio.Text = _Municipio.CodigoIBGE;
        }
                      
        private void EmissaoNFeNFCe_Click(object sender, EventArgs e)
        {
          /*  if (EmissaoNFeNFCe.Checked == false)
            {
                if (UTIL.SyncMessager.CreateMessage(0, NOME_TELA, "Deseja realmente desabilitar a emissão de NF-e e NFC-e? Todas as informações fiscais serão apagadas ao salvar.", "yellow", true, false) != DialogResult.OK)
                {
                    EmissaoNFeNFCe.Checked = true;
                    return;
                }
            }

            AtualizaTelaCertificado();*/
        }
      
        private void TXT_IDMunicipio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TXT_IDMunicipio.Text = SyncUtil.SomenteNumeros(TXT_IDMunicipio.Text);
        }

        private void ovTXT_Numero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Numero.Text = SyncUtil.SomenteNumeros(ovTXT_Numero.Text);
        }

        private void TXT_IDMunicipio_Click(object sender, EventArgs e)
        {
            if (_SelectedUnidadeFederativa == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe a UF.", "yellow", false, false);
                TXT_UF.Focus();
                return;
            }
        }

        private void TXT_UF_Click(object sender, EventArgs e)
        {
            if (ovCMB_Pais.SelectedItem == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe o País.", "yellow", false, false);
                ovCMB_Pais.Focus();
                return;
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void ovCMB_Pais_SelectedValueChanged(object sender, EventArgs e)
        {
            LimparSelecaoCombosEndereco(0);
        }
    }
}