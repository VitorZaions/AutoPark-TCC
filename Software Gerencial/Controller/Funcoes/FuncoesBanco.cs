using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesBanco
    {
        public static List<Banco> GetBancos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT * FROM BANCO";
                oSQL.Open();
                return new DataTableParser<Banco>().ParseDataTable(oSQL.dtDados);
                //return new DataTableParser<Banco>().ParseDataTable(oSQL.dtDados); volta o datatable em list
            }
        }


        public static DataTable GetBancosNome(string Nome)
        {
            List<string> Filtros = new List<string>();
            if (!string.IsNullOrEmpty(Nome))
                Filtros.Add(string.Format("(UNACCENT(UPPER(NOME)) LIKE UNACCENT(UPPER('%{0}%')))", Nome));

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT * FROM BANCO {0}", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static Banco GetBanco(decimal IDContaBancaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT BANCO.*
                               FROM CONTABANCARIA
                                 INNER JOIN BANCO ON (CONTABANCARIA.IDBANCO = BANCO.IDBANCO)
                             WHERE CONTABANCARIA.IDCONTABANCARIA = @IDCONTABANCARIA";
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                oSQL.Open();
                return EntityUtil<Banco>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Banco GetBancoCodigo(decimal CodigoBACEN)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDBANCO,
                                    CODBACEN,
                                    NOME,
                                    SITE
                               FROM BANCO                                 
                               WHERE CODBACEN = @CODIGOBACEN";
                oSQL.ParamByName["CODIGOBACEN"] = CodigoBACEN;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Banco>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

    }
}
