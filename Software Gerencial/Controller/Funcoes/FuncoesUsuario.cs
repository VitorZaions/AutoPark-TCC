using AutoDAO.DB.Controller;
using System.Data;
using AutoDAO.Enum;
using AutoDAO.Custom;
using AutoDAO.Entidades;

namespace AutoController.Funcoes
{
    public class FuncoesUsuario
    {
        public static Usuario GetUsuarioRoot(string Login, string Senha)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT U.* 
                               FROM USUARIO U
                              WHERE LOGIN = @LOGIN 
                               AND SENHA = @SENHA 
                               AND COALESCE(ROOT, 0) = 1";
                oSQL.ParamByName["LOGIN"] = Login;
                oSQL.ParamByName["SENHA"] = Senha;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Usuario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Usuario GetUsuarioSupervisor(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT US.IDUSUARIO,
                                    US.NOME,
                                    US.LOGIN,
                                    US.SENHA,
                                    US.EMAIL,
                                    US.ATIVO
                             FROM USUARIO
                                 LEFT JOIN USUARIO US ON (USUARIO.IDUSUARIOSUPERVISOR = US.IDUSUARIO)
                             WHERE USUARIO.IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Usuario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Usuario GetUsuarioPorLoginESenha(string Login, string Senha)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT USUARIO.IDUSUARIO,
                                    USUARIO.LOGIN,
                                    USUARIO.SENHA,
                                    USUARIO.NOME,
                                    USUARIO.EMAIL,
                             
                                    PERFILACESSO.IDPERFILACESSO,
                                    PERFILACESSO.DESCRICAO AS PERFILACESSO
                             
                             FROM USUARIO
                               LEFT JOIN PERFILACESSO ON USUARIO.IDPERFILACESSO = PERFILACESSO.IDPERFILACESSO
                             WHERE LOGIN = @LOGIN
                               AND SENHA = @SENHA
                               AND COALESCE(USUARIO.ATIVO, 0) = 1";
                oSQL.ParamByName["LOGIN"] = Login;
                oSQL.ParamByName["SENHA"] = Senha;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Usuario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM USUARIO WHERE IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExisteLogin(decimal IDUsuario, string Login)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM USUARIO WHERE UPPER(LOGIN) = UPPER(@LOGIN) AND IDUSUARIO <> @IDUSUARIO";
                oSQL.ParamByName["LOGIN"] = Login;
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static DataTable GetUsuarios(string Nome, string Login, decimal IDUsuario, bool Ativo, bool Inativo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                // Filtros.Add(string.Format("COALESCE(ROOT, 0) = 0"));
                if (!string.IsNullOrEmpty(Nome))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(NOME)) LIKE UNACCENT(UPPER('%{0}%')))", Nome));

                if (IDUsuario != -1)
                    Filtros.Add(string.Format("IDUSUARIO <> {0}", IDUsuario));

                if (!string.IsNullOrEmpty(Login))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(LOGIN)) LIKE UNACCENT(UPPER('%{0}%')))", Login));

                if (!Ativo)
                    Filtros.Add(string.Format("(ATIVO <> 1)"));

                if (!Inativo)
                    Filtros.Add(string.Format("(ATIVO <> 0)"));

                oSQL.SQL = string.Format(@"SELECT 
                                          IDUSUARIO, 
                                          LOGIN, 
                                          NOME, 
                                          CASE WHEN ATIVO = 0 THEN 'Não' ELSE 'Sim' END AS ATIVO 
                                          FROM USUARIO {0} ORDER BY NOME", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Usuario> GetUsuarios(decimal IDUsuario)
        {
            List<string> Filtros = new List<string>();

            Filtros.Add(string.Format("ATIVO = 1"));

            if (IDUsuario != -1)
                Filtros.Add(string.Format("IDUSUARIO <> {0}", IDUsuario));

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format("SELECT IDUSUARIO, LOGIN, NOME FROM USUARIO {0} ORDER BY NOME", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return new DataTableParser<Usuario>().ParseDataTable(oSQL.dtDados);
            }
        }


        public static Usuario GetUsuario(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT USUARIO.IDUSUARIO,
                                    USUARIO.NOME,
                                    USUARIO.LOGIN,
                                    USUARIO.SENHA,
                                    USUARIO.EMAIL,
                                    USUARIO.ATIVO,
                                    USUARIO.ROOT,
                                    PERFILACESSO.IDPERFILACESSO,
                                    PERFILACESSO.DESCRICAO AS PERFILACESSO,
                                    USUARIO.IDUSUARIOSUPERVISOR
                               FROM USUARIO 
                                  LEFT JOIN PERFILACESSO ON (USUARIO.IDPERFILACESSO = PERFILACESSO.IDPERFILACESSO)
                             WHERE IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Usuario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Remover(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM USUARIO WHERE IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Salvar(Usuario User, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO USUARIO (IDUSUARIO, NOME, LOGIN, SENHA, EMAIL, ATIVO, IDPERFILACESSO, IDUSUARIOSUPERVISOR) 
                                                 VALUES  (@IDUSUARIO, @NOME, @LOGIN, @SENHA, @EMAIL, @ATIVO, @IDPERFILACESSO, @IDUSUARIOSUPERVISOR)";
                        oSQL.ParamByName["LOGIN"] = User.Login;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE USUARIO
                                        SET NOME = @NOME,
                                            SENHA = @SENHA,
                                            EMAIL = @EMAIL,
                                            ATIVO = @ATIVO,
                                            IDPERFILACESSO = @IDPERFILACESSO,
                                            IDUSUARIOSUPERVISOR = @IDUSUARIOSUPERVISOR
                                     WHERE IDUSUARIO = @IDUSUARIO";
                        break;
                }
                oSQL.ParamByName["NOME"] = User.Nome;
                oSQL.ParamByName["SENHA"] = User.Senha;
                oSQL.ParamByName["EMAIL"] = User.Email;
                oSQL.ParamByName["ATIVO"] = User.Ativo;
                oSQL.ParamByName["IDUSUARIO"] = User.IDUsuario;
                oSQL.ParamByName["IDPERFILACESSO"] = User.IDPerfilAcesso;
                if (User.IDUsuarioSupervisor != -1)
                    oSQL.ParamByName["IDUSUARIOSUPERVISOR"] = User.IDUsuarioSupervisor;
                else
                    oSQL.ParamByName["IDUSUARIOSUPERVISOR"] = null;
                return oSQL.ExecSQL() == 1;
            }
        }       
    }
}
