using AutoController.Funcoes;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using AutoUTIL;
using MetroFramework.Forms;
using Newtonsoft.Json;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_Fornecedor : MetroForm
    {
        private string NOME_TELA = "Cadastro de fornecedor";
        private Fornecedor _Fornecedor = null;
        private Endereco _Endereco = null;
        private Contato _Contato = null;

        private List<UnidadeFederativa> _UnidadesFederativas = null;
        private UnidadeFederativa _SelectedUnidadeFederativa = null;
        private Municipio _Municipio = null;
        List<Pais> _Paises = null;

        decimal LastDocument;
        public FCA_Fornecedor(Fornecedor _F)
        {
            InitializeComponent();
            _Fornecedor = _F;
            PreencherTela();
        }

        private void PreencherTela()
        {
            LastDocument = _Fornecedor.TipoDocumento;
            List<Pais> _Paises = FuncoesPais.GetPaises();
            ovCMB_Pais.DataSource = _Paises;
            ovCMB_Pais.DisplayMember = "descricao";
            ovCMB_Pais.ValueMember = "idpais";

            /* Aba Identificação */
                    
            if (_Fornecedor.InscricaoEstadual.HasValue)
            {
                ovTXT_InscricaoEstadual.Text = _Fornecedor.InscricaoEstadual.ToString();
            }

            ovCMB_TipoDocumento.SelectedIndex = Convert.ToInt32(_Fornecedor.TipoDocumento);
            ovTXT_CNPJCPF.Text = _Fornecedor.CPFCNPJ;
            ovTXT_RazaoSocial.Text = _Fornecedor.RazaoSocial;
            ovTXT_NomeFantasia.Text = _Fornecedor.NomeFantasia;

            _Contato = new Contato();
            if (_Fornecedor.IDContato.HasValue)
                _Contato = FuncoesContato.GetContato(_Fornecedor.IDContato.Value);

            _Endereco = new Endereco();
            if (_Fornecedor.IDEndereco.HasValue)
                _Endereco = FuncoesEndereco.GetEndereco(_Fornecedor.IDEndereco.Value);

            PreencherAbaEndereco();
            PreencherAbaContato();
        }

        private void PreencherAbaContato()
        {
            ovTXT_Contato_Celular.Text = _Contato.Celular;
            ovTXT_Contato_Email.Text = _Contato.Email;
            ovTXT_Contato_EmailAlternativo.Text = _Contato.EmailAlternativo;
            ovTXT_Contato_Telefone.Text = _Contato.Telefone;
        }


        private void PreencherAbaEndereco()
        {
            ovTXT_Logradouro.Text = _Endereco.Logradouro;
            ovTXT_Numero.Text = _Endereco.Numero.HasValue ? _Endereco.Numero.Value.ToString() : string.Empty;
            ovTXT_Cep.Text = _Endereco.Cep != null ? _Endereco.Cep : string.Empty;
            ovTXT_Complemento.Text = _Endereco.Complemento;
            ovTXT_Bairro.Text = _Endereco.Bairro;

            if (_Endereco.IDPais.HasValue)
            {
                _Paises = null;
                _Paises = FuncoesPais.GetPaises();
                ovCMB_Pais.DataSource = _Paises;
                ovCMB_Pais.SelectedItem = _Paises.Where(o => o.IDPais == _Endereco.IDPais.Value).FirstOrDefault();

                if (_Endereco.IDUnidadeFederativa != null)
                {
                    List<UnidadeFederativa> _Unidades = FuncoesUF.GetUnidadesFederativa(_Endereco.IDPais.Value);

                    _SelectedUnidadeFederativa = FuncoesUF.GetUnidadeFederativa(_Endereco.IDUnidadeFederativa.Value);
                    TXT_UF.Text = _SelectedUnidadeFederativa.Sigla;

                    if (_Endereco.IDMunicipio != null)
                    {
                        List<Municipio> _Municipios = FuncoesMunicipio.GetMunicipios(_Endereco.IDUnidadeFederativa.Value);
                        _Municipio = FuncoesMunicipio.GetMunicipio(_Endereco.IDMunicipio.Value);
                        TXT_MunicipioDescricao.Text = _Municipio.Descricao;
                        TXT_IDMunicipio.Text = _Municipio.CodigoIBGE;
                    }
                }
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* public bool ValidouDados()
         {

             string CNPJ_NOW = SyncUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);

             if (_Fornecedor.IDFornecedor == -1)
             {
                 if (FuncoesFornecedor.ExisteFornecedorCNPJ(CNPJ_NOW))
                 {
                     PDV.UTIL.SyncMessager.CreateMessage(0,NOME_TELA, "O fornecedor com este CNPJ já existe, faça uma pesquisa.", "red", false, false);
                     ovTXT_CNPJCPF.Focus();
                     return false;
                 }
             }
             else//Check do update
             {
                 if (FuncoesFornecedor.ExisteFornecedorCNPJ(CNPJ_NOW))
                 {
                     //Categoria CatCheck = FuncoesCategoria.GetCategoriaDescricao(ovTXT_Descricao.Text);
                     Fornecedor ForCheck = FuncoesFornecedor.GetFornecedorPorCNPJ(CNPJ_NOW);

                     if (ForCheck.IDFornecedor != _Fornecedor.IDFornecedor)
                     {
                         if (ForCheck.CNPJ == CNPJ_NOW)
                         {
                             PDV.UTIL.SyncMessager.CreateMessage(0,NOME_TELA, "O Fornecedor com este CNPJ já existe, faça uma pesquisa.", "red", false, false);
                             ovTXT_CNPJCPF.Focus();
                             return false;
                         }
                     }
                 }
             }

             return true;
         } */

        private bool ValidouDados()
        {
            if (ovCMB_TipoDocumento.SelectedItem == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe o Tipo de Documento.", "yellow", false, false);
                ovCMB_TipoDocumento.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_RazaoSocial.Text))
            {
                string Pessoa = ovCMB_TipoDocumento.SelectedIndex == 0 ? "a Razão Social" : "o Nome";
                SyncMessager.CreateMessage(0,NOME_TELA, $"Informe {Pessoa}.", "yellow", false, false);
                ovTXT_RazaoSocial.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(SyncUtil.SomenteNumeros(ovTXT_CNPJCPF.Text)))
            {
                string Pessoa = ovCMB_TipoDocumento.SelectedIndex == 0 ? "o CNPJ" : "o CPF";
                SyncMessager.CreateMessage(0,NOME_TELA, $"Informe {Pessoa}.", "yellow", false, false);
                ovTXT_CNPJCPF.Focus();
                return false;
            }

            if(ovCMB_TipoDocumento.SelectedIndex == 0)
            {
                if (ovTXT_CNPJCPF.Text.Length != 14)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, $"Informe um CNPJ válido.", "yellow", false, false);
                    ovTXT_CNPJCPF.Focus();
                    return false;
                }
            }
            else
            {
                if (ovTXT_CNPJCPF.Text.Length != 11)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, $"Informe um CPF válido.", "yellow", false, false);
                    ovTXT_CNPJCPF.Focus();
                    return false;
                }
            }


            if (!SyncUtil.IsValidCNPJCPF(ovTXT_CNPJCPF.Text))
            {
                string Pessoa = ovCMB_TipoDocumento.SelectedIndex == 0 ? "um CNPJ" : "um CPF";
                SyncMessager.CreateMessage(0,NOME_TELA, $"Informe {Pessoa} válido.", "yellow", false, false);
                ovTXT_CNPJCPF.Focus();
                return false;
            }
           

            if (FuncoesFornecedor.ExisteFornecedorPorCPFCNPJ(SyncUtil.SomenteNumeros(ovTXT_CNPJCPF.Text), _Fornecedor.IDFornecedor))
            {
                string Pessoa = ovCMB_TipoDocumento.SelectedIndex == 0 ? "CNPJ" : "CPF";
                SyncMessager.CreateMessage(0, NOME_TELA, $"Este {Pessoa} já está sendo usado.", "yellow", false, false);
                ovTXT_CNPJCPF.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(ovTXT_Cep.Text))
            {
                if (ovTXT_Cep.Text.Length < 8)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Informe um CEP Válido.", "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[1];
                    guna2TabControl1.SelectedIndex = 1;
                    ovTXT_Cep.Focus();
                    return false;
                }
            }

            if (ovTXT_InscricaoEstadual.Text != "")
            {
                if (ovTXT_InscricaoEstadual.Text.Length < 9)
                {
                   SyncMessager.CreateMessage(0, NOME_TELA, "Insira uma inscrição estadual válida, com 9 digitos.", "yellow", false, false);
                    ovTXT_InscricaoEstadual.Focus();
                    return false;
                }
            }

            // Aba Contato

            if (ovTXT_Contato_Telefone.Text != "")
            {
                if (ovTXT_Contato_Telefone.Text.Length < 10)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Insira um telefone válido, com pelo menos 10 digitos.", "yellow", false, false);
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
        private void metroButton4_Click(object sender, EventArgs e)
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;
            try
            {
                ovTXT_CNPJCPF.Text = ovTXT_CNPJCPF.Text.Trim();
                ovTXT_RazaoSocial.Text = ovTXT_RazaoSocial.Text.Trim();

                // Aba Endereço
                ovTXT_Logradouro.Text = ovTXT_Logradouro.Text.Trim();
                ovTXT_Complemento.Text = ovTXT_Complemento.Text.Trim();
                ovTXT_Bairro.Text = ovTXT_Bairro.Text.Trim();
                ovTXT_Numero.Text = ovTXT_Numero.Text.Trim();
                ovTXT_Cep.Text = ovTXT_Cep.Text.Trim();

                // Aba contato
                ovTXT_Contato_Email.Text = ovTXT_Contato_Email.Text.Trim();
                ovTXT_Contato_Telefone.Text = ovTXT_Contato_Telefone.Text.Trim();
                ovTXT_Contato_Celular.Text = ovTXT_Contato_Celular.Text.Trim();
                ovTXT_Contato_EmailAlternativo.Text = ovTXT_Contato_EmailAlternativo.Text.Trim();

                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                TipoOperacao TOTransportadora = TipoOperacao.UPDATE;
                if (_Fornecedor.IDFornecedor == -1)
                {
                    TOTransportadora = TipoOperacao.INSERT;
                    _Fornecedor.IDFornecedor = Sequence.GetNextID("FORNECEDOR", "IDFORNECEDOR");
                }

                TipoOperacao TOEndereco = TipoOperacao.UPDATE;
                if (_Fornecedor.IDEndereco == -1 || _Fornecedor.IDEndereco == null)
                {
                    TOEndereco = TipoOperacao.INSERT;
                    _Fornecedor.IDEndereco = Sequence.GetNextID("ENDERECO", "IDENDERECO");
                }

                TipoOperacao TOContato = TipoOperacao.UPDATE;
                if (_Fornecedor.IDContato == -1 || _Fornecedor.IDContato == null)
                {
                    TOContato = TipoOperacao.INSERT;
                    _Fornecedor.IDContato = Sequence.GetNextID("CONTATO", "IDCONTATO");
                }

                _Fornecedor.TipoDocumento = ovCMB_TipoDocumento.SelectedIndex;
                _Fornecedor.CPFCNPJ = SyncUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);
                _Fornecedor.RazaoSocial = ovTXT_RazaoSocial.Text;

                if (ovCMB_TipoDocumento.SelectedIndex == 0)
                {

                    if (ovTXT_InscricaoEstadual.Text != "" && ovTXT_InscricaoEstadual.Text != null)
                        _Fornecedor.InscricaoEstadual = Convert.ToDecimal(ovTXT_InscricaoEstadual.Text.Trim());

                    if (ovTXT_NomeFantasia.Text.Trim() != "" && ovTXT_NomeFantasia.Text.Trim() != null)
                        _Fornecedor.NomeFantasia = ovTXT_NomeFantasia.Text.Trim();
                }
                else
                {
                    _Fornecedor.InscricaoEstadual = null;
                    _Fornecedor.NomeFantasia = null;
                }
                /////////////////

                _Contato.IDContato = _Fornecedor.IDContato.Value;
                _Contato.Email = ovTXT_Contato_Email.Text;
                _Contato.EmailAlternativo = ovTXT_Contato_EmailAlternativo.Text;
                _Contato.Telefone = SyncUtil.SomenteNumeros(ovTXT_Contato_Telefone.Text);
                _Contato.Celular = SyncUtil.SomenteNumeros(ovTXT_Contato_Celular.Text);

                /* Aba Endereço */
                _Endereco.IDEndereco = _Fornecedor.IDEndereco.Value;
                _Endereco.Logradouro = ovTXT_Logradouro.Text;
                _Endereco.Numero = null;
                if (!string.IsNullOrEmpty(ovTXT_Numero.Text))
                    _Endereco.Numero = Convert.ToDecimal(ovTXT_Numero.Text);

                _Endereco.Complemento = ovTXT_Complemento.Text;
                _Endereco.Bairro = ovTXT_Bairro.Text;

                _Endereco.Cep = null;
                if (!string.IsNullOrEmpty(SyncUtil.SomenteNumeros(ovTXT_Cep.Text)))
                    _Endereco.Cep = SyncUtil.SomenteNumeros(ovTXT_Cep.Text);

                _Endereco.IDPais = null;
                if (ovCMB_Pais.SelectedItem != null)
                    _Endereco.IDPais = ((Pais)ovCMB_Pais.SelectedItem).IDPais;

                if (_SelectedUnidadeFederativa != null)
                    _Endereco.IDUnidadeFederativa = _SelectedUnidadeFederativa.IDUnidadeFederativa;

                if (_Municipio != null)
                    _Endereco.IDMunicipio = _Municipio.IDMunicipio;

                if (!FuncoesContato.Salvar(_Contato, TOContato))
                    throw new Exception("Não foi possível salvar o Contato.");

                if (!FuncoesEndereco.Salvar(_Endereco, TOEndereco))
                    throw new Exception("Não foi possível salvar o Endereço.");

                if (!FuncoesFornecedor.Salvar(_Fornecedor, TOTransportadora))
                    throw new Exception("Não foi possível salvar o Fornecedor.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                SyncMessager.CreateMessage(0,NOME_TELA, "Fornecedor salvo com sucesso.", "green", false, false);
            }
            catch (Exception Ex)
            {
                if (InTransaction)
                    PDVControlador.Rollback();
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();
                SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
            }
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
        private void FCA_Fornecedor_Load(object sender, EventArgs e)
        {

        }

        private void ovCMB_Pais_SelectedValueChanged(object sender, EventArgs e)
        {
            LimparSelecaoCombosEndereco(0);
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

        private void TXT_UF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TXT_IDMunicipio.Focus();
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

        private void TXT_UF_TextChanged(object sender, EventArgs e)
        {
            LimparSelecaoCombosEndereco(1);
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

        private void TXT_IDMunicipio_Enter(object sender, EventArgs e)
        {
            if (_SelectedUnidadeFederativa == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe a UF.", "yellow", false, false);
                TXT_UF.Focus();
                return;
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

        private void ovTXT_InscricaoEstadual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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

        private void FCA_Fornecedor_Shown(object sender, EventArgs e)
        {
            ovTXT_RazaoSocial.Focus();
        }

        private void ovTXT_InscricaoEstadual_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_InscricaoEstadual.Text = SyncUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text);
        }

        private void TXT_IDMunicipio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TXT_IDMunicipio.Text = SyncUtil.SomenteNumeros(TXT_IDMunicipio.Text);
        }

        private void ovTXT_Numero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Numero.Text = SyncUtil.SomenteNumeros(ovTXT_Numero.Text);
        }

        private void ovCMB_TipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ovCMB_TipoDocumento.SelectedIndex)
            {
                case 0:
                    if (LastDocument == 1)
                    {
                        ovTXT_CNPJCPF.Text = string.Empty;
                        ovTXT_InscricaoEstadual.Text = string.Empty;
                        LastDocument = 0;
                    }

                    ovTXT_CNPJCPF.Mask = "00,000,000/0000-00";
                    ovLBL_CNPJCPF.Text = "* CNPJ:";
                    ovLBL_RazaoSocial.Text = "* Razão Social:";
                    ovTXT_NomeFantasia.Enabled = true;

                    // Inscrições
                    ovTXT_InscricaoEstadual.Enabled = true;
                    break;
                case 1:
                    //Inscrições
                    ovTXT_InscricaoEstadual.Enabled = false;
                                       
                    if (LastDocument == 0)
                    {
                        ovTXT_CNPJCPF.Text = string.Empty;
                        ovTXT_InscricaoEstadual.Text = string.Empty;
                        LastDocument = 1;
                    }

                    ovLBL_CNPJCPF.Text = "* CPF:";
                    ovLBL_RazaoSocial.Text = "* Nome:";
                    ovTXT_CNPJCPF.Mask = "000,000,000-00";
                    ovTXT_NomeFantasia.Enabled = false;

                    ovTXT_NomeFantasia.Text = string.Empty;
                    break;                
            }
        }
    }
}
