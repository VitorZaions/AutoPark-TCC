using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;

namespace AutoController.Funcoes
{
    public class FuncoesContaBancaria
    {
        public static bool Existe(decimal IDContaBancaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONTABANCARIA WHERE IDCONTABANCARIA = @IDCONTABANCARIA";
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExistePorNome(string NOME, decimal CodBanco, string CodAgencia, string DigAgencia, string CodConta, string DigConta, string Operacao, decimal IDCONTABANCARIA)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONTABANCARIA WHERE UNACCENT(UPPER(NOME)) = @NOME AND IDBANCO = @IDBANCO AND AGENCIA = @AGENCIA AND CONTA = @CONTA AND DIGITO = @DIGITO AND OPERACAO = @OPERACAO AND DIGITOAGENCIA = @DIGITOAGENCIA AND IDCONTABANCARIA <> @IDCONTABANCARIA";
                oSQL.ParamByName["NOME"] = NOME.ToUpper();
                oSQL.ParamByName["IDCONTABANCARIA"] = IDCONTABANCARIA;
                oSQL.ParamByName["IDBANCO"] = CodBanco;
                oSQL.ParamByName["AGENCIA"] = CodAgencia;
                oSQL.ParamByName["DIGITOAGENCIA"] = Convert.ToDecimal(DigAgencia);
                oSQL.ParamByName["CONTA"] = CodConta;
                oSQL.ParamByName["DIGITO"] = DigConta;
                oSQL.ParamByName["OPERACAO"] = Operacao;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static ContaBancaria GetContaBancaria(decimal IDContaBancaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CONTABANCARIA.*
                               FROM CONTABANCARIA
                             WHERE IDCONTABANCARIA = @IDCONTABANCARIA";
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                oSQL.Open();
                return EntityUtil<ContaBancaria>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetContasBancarias(string Nome, bool Ativo, bool Inativo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Nome))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(CONTABANCARIA.NOME)) LIKE UNACCENT(UPPER('%{0}%')))", Nome));

                if (!Ativo)
                    Filtros.Add(string.Format("(ATIVO <> 1)"));

                if (!Inativo)
                    Filtros.Add(string.Format("(ATIVO <> 0)"));


                oSQL.SQL = string.Format(@"SELECT CONTABANCARIA.NOME,
                                     BANCO.NOME AS BANCO,
                                     CONTABANCARIA.AGENCIA||'-'||CONTABANCARIA.DIGITOAGENCIA AS AGENCIA,
                                     CONTABANCARIA.CONTA||'-'||CONTABANCARIA.DIGITO AS CONTA,
	                                 case
		                                 when CONTABANCARIA.ATIVO = 1 then 'Sim'
		                                 else 'Não'
	                                 end as ATIVO,
                                     CONTABANCARIA.CAIXA,
                                     CONTABANCARIA.IDBANCO,
                                     CONTABANCARIA.IDCONTABANCARIA
                               FROM CONTABANCARIA
                                 LEFT JOIN BANCO ON (CONTABANCARIA.IDBANCO = BANCO.IDBANCO)
                                 {0} ORDER BY CONTABANCARIA.NOME", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<ContaBancaria> GetContasBancarias(bool somenteAtivos = false)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CONTABANCARIA.IDCONTABANCARIA,
                                    CONTABANCARIA.NOME
                               FROM CONTABANCARIA
                                 LEFT JOIN BANCO ON (CONTABANCARIA.IDBANCO = BANCO.IDBANCO)";
                if (somenteAtivos)
                {
                    oSQL.SQL = oSQL.SQL + " WHERE CONTABANCARIA.ATIVO = 1";
                }
                oSQL.Open();
                return new DataTableParser<ContaBancaria>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(ContaBancaria Conta, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                       CONTABANCARIA(IDCONTABANCARIA, IDBANCO, NOME, AGENCIA, CONTA, DIGITO, ATIVO, CAIXA, DIGITOAGENCIA, OPERACAO)
                                     VALUES (@IDCONTABANCARIA, @IDBANCO, @NOME, @AGENCIA, @CONTA, @DIGITO, @ATIVO, @CAIXA, @DIGITOAGENCIA, @OPERACAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONTABANCARIA
                                       SET IDBANCO = @IDBANCO, 
                                           NOME = @NOME, 
                                           AGENCIA = @AGENCIA,
                                           CONTA = @CONTA,
                                           DIGITO = @DIGITO, 
                                           ATIVO = @ATIVO,
                                           CAIXA = @CAIXA,
                                           DIGITOAGENCIA = @DIGITOAGENCIA,
                                           OPERACAO = @OPERACAO
                                     WHERE IDCONTABANCARIA = @IDCONTABANCARIA";
                        break;
                }
                oSQL.ParamByName["IDCONTABANCARIA"] = Conta.IDContaBancaria;
                oSQL.ParamByName["IDBANCO"] = Conta.IDBanco;
                oSQL.ParamByName["NOME"] = Conta.Nome;
                oSQL.ParamByName["AGENCIA"] = Conta.Agencia;
                oSQL.ParamByName["CONTA"] = Conta.Conta;
                oSQL.ParamByName["DIGITO"] = Conta.Digito;
                oSQL.ParamByName["ATIVO"] = Conta.Ativo;
                oSQL.ParamByName["CAIXA"] = Conta.Caixa;
                oSQL.ParamByName["OPERACAO"] = Conta.Operacao;
                oSQL.ParamByName["DIGITOAGENCIA"] = Convert.ToDecimal(Conta.DigitoAgencia);
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDContaBancaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CONTABANCARIA WHERE IDCONTABANCARIA = @IDCONTABANCARIA";
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
