using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System.Collections.Generic;
using System.Data;


namespace AutoController.Funcoes
{
    public class FuncoesCentroCusto
    {
        public static bool Existe(decimal idCentroCusto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CENTROCUSTO WHERE IDCENTROCUSTO = @IDCENTROCUSTO";
                oSQL.ParamByName["IDCENTROCUSTO"] = idCentroCusto;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExistePorCentro(string CENTRO, decimal IDCENTROCUSTO)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CENTROCUSTO WHERE CENTRO = @CENTRO AND IDCENTROCUSTO <> @IDCENTROCUSTO";
                oSQL.ParamByName["CENTRO"] = CENTRO;
                oSQL.ParamByName["IDCENTROCUSTO"] = IDCENTROCUSTO;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }


        public static bool ExistePorCentroDescricao(string CENTRO, decimal IDCENTROCUSTO)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CENTROCUSTO WHERE UPPER(CENTRO) = UPPER(@CENTRO) AND IDCENTROCUSTO <> @IDCENTROCUSTO";
                oSQL.ParamByName["CENTRO"] = CENTRO;
                oSQL.ParamByName["IDCENTROCUSTO"] = IDCENTROCUSTO;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExistePorDescricao(string DESCRICAO, decimal IDCENTROCUSTO)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CENTROCUSTO WHERE DESCRICAO = @DESCRICAO AND IDCENTROCUSTO <> @IDCENTROCUSTO";
                oSQL.ParamByName["DESCRICAO"] = DESCRICAO;
                oSQL.ParamByName["IDCENTROCUSTO"] = IDCENTROCUSTO;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static CentroCusto GetCentroCusto(decimal idCentroCusto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCENTROCUSTO,
                                    CENTRO,
                                    DESCRICAO,
                                    OBSERVACAO
                               FROM CENTROCUSTO
                             WHERE IDCENTROCUSTO = @IDCENTROCUSTO";
                oSQL.ParamByName["IDCENTROCUSTO"] = idCentroCusto;
                oSQL.Open();
                return EntityUtil<CentroCusto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetCentrosCusto(string Centro, string Descricao, decimal IDCentroNaoPegar)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Centro))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(CENTROCUSTO.CENTRO)) LIKE UNACCENT(UPPER('%{0}%')))", Centro));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(CENTROCUSTO.DESCRICAO)) LIKE UNACCENT(UPPER('%{0}%')))", Descricao));

                if (IDCentroNaoPegar != -1)
                    Filtros.Add(string.Format("IDCENTROCUSTO <> @IDCENTROCUSTO {0}))", IDCentroNaoPegar));


                oSQL.SQL = string.Format(
                           @"SELECT CENTROCUSTO.IDCENTROCUSTO,
                                    CENTROCUSTO.CENTRO,
                                    CENTROCUSTO.DESCRICAO,
                                    CENTROCUSTOSUPERIOR.DESCRICAO AS CENTROSUPERIOR
                               FROM CENTROCUSTO 
                                 LEFT JOIN CENTROCUSTO CENTROCUSTOSUPERIOR ON (CENTROCUSTO.IDCENTROCUSTOSUPERIOR = CENTROCUSTOSUPERIOR.IDCENTROCUSTO)
                               {0}
                             ORDER BY CENTROCUSTO.DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<CentroCusto> GetCentrosCusto(decimal IDCentroCusto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT * FROM CENTROCUSTO WHERE IDCENTROCUSTO <> @IDCENTROCUSTO ORDER BY DESCRICAO";
                oSQL.ParamByName["IDCENTROCUSTO"] = IDCentroCusto;
                oSQL.Open();
                return new DataTableParser<CentroCusto>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<CentroCusto> GetCentrosCusto()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM CENTROCUSTO ORDER BY DESCRICAO";
                oSQL.Open();
                return EntityUtil<CentroCusto>.ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(CentroCusto _CentroCusto, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                        CENTROCUSTO (IDCENTROCUSTO, CENTRO, DESCRICAO, OBSERVACAO, IDCENTROCUSTOSUPERIOR) 
                                            VALUES (@IDCENTROCUSTO, @CENTRO, @DESCRICAO, @OBSERVACAO, @IDCENTROCUSTOSUPERIOR)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CENTROCUSTO
                                      SET CENTRO = @CENTRO, 
                                          DESCRICAO = @DESCRICAO,
                                          OBSERVACAO = @OBSERVACAO,
                                          IDCENTROCUSTOSUPERIOR = @IDCENTROCUSTOSUPERIOR
                                     WHERE IDCENTROCUSTO = @IDCENTROCUSTO";
                        break;
                }

                oSQL.ParamByName["IDCENTROCUSTO"] = _CentroCusto.IDCentroCusto;
                oSQL.ParamByName["CENTRO"] = _CentroCusto.Centro;
                oSQL.ParamByName["DESCRICAO"] = _CentroCusto.Descricao;
                oSQL.ParamByName["OBSERVACAO"] = _CentroCusto.Observacao;
                oSQL.ParamByName["IDCENTROCUSTOSUPERIOR"] = _CentroCusto.IDCentroCustoSuperior;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDCentroCusto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM CLASSIFICACAOCONTARECEBER WHERE IDCENTROCUSTO = @IDCENTROCUSTO
                               UNION 
                             SELECT 1 FROM CLASSIFICACAOCONTAPAGAR WHERE IDCENTROCUSTO = @IDCENTROCUSTO";
                oSQL.ParamByName["IDCENTROCUSTO"] = IDCentroCusto;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new System.Exception("O Centro de Custo tem vínculo com Classificação e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = "SELECT 1 FROM CENTROCUSTO WHERE IDCENTROCUSTOSUPERIOR = @IDCENTROCUSTO";
                oSQL.ParamByName["IDCENTROCUSTO"] = IDCentroCusto;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new System.Exception("O Centro de Custo tem vínculo com Centro de Custo Superior e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM CENTROCUSTO WHERE IDCENTROCUSTO = @IDCENTROCUSTO";
                oSQL.ParamByName["IDCENTROCUSTO"] = IDCentroCusto;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
