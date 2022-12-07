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
    public class FuncoesPais
    {
        public static bool Existe(decimal IDPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PAIS WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExistePorCodigo(string CODIGO, decimal IDPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PAIS WHERE CODIGO = @CODIGO and IDPAIS <> @IDPAIS";
                oSQL.ParamByName["CODIGO"] = CODIGO;
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }


        public static DataTable GetPaisesDataTable(string Codigo, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Codigo))
                    Filtros.Add(string.Format("(PAIS.CODIGO = {0})", Codigo));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(PAIS.DESCRICAO)) LIKE UNACCENT(UPPER('%{0}%')))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT PAIS.IDPAIS, 
                                    PAIS.CODIGO, 
                                    PAIS.DESCRICAO
                               FROM PAIS {0}
                             ORDER BY DESCRICAO, CODIGO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Pais> GetPaises()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDPAIS, CODIGO, DESCRICAO FROM PAIS ORDER BY DESCRICAO";
                oSQL.Open();
                return new DataTableParser<Pais>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static Pais GetPais(decimal IDPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDPAIS, CODIGO, DESCRICAO FROM PAIS WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();
                return EntityUtil<Pais>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetPaises(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(DESCRICAO)) LIKE UNACCENT(UPPER('%{0}%')))", Descricao));

                oSQL.SQL = string.Format("SELECT IDPAIS, DESCRICAO FROM PAIS {0} ORDER BY DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(Pais _P, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO PAIS (IDPAIS, CODIGO, DESCRICAO) VALUES (@IDPAIS, @CODIGO, @DESCRICAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = "UPDATE PAIS SET DESCRICAO = @DESCRICAO, CODIGO = @CODIGO WHERE IDPAIS = @IDPAIS";
                        break;
                }
                oSQL.ParamByName["IDPAIS"] = _P.IDPais;
                oSQL.ParamByName["DESCRICAO"] = _P.Descricao;
                oSQL.ParamByName["CODIGO"] = _P.Codigo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM UNIDADEFEDERATIVA WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();

                if (!oSQL.IsEmpty)
                    throw new Exception("O Pais tem vinculo com Unidade Federativa e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = @"SELECT 1 FROM UNIDADEFEDERATIVA WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("O Pais tem vinculo com Endereço e não pode ser remvido.");

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM PAIS WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                return oSQL.ExecSQL() == 1;
            }
        }

    }
}