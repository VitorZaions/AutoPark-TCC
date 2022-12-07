using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesBaixaPagamento
    {
        public static bool Salvar(BaixaPagamento BaixaPagamento, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO BAIXAPAGAMENTO(IDBAIXAPAGAMENTO, IDCONTAPAGAR, IDFORMADEPAGAMENTO, IDCONTABANCARIA, 
                                                                ORIGEM, COMPLEMENTO, BAIXA, MULTA, JUROS, DESCONTO, VALOR, DATACONCILIACAO)
                                       VALUES (@IDBAIXAPAGAMENTO, @IDCONTAPAGAR, @IDFORMADEPAGAMENTO, @IDCONTABANCARIA,
                                               @ORIGEM, @COMPLEMENTO, @BAIXA, @MULTA, @JUROS, @DESCONTO, @VALOR, @DATACONCILIACAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE BAIXAPAGAMENTO
                                       SET  IDCONTAPAGAR = @IDCONTAPAGAR, 
                                            IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO, 
                                            IDCONTABANCARIA = @IDCONTABANCARIA, 
                                            ORIGEM = @ORIGEM,
                                            COMPLEMENTO = @COMPLEMENTO, 
                                            BAIXA = @BAIXA, 
                                            MULTA = @MULTA,
                                            JUROS = @JUROS,
                                            DESCONTO = @DESCONTO, 
                                            VALOR = @VALOR, 
                                            DATACONCILIACAO = @DATACONCILIACAO
                                     WHERE IDBAIXAPAGAMENTO = @IDBAIXAPAGAMENTO";
                        break;
                }
                oSQL.ParamByName["IDBAIXAPAGAMENTO"] = BaixaPagamento.IDBaixaPagamento;
                oSQL.ParamByName["IDCONTAPAGAR"] = BaixaPagamento.IDContaPagar;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = BaixaPagamento.IDFormaDePagamento;
                oSQL.ParamByName["IDCONTABANCARIA"] = BaixaPagamento.IDContaBancaria;
                oSQL.ParamByName["ORIGEM"] = BaixaPagamento.Origem;
                oSQL.ParamByName["COMPLEMENTO"] = BaixaPagamento.Complemento;
                oSQL.ParamByName["BAIXA"] = BaixaPagamento.Baixa;
                oSQL.ParamByName["MULTA"] = BaixaPagamento.Multa;
                oSQL.ParamByName["JUROS"] = BaixaPagamento.Juros;
                oSQL.ParamByName["DESCONTO"] = BaixaPagamento.Desconto;
                oSQL.ParamByName["VALOR"] = BaixaPagamento.Valor;
                oSQL.ParamByName["DATACONCILIACAO"] = BaixaPagamento.DataConciliacao;

                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDBaixaPagamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM CHEQUECONTAPAGAR WHERE IDBAIXAPAGAMENTO = @IDBAIXAPAGAMENTO";
                oSQL.ParamByName["IDBAIXAPAGAMENTO"] = IDBaixaPagamento;
                oSQL.ExecSQL();

                oSQL.ClearAll();

                oSQL.SQL = "DELETE FROM BAIXAPAGAMENTO WHERE IDBAIXAPAGAMENTO = @IDBAIXAPAGAMENTO";
                oSQL.ParamByName["IDBAIXAPAGAMENTO"] = IDBaixaPagamento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetBaixas(decimal IDContaPagar)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT BAIXAPAGAMENTO.IDBAIXAPAGAMENTO,
                                    BAIXAPAGAMENTO.BAIXA,
                                    CONTABANCARIA.NOME AS CONTABANCARIA,
                                    BAIXAPAGAMENTO.IDCONTAPAGAR,
                                    BAIXAPAGAMENTO.IDFORMADEPAGAMENTO,
                                    BAIXAPAGAMENTO.IDCONTABANCARIA,
                                    BAIXAPAGAMENTO.ORIGEM,
                                    BAIXAPAGAMENTO.COMPLEMENTO,
                                    BAIXAPAGAMENTO.MULTA,
                                    BAIXAPAGAMENTO.JUROS,
                                    BAIXAPAGAMENTO.DESCONTO,
                                    BAIXAPAGAMENTO.DATACONCILIACAO,
                                    BAIXAPAGAMENTO.VALOR,
                                    (COALESCE(BAIXAPAGAMENTO.VALOR, 0) - COALESCE(BAIXAPAGAMENTO.DESCONTO, 0)) + COALESCE(BAIXAPAGAMENTO.MULTA, 0) + COALESCE(BAIXAPAGAMENTO.JUROS, 0) AS TOTAL
                               FROM BAIXAPAGAMENTO
                                 INNER JOIN CONTABANCARIA ON (BAIXAPAGAMENTO.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                             WHERE BAIXAPAGAMENTO.IDCONTAPAGAR = @IDCONTAPAGAR";
                oSQL.ParamByName["IDCONTAPAGAR"] = IDContaPagar;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
