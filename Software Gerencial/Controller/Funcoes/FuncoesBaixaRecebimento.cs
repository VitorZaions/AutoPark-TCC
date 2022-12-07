using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesBaixaRecebimento
    {
        public static bool Salvar(BaixaRecebimento BaixaRecebimento, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO BAIXARECEBIMENTO(IDBAIXARECEBIMENTO, IDCONTARECEBER, IDFORMADEPAGAMENTO, IDCONTABANCARIA, 
                                        COMPLEMENTO, BAIXA, MULTA, JUROS, DESCONTO, VALOR, DATACONCILIACAO)
                                       VALUES (@IDBAIXARECEBIMENTO, @IDCONTARECEBER, @IDFORMADEPAGAMENTO, @IDCONTABANCARIA, 
                                        @COMPLEMENTO, @BAIXA, @MULTA, @JUROS, @DESCONTO, @VALOR, @DATACONCILIACAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE BAIXARECEBIMENTO
                                       SET  IDCONTARECEBER        = @IDCONTARECEBER, 
                                            IDFORMADEPAGAMENTO    = @IDFORMADEPAGAMENTO, 
                                            IDCONTABANCARIA       = @IDCONTABANCARIA,
                                            COMPLEMENTO          = @COMPLEMENTO, 
                                            BAIXA                 = @BAIXA, 
                                            MULTA                 = @MULTA,
                                            JUROS                 = @JUROS,
                                            DESCONTO              = @DESCONTO, 
                                            VALOR                 = @VALOR, 
                                            DATACONCILIACAO       = @DATACONCILIACAO
                                     WHERE IDBAIXARECEBIMENTO     = @IDBAIXARECEBIMENTO";
                        break;
                }
                oSQL.ParamByName["IDBAIXARECEBIMENTO"] = BaixaRecebimento.IDBaixaRecebimento;
                oSQL.ParamByName["IDCONTARECEBER"] = BaixaRecebimento.IDContaReceber;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = BaixaRecebimento.IDFormaDePagamento;
                oSQL.ParamByName["IDCONTABANCARIA"] = BaixaRecebimento.IDContaBancaria;
                oSQL.ParamByName["COMPLEMENTO"] = BaixaRecebimento.Complemento;
                oSQL.ParamByName["BAIXA"] = BaixaRecebimento.Baixa;
                oSQL.ParamByName["MULTA"] = BaixaRecebimento.Multa;
                oSQL.ParamByName["JUROS"] = BaixaRecebimento.Juros;
                oSQL.ParamByName["DESCONTO"] = BaixaRecebimento.Desconto;
                oSQL.ParamByName["VALOR"] = BaixaRecebimento.Valor;
                oSQL.ParamByName["DATACONCILIACAO"] = BaixaRecebimento.DataConciliacao;

                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDBAIXARECEBIMENTO)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM CHEQUECONTARECEBER WHERE IDBAIXARECEBIMENTO = @IDBAIXARECEBIMENTO";
                oSQL.ParamByName["IDBAIXARECEBIMENTO"] = IDBAIXARECEBIMENTO;
                oSQL.ExecSQL();

                oSQL.ClearAll();

                oSQL.SQL = "DELETE FROM BAIXARECEBIMENTO WHERE IDBAIXARECEBIMENTO = @IDBAIXARECEBIMENTO";
                oSQL.ParamByName["IDBAIXARECEBIMENTO"] = IDBAIXARECEBIMENTO;
                oSQL.ExecSQL();
                return true;
            }
        }

        public static DataTable GetBaixas(decimal IDContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT BAIXARECEBIMENTO.IDBAIXARECEBIMENTO,
                                    BAIXARECEBIMENTO.BAIXA,
                                    CONTABANCARIA.NOME AS CONTABANCARIA,
                                    (COALESCE(BAIXARECEBIMENTO.VALOR, 0) - COALESCE(BAIXARECEBIMENTO.DESCONTO, 0)) + COALESCE(BAIXARECEBIMENTO.MULTA, 0) + COALESCE(BAIXARECEBIMENTO.JUROS, 0) AS TOTAL,
                                    BAIXARECEBIMENTO.VALOR,
                                    BAIXARECEBIMENTO.IDCONTARECEBER,
                                    BAIXARECEBIMENTO.IDFORMADEPAGAMENTO,
                                    BAIXARECEBIMENTO.IDCONTABANCARIA,
                                    BAIXARECEBIMENTO.ORIGEM,
                                    BAIXARECEBIMENTO.COMPLEMENTO,
                                    BAIXARECEBIMENTO.MULTA,
                                    BAIXARECEBIMENTO.JUROS,
                                    BAIXARECEBIMENTO.DESCONTO,
                                    BAIXARECEBIMENTO.DATACONCILIACAO
                               FROM BAIXARECEBIMENTO
                                 INNER JOIN CONTABANCARIA ON (BAIXARECEBIMENTO.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                             WHERE BAIXARECEBIMENTO.IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
