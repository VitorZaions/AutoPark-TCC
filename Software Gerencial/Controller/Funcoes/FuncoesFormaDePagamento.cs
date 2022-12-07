using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using PDV.DAO.Entidades;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesFormaDePagamento
    {
        public static bool Existe(decimal IDFormaDePagamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM FORMADEPAGAMENTO WHERE IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO";
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = IDFormaDePagamento;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExistePorIdentificacao(string IDENTIFICACAO, decimal IDFORMADEPAGAMENTO)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM FORMADEPAGAMENTO WHERE UPPER(IDENTIFICACAO) = UPPER(@IDENTIFICACAO) AND IDFORMADEPAGAMENTO <> @IDFORMADEPAGAMENTO";
                oSQL.ParamByName["IDENTIFICACAO"] = IDENTIFICACAO;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = IDFORMADEPAGAMENTO;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static FormaDePagamento GetFormaDePagamento(decimal IDFormaDePagamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT FORMADEPAGAMENTO.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.CODIGOTIPOPAGAMENTO,
                                    FORMADEPAGAMENTO.IDBANDEIRACARTAO,
                                    FORMADEPAGAMENTO.IDENTIFICACAO,
                                    FORMADEPAGAMENTO.ATIVO,
                                    TIPOPAGAMENTO.DESCRICAO AS DESCRICAOTIPOPAGAMENTO
                               FROM FORMADEPAGAMENTO 
                               INNER JOIN TIPOPAGAMENTO ON (FORMADEPAGAMENTO.CODIGOTIPOPAGAMENTO = TIPOPAGAMENTO.CODIGOTIPOPAGAMENTO)
                             WHERE IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO";
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = IDFormaDePagamento;
                oSQL.Open();
                return EntityUtil<FormaDePagamento>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetFormasDePagamento(string IDForma, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(IDForma))
                    Filtros.Add(string.Format("(UPPER(FORMADEPAGAMENTO.IDFORMADEPAGAMENTO::VARCHAR) LIKE UNACCENT(UPPER('%{0}%')))", IDForma));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(TIPOPAGAMENTO.DESCRICAO)) LIKE UNACCENT(UPPER('%{0}%')))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT FORMADEPAGAMENTO.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.CODIGOTIPOPAGAMENTO,
                                    BANDEIRACARTAO.DESCRICAO AS BANDEIRACARTAO,
                                    FORMADEPAGAMENTO.IDENTIFICACAO,
                                    CASE WHEN FORMADEPAGAMENTO.ATIVO = 0 THEN 'Não' ELSE 'Sim' END AS ATIVO,
                                    BANDEIRACARTAO.IDBANDEIRACARTAO,
                                    TIPOPAGAMENTO.DESCRICAO AS DESCRICAOTIPOPAGAMENTO
                               FROM FORMADEPAGAMENTO
                                 INNER JOIN TIPOPAGAMENTO ON (FORMADEPAGAMENTO.CODIGOTIPOPAGAMENTO = TIPOPAGAMENTO.CODIGOTIPOPAGAMENTO)
                                 LEFT JOIN BANDEIRACARTAO ON (FORMADEPAGAMENTO.IDBANDEIRACARTAO = BANDEIRACARTAO.IDBANDEIRACARTAO)
                             {0}
                             ORDER BY FORMADEPAGAMENTO.IDENTIFICACAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }


        public static List<FormaDePagamento> GetFormasPagamento()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT FORMADEPAGAMENTO.IDBANDEIRACARTAO,
                                    FORMADEPAGAMENTO.CODIGOTIPOPAGAMENTO,
                                    CASE WHEN FORMADEPAGAMENTO.IDBANDEIRACARTAO IS NULL
                                      THEN TIPOPAGAMENTO.DESCRICAO ELSE TIPOPAGAMENTO.DESCRICAO||' - '||BANDEIRACARTAO.DESCRICAO
                                    END AS FORMADEPAGAMENTOBANDEIRA,
                                    FORMADEPAGAMENTO.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.IDENTIFICACAO,
                                    FORMADEPAGAMENTO.ATIVO,
                                    TIPOPAGAMENTO.DESCRICAO AS DESCRICAOTIPOPAGAMENTO
                               FROM FORMADEPAGAMENTO 
                                 INNER JOIN TIPOPAGAMENTO ON (FORMADEPAGAMENTO.CODIGOTIPOPAGAMENTO = TIPOPAGAMENTO.CODIGOTIPOPAGAMENTO)
                                 LEFT JOIN BANDEIRACARTAO ON (FORMADEPAGAMENTO.IDBANDEIRACARTAO = BANDEIRACARTAO.IDBANDEIRACARTAO)
                               WHERE FORMADEPAGAMENTO.ATIVO = 1
                             ORDER BY TIPOPAGAMENTO.DESCRICAO";
                oSQL.Open();
                return new DataTableParser<FormaDePagamento>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(FormaDePagamento _FormaDePagamento, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO FORMADEPAGAMENTO (IDFORMADEPAGAMENTO, IDBANDEIRACARTAO, IDENTIFICACAO, CODIGOTIPOPAGAMENTO, ATIVO)
                                        VALUES (@IDFORMADEPAGAMENTO, @IDBANDEIRACARTAO, @IDENTIFICACAO, @CODIGOTIPOPAGAMENTO , @ATIVO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE FORMADEPAGAMENTO SET
                                          IDBANDEIRACARTAO = @IDBANDEIRACARTAO,
                                          IDENTIFICACAO = @IDENTIFICACAO,
                                          ATIVO = @ATIVO,
                                          CODIGOTIPOPAGAMENTO = @CODIGOTIPOPAGAMENTO
                                     WHERE IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO";
                        break;
                }
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = _FormaDePagamento.IDFormaDePagamento;
                oSQL.ParamByName["CODIGOTIPOPAGAMENTO"] = _FormaDePagamento.CodigoTipoPagamento;
                oSQL.ParamByName["IDBANDEIRACARTAO"] = _FormaDePagamento.IDBandeiraCartao;
                oSQL.ParamByName["IDENTIFICACAO"] = _FormaDePagamento.Identificacao;
                oSQL.ParamByName["ATIVO"] = _FormaDePagamento.Ativo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDFormaDePagamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM FORMADEPAGAMENTO WHERE IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO";
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = IDFormaDePagamento;
                return oSQL.ExecSQL() == 1;
            }
        }

    }
}
