using AutoDAO.Entidades;
using AutoDAO.DB.Controller;

namespace AutoController.Funcoes
{
    public class FuncoesLogs
    {
        public static void DefinirUsuarioLogado(Usuario usuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SET LOCAL VAR.USUARIO_LOGADO = " + usuario.IDUsuario;
                oSQL.ExecSQL();
            }
        }
    }
}
