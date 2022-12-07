
using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;

namespace AutoController.Funcoes
{
    public class FuncoesEndereco
    {
        public static bool ExisteEndereco(decimal IDEndereco)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM ENDERECO WHERE IDENDERECO = @IDENDERECO";
                oSQL.ParamByName["IDENDERECO"] = IDEndereco;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Endereco GetEndereco(decimal IDEndereco)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT IDENDERECO,
                                   LOGRADOURO,
                                   NUMERO,
                                   CEP,
                                   COMPLEMENTO,
                                   BAIRRO,
                                   PAIS.IDPAIS,
                                   PAIS.DESCRICAO AS PAIS,
                                   UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                   UNIDADEFEDERATIVA.SIGLA AS UNIDADEFEDERATIVA,
                                   MUNICIPIO.IDMUNICIPIO,
                                   MUNICIPIO.DESCRICAO AS MUNICIPIO
                            FROM ENDERECO
                             LEFT JOIN PAIS ON(ENDERECO.IDPAIS = PAIS.IDPAIS)
                             LEFT JOIN UNIDADEFEDERATIVA ON (ENDERECO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                             LEFT JOIN MUNICIPIO ON(ENDERECO.IDMUNICIPIO = MUNICIPIO.IDMUNICIPIO)
                              WHERE IDENDERECO = @IDENDERECO";
                oSQL.ParamByName["IDENDERECO"] = IDEndereco;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Endereco>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Salvar(Endereco _Endereco, TipoOperacao _Operacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (_Operacao)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO ENDERECO
                                       (IDENDERECO, LOGRADOURO, NUMERO, CEP, COMPLEMENTO, BAIRRO, IDPAIS, IDUNIDADEFEDERATIVA, IDMUNICIPIO)
                                     VALUES 
                                       (@IDENDERECO, @LOGRADOURO, @NUMERO, @CEP, @COMPLEMENTO, @BAIRRO, @IDPAIS, @IDUNIDADEFEDERATIVA, @IDMUNICIPIO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE ENDERECO
                                       SET LOGRADOURO = @LOGRADOURO, 
                                           NUMERO = @NUMERO,
                                           CEP = @CEP,
                                           COMPLEMENTO = @COMPLEMENTO,
                                           BAIRRO = @BAIRRO,
                                           IDPAIS = @IDPAIS,
                                           IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA,
                                           IDMUNICIPIO = @IDMUNICIPIO
                                      WHERE IDENDERECO = @IDENDERECO";
                        break;
                }
                oSQL.ParamByName["IDENDERECO"] = _Endereco.IDEndereco;
                oSQL.ParamByName["LOGRADOURO"] = _Endereco.Logradouro;
                oSQL.ParamByName["NUMERO"] = _Endereco.Numero;
                oSQL.ParamByName["CEP"] = _Endereco.Cep;
                oSQL.ParamByName["COMPLEMENTO"] = _Endereco.Complemento;
                oSQL.ParamByName["BAIRRO"] = _Endereco.Bairro;
                oSQL.ParamByName["IDPAIS"] = _Endereco.IDPais;
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = _Endereco.IDUnidadeFederativa;
                oSQL.ParamByName["IDMUNICIPIO"] = _Endereco.IDMunicipio;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDEndereco)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM ENDERECO WHERE IDENDERECO = @IDENDERECO";
                oSQL.ParamByName["IDENDERECO"] = IDEndereco;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
