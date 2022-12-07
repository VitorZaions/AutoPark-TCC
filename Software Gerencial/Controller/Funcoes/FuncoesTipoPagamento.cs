using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoController.Funcoes
{
    public class FuncoesTipoPagamento
    {
        public static List<TipoPagamento> GetTiposPagamento()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM TIPOPAGAMENTO";
                oSQL.Open();
                return new DataTableParser<TipoPagamento>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
