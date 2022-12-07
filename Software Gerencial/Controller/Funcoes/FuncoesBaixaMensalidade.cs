using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesBaixaMensalidade
    {
        public static bool Salvar(BaixaMensalidade _BaixaMensalidade, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO BAIXAMENSALIDADE(IDBAIXAMENSALIDADE, IDMENSALIDADE, IDFORMADEPAGAMENTO, IDCONTABANCARIA, 
                                        COMPLEMENTO, BAIXA, MULTA, JUROS, DESCONTO, VALOR, DATACONCILIACAO)
                                       VALUES (@IDBAIXAMENSALIDADE, @IDMENSALIDADE, @IDFORMADEPAGAMENTO, @IDCONTABANCARIA, 
                                        @COMPLEMENTO, @BAIXA, @MULTA, @JUROS, @DESCONTO, @VALOR, @DATACONCILIACAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE BAIXAMENSALIDADE
                                       SET  IDMENSALIDADE        = @IDMENSALIDADE, 
                                            IDFORMADEPAGAMENTO    = @IDFORMADEPAGAMENTO, 
                                            IDCONTABANCARIA       = @IDCONTABANCARIA,
                                            COMPLEMENTO          = @COMPLEMENTO, 
                                            BAIXA                 = @BAIXA, 
                                            MULTA                 = @MULTA,
                                            JUROS                 = @JUROS,
                                            DESCONTO              = @DESCONTO, 
                                            VALOR                 = @VALOR, 
                                            DATACONCILIACAO       = @DATACONCILIACAO
                                     WHERE IDBAIXAMENSALIDADE     = @IDBAIXAMENSALIDADE";
                        break;
                }
                oSQL.ParamByName["IDBAIXAMENSALIDADE"] = _BaixaMensalidade.IDBaixaMensalidade;
                oSQL.ParamByName["IDMENSALIDADE"] = _BaixaMensalidade.IDMensalidade;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = _BaixaMensalidade.IDFormaDePagamento;
                oSQL.ParamByName["IDCONTABANCARIA"] = _BaixaMensalidade.IDContaBancaria;
                oSQL.ParamByName["COMPLEMENTO"] = _BaixaMensalidade.Complemento;
                oSQL.ParamByName["BAIXA"] = _BaixaMensalidade.Baixa;
                oSQL.ParamByName["MULTA"] = _BaixaMensalidade.Multa;
                oSQL.ParamByName["JUROS"] = _BaixaMensalidade.Juros;
                oSQL.ParamByName["DESCONTO"] = _BaixaMensalidade.Desconto;
                oSQL.ParamByName["VALOR"] = _BaixaMensalidade.Valor;
                oSQL.ParamByName["DATACONCILIACAO"] = _BaixaMensalidade.DataConciliacao;

                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDBAIXAMENSALIDADE)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM CHEQUEMENSALIDADE WHERE IDBAIXAMENSALIDADE = @IDBAIXAMENSALIDADE";
                oSQL.ParamByName["IDBAIXAMENSALIDADE"] = IDBAIXAMENSALIDADE;
                oSQL.ExecSQL();

                oSQL.ClearAll();

                oSQL.SQL = "DELETE FROM BAIXAMENSALIDADE WHERE IDBAIXAMENSALIDADE = @IDBAIXAMENSALIDADE";
                oSQL.ParamByName["IDBAIXAMENSALIDADE"] = IDBAIXAMENSALIDADE;
                oSQL.ExecSQL();
                return true;
            }
        }

        public static DataTable GetBaixas(decimal IDMENSALIDADE)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT BAIXAMENSALIDADE.IDBAIXAMENSALIDADE,
                                    BAIXAMENSALIDADE.BAIXA,
                                    CONTABANCARIA.NOME AS CONTABANCARIA,
                                    (COALESCE(BAIXAMENSALIDADE.VALOR, 0) - COALESCE(BAIXAMENSALIDADE.DESCONTO, 0)) + COALESCE(BAIXAMENSALIDADE.MULTA, 0) + COALESCE(BAIXAMENSALIDADE.JUROS, 0) AS TOTAL,
                                    BAIXAMENSALIDADE.VALOR,
                                    BAIXAMENSALIDADE.IDMENSALIDADE,
                                    BAIXAMENSALIDADE.IDFORMADEPAGAMENTO,
                                    BAIXAMENSALIDADE.IDCONTABANCARIA,
                                    BAIXAMENSALIDADE.ORIGEM,
                                    BAIXAMENSALIDADE.COMPLEMENTO,
                                    BAIXAMENSALIDADE.MULTA,
                                    BAIXAMENSALIDADE.JUROS,
                                    BAIXAMENSALIDADE.DESCONTO,
                                    BAIXAMENSALIDADE.DATACONCILIACAO
                               FROM BAIXAMENSALIDADE
                                 INNER JOIN CONTABANCARIA ON (BAIXAMENSALIDADE.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                             WHERE BAIXAMENSALIDADE.IDMENSALIDADE = @IDMENSALIDADE";
                oSQL.ParamByName["IDMENSALIDADE"] = IDMENSALIDADE;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
