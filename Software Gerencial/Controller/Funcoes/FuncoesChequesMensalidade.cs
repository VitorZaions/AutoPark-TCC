using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesChequesMensalidade
    {
        public static bool Existe(decimal IDCHEQUEMENSALIDADE)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CHEQUEMENSALIDADE WHERE IDCHEQUEMENSALIDADE = @IDCHEQUEMENSALIDADE";
                oSQL.ParamByName["IDCHEQUEMENSALIDADE"] = IDCHEQUEMENSALIDADE;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static DataTable GetChequeMensalidade(decimal IDBaixaMensalidade)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CHEQUEMENSALIDADE.IDCHEQUEMENSALIDADE,
                                    CHEQUEMENSALIDADE.NUMERO,
                                    CHEQUEMENSALIDADE.EMISSAO,
                                    CHEQUEMENSALIDADE.VENCIMENTO,
                                    CHEQUEMENSALIDADE.VALOR,                             
                                    CHEQUEMENSALIDADE.CRUZADO,
                                    CHEQUEMENSALIDADE.COMPENSADO,
                                    CHEQUEMENSALIDADE.DATACOMPENSACAO,
                                    CHEQUEMENSALIDADE.DEVOLVIDO,
                                    CHEQUEMENSALIDADE.DATADEVOLUCAO,
                                    CHEQUEMENSALIDADE.REPASSE,
                                    CHEQUEMENSALIDADE.DATAREPASSE,
                                    CHEQUEMENSALIDADE.OBSREPASSE,
                                    CHEQUEMENSALIDADE.IDBAIXAMENSALIDADE
                               FROM CHEQUEMENSALIDADE
                             WHERE CHEQUEMENSALIDADE.IDBAIXAMENSALIDADE = @IDBAIXAMENSALIDADE";
                oSQL.ParamByName["IDBAIXAMENSALIDADE"] = IDBaixaMensalidade;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(ChequeMensalidade chequeMensalidade, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CHEQUECONTARECEBER(IDCHEQUEMENSALIDADE, 
                                                                    IDBAIXAMENSALIDADE, 
                                                                    NUMERO, 
                                                                    VALOR, 
                                                                    EMISSAO, 
                                                                    VENCIMENTO, 
                                                                    CRUZADO,
                                                                    COMPENSADO, 
                                                                    DATACOMPENSACAO, 
                                                                    DEVOLVIDO, 
                                                                    DATADEVOLUCAO, 
                                                                    REPASSE, 
                                                                    DATAREPASSE, 
                                                                    OBSREPASSE)
                                       VALUES (@IDCHEQUEMENSALIDADE,
                                               @IDBAIXAMENSALIDADE, 
                                               @NUMERO, 
                                               @VALOR, 
                                               @EMISSAO, 
                                               @VENCIMENTO, 
                                               @CRUZADO, 
                                               @COMPENSADO, 
                                               @DATACOMPENSACAO, 
                                               @DEVOLVIDO, 
                                               @DATADEVOLUCAO, 
                                               @REPASSE, 
                                               @DATAREPASSE, 
                                               @OBSREPASSE)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CHEQUECONTARECEBER
                                       SET  IDCHEQUEMENSALIDADE  = @IDCHEQUEMENSALIDADE,                                               
                                            IDBAIXAMENSALIDADE = @IDBAIXAMENSALIDADE, 
                                            NUMERO           = @NUMERO, 
                                            VALOR            = @VALOR, 
                                            EMISSAO          = @EMISSAO, 
                                            VENCIMENTO       = @VENCIMENTO, 
                                            CRUZADO          = @CRUZADO, 
                                            COMPENSADO       = @COMPENSADO, 
                                            DATACOMPENSACAO  = @DATACOMPENSACAO, 
                                            DEVOLVIDO        = @DEVOLVIDO, 
                                            DATADEVOLUCAO    = @DATADEVOLUCAO,
                                            REPASSE          = @REPASSE, 
                                            DATAREPASSE      = @DATAREPASSE,
                                            OBSREPASSE       = @OBSREPASSE
                                     WHERE IDCHEQUEMENSALIDADE = @IDCHEQUEMENSALIDADE";
                        break;
                }
                oSQL.ParamByName["IDCHEQUEMENSALIDADE"] = chequeMensalidade.IDChequeMensalidade;
                oSQL.ParamByName["IDBAIXAMENSALIDADE"] = chequeMensalidade.IDBaixaMensalidade;
                oSQL.ParamByName["NUMERO"] = chequeMensalidade.Numero;
                oSQL.ParamByName["VALOR"] = chequeMensalidade.Valor;
                oSQL.ParamByName["EMISSAO"] = chequeMensalidade.Emissao;
                oSQL.ParamByName["VENCIMENTO"] = chequeMensalidade.Vencimento;
                oSQL.ParamByName["CRUZADO"] = chequeMensalidade.Cruzado;
                oSQL.ParamByName["COMPENSADO"] = chequeMensalidade.Compensado;
                oSQL.ParamByName["DATACOMPENSACAO"] = chequeMensalidade.DataCompensacao;
                oSQL.ParamByName["DEVOLVIDO"] = chequeMensalidade.Devolvido;
                oSQL.ParamByName["DATADEVOLUCAO"] = chequeMensalidade.DataDevolucao;
                oSQL.ParamByName["REPASSE"] = chequeMensalidade.Repasse;
                oSQL.ParamByName["DATAREPASSE"] = chequeMensalidade.DataRepasse;
                oSQL.ParamByName["OBSREPASSE"] = chequeMensalidade.ObsRepasse;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDCHEQUEMENSALIDADE)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CHEQUEMENSALIDADE WHERE IDCHEQUEMENSALIDADE = @IDCHEQUEMENSALIDADE";
                oSQL.ParamByName["IDCHEQUEMENSALIDADE"] = IDCHEQUEMENSALIDADE;
                oSQL.ExecSQL();
                return true;
            }
        }
    }
}
