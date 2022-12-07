using AutoController.Funcoes;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using AutoPark.Forms.Consultas;
using AutoUTIL;
using MetroFramework.Forms;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace AutoPark.Forms.Cadastro
{
    public partial class FCA_Veiculo : MetroForm    
    {
        Veiculo _Veiculo;
        private List<UnidadeFederativa> _UnidadesFederativas = null;
        private UnidadeFederativa _SelectedUnidadeFederativa = null;
        List<Pais> _Paises = null;
        string NOME_TELA = "Cadastro de Veículo";
        private Cliente CLIENTE = null;
        public FCA_Veiculo(Veiculo _V)
        {
            InitializeComponent();
            _Veiculo = _V;
            _UnidadesFederativas = FuncoesUF.GetUnidadesFederativa(_Veiculo.IDPais);
            
            _Paises = FuncoesPais.GetPaises();
            ovCMB_Pais.DataSource = _Paises;
            ovCMB_Pais.DisplayMember = "descricao";
            ovCMB_Pais.ValueMember = "idpais";
            ovCMB_Pais.SelectedItem = _Paises.Where(o => o.IDPais == _Veiculo.IDPais).FirstOrDefault();

            if (_Veiculo != null)
                if(_Veiculo.IDVeiculo != -1)
                    PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Descricao.Text = _Veiculo.Descricao;            
            ovTXT_Descricao.Text = _Veiculo.Descricao;
            ovTXT_Placa.Text = _Veiculo.Placa;     
            ovCMB_Pais.SelectedItem = _Paises.Where(o => o.IDPais == _Veiculo.IDPais).FirstOrDefault();
            _SelectedUnidadeFederativa = FuncoesUF.GetUnidadeFederativa(_Veiculo.IDUnidadeFederativa);
            TXT_UF.Text = _SelectedUnidadeFederativa.Sigla;
            ovCMB_Tipo.SelectedIndex = Convert.ToInt32(_Veiculo.Tipo);
            CLIENTE = _Veiculo.IDCLIENTE.HasValue ? FuncoesCliente.GetCliente(_Veiculo.IDCLIENTE.Value) : null;

            if (CLIENTE != null)
            {
                if (CLIENTE.TipoDocumento == 0)
                {
                    // CNPJ
                    ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CNPJ)).ToString(@"00\.000\.000\/0000\-00");
                }
                else if (CLIENTE.TipoDocumento == 1)
                {
                    // CPF
                    ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CPF)).ToString(@"000\.000\.000\-00");
                }
                else
                {
                    //Estrangeiro
                    ovTXT_CodCliente.Text = CLIENTE.DocEstrangeiro;
                }

                ovTXT_Cliente.Text = CLIENTE.TipoDocumento == 0 ? CLIENTE.RazaoSocial : CLIENTE.Nome;
            }
            else
            {
                ovTXT_Cliente.Text = "<Cliente Não Informado>";
            }

        }


        private void FCA_Veiculo_Load(object sender, EventArgs e)
        {

        }

        public bool ValidouDados()
        {
            /* Aba Transportadora */

            if (string.IsNullOrEmpty(ovTXT_Descricao.Text))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, string.Format("Informe a Descrição."), "yellow", false, false);
                ovTXT_Descricao.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ovTXT_Placa.Text))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, string.Format("Informe a Placa."), "yellow", false, false);
                ovTXT_Placa.Focus();
                return false;
            }

            if (ovCMB_Tipo.SelectedItem == null || ovCMB_Tipo.SelectedIndex == -1)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o Tipo.", "yellow", false, false);
                ovCMB_Tipo.Focus();
                return false;
            }

            if (ovCMB_Pais.SelectedItem == null || ovCMB_Pais.SelectedIndex == -1)
            {
               SyncMessager.CreateMessage(0, NOME_TELA, "Selecione o País.", "yellow", false, false);
                ovCMB_Pais.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TXT_UF.Text))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Selecione a Unidade Federativa.", "yellow", false, false);
                TXT_UF.Focus();
                return false;
            }

            if (FuncoesVeiculo.ExisteVeiculoPorPlaca(_Veiculo.IDVeiculo, ovTXT_Placa.Text))
            {
                SyncMessager.CreateMessage(0, NOME_TELA, string.Format("Informa uma placa ainda não cadastrada."), "yellow", false, false);
                ovTXT_Placa.Focus();
                return false;
            }

            return true;
        }


        private void BTN_Salvar_Click(object sender, EventArgs e)
        {
            LoadingCall LoadingScreen = new LoadingCall("Salvando..");
            bool InTransaction = false;
            bool IsLoadingScreen = false;

            try
            {
                ovTXT_Descricao.Text = ovTXT_Descricao.Text.Trim();
                ovTXT_Placa.Text = ovTXT_Placa.Text.Trim();
 
                if (!ValidouDados())
                {
                    return;
                }

                PDVControlador.BeginTransaction();
                InTransaction = true;
                LoadingScreen.ShowLoading();
                IsLoadingScreen = true;

                TipoOperacao TOVeiculo = TipoOperacao.UPDATE;
                if (_Veiculo.IDVeiculo == -1)
                {
                    TOVeiculo = TipoOperacao.INSERT;
                    _Veiculo.IDVeiculo = Sequence.GetNextID("VEICULO", "IDVEICULO");
                }

                _Veiculo.Ativo = CheckBox_Ativo.Checked ? 1 : 0;
                _Veiculo.Descricao = ovTXT_Descricao.Text;
                _Veiculo.Placa = ovTXT_Placa.Text;
                _Veiculo.IDPais = (ovCMB_Pais.SelectedItem as Pais).IDPais;
                _Veiculo.IDUnidadeFederativa = _SelectedUnidadeFederativa.IDUnidadeFederativa;
                _Veiculo.IDCLIENTE = CLIENTE == null ? null : (decimal?)CLIENTE.IDCliente;
                _Veiculo.Tipo = ovCMB_Tipo.SelectedIndex;

                if (!FuncoesVeiculo.Salvar(_Veiculo, TOVeiculo))
                    throw new Exception("Não foi possível salvar o Veículo.");

                PDVControlador.Commit();
                InTransaction = false;
                LoadingScreen.CloseLoading();
                IsLoadingScreen = false;

               SyncMessager.CreateMessage(0, NOME_TELA, 
                   "Veículo salvo com sucesso!", "green", false, false);
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

        private void BTN_Transportadora_Click(object sender, EventArgs e)
        {
           
        }

        private void ovTXT_RNTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovCMB_Pais_SelectedValueChanged(object sender, EventArgs e)
        {
            LimparSelecaoCombosEndereco(0);
        }

        private void LimparSelecaoCombosEndereco(int Modo)
        {
            switch (Modo)
            {
                case 0: // TIRA UF
                    TXT_UF.Text = null;
                    _SelectedUnidadeFederativa = null;
                    break;
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

        private void TXT_UF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BTN_Salvar.Focus();
            }
        }

        private void FCA_Veiculo_Shown(object sender, EventArgs e)
        {
            ovTXT_Descricao.Focus();
        }

        private void ovTXT_CodCliente_Leave(object sender, EventArgs e)
        {
            if (ovTXT_CodCliente.Text != string.Empty)
            {
                CLIENTE = FuncoesCliente.GetClientePorDocumento(SyncUtil.SomenteNumeros(ovTXT_CodCliente.Text));

                if (CLIENTE == null)
                {
                    SyncMessager.CreateMessage(0, NOME_TELA, "Cliente inexistente, insira uma Cliente válido.", "yellow", false, false);
                    ovTXT_Cliente.Text = "<Cliente Não Informado>";
                    ovTXT_CodCliente.Text = null;
                    ovTXT_CodCliente.Focus();
                }
                else
                {
                    if (CLIENTE.TipoDocumento == 0)
                    {
                        // CNPJ
                        ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CNPJ)).ToString(@"00\.000\.000\/0000\-00");
                    }
                    else if (CLIENTE.TipoDocumento == 1)
                    {
                        // CPF
                        ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CPF)).ToString(@"000\.000\.000\-00");
                    }
                    else
                    {
                        //Estrangeiro
                        ovTXT_CodCliente.Text = CLIENTE.DocEstrangeiro;
                    }
                    ovTXT_Cliente.Text = CLIENTE.TipoDocumento == 0 ? CLIENTE.RazaoSocial : CLIENTE.Nome;
                }
            }
            else
            {
                CLIENTE = null;
                ovTXT_Cliente.Text = "<Cliente Não Informado>";
                ovTXT_CodCliente.Text = null;
            }
        }

        private void ovTXT_CodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BTN_Salvar.Focus();
            }
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            FCO_Cliente SeletorCliente = new FCO_Cliente(true);
            SeletorCliente.ShowDialog(this);

            if (SeletorCliente.DRSelected == null)
                return;

            DataRow DrSelecionada = SeletorCliente.DRSelected;
            CLIENTE = FuncoesCliente.GetCliente(Convert.ToDecimal(DrSelecionada["IDCLIENTE"]));

            if (CLIENTE == null)
            {
                SyncMessager.CreateMessage(0, NOME_TELA, "Cliente inexistente, insira uma Cliente válido.", "yellow", false, false);
                ovTXT_Cliente.Text = "<Cliente Não Informado>";
                ovTXT_CodCliente.Text = null;
                ovTXT_CodCliente.Focus();
            }
            else
            {
                if (CLIENTE.TipoDocumento == 0)
                {
                    // CNPJ
                    ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CNPJ)).ToString(@"00\.000\.000\/0000\-00");
                }
                else if (CLIENTE.TipoDocumento == 1)
                {
                    // CPF
                    ovTXT_CodCliente.Text = Convert.ToInt64(SyncUtil.SomenteNumeros(CLIENTE.CPF)).ToString(@"000\.000\.000\-00");
                }
                else
                {
                    //Estrangeiro
                    ovTXT_CodCliente.Text = CLIENTE.DocEstrangeiro;
                }

                ovTXT_Cliente.Text = CLIENTE.TipoDocumento == 0 ? CLIENTE.RazaoSocial : CLIENTE.Nome;
            }
        }

        private void BTN_Limpar_Click(object sender, EventArgs e)
        {
            CLIENTE = null;
            ovTXT_Cliente.Text = "<Cliente Não Informado>";
            ovTXT_CodCliente.Text = null;
        }

        private void ovTXT_Placa_Validating_1(object sender, CancelEventArgs e)
        {
             ovTXT_Placa.Text = SyncUtil.RemoveSpecialCharacters(ovTXT_Placa.Text);
        }

        private void ovTXT_Placa_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }            
        }
    }
}
