using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesContaReceber
    {
        public static bool Salvar(ContaReceber Conta, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CONTARECEBER(
                                                 IDCONTARECEBER, IDCLIENTE, PARCELA,
                                                 EMISSAO, VENCIMENTO, COMPLEMENTO, VALOR, ORIGEM, MULTA, JUROS, 
                                                 DESCONTO, STATUS, VALORTOTAL, SALDO, IDNATUREZA, IDFORMADEPAGAMENTO, IDENTRADA)
                                         VALUES (@IDCONTARECEBER, @IDCLIENTE,
                                                 @PARCELA, @EMISSAO, @VENCIMENTO, @COMPLEMENTO, @VALOR, @ORIGEM, @MULTA, @JUROS, 
                                                 @DESCONTO, @STATUS, @VALORTOTAL, @SALDO, @IDNATUREZA, @IDFORMADEPAGAMENTO, @IDENTRADA)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONTARECEBER
                                       SET IDCLIENTE = @IDCLIENTE, 
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
                                           IDNATUREZA = @IDNATUREZA,
                                           IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO,
                                           IDENTRADA = @IDENTRADA
                                     WHERE IDCONTARECEBER = @IDCONTARECEBER";
                        break;
                }
                oSQL.ParamByName["IDCONTARECEBER"] = Conta.IDContaReceber;
                oSQL.ParamByName["IDCLIENTE"] = Conta.IDCliente;
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
                oSQL.ParamByName["IDNATUREZA"] = Conta.IDNatureza;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = Conta.IDFormaDePagamento;
                oSQL.ParamByName["IDENTRADA"] = Conta.IDEntrada;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CONTARECEBER WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static DataTable GetContas(decimal? Codigo, string Cliente, DateTime VencimentoInicio, DateTime VencimentoFim, DateTime EmissaoInicio, DateTime EmissaoFim, string Complemento, string Origem, bool Aberto, bool Parcial, bool Baixado, bool Cancelado, decimal TipoCliente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                string ClienteDesc = "Cliente Não Informado";
                if (TipoCliente != 0)
                {
                    ClienteDesc = "-";
                }

                List<string> Filtros = new List<string>();

                Filtros.Add($"(CONTARECEBER.VENCIMENTO::date BETWEEN (@INICIOVENCIMENTO)::date AND (@FIMVENCIMENTO)::date)");
                Filtros.Add($"(CONTARECEBER.EMISSAO::date BETWEEN (@INICIOEMISSAO)::date AND (@FIMEMISSAO)::date)");
                Filtros.Add($"(UPPER(COALESCE(CLIENTE.NOME, '')) LIKE UPPER('%{Cliente}%') OR UPPER(COALESCE(CLIENTE.NOMEFANTASIA, '')) LIKE UPPER('%{Cliente}%'))");

                if (Codigo != null)
                    Filtros.Add($"(CONTARECEBER.IDCONTARECEBER = {Codigo})");

                if (!string.IsNullOrEmpty(Cliente))
                    Filtros.Add($@"((UNACCENT(UPPER(COALESCE(CLIENTE.NOME, ''))) LIKE UNACCENT(UPPER('%{Cliente}%'))) OR
                        (UNACCENT(UPPER(COALESCE(CLIENTE.NOMEFANTASIA, ''))) LIKE UNACCENT(UPPER('%{Cliente}%'))) or 
                        (UNACCENT(UPPER(COALESCE(CLIENTE.CPF, ''))) LIKE UNACCENT(UPPER('{Cliente}'))) OR 
                        (UPPER(COALESCE(CLIENTE.CNPJ, '')) LIKE UNACCENT(UPPER('{Cliente}'))) OR 
                        (UPPER(COALESCE(CLIENTE.DOCESTRANGEIRO, '')) LIKE UNACCENT(UPPER('{Cliente}'))))");
                
                if (!string.IsNullOrEmpty(Origem))
                    Filtros.Add($"(UPPER(CONTARECEBER.ORIGEM) LIKE UPPER('%{Origem}%') OR UPPER(CONTARECEBER.TITULO) LIKE UPPER('%{Origem}%'))");

                if (!string.IsNullOrEmpty(Complemento))
                    Filtros.Add($"(UPPER(CONTARECEBER.COMPLEMENTO) LIKE UPPER('%{Complemento}%'))");                               
                
                if (!Aberto)
                    Filtros.Add($"(CONTARECEBER.STATUS <> 1)");

                if (!Parcial)
                    Filtros.Add($"(CONTARECEBER.STATUS <> 2)");

                if (!Baixado)
                    Filtros.Add($"(CONTARECEBER.STATUS <> 3)");

                if (!Cancelado)
                    Filtros.Add($"(CONTARECEBER.STATUS <> 0)");

                oSQL.SQL = $@"SELECT DISTINCT CONTARECEBER.IDCONTARECEBER,
                                     CONTARECEBER.IDCLIENTE,
                                     CASE 
                                        WHEN CONTARECEBER.IDCLIENTE IS NULL THEN '{ClienteDesc}'
                                        WHEN CLIENTE.TIPODOCUMENTO IN (1,2) THEN CLIENTE.NOME
                                        WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.RAZAOSOCIAL
                                     END AS CLIENTE,
                                     CONTARECEBER.PARCELA,
                                     CONTARECEBER.EMISSAO,
                                     CONTARECEBER.VENCIMENTO,                                     
                                     CONTARECEBER.ORIGEM,
                                     CONTARECEBER.COMPLEMENTO,
                                     CONTARECEBER.VALORTOTAL,
                                     CASE
                                       WHEN CONTARECEBER.STATUS = 0 THEN 'Cancelado'
                                       WHEN CONTARECEBER.STATUS = 1 THEN 'Aberto'
                                       WHEN CONTARECEBER.STATUS = 2 THEN 'Parcial'
                                       WHEN CONTARECEBER.STATUS = 3 THEN 'Baixado'
                                     END AS STATUS
                                FROM CONTARECEBER                                  
                                  LEFT JOIN CLIENTE ON (CONTARECEBER.IDCLIENTE = CLIENTE.IDCLIENTE)
                                  {(Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty)}
                                  ORDER BY CONTARECEBER.VENCIMENTO, CONTARECEBER.PARCELA";

                oSQL.ParamByName["INICIOVENCIMENTO"] = VencimentoInicio;
                oSQL.ParamByName["FIMVENCIMENTO"] = VencimentoFim;
                oSQL.ParamByName["INICIOEMISSAO"] = EmissaoInicio;
                oSQL.ParamByName["FIMEMISSAO"] = EmissaoFim;

                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static ContaReceber GetContaReceber(decimal IDContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM CONTARECEBER WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                oSQL.Open();
                return EntityUtil<ContaReceber>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static ContaReceber GetContaReceberPorEntrada(decimal IDENTRADA)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM CONTARECEBER WHERE IDENTRADA = @IDENTRADA";
                oSQL.ParamByName["IDENTRADA"] = IDENTRADA;
                oSQL.Open();
                return EntityUtil<ContaReceber>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONTARECEBER WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }          
    }
}
