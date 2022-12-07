using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesMunicipio
    {
        public static Municipio GetMunicipio(decimal IDMunicipio)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT MUNICIPIO.IDMUNICIPIO,
                                    MUNICIPIO.DESCRICAO,
                                    UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO AS UNIDADEFEDERATIVA,
                                    MUNICIPIO.CODIGOIBGE
                               FROM MUNICIPIO
                                 INNER JOIN UNIDADEFEDERATIVA ON (MUNICIPIO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                               WHERE MUNICIPIO.IDMUNICIPIO = @IDMUNICIPIO";
                oSQL.ParamByName["IDMUNICIPIO"] = IDMunicipio;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Municipio>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Municipio GetMunicipioPorCodigo(decimal CodigoIBGE)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT MUNICIPIO.IDMUNICIPIO,
                                    MUNICIPIO.DESCRICAO,
                                    UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO AS UNIDADEFEDERATIVA,
                                    MUNICIPIO.CODIGOIBGE
                               FROM MUNICIPIO
                                 INNER JOIN UNIDADEFEDERATIVA ON (MUNICIPIO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                               WHERE MUNICIPIO.CODIGOIBGE = @CODIGOIBGE";
                oSQL.ParamByName["CODIGOIBGE"] = CodigoIBGE;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Municipio>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetMunicipios(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(MUNICIPIO.DESCRICAO)) LIKE UNACCENT(UPPER('%{0}%')))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT MUNICIPIO.IDMUNICIPIO,
                                    MUNICIPIO.DESCRICAO,
                                    MUNICIPIO.CODIGOIBGE,
                                    UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO AS UNIDADEFEDERATIVA
                             FROM MUNICIPIO
                               INNER JOIN UNIDADEFEDERATIVA ON (MUNICIPIO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                             {0} ORDER BY MUNICIPIO.DESCRICAO, UNIDADEFEDERATIVA.DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetMunicipiosDescricaoEUf(string Descricao, decimal UF)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(MUNICIPIO.DESCRICAO)) LIKE UNACCENT(UPPER('%{0}%')))", Descricao));
                if (UF != 0)
                    Filtros.Add(string.Format("(MUNICIPIO.IDUNIDADEFEDERATIVA = {0})", UF));

                oSQL.SQL = string.Format(
                           @"SELECT MUNICIPIO.IDMUNICIPIO,
                                    MUNICIPIO.DESCRICAO,
                                    MUNICIPIO.CODIGOIBGE,
                                    UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO AS UNIDADEFEDERATIVA
                             FROM MUNICIPIO
                               INNER JOIN UNIDADEFEDERATIVA ON (MUNICIPIO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                             {0} ORDER BY MUNICIPIO.DESCRICAO, UNIDADEFEDERATIVA.DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(Municipio _Municipio, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO MUNICIPIO (IDMUNICIPIO, IDUNIDADEFEDERATIVA, DESCRICAO, CODIGOIBGE) VALUES (@IDMUNICIPIO, @IDUNIDADEFEDERATIVA, @DESCRICAO, @CODIGOIBGE)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE MUNICIPIO
                                        SET DESCRICAO = @DESCRICAO,
                                            IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA,
                                            CODIGOIBGE = @CODIGOIBGE
                                      WHERE IDMUNICIPIO = @IDMUNICIPIO";
                        break;
                }
                oSQL.ParamByName["IDMUNICIPIO"] = _Municipio.IDMunicipio;
                oSQL.ParamByName["DESCRICAO"] = _Municipio.Descricao;
                oSQL.ParamByName["CODIGOIBGE"] = _Municipio.CodigoIBGE;
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = _Municipio.IDUnidadeFederativa;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDMunicipio)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM MUNICIPIO WHERE IDMUNICIPIO = @IDMUNICIPIO";
                oSQL.ParamByName["IDMUNICIPIO"] = IDMunicipio;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool Remover(decimal IDMunicipio)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM ENDERECO WHERE IDMUNICIPIO = @IDMUNICIPIO";
                oSQL.ParamByName["IDMUNICIPIO"] = IDMunicipio;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("O Município tem vinculo com Endereço e não pode ser remvido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM MUNICIPIO WHERE IDMUNICIPIO = @IDMUNICIPIO";
                oSQL.ParamByName["IDMUNICIPIO"] = IDMunicipio;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<Municipio> GetMunicipios(decimal IDUnidadeFederativa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMUNICIPIO, 
                                    IDUNIDADEFEDERATIVA,
                                    DESCRICAO,
                                    CODIGOIBGE
                             FROM MUNICIPIO 
                               WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();
                return new DataTableParser<Municipio>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
