using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesFornecedor
    {
        public static bool ExisteFornecedor(decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Fornecedor GetFornecedor(decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Fornecedor>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Fornecedor GetFornecedorPorCPFCNPJ(string CPFCNPJ)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM FORNECEDOR WHERE CPFCNPJ = @CPFCNPJ";
                oSQL.ParamByName["CPFCNPJ"] = CPFCNPJ;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Fornecedor>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetFornecedores(string Nome_RazaoSocial, string CPF_CNPJ)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Nome_RazaoSocial))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(RAZAOSOCIAL)) LIKE UNACCENT(UPPER('%{0}%')))", Nome_RazaoSocial));

                if (!string.IsNullOrEmpty(CPF_CNPJ))
                    Filtros.Add(string.Format("(CPFCNPJ LIKE UNACCENT(UPPER('%{0}%')))", CPF_CNPJ));

                oSQL.SQL = string.Format(@"SELECT FORNECEDOR.IDFORNECEDOR,
                                                  CPFCNPJ,
                                                  RAZAOSOCIAL,
                                                  IDENDERECO,
                                                  IDCONTATO,
                                                  INSCRICAOESTADUAL,
                                                  NOMEFANTASIA
                                           FROM FORNECEDOR {0}
                                              ORDER BY RAZAOSOCIAL, CPFCNPJ", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Fornecedor> GetFornecedores()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT FORNECEDOR.IDFORNECEDOR,
                                    CPFCNPJ,
                                    RAZAOSOCIAL,
                                    FORNECEDOR.CPFCNPJ || ' - ' || FORNECEDOR.RAZAOSOCIAL AS DESCRICAO,
                                    IDCONTATO,
                                    IDENDERECO,
                                    INSCRICAOESTADUAL,
                                    NOMEFANTASIA
                             FROM FORNECEDOR
                                ORDER BY RAZAOSOCIAL, CPFCNPJ";
                oSQL.Open();
                return EntityUtil<Fornecedor>.ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool ExisteFornecedorPorCPFCNPJ(string CPFCNPJ, decimal IDFORNECEDOR)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM FORNECEDOR WHERE UPPER(CPFCNPJ) = UPPER(@CPFCNPJ) AND IDFORNECEDOR <> @IDFORNECEDOR";
                oSQL.ParamByName["CPFCNPJ"] = CPFCNPJ;
                oSQL.ParamByName["IDFORNECEDOR"] = IDFORNECEDOR;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool Salvar(Fornecedor _Fornecedor, TipoOperacao _Operacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (_Operacao)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO FORNECEDOR
                                       (IDFORNECEDOR, RAZAOSOCIAL, CPFCNPJ, IDENDERECO, IDCONTATO, INSCRICAOESTADUAL, NOMEFANTASIA, TIPODOCUMENTO)
                                     VALUES
                                       (@IDFORNECEDOR, @RAZAOSOCIAL, @CPFCNPJ, @IDENDERECO, @IDCONTATO, @INSCRICAOESTADUAL, @NOMEFANTASIA, @TIPODOCUMENTO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE FORNECEDOR
                                       SET RAZAOSOCIAL = @RAZAOSOCIAL, 
                                           CPFCNPJ = @CPFCNPJ,
                                           IDENDERECO = @IDENDERECO,
                                           IDCONTATO = @IDCONTATO,
                                           INSCRICAOESTADUAL = @INSCRICAOESTADUAL,
                                           NOMEFANTASIA = @NOMEFANTASIA,
                                           TIPODOCUMENTO = @TIPODOCUMENTO
                                     WHERE IDFORNECEDOR = @IDFORNECEDOR";
                        break;
                }
                oSQL.ParamByName["IDFORNECEDOR"] = _Fornecedor.IDFornecedor;
                oSQL.ParamByName["RAZAOSOCIAL"] = _Fornecedor.RazaoSocial;
                oSQL.ParamByName["CPFCNPJ"] = _Fornecedor.CPFCNPJ;
                oSQL.ParamByName["IDCONTATO"] = _Fornecedor.IDContato;
                oSQL.ParamByName["IDENDERECO"] = _Fornecedor.IDEndereco;
                oSQL.ParamByName["INSCRICAOESTADUAL"] = _Fornecedor.InscricaoEstadual;
                oSQL.ParamByName["NOMEFANTASIA"] = _Fornecedor.NomeFantasia;
                oSQL.ParamByName["TIPODOCUMENTO"] = _Fornecedor.TipoDocumento;
                return oSQL.ExecSQL() == 1;              
            }
        }

        public static bool Remover(decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PRODUTO WHERE IDFORNECEDOR = @IDFORNECEDOR";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("Não é possível remover o Fornecedor, existe vinculo com Produto.");

                // Exclui contato e endereço
                decimal? IDEndereco = null;
                decimal? IDContato = null;

                oSQL.ClearAll();
                oSQL.SQL = "SELECT IDENDERECO FROM FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    IDEndereco = Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDENDERECO"]);

                oSQL.ClearAll();
                oSQL.SQL = "SELECT IDCONTATO FROM FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    IDContato = Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDCONTATO"]);
                 
                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                if (oSQL.ExecSQL() != 1)
                    throw new Exception();

                if (IDEndereco.HasValue)
                {
                    oSQL.ClearAll();
                    oSQL.SQL = "DELETE FROM ENDERECO WHERE IDENDERECO = @IDENDERECO";
                    oSQL.ParamByName["IDENDERECO"] = IDEndereco.Value;
                    if (oSQL.ExecSQL() != 1)
                        throw new Exception();
                }

                if (IDContato.HasValue)
                {
                    oSQL.ClearAll();
                    oSQL.SQL = "DELETE FROM CONTATO WHERE IDCONTATO = @IDCONTATO";
                    oSQL.ParamByName["IDCONTATO"] = IDContato.Value;
                    if (oSQL.ExecSQL() != 1)
                        throw new Exception();
                }

                /*oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM ENDERECO WHERE IDENDERECO IN (SELECT COALESCE(IDENDERECO, -1) FROM FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR)";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.ExecSQL();*/
                return true;
            }
        }
    }
}
