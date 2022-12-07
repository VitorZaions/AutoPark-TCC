using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesAgendaContato
    {

        public static bool Salvar(AgendaContato _AgendaContato, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO AGENDACONTATO
                                        (IDCONTATO, NOME, TELEFONE, CELULAR, EMAIL, OBSERVACAO)
                                     VALUES
                                        (@IDCONTATO, @NOME, @TELEFONE, @CELULAR, @EMAIL, @OBSERVACAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE AGENDACONTATO
                                      SET NOME = @NOME,
                                          TELEFONE = @TELEFONE,
                                          CELULAR = @CELULAR,
                                          EMAIL = @EMAIL,
                                          OBSERVACAO = @OBSERVACAO
                                      WHERE IDCONTATO = @IDCONTATO";
                        break;
                }
                oSQL.ParamByName["IDCONTATO"] = _AgendaContato.IDCONTATO;
                oSQL.ParamByName["NOME"] = _AgendaContato.NOME;
                oSQL.ParamByName["TELEFONE"] = _AgendaContato.Telefone;
                oSQL.ParamByName["CELULAR"] = _AgendaContato.Celular;
                oSQL.ParamByName["EMAIL"] = _AgendaContato.EMAIL;
                oSQL.ParamByName["OBSERVACAO"] = _AgendaContato.OBSERVACAO;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDAgendaContato)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM AGENDACONTATO WHERE IDCONTATO = @IDCONTATO";
                oSQL.ParamByName["IDCONTATO"] = IDAgendaContato;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDAgendaContato)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM AGENDACONTATO WHERE IDCONTATO = @IDCONTATO";
                oSQL.ParamByName["IDCONTATO"] = IDAgendaContato;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExistePorNome(string Nome, decimal IDAgendaContato)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM AGENDACONTATO WHERE UNACCENT(UPPER(NOME)) = UPPER(@NOME) AND IDCONTATO <> @IDCONTATO";
                oSQL.ParamByName["NOME"] = Nome;
                oSQL.ParamByName["IDCONTATO"] = IDAgendaContato;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }


        public static DataTable GetAgendaContatos(string Nome)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();

                if (!string.IsNullOrEmpty(Nome))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(NOME)) LIKE UNACCENT(UPPER('%{0}%')))", Nome));

                oSQL.SQL = string.Format(
                           @"SELECT IDCONTATO,
                                    NOME,
                                    TELEFONE,
                                    CELULAR,
                                    EMAIL,
                                    OBSERVACAO
								FROM AGENDACONTATO {0} 
								ORDER BY NOME", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }


        public static AgendaContato GetAgendaContato(decimal IDAgendaContato)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM AGENDACONTATO WHERE IDCONTATO = @IDCONTATO";
                oSQL.ParamByName["IDCONTATO"] = IDAgendaContato;
                oSQL.Open();
                return EntityUtil<AgendaContato>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }


    }
}
