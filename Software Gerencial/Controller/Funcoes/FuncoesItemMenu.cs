using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using System.Collections.Generic;

namespace AutoController.Funcoes
{
    public class FuncoesItemMenu
    {
        public static List<ItemMenu> GetModulos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM ITEMMENU WHERE IDITEMMENUSUPERIOR IS NULL ORDER BY DESCRICAO";
                oSQL.Open();
                return new DataTableParser<ItemMenu>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<ItemMenu> GetItensMenu()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDITEMMENU, CODIGO, DESCRICAO FROM ITEMMENU ORDER BY DESCRICAO";
                oSQL.Open();
                return new DataTableParser<ItemMenu>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<ItemMenu> GetItensMenuComSuperior()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ITEMMENU.IDITEMMENU,
                                    ITEMSUPERIOR.DESCRICAO AS ITEMSUPERIOR,
                                    ITEMMENU.DESCRICAO
                                    
                               FROM ITEMMENU
                             INNER JOIN ITEMMENU ITEMSUPERIOR ON (ITEMMENU.IDITEMMENUSUPERIOR = ITEMSUPERIOR.IDITEMMENU)
                             ORDER BY ITEMSUPERIOR.DESCRICAO, ITEMMENU.DESCRICAO";
                oSQL.Open();
                return new DataTableParser<ItemMenu>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
