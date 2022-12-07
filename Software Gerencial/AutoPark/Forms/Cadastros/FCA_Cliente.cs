using MetroFramework.Forms;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Drawing;
using System.Threading;
using System.Net.Http;
using AutoDAO.Entidades;
using AutoController.Funcoes;
using AutoDAO.Enum;
using AutoDAO.DB.Utils;
using AutoUTIL;
using Utils;
//using Nancy.Json;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_Cliente : MetroForm
    {
        private string NOME_TELA = "Cadastro de cliente";
        private Cliente _Cliente = null;
        private Endereco _Endereco = null;
        private Contato _Contato = null;
        private List<UnidadeFederativa> _UnidadesFederativas = null;
        private UnidadeFederativa _SelectedUnidadeFederativa = null;
        private Municipio _Municipio = null;
        List<Pais> _Paises = null;
        private DataTable AutorizadosCliente= null;

        private decimal LastDocument = 0;

        public FCA_Cliente(Cliente _C)
        {
            InitializeComponent();
            _Cliente = _C;

            ovCMB_TipoDocumento.SelectedIndex = 0;
            LastDocument = 0;

            _Paises = FuncoesPais.GetPaises();
            ovCMB_Pais.DataSource = _Paises;
            ovCMB_Pais.DisplayMember = "descricao";
            ovCMB_Pais.ValueMember = "idpais";

            PreencherTela();
           
        }

        private void PreencherTela()
        {
            PreencherAbaIdentificacao();

            _Contato = new Contato();
            if (_Cliente.IDContato != -1)
                _Contato = FuncoesContato.GetContato(_Cliente.IDContato);

            _Endereco = new Endereco();
            if (_Cliente.IDEndereco != -1)
                _Endereco = FuncoesEndereco.GetEndereco(_Cliente.IDEndereco);

            PreencherAbaEndereco();
            PreencherAbaContato();
        }

        private void LimparSelecaoCombosEndereco(int Modo)
        {
            switch (Modo)
            {
                case 0: // TIRA UF E MUNICIPIO
                    _Municipio = null;
                    TXT_IDMunicipio.Text = null;
                    TXT_MunicipioDescricao.Text = null;
                    TXT_UF.Text = null;
                    _SelectedUnidadeFederativa = null;
                    break;
                case 1: // SOMENTE MUNICIPIO
                    _Municipio = null;
                    TXT_MunicipioDescricao.Text = null;
                    TXT_IDMunicipio.Text = null;
                    break;
            }
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

        private void PreencherAbaContato()
        {
            ovTXT_Contato_Celular.Text = _Contato.Celular;
            ovTXT_Contato_Email.Text = _Contato.Email;
            ovTXT_Contato_EmailAlternativo.Text = _Contato.EmailAlternativo;
            ovTXT_Contato_Telefone.Text = _Contato.Telefone;
        }

        private void PreencherAbaIdentificacao()
        {
            ovCMB_TipoDocumento.SelectedIndex = Convert.ToInt32(_Cliente.TipoDocumento);
            LastDocument = ovCMB_TipoDocumento.SelectedIndex;
            ovTXT_CNPJCPF.Text = _Cliente.TipoDocumento == 0 ? _Cliente.CNPJ : _Cliente.CPF;

            ovTXT_RazaoSocial.Text = _Cliente.TipoDocumento == 0 ? _Cliente.RazaoSocial : _Cliente.Nome;            
            ovTXT_NomeFantasia.Text = _Cliente.NomeFantasia;


            if (_Cliente.IDCliente != -1)
            {
                ovTXT_CodigoCliente.Text = _Cliente.IDCliente.ToString();
            }

            ovCMB_Ativo.Checked = _Cliente.Ativo == 1;

        }

        void CheckEstrangeiro()
        {
            if (ovCMB_TipoDocumento.SelectedIndex != 2)
            {
                LBL_DocEstrangeiro.Text = "Doc. Estrangeiro:";
                LBL_DocEstrangeiro.Font = new Font("Segoe UI", (float)9.75, FontStyle.Regular);
                ovTXT_DocEstrangeiro.Enabled = false;
                ovTXT_DocEstrangeiro.Text = "";
            }
            else
            {
                ovTXT_DocEstrangeiro.Enabled = true;
                LBL_DocEstrangeiro.Text = "* Doc. Estrangeiro:";
                LBL_DocEstrangeiro.Font = new Font("Segoe UI", (float)9.75, FontStyle.Bold);
            }
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Salvar()
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

             try
            {
                // Trim nos textboxs, evitando espaços indevidos.

                ovTXT_CNPJCPF.Text = ovTXT_CNPJCPF.Text.Trim();
                ovTXT_RazaoSocial.Text = ovTXT_RazaoSocial.Text.Trim();
                ovTXT_NomeFantasia.Text = ovTXT_NomeFantasia.Text.Trim();
                ovTXT_DocEstrangeiro.Text = ovTXT_DocEstrangeiro.Text.Trim();

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

                TipoOperacao TOCliente = TipoOperacao.UPDATE;
                //if (!FuncoesCliente.ExisteCliente(_Cliente.IDCliente))
                if (_Cliente.IDCliente == -1) // -1 = Cliente não existe
                {
                    TOCliente = TipoOperacao.INSERT;
                    _Cliente.IDCliente = Sequence.GetNextID("CLIENTE", "IDCLIENTE");
                }

                TipoOperacao TOEndereco = TipoOperacao.UPDATE;
                if (_Cliente.IDEndereco == -1)
                {
                    TOEndereco =TipoOperacao.INSERT;
                    _Cliente.IDEndereco = Sequence.GetNextID("ENDERECO", "IDENDERECO");
                }

                TipoOperacao TOContato = TipoOperacao.UPDATE;
                if (_Cliente.IDContato == -1)
                {
                    TOContato = TipoOperacao.INSERT;
                    _Cliente.IDContato = Sequence.GetNextID("CONTATO", "IDCONTATO");
                }

                _Cliente.TipoDocumento = ovCMB_TipoDocumento.SelectedIndex;
                if (ovCMB_TipoDocumento.SelectedIndex == 0)
                {                   
                    _Cliente.CNPJ = SyncUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);
                    _Cliente.RazaoSocial = ovTXT_RazaoSocial.Text;
                    _Cliente.CPF = string.Empty;
                    _Cliente.Nome = string.Empty;
                    _Cliente.NomeFantasia = ovTXT_NomeFantasia.Text;
                }
                else if(ovCMB_TipoDocumento.SelectedIndex == 1)
                {
                    _Cliente.CNPJ = string.Empty;
                    _Cliente.RazaoSocial = string.Empty;
                    _Cliente.Nome = ovTXT_RazaoSocial.Text;
                    _Cliente.CPF = SyncUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);
                    _Cliente.NomeFantasia = string.Empty;
                }
                else
                {
                    _Cliente.CNPJ = string.Empty;
                    _Cliente.RazaoSocial = string.Empty;
                    _Cliente.Nome = ovTXT_RazaoSocial.Text;
                    _Cliente.CPF = string.Empty;
                    _Cliente.NomeFantasia = string.Empty;
                }

                _Cliente.Ativo = ovCMB_Ativo.Checked ? 1 : 0;

                /* AbaContato */
                _Contato.IDContato = _Cliente.IDContato;
                _Contato.Email = ovTXT_Contato_Email.Text;
                _Contato.EmailAlternativo = ovTXT_Contato_EmailAlternativo.Text;
                _Contato.Telefone = SyncUtil.SomenteNumeros(ovTXT_Contato_Telefone.Text);
                _Contato.Celular = SyncUtil.SomenteNumeros(ovTXT_Contato_Celular.Text);

                /* Aba Endereço */

                // Obrigatorio
                _Endereco.IDEndereco = _Cliente.IDEndereco;
                _Endereco.Logradouro = ovTXT_Logradouro.Text;
                _Endereco.Bairro = ovTXT_Bairro.Text;
                _Endereco.Complemento = ovTXT_Complemento.Text;

                //Opcionais
                if (!string.IsNullOrEmpty(ovTXT_Numero.Text))
                    _Endereco.Numero = Convert.ToDecimal(ovTXT_Numero.Text);
                else
                    _Endereco.Numero = null;

                if (!string.IsNullOrEmpty(SyncUtil.SomenteNumeros(ovTXT_Cep.Text)))
                    _Endereco.Cep = SyncUtil.SomenteNumeros(ovTXT_Cep.Text);
                else
                    _Endereco.Cep = null;

                _Endereco.IDPais = ((Pais)ovCMB_Pais.SelectedItem).IDPais;


                // Depende se for EX ou interno

                if(((Pais)ovCMB_Pais.SelectedItem).Codigo != "1058")
                {
                    _Endereco.IDUnidadeFederativa = null;
                    _Endereco.IDMunicipio = null;
                }
                else
                {
                    _Endereco.IDUnidadeFederativa = _SelectedUnidadeFederativa.IDUnidadeFederativa;
                    _Endereco.IDMunicipio = _Municipio.IDMunicipio;
                }

                if (!FuncoesContato.Salvar(_Contato, TOContato))
                    throw new Exception("Não foi possível salvar o Contato.");

                if (!FuncoesEndereco.Salvar(_Endereco, TOEndereco))
                    throw new Exception("Não foi possível salvar o Endereço.");

                if (!FuncoesCliente.Salvar(_Cliente, TOCliente))
                    throw new Exception("Não foi possível salvar o Cliente.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

                ovTXT_CodigoCliente.Text = _Cliente.IDCliente.ToString();
                SyncMessager.CreateMessage(0,NOME_TELA, "Cliente salvo com sucesso.", "green", false, false);
            }
            catch (Exception Ex)
            {
                if (InTransaction)
                    PDVControlador.Rollback();
                if (IsLoadingScreen)
                    LoadingScreen.CloseLoading();
               SyncMessager.CreateMessage(0,NOME_TELA, Ex.Message, "red", false, false);
                Close();
            }
        }

        public bool ValidouDados()
        {

            if (ovCMB_TipoDocumento.SelectedItem == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Tipo de Documento", "yellow", false, false);
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovCMB_TipoDocumento.Focus();
                return false;
            }

            if (ovCMB_TipoDocumento.SelectedIndex == 0 || ovCMB_TipoDocumento.SelectedIndex == 1)
            {

                if (string.IsNullOrEmpty(SyncUtil.SomenteNumeros(ovTXT_CNPJCPF.Text)))
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, string.Format("Informe o {0}.", ovCMB_TipoDocumento.SelectedIndex == 0 ? "CNPJ" : "CPF"), "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                    guna2TabControl1.SelectedIndex = 0;
                    ovTXT_CNPJCPF.Focus();
                    return false;
                }

                //Verificar se o cpf ou cnpj é valido por digito verificador

                if (ovCMB_TipoDocumento.SelectedIndex == 0)
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
                    string Tipo = ovCMB_TipoDocumento.SelectedIndex == 0 ? "CNPJ" : "CPF";
                    SyncMessager.CreateMessage(0, NOME_TELA, "Digite um " + Tipo + " válido.", "yellow", false, false);
                    ovTXT_CNPJCPF.Focus();
                    return false;
                }

                // Não é necessário, pois a verificação acima já faz isso
                /*
                if (ovTXT_CNPJCPF.Text != "")
                {
                    if (ovCMB_TipoDocumento.SelectedIndex == 0)
                    { //CNPJ
                        if (ovTXT_CNPJCPF.Text.Length < 14)
                        {
                            PDV.UTIL.SyncMessager.CreateMessage(0,NOME_TELA, "Insira um CNPJ válido, com 14 digitos.", "yellow", false, false);
                            ovTXT_CNPJCPF.Focus();
                            return false;
                        }
                    }
                    else // CPF
                    {
                        if (ovTXT_CNPJCPF.Text.Length < 11)
                        {
                            PDV.UTIL.SyncMessager.CreateMessage(0,NOME_TELA, "Insira um CPF válido, com 11 digitos.", "yellow", false, false);
                            ovTXT_CNPJCPF.Focus();
                            return false;
                        }
                    }
                }*/

                // Verificação se já existe CNPJ ou CPF cadastrado.
                decimal TipoCliente = ovCMB_TipoDocumento.SelectedIndex;
                if (TipoCliente == 0) // CNPJ
                {
                    string CNPJCPF = SyncUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);
                    if (FuncoesCliente.ExisteClientePorCNPJ(CNPJCPF, _Cliente.IDCliente))
                    {
                        SyncMessager.CreateMessage(0, NOME_TELA, "Este CNPJ já está cadastrado.", "yellow", false, false);
                        ovTXT_CNPJCPF.Focus();
                        return false;
                    }
                }
                else
                {
                    string CNPJCPF = SyncUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);
                    if (FuncoesCliente.ExisteClientePorCPF(CNPJCPF, _Cliente.IDCliente))
                    {
                        SyncMessager.CreateMessage(0, NOME_TELA, "Este CPF já está cadastrado.", "yellow", false, false);
                        ovTXT_CNPJCPF.Focus();
                        return false;
                    }
                }
            }
            else
            {
                if (FuncoesCliente.ExisteClientePorDocEstrangeiro(ovTXT_DocEstrangeiro.Text, _Cliente.IDCliente))
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Este Documento Estrangeiro já está cadastrado.", "yellow", false, false);
                    ovTXT_CNPJCPF.Focus();
                    return false;
                }
            }                       

            if (string.IsNullOrEmpty(ovTXT_RazaoSocial.Text))
            {
                if (ovCMB_TipoDocumento.SelectedIndex == 0)
                    SyncMessager.CreateMessage(0, NOME_TELA, "Informe a Razão Social.", "yellow", false, false);
                else
                    SyncMessager.CreateMessage(0, NOME_TELA, "Informe o Nome.", "yellow", false, false);
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                guna2TabControl1.SelectedIndex = 0;
                ovTXT_RazaoSocial.Focus();
                return false;
            }

            if (ovTXT_NomeFantasia.Visible)
            {
                if (string.IsNullOrEmpty(ovTXT_NomeFantasia.Text))
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Nome Fantasia.", "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                    guna2TabControl1.SelectedIndex = 0;
                    ovTXT_NomeFantasia.Focus();
                    return false;
                }
            }

            if (ovCMB_TipoDocumento.SelectedIndex == 2)
            {
                if (string.IsNullOrEmpty(ovTXT_DocEstrangeiro.Text))
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Informe o Documento Estrangeiro.", "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
                    guna2TabControl1.SelectedIndex = 0;
                    ovTXT_DocEstrangeiro.Focus();
                    return false;
                }
            }

            // Aba Endereço

            if (ovCMB_Pais.SelectedItem == null)
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Pais.", "yellow", false, false);
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[1];
                guna2TabControl1.SelectedIndex = 1;
                ovCMB_Pais.Focus();
                return false;
            }

            if ((ovCMB_Pais.SelectedItem as Pais).Codigo == "1058")
            {
                if (_SelectedUnidadeFederativa == null)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Informe a UF.", "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[1];
                    guna2TabControl1.SelectedIndex = 1;
                    TXT_UF.Focus();
                    return false;
                }
            
                if (_Municipio == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Município.", "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[1];
                    guna2TabControl1.SelectedIndex = 1;
                    TXT_IDMunicipio.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(ovTXT_Cep.Text))
            {
                if (ovTXT_Cep.Text.Length < 8 && (ovCMB_Pais.SelectedItem as Pais).Codigo == "1058")
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Informe um CEP Válido.", "yellow", false, false);
                    guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[1];
                    guna2TabControl1.SelectedIndex = 1;
                    ovTXT_Cep.Focus();
                    return false;
                }
            }
  

            if (string.IsNullOrEmpty(ovTXT_Logradouro.Text))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Logradouro.", "yellow", false, false);
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[1];
                guna2TabControl1.SelectedIndex = 1;
                ovTXT_Logradouro.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_Bairro.Text))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Bairro.", "yellow", false, false);
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[1];
                guna2TabControl1.SelectedIndex = 1;
                ovTXT_Bairro.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(SyncUtil.SomenteNumeros(ovTXT_Numero.Text)))
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Informe o Número.", "yellow", false, false);
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[1];
                guna2TabControl1.SelectedIndex = 1;
                ovTXT_Numero.Focus();
                return false;
            }           

            // Verifica as inscrições

            if (ovTXT_Contato_Telefone.Text != "")
            {
                if (ovTXT_Contato_Telefone.Text.Length < 10)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Insira um telefone válido, com pelo menos 10 digitos.", "yellow", false, false);
                    ovTXT_Contato_Telefone.Focus();
                    return false;
                }
            }

            // Verificar telefone e celular

            if (ovTXT_Contato_Celular.Text != "")
            {
                if (ovTXT_Contato_Celular.Text.Length < 11)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Insira um celular válido, com pelo menos 11 digitos.", "yellow", false, false);
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
            Salvar();
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
        private void FCA_Cliente_Load(object sender, EventArgs e)
        {
        }

        private void ovCMB_TipoDocumento_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            switch (ovCMB_TipoDocumento.SelectedIndex)
            {
                case 0:
                    ovTXT_CNPJCPF.Mask = "00,000,000/0000-00";
                    ovLBL_CNPJCPF.Text = "* CNPJ:";
                    ovLBL_RazaoSocial.Text = "* Razão Social:";

                    ovTXT_DocEstrangeiro.Enabled = false;
                    ovTXT_CNPJCPF.Enabled = true;
                    ovLBL_CNPJCPF.Font = new Font("Segoe UI", (float)9.75, FontStyle.Bold);

                    LBL_DocEstrangeiro.Font = new Font("Segoe UI", (float)9.75, FontStyle.Regular);
                    LBL_DocEstrangeiro.Text = "Doc. Estrangeiro:";

                    if (LastDocument == 1 || LastDocument == 2)
                    {
                        ovTXT_CNPJCPF.Text = string.Empty;
                        ovTXT_DocEstrangeiro.Text = string.Empty;
                        LastDocument = 0;
                    }

                    ovTXT_RazaoSocial.Width = 349;
                    ovTXT_NomeFantasia.Visible = true;
                    ovLBL_NomeFantasia.Visible = true;
                    // Doc Estrangeiro
                    //ovCKB_Estrangeiro.Enabled = false;

                    break;
                case 1:
                    ovTXT_CNPJCPF.Mask = "000,000,000-00";
                    ovTXT_DocEstrangeiro.Enabled = false;
                    ovTXT_CNPJCPF.Enabled = true;
                    ovLBL_CNPJCPF.Font = new Font("Segoe UI", (float)9.75, FontStyle.Bold);

                    ovLBL_CNPJCPF.Text = "* CPF:";
                    ovLBL_RazaoSocial.Text = "* Nome:";

                    LBL_DocEstrangeiro.Font = new Font("Segoe UI", (float)9.75, FontStyle.Regular);
                    LBL_DocEstrangeiro.Text = "Doc. Estrangeiro:";

                    if (LastDocument == 0 || LastDocument == 2)
                    {
                        ovTXT_CNPJCPF.Text = string.Empty;
                        ovTXT_DocEstrangeiro.Text = string.Empty;
                        LastDocument = 1;
                    }
                    ovTXT_RazaoSocial.Width = 728;
                    ovTXT_NomeFantasia.Visible = false;
                    ovLBL_NomeFantasia.Visible = false;
                    break;
                case 2:
                    ovTXT_CNPJCPF.Enabled = false;
                    ovLBL_CNPJCPF.Font = new Font("Segoe UI", (float)9.75, FontStyle.Regular);
                    //Inscrições
                    ovTXT_DocEstrangeiro.Enabled = true;

                    ovLBL_RazaoSocial.Text = "* Nome:";

                    LBL_DocEstrangeiro.Font = new Font("Segoe UI", (float)9.75, FontStyle.Bold);
                    LBL_DocEstrangeiro.Text = "* Doc. Estrangeiro:";

                    if (LastDocument == 0 || LastDocument == 2)
                    {
                        ovTXT_CNPJCPF.Text = string.Empty;
                        ovTXT_Cep.Text = string.Empty;
                        LastDocument = 2;
                    }
                    ovTXT_RazaoSocial.Width = 728;
                    ovTXT_NomeFantasia.Visible = false;
                    ovLBL_NomeFantasia.Visible = false;
                    break;
            }
        }



        private void ovCKB_Estrangeiro_CheckedChanged(object sender, EventArgs e)
        {
            CheckEstrangeiro();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void ovTXT_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ovCMB_Pais_SelectedValueChanged_1(object sender, EventArgs e)
        {
            LimparSelecaoCombosEndereco(0);
           
            if(ovCMB_Pais.SelectedItem != null)
            {
                if((ovCMB_Pais.SelectedItem as Pais).Codigo != "1058")
                {
                    BTN_LocalizarCEP.Enabled = false;
                    LBL_UF.Text = "UF:";
                    LBL_UF.Font = new Font("Segoe UI", (float)9.75, FontStyle.Regular);
                    LBL_Municipio.Text = "Município:";
                    LBL_Municipio.Font = new Font("Segoe UI", (float)9.75, FontStyle.Regular);

                    TXT_UF.Text = null;
                    _SelectedUnidadeFederativa = null;
                    _Municipio = null;
                    TXT_IDMunicipio.Text = null;
                    TXT_MunicipioDescricao.Text = null;
                    TXT_UF.Enabled = false;
                    TXT_IDMunicipio.Enabled = false;
                    ovBTN_Pesquisar.Enabled = false;
                    ovTXT_Cep.Enabled = false;
                    ovTXT_Cep.Text = null;

                    ovTXT_Logradouro.Focus();
                }
                else
                {
                    BTN_LocalizarCEP.Enabled = true;
                    TXT_IDMunicipio.Enabled = true;
                    ovBTN_Pesquisar.Enabled = true;
                    TXT_UF.Enabled = true;
                    ovTXT_Cep.Enabled = true;

                    LBL_UF.Text = "* UF:";
                    LBL_UF.Font = new Font("Segoe UI", (float)9.75, FontStyle.Bold);
                    LBL_Municipio.Text = "* Município:";
                    LBL_Municipio.Font = new Font("Segoe UI", (float)9.75, FontStyle.Bold);

                }
            }
        }

        private void ovCMB_UF_SelectedValueChanged(object sender, EventArgs e)
        {
            LimparSelecaoCombosEndereco(1);
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TXT_UF_Leave(object sender, EventArgs e)
        {
            if (TXT_UF.Text != string.Empty)
            {
                _UnidadesFederativas = FuncoesUF.GetUnidadesFederativa(((Pais)ovCMB_Pais.SelectedItem).IDPais);
                TXT_UF.Text = (TXT_UF.Text).ToUpper();
                _SelectedUnidadeFederativa = _UnidadesFederativas.Find(x => x.Sigla == TXT_UF.Text);

                if (_SelectedUnidadeFederativa == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "UF Inexistente, insira uma UF válida.", "yellow", false, false);
                    TXT_UF.Text = null;
                    TXT_UF.Focus();
                }
            }
            else
            {
                _SelectedUnidadeFederativa = null;
            }
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            if (_SelectedUnidadeFederativa == null)
            {
                SyncMessager.CreateMessage(0,NOME_TELA, "Selecione uma UF antes de selecionar o município.", "yellow", false, false);
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

        private void TXT_MunicipioDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXT_UF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TXT_IDMunicipio.Focus();
            }
        }

        private void TXT_IDMunicipio_Leave(object sender, EventArgs e)
        {
            if (TXT_IDMunicipio.Text != string.Empty)
            {
                _Municipio = FuncoesMunicipio.GetMunicipioPorCodigo(Convert.ToDecimal(TXT_IDMunicipio.Text));

                if (_Municipio == null)
                {
                    SyncMessager.CreateMessage(0,NOME_TELA, "Município Inexistente, insira uma Município válido.", "yellow", false, false);
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

        private void TXT_UF_TextChanged(object sender, EventArgs e)
        {
            LimparSelecaoCombosEndereco(1);
        }

        private void ovTXT_CNPJCPF_Leave(object sender, EventArgs e)
        {
            if (ovTXT_CNPJCPF.Text != "")
            {
                if (ovCMB_TipoDocumento.SelectedIndex == 0)
                { //CNPJ
                    if (ovTXT_CNPJCPF.Text.Length < 14)
                    {
                        SyncMessager.CreateMessage(0, NOME_TELA, "Insira um CNPJ válido, com 14 digitos.", "yellow", false, false);
                        ovTXT_CNPJCPF.Focus();
                    }
                }
                else // CPF
                {
                    if (ovTXT_CNPJCPF.Text.Length < 11)
                    {
                        SyncMessager.CreateMessage(0, NOME_TELA, "Insira um CPF válido, com 11 digitos.", "yellow", false, false);
                        ovTXT_CNPJCPF.Focus();
                    }
                }
            }
        }   
              
        private void ovTXT_DocEstrangeiro_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ovTXT_DocEstrangeiro.Text = SyncUtil.SomenteNumeros(ovTXT_DocEstrangeiro.Text);
        }

        private void TXT_IDMunicipio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TXT_IDMunicipio.Text = SyncUtil.SomenteNumeros(TXT_IDMunicipio.Text);
        }

        private void ovTXT_Numero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ovTXT_Numero.Text = SyncUtil.SomenteNumeros(ovTXT_Numero.Text);
        }
        
        
        private void ovTXT_Bairro_Enter(object sender, EventArgs e)
        {

        }

        private void TXT_IDMunicipio_Click(object sender, EventArgs e)
        {
            if (_SelectedUnidadeFederativa == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Informe a UF.", "yellow", false, false);
                TXT_UF.Focus();
            }
        }

        private void TXT_UF_Enter(object sender, EventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ovLBL_CNPJCPF_Click(object sender, EventArgs e)
        {

        }
    }
}
