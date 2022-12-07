using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesContaPagar
    {
        public static bool Salvar(ContaPagar Conta, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CONTAPAGAR(
                                                 IDCONTAPAGAR, IDFORNECEDOR, PARCELA, EMISSAO, 
                                                 VENCIMENTO, COMPLEMENTO, VALOR, ORIGEM, MULTA, JUROS, 
                                                 DESCONTO, STATUS, VALORTOTAL, SALDO, IDCENTROCUSTO, IDNATUREZA, IDFORMADEPAGAMENTO)
                                         VALUES (@IDCONTAPAGAR, @IDFORNECEDOR, @PARCELA, @EMISSAO, 
                                                 @VENCIMENTO, @COMPLEMENTO, @VALOR, @ORIGEM, @MULTA, @JUROS, 
                                                 @DESCONTO, @STATUS, @VALORTOTAL, @SALDO, @IDCENTROCUSTO, @IDNATUREZA, @IDFORMADEPAGAMENTO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONTAPAGAR
                                       SET IDFORNECEDOR = @IDFORNECEDOR,
                                           PARCELA = @PARCELA, 
                                           EMISSAO = @EMISSAO, 
                                           VENCIMENTO = @VENCIMENTO, 
                                           COMPLEMENTO = @COMPLEMENTO,
                                           VALOR = @VALOR, 
                                           ORIGEM = @ORIGEM, 
                                           MULTA = @MULTA, 
                                           JUROS = @JUROS, 
                                           DESCONTO = @DESCONTO, 
                                           STATUS = @STATUS, 
                                           VALORTOTAL = @VALORTOTAL, 
                                           SALDO = @SALDO,
                                           IDCENTROCUSTO = @IDCENTROCUSTO,
                                           IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO
                                     WHERE IDCONTAPAGAR = @IDCONTAPAGAR";
                        break;
                }
                oSQL.ParamByName["IDCONTAPAGAR"] = Conta.IDContaPagar;
                oSQL.ParamByName["IDFORNECEDOR"] = Conta.IDFornecedor;
                oSQL.ParamByName["PARCELA"] = Conta.Parcela;
                oSQL.ParamByName["EMISSAO"] = Conta.Emissao;
                oSQL.ParamByName["VENCIMENTO"] = Conta.Vencimento;
                oSQL.ParamByName["COMPLEMENTO"] = Conta.Complemento;
                oSQL.ParamByName["VALOR"] = Conta.Valor;
                oSQL.ParamByName["ORIGEM"] = Conta.Origem;
                oSQL.ParamByName["MULTA"] = Conta.Multa;
                oSQL.ParamByName["JUROS"] = Conta.Juros;
                oSQL.ParamByName["DESCONTO"] = Conta.Desconto;
                oSQL.ParamByName["STATUS"] = Conta.Status;
                oSQL.ParamByName["VALORTOTAL"] = Conta.ValorTotal;
                oSQL.ParamByName["SALDO"] = Conta.Saldo;
                oSQL.ParamByName["IDCENTROCUSTO"] = Conta.IDCentroCusto;
                oSQL.ParamByName["IDNATUREZA"] = Conta.IDNatureza;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = Conta.IDFormaDePagamento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool AlterarStatus(decimal IDCONTAPAGAR, decimal Status)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE CONTAPAGAR
                            SET STATUS = @STATUS
                            WHERE IDCONTAPAGAR = @IDCONTAPAGAR";
                oSQL.ParamByName["IDCONTAPAGAR"] = IDCONTAPAGAR;
                oSQL.ParamByName["STATUS"] = Status;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDContaPagar)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CONTAPAGAR WHERE IDCONTAPAGAR = @IDCONTAPAGAR";
                oSQL.ParamByName["IDCONTAPAGAR"] = IDContaPagar;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetContas(decimal? Codigo, string Fornecedor, DateTime VencimentoInicio, DateTime VencimentoFim, DateTime EmissaoInicio, DateTime EmissaoFim, string Complemento, string Origem, bool Aberto, bool Parcial, bool Baixado, bool Cancelado)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();

                Filtros.Add($"(CONTAPAGAR.VENCIMENTO::date BETWEEN (@INICIOVENCIMENTO)::date AND (@FIMVENCIMENTO)::date)");
                Filtros.Add($"(CONTAPAGAR.EMISSAO::date BETWEEN (@INICIOEMISSAO)::date AND (@FIMEMISSAO)::date)");

                if (Codigo != null)
                    Filtros.Add($"(CONTAPAGAR.IDCONTAPAGAR = {Codigo})");

                if (!string.IsNullOrEmpty(Fornecedor))
                    Filtros.Add($@"((UPPER(COALESCE(FORNECEDOR.RAZAOSOCIAL, '')) LIKE UPPER('%{Fornecedor}%')) OR
                            (UPPER(COALESCE(FORNECEDOR.CPFCNPJ, '')) LIKE UNACCENT(UPPER('{Fornecedor}'))))");

                if (!string.IsNullOrEmpty(Origem))
                    Filtros.Add($"(UPPER(CONTAPAGAR.ORIGEM) LIKE UPPER('%{Origem}%'))");

                if (!string.IsNullOrEmpty(Complemento))
                    Filtros.Add($"(UPPER(CONTAPAGAR.COMPLEMENTO) LIKE UPPER('%{Complemento}%'))");

                if (!Aberto)
                    Filtros.Add($"(STATUS <> 1)");

                if (!Parcial)
                    Filtros.Add($"(STATUS <> 2)");

                if (!Baixado)
                    Filtros.Add($"(STATUS <> 3)");

                if (!Cancelado)
                    Filtros.Add($"(STATUS <> 0)");

                oSQL.SQL = $@"SELECT CONTAPAGAR.IDCONTAPAGAR,
                                     CONTAPAGAR.IDFORNECEDOR,
                                     FORNECEDOR.RAZAOSOCIAL AS FORNECEDOR,
                                     CONTAPAGAR.PARCELA,
                                     CONTAPAGAR.EMISSAO,
                                     CONTAPAGAR.VENCIMENTO,
                                     CONTAPAGAR.ORIGEM,
                                     CONTAPAGAR.COMPLEMENTO,
                                     CONTAPAGAR.VALORTOTAL,
                                     CASE
                                       WHEN CONTAPAGAR.STATUS = 0 THEN 'Cancelado'
                                       WHEN CONTAPAGAR.STATUS = 1 THEN 'Aberto'
                                       WHEN CONTAPAGAR.STATUS = 2 THEN 'Parcial'
                                       WHEN CONTAPAGAR.STATUS = 3 THEN 'Baixado'
                                     END AS STATUS
                                FROM CONTAPAGAR
                                   INNER JOIN FORNECEDOR ON (CONTAPAGAR.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                                {(Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty)}
                                ORDER BY CONTAPAGAR.VENCIMENTO, CONTAPAGAR.PARCELA, CONTAPAGAR.IDCONTAPAGAR";                
                              
                oSQL.ParamByName["INICIOVENCIMENTO"] = VencimentoInicio;
                oSQL.ParamByName["FIMVENCIMENTO"] = VencimentoFim;
                oSQL.ParamByName["INICIOEMISSAO"] = EmissaoInicio;
                oSQL.ParamByName["FIMEMISSAO"] = EmissaoFim;

                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<ContaPagar> GetContasAviso(DateTime Start, DateTime End)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT CONTAPAGAR.IDFORNECEDOR,
                                     FORNECEDOR.RAZAOSOCIAL AS FORNECEDOR,
                                     CONTAPAGAR.PARCELA,
                                     CONTAPAGAR.EMISSAO,
                                     CONTAPAGAR.VENCIMENTO,
                                     CONTAPAGAR.VALOR
                                     FROM CONTAPAGAR
                                LEFT JOIN FORNECEDOR ON (CONTAPAGAR.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                                WHERE (CONTAPAGAR.STATUS = 1 OR CONTAPAGAR.STATUS = 2) AND CONTAPAGAR.VENCIMENTO BETWEEN @INICIOVENCIMENTO AND @FIMVENCIMENTO
                                ORDER BY FORNECEDOR";
                oSQL.ParamByName["INICIOVENCIMENTO"] = Start;
                oSQL.ParamByName["FIMVENCIMENTO"] = End;
                oSQL.Open();
                return new DataTableParser<ContaPagar>().ParseDataTable(oSQL.dtDados);
            }
        }


        public static ContaPagar GetContaPagar(decimal IDContaPagar)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM CONTAPAGAR WHERE IDCONTAPAGAR = @IDCONTAPAGAR";
                oSQL.ParamByName["IDCONTAPAGAR"] = IDContaPagar;
                oSQL.Open();
                return EntityUtil<ContaPagar>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDContaPagar)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONTAPAGAR WHERE IDCONTAPAGAR = @IDCONTAPAGAR";
                oSQL.ParamByName["IDCONTAPAGAR"] = IDContaPagar;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
    }
}