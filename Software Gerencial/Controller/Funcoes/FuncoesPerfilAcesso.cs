using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesPerfilAcesso
    {
        /*   public static bool RemoverPerfilAcessoItemMenu(decimal IDPerfilAcesso, decimal IDItemMenu)
           {
               using (SQLQuery oSQL = new SQLQuery())
               {
                   oSQL.SQL = "SELECT 1 FROM PERFILACESSOITEMMENU WHERE IDPERFILACESSO = @IDPERFILACESSO AND IDITEMMENU = @IDITEMMENU";
                   oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                   oSQL.ParamByName["IDITEMMENU"] = IDItemMenu;
                   oSQL.Open();
                   if (oSQL.IsEmpty)
                       return true;

                   oSQL.ClearAll();
                   oSQL.SQL = @"DELETE FROM PERFILACESSOITEMMENU WHERE IDPERFILACESSO = @IDPERFILACESSO AND IDITEMMENU = @IDITEMMENU";
                   oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                   oSQL.ParamByName["IDITEMMENU"] = IDItemMenu;
                   return oSQL.ExecSQL() == 1;
               }
           } */

        public static bool RemoverPerfilAcessoItemMenu(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM PERFILACESSOITEMMENU WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                return oSQL.ExecSQL() >= 0;
            }
        }



        // public static bool SalvarPerfilAcessoItemMenu(decimal IDPerfilAcessoItemMenu, decimal IDPerfilAcesso, decimal IDItemMenu)
        /*  public static bool SalvarPerfilAcessoItemMenu(decimal IDPerfilAcesso, decimal IDItemMenu)
          {
              using (SQLQuery oSQL = new SQLQuery())
              {
                  oSQL.SQL = @"SELECT 1 FROM PERFILACESSOITEMMENU WHERE IDPERFILACESSO = @IDPERFILACESSO AND IDITEMMENU = @IDITEMMENU";
                  oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                  oSQL.ParamByName["IDITEMMENU"] = IDItemMenu;
                  oSQL.Open();
                  if (!oSQL.IsEmpty)
                      return true;

                  oSQL.ClearAll();
                  oSQL.SQL = @"INSERT INTO PERFILACESSOITEMMENU (IDPERFILACESSOITEMMENU, IDPERFILACESSO, IDITEMMENU)
                                 VALUES (@IDPERFILACESSOITEMMENU, @IDPERFILACESSO, @IDITEMMENU)";
                  oSQL.ParamByName["IDPERFILACESSOITEMMENU"] = IDPerfilAcessoItemMenu;
                  oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                  oSQL.ParamByName["IDITEMMENU"] = IDItemMenu;
                  return oSQL.ExecSQL() == 1;
              }
          } */

        public static bool SalvarPerfilAcessoItemMenu(decimal IDPerfilAcesso, decimal IDItemMenu)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO PERFILACESSOITEMMENU (IDPERFILACESSOITEMMENU, IDPERFILACESSO, IDITEMMENU)
                               VALUES (@IDPERFILACESSOITEMMENU, @IDPERFILACESSO, @IDITEMMENU)";
                oSQL.ParamByName["IDPERFILACESSOITEMMENU"] = Sequence.GetNextID("PERFILACESSOITEMMENU", "IDPERFILACESSOITEMMENU");
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.ParamByName["IDITEMMENU"] = IDItemMenu;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetItensMenuPorPerfil(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ITEMMENU.DESCRICAO,
                                    PERFILACESSOITEMMENU.IDPERFILACESSOITEMMENU, 
                                    ITEMMENU.IDITEMMENU,
                                    ITEMMENU.IDITEMMENUSUPERIOR
                               FROM ITEMMENU
                              INNER JOIN PERFILACESSOITEMMENU ON (ITEMMENU.IDITEMMENU = PERFILACESSOITEMMENU.IDITEMMENU)
                             WHERE PERFILACESSOITEMMENU.IDPERFILACESSO = @IDPERFILACESSO
                             ORDER BY ITEMMENU.DESCRICAO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<ItemMenu> GetItensMenuPorPerfilAcesso(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ITEMMENU.IDITEMMENU,
                                    ITEMSUPERIOR.DESCRICAO AS ITEMSUPERIOR,
                                    ITEMMENU.DESCRICAO                                    
                               FROM ITEMMENU
                                 INNER JOIN PERFILACESSOITEMMENU ON (ITEMMENU.IDITEMMENU = PERFILACESSOITEMMENU.IDITEMMENU)
                                  LEFT JOIN ITEMMENU ITEMSUPERIOR ON (ITEMMENU.IDITEMMENUSUPERIOR = ITEMSUPERIOR.IDITEMMENU)
                               
                             WHERE PERFILACESSOITEMMENU.IDPERFILACESSO = @IDPERFILACESSO
                             ORDER BY ITEMSUPERIOR.DESCRICAO, ITEMMENU.DESCRICAO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.Open();
                return new DataTableParser<ItemMenu>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(PerfilAcesso Perfil, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO PERFILACESSO (IDPERFILACESSO, DESCRICAO, ATIVO) VALUES (@IDPERFILACESSO, @DESCRICAO, @ATIVO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PERFILACESSO
                                       SET DESCRICAO = @DESCRICAO,
                                           ATIVO = @ATIVO
                                     WHERE IDPERFILACESSO = @IDPERFILACESSO";
                        break;
                }
                oSQL.ParamByName["IDPERFILACESSO"] = Perfil.IDPerfilAcesso;
                oSQL.ParamByName["DESCRICAO"] = Perfil.Descricao;
                oSQL.ParamByName["ATIVO"] = Perfil.Ativo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM USUARIO WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("O Perfil de Acesso tem vinculo com usuário e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM PERFILACESSOITEMMENU WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.ExecSQL();

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM PERFILACESSO  WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PERFILACESSO WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExistePorDescricao(string DESCRICAO, decimal IDPERFILACESSO)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PERFILACESSO WHERE UNACCENT(UPPER(DESCRICAO)) = UPPER(@DESCRICAO) AND IDPERFILACESSO <> @IDPERFILACESSO";
                oSQL.ParamByName["DESCRICAO"] = DESCRICAO;
                oSQL.ParamByName["IDPERFILACESSO"] = IDPERFILACESSO;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }


        public static List<PerfilAcesso> GetPerfisAcesso_CadastroUsuario(bool SomenteAtivos = false)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDPERFILACESSO, DESCRICAO, ATIVO FROM PERFILACESSO";
                
                if (SomenteAtivos)
                {
                    oSQL.SQL += " WHERE ATIVO = 1";
                }
                oSQL.SQL += " ORDER BY DESCRICAO";

                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return new DataTableParser<PerfilAcesso>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static PerfilAcesso GetPerfil(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDPERFILACESSO, DESCRICAO, ATIVO FROM PERFILACESSO WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<PerfilAcesso>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetPerfisAcesso(string Descricao, bool Ativo, bool Inativo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(DESCRICAO)) LIKE UNACCENT(UPPER('%{0}%')))", Descricao));
               
                if(Ativo == false)
                    Filtros.Add(string.Format("(ATIVO <> 1)"));

                if(Inativo == false)
                    Filtros.Add(string.Format("(ATIVO <> 0)"));


                oSQL.SQL = string.Format(@"SELECT IDPERFILACESSO, 
                                                  DESCRICAO,
                                                  CASE WHEN ATIVO = 0 THEN 'Não' ELSE 'Sim' END AS ATIVO
                                             FROM PERFILACESSO {0}
                                           ORDER BY DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetModulos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT ITEMMENU.DESCRICAO,
                                    ITEMMENU.IDITEMMENU
                               FROM ITEMMENU
                                WHERE IDITEMMENUSUPERIOR IS NULL
                             ORDER BY ITEMMENU.DESCRICAO";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetItensPorItemMenuSuperior(decimal IDItemMenuSuperior)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT ITEMMENU.DESCRICAO,
                                    ITEMMENU.IDITEMMENU
                               FROM ITEMMENU
                                WHERE IDITEMMENUSUPERIOR = @IDITEMMENUSUPERIOR
                             ORDER BY ITEMMENU.DESCRICAO";
                oSQL.ParamByName["IDITEMMENUSUPERIOR"] = IDItemMenuSuperior;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool ISEstoqueLiberado()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM ITEMMENU WHERE IDITEMMENU = 4";
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
    }
}
