using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesUF
    {
        public static bool Existe(decimal IDUnidadeFederativa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM UNIDADEFEDERATIVA WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExistePorCodigo(decimal IDUF, decimal CODIGO, decimal IDPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM UNIDADEFEDERATIVA WHERE CODIGO = @CODIGO AND IDPAIS = @IDPAIS AND IDUNIDADEFEDERATIVA <> @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["CODIGO"] = CODIGO;
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUF;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExistePorSigla(decimal IDUF, decimal IDPais, string Sigla)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM UNIDADEFEDERATIVA WHERE IDPAIS = @IDPAIS AND SIGLA = @SIGLA AND IDUNIDADEFEDERATIVA <> @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.ParamByName["SIGLA"] = Sigla;
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUF;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }


        public static UnidadeFederativa GetUnidadeFederativa(decimal IDUnidadeFederativa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.*
                               FROM UNIDADEFEDERATIVA
                                 INNER JOIN PAIS ON(UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                               WHERE UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static UnidadeFederativa GetUnidadeFederativaPorSigla(string Sigla)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.*
                               FROM UNIDADEFEDERATIVA
                                 INNER JOIN PAIS ON(UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                               WHERE UPPER(UNIDADEFEDERATIVA.SIGLA) = @SIGLA";
                oSQL.ParamByName["SIGLA"] = Sigla.ToUpper();
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<UnidadeFederativa> GetUnidadeFederativaPorCodigoPais(string CodigoPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO,
                                    UNIDADEFEDERATIVA.SIGLA,
                                    UNIDADEFEDERATIVA.CODIGO,
                                    PAIS.IDPAIS,
                                    PAIS.DESCRICAO AS PAIS
                               FROM UNIDADEFEDERATIVA
                                 INNER JOIN PAIS ON(UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                               WHERE PAIS.CODIGO = @CODIGO";
                oSQL.ParamByName["CODIGO"] = CodigoPais;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return new DataTableParser<UnidadeFederativa>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static DataTable GetUnidadesFederativa(string Codigo, string Sigla, string Pais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Codigo))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(UNIDADEFEDERATIVA.CODIGO::TEXT)) LIKE UNACCENT(UPPER('%{0}%')))", Codigo));

                if (!string.IsNullOrEmpty(Sigla))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(UNIDADEFEDERATIVA.Sigla)) LIKE UNACCENT(UPPER('%{0}%')))", Sigla));

                if (!string.IsNullOrEmpty(Pais))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(Pais.DESCRICAO)) LIKE UNACCENT(UPPER('%{0}%')))", Pais));

                oSQL.SQL = string.Format(
                           @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO AS UNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.SIGLA,
                                    UNIDADEFEDERATIVA.CODIGO,                             
                                    PAIS.IDPAIS,
                                    PAIS.DESCRICAO AS PAIS
                               FROM UNIDADEFEDERATIVA
                                 INNER JOIN PAIS ON (UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                               {0} ORDER BY PAIS.DESCRICAO, PAIS.IDPAIS, UNIDADEFEDERATIVA.SIGLA, UNIDADEFEDERATIVA.CODIGO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Remover(decimal IDUnidadeFederativa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM MUNICIPIO WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();

                if (!oSQL.IsEmpty)
                    throw new Exception("A Unidade Federativa tem vinculo com município e não pode ser removida.");

                oSQL.ClearAll();
                oSQL.SQL = @"SELECT 1 FROM ENDERECO WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("A Unidade Federativa tem vinculo com Endereço e não pode ser remvido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM UNIDADEFEDERATIVA WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Salvar(UnidadeFederativa UF, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                        UNIDADEFEDERATIVA (IDUNIDADEFEDERATIVA, SIGLA, DESCRICAO, IDPAIS, CODIGO)
                                     VALUES (@IDUNIDADEFEDERATIVA, @SIGLA, @DESCRICAO, @IDPAIS, @CODIGO)";

                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE UNIDADEFEDERATIVA 
                                        SET SIGLA = @SIGLA,
                                            DESCRICAO = @DESCRICAO,
                                            IDPAIS = @IDPAIS,
                                            CODIGO = @CODIGO
                                        WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                        break;
                }
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = UF.IDUnidadeFederativa;
                oSQL.ParamByName["IDPAIS"] = UF.IDPais;
                oSQL.ParamByName["DESCRICAO"] = UF.Descricao;
                oSQL.ParamByName["SIGLA"] = UF.Sigla;
                oSQL.ParamByName["CODIGO"] = UF.Codigo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<UnidadeFederativa> GetUnidadesFederativa(decimal IDPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDUNIDADEFEDERATIVA,
                                    IDPAIS,
                                    SIGLA, 
                                    DESCRICAO,
                                    CODIGO
                             FROM UNIDADEFEDERATIVA
                              WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();
                return new DataTableParser<UnidadeFederativa>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<UnidadeFederativa> GetUnidadesFederativa()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.IDPAIS,
                                    UNIDADEFEDERATIVA.SIGLA, 
                                    UNIDADEFEDERATIVA.DESCRICAO,
                                    UNIDADEFEDERATIVA.CODIGO,
                             FROM UNIDADEFEDERATIVA
                               INNER JOIN PAIS ON (UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                              ORDER BY UNIDADEFEDERATIVA.SIGLA";
                oSQL.Open();
                return new DataTableParser<UnidadeFederativa>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<UnidadeFederativa> GetUnidadesFederativaNFe()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.SIGLA,
                                    UNIDADEFEDERATIVA.CODIGO
                             FROM UNIDADEFEDERATIVA
                               INNER JOIN PAIS ON (UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                              ORDER BY UNIDADEFEDERATIVA.SIGLA";
                oSQL.Open();
                return new DataTableParser<UnidadeFederativa>().ParseDataTable(oSQL.dtDados);
            }
        }
        
        public static DataTable GetUnidadesFederativaComAliquotasICMSDT()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA, 
                                     UNIDADEFEDERATIVA.IDPAIS, 
                                     UNIDADEFEDERATIVA.SIGLA,
                                     UNIDADEFEDERATIVA.CODIGO,
                                     COALESCE(UNIDADEFEDERATIVAICMS.ALIQUOTAINTER, 0) AS ALIQUOTAINTER, 
                                     COALESCE(UNIDADEFEDERATIVAICMS.ALIQUOTAINTRA, 0) AS ALIQUOTAINTRA,
                                     COALESCE(UNIDADEFEDERATIVAICMS.ALIQUOTAFCP, 0) AS ALIQUIOTAFCP                               
                             FROM UNIDADEFEDERATIVA                              
                             INNER JOIN UNIDADEFEDERATIVAICMS ON (UNIDADEFEDERATIVAICMS.IDUNIDADEFEDERATIVAICMS =  UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        

        public static UnidadeFederativa GetUnidadesFederativaComAliquotasICMS()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA, 
                                     UNIDADEFEDERATIVA.IDPAIS, 
                                     UNIDADEFEDERATIVA.SIGLA, 
                                     UNIDADEFEDERATIVA.CODIGO,
                                     COALESCE(UNIDADEFEDERATIVAICMS.ALIQUOTAINTER, 0) AS ALIQUOTAINTER, 
                                     COALESCE(UNIDADEFEDERATIVAICMS.ALIQUOTAINTRA, 0) AS ALIQUOTAINTRA,
                                     COALESCE(UNIDADEFEDERATIVAICMS.ALIQUOTAFCP, 0) AS ALIQUIOTAFCP                               
                             FROM UNIDADEFEDERATIVA                              
                             INNER JOIN UNIDADEFEDERATIVAICMS ON (UNIDADEFEDERATIVAICMS.IDUNIDADEFEDERATIVA =  UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)";
                oSQL.Open();
                if (!oSQL.IsEmpty)
                { 
                    return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
                }
                else
                {
                    return null;
                }
            }
        }

        public static UnidadeFederativa GetUnidadesFederativaComAliquotasICMS_PorUF(decimal IDUnidadeFederativa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA, 
                                     UNIDADEFEDERATIVA.IDPAIS, 
                                     UNIDADEFEDERATIVA.SIGLA, 
                                     UNIDADEFEDERATIVA.CODIGO,
                                     COALESCE(UNIDADEFEDERATIVAICMS.ALIQUOTAINTER, 0) AS ALIQUOTAINTER, 
                                     COALESCE(UNIDADEFEDERATIVAICMS.ALIQUOTAINTRA, 0) AS ALIQUOTAINTRA,
                                     COALESCE(UNIDADEFEDERATIVAICMS.ALIQUOTAFCP, 0) AS FCP
                             FROM UNIDADEFEDERATIVA
                               INNER JOIN ENDERECO ON (UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA = ENDERECO.IDUNIDADEFEDERATIVA)
                               LEFT JOIN UNIDADEFEDERATIVAICMS ON (UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVAICMS.IDUNIDADEFEDERATIVA)
                            WHERE UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();
                return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
