using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesEmitente
    {        
        /* Funções Emitente */

        public static bool SalvarEmitente(Emitente _Emitente, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO EMITENTE(
                                                 IDEMITENTE, IDENDERECO, CNPJ, RAZAOSOCIAL, NOMEFANTASIA, EMAIL,
                                                 LOGOMARCA, NOMELOGOMARCA, SITE, FACEBOOK, INSTAGRAM, IDCONTATO)
                                         VALUES (@IDEMITENTE, @IDENDERECO, @CNPJ, @RAZAOSOCIAL, @NOMEFANTASIA, @EMAIL, 
                                                 @LOGOMARCA, @NOMELOGOMARCA, @SITE, @FACEBOOK, @INSTAGRAM, @IDCONTATO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE EMITENTE
                                       SET IDENDERECO = @IDENDERECO, CNPJ = @CNPJ, RAZAOSOCIAL = @RAZAOSOCIAL, NOMEFANTASIA = @NOMEFANTASIA, 
                                           EMAIL = @EMAIL, LOGOMARCA = @LOGOMARCA, NOMELOGOMARCA = @NOMELOGOMARCA, SITE = @SITE, FACEBOOK = @FACEBOOK, INSTAGRAM = @INSTAGRAM, IDCONTATO = @IDCONTATO
                                     WHERE IDEMITENTE = @IDEMITENTE";
                        break;
                }
                oSQL.ParamByName["IDEMITENTE"] = _Emitente.IDEmitente;
                oSQL.ParamByName["IDENDERECO"] = _Emitente.IDEndereco;
                oSQL.ParamByName["IDCONTATO"] = _Emitente.IDContato;
                oSQL.ParamByName["CNPJ"] = _Emitente.CNPJ;
                oSQL.ParamByName["RAZAOSOCIAL"] = _Emitente.RazaoSocial;
                oSQL.ParamByName["NOMEFANTASIA"] = _Emitente.NomeFantasia;
                oSQL.ParamByName["EMAIL"] = _Emitente.Email;
                oSQL.ParamByName["LOGOMARCA"] = _Emitente.Logomarca;
                oSQL.ParamByName["NOMELOGOMARCA"] = _Emitente.NomeLogomarca;
                oSQL.ParamByName["INSTAGRAM"] = _Emitente.Instagram;
                oSQL.ParamByName["SITE"] = _Emitente.Site;
                oSQL.ParamByName["FACEBOOK"] = _Emitente.Facebook;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static Emitente GetEmitente()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT EMITENTE.IDEMITENTE, 
                                    EMITENTE.IDENDERECO, 
                                    EMITENTE.IDCONTATO, 
                                    EMITENTE.CNPJ, 
                                    EMITENTE.RAZAOSOCIAL, 
                                    EMITENTE.NOMEFANTASIA, 
                                    EMITENTE.LOGOMARCA,
                                    EMITENTE.NOMELOGOMARCA,
                                    EMITENTE.SITE,
                                    EMITENTE.FACEBOOK,
                                    EMITENTE.INSTAGRAM
                               FROM EMITENTE";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Emitente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
           

        public static UnidadeFederativa GetUnidadeFederativaPorEmitente()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.*
                               FROM EMITENTE
                                 INNER JOIN ENDERECO ON (EMITENTE.IDENDERECO = ENDERECO.IDENDERECO)
                                 INNER JOIN UNIDADEFEDERATIVA ON (ENDERECO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)";
                oSQL.Open();
                return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
