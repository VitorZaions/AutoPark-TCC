using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesMensalidade
    {
        public static bool Salvar(Mensalidade Mensalidade, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO MENSALIDADE(
                                                 IDMENSALIDADE, IDCLIENTE, IDVEICULO, PARCELA,
                                                 EMISSAO, VENCIMENTO, COMPLEMENTO, VALOR, ORIGEM, MULTA, JUROS, 
                                                 DESCONTO, STATUS, VALORTOTAL, SALDO, IDNATUREZA, IDFORMADEPAGAMENTO)
                                         VALUES (@IDMENSALIDADE, @IDCLIENTE, @IDVEICULO, @PARCELA, 
                                                 @EMISSAO, @VENCIMENTO, @COMPLEMENTO, @VALOR, @ORIGEM, @MULTA, @JUROS, 
                                                 @DESCONTO, @STATUS, @VALORTOTAL, @SALDO, @IDNATUREZA, @IDFORMADEPAGAMENTO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE MENSALIDADE
                                       SET IDCLIENTE = @IDCLIENTE, 
                                           IDVEICULO = @IDVEICULO,
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
                                           IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO
                                     WHERE IDMENSALIDADE = @IDMENSALIDADE";
                        break;
                }
                oSQL.ParamByName["IDMENSALIDADE"] = Mensalidade.IDMensalidade;
                oSQL.ParamByName["IDCLIENTE"] = Mensalidade.IDCliente;
                oSQL.ParamByName["IDVEICULO"] = Mensalidade.IDVeiculo;
                oSQL.ParamByName["PARCELA"] = Mensalidade.Parcela;
                oSQL.ParamByName["EMISSAO"] = Mensalidade.Emissao;
                oSQL.ParamByName["VENCIMENTO"] = Mensalidade.Vencimento;
                oSQL.ParamByName["COMPLEMENTO"] = Mensalidade.Complemento;
                oSQL.ParamByName["VALOR"] = Mensalidade.Valor;
                oSQL.ParamByName["ORIGEM"] = Mensalidade.Origem;
                oSQL.ParamByName["MULTA"] = Mensalidade.Multa;
                oSQL.ParamByName["JUROS"] = Mensalidade.Juros;
                oSQL.ParamByName["DESCONTO"] = Mensalidade.Desconto;
                oSQL.ParamByName["STATUS"] = Mensalidade.Status;
                oSQL.ParamByName["VALORTOTAL"] = Mensalidade.ValorTotal;
                oSQL.ParamByName["SALDO"] = Mensalidade.Saldo;
                oSQL.ParamByName["IDNATUREZA"] = Mensalidade.IDNatureza;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = Mensalidade.IDFormaDePagamento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDMENSALIDADE)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM MENSALIDADE WHERE IDMENSALIDADE = @IDMENSALIDADE";
                oSQL.ParamByName["IDMENSALIDADE"] = IDMENSALIDADE;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetMensalidades(decimal? Codigo, string Cliente, string Placa, DateTime VencimentoInicio, DateTime VencimentoFim, DateTime EmissaoInicio, DateTime EmissaoFim, bool Aberto, bool Parcial, bool Baixado, bool Cancelado)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();

                Filtros.Add($"(MENSALIDADE.VENCIMENTO::date BETWEEN (@INICIOVENCIMENTO)::date AND (@FIMVENCIMENTO)::date)");

                if (Codigo != null)
                    Filtros.Add($"(MENSALIDADE.IDMENSALIDADE = {Codigo})");

                if (!string.IsNullOrEmpty(Cliente))
                    Filtros.Add($@"((UNACCENT(UPPER(COALESCE(CLIENTE.NOME, ''))) LIKE UNACCENT(UPPER('%{Cliente}%'))) OR
                        (UNACCENT(UPPER(COALESCE(CLIENTE.NOMEFANTASIA, ''))) LIKE UNACCENT(UPPER('%{Cliente}%'))) or 
                        (UNACCENT(UPPER(COALESCE(CLIENTE.CPF, ''))) LIKE UNACCENT(UPPER('{Cliente}'))) OR 
                        (UPPER(COALESCE(CLIENTE.CNPJ, '')) LIKE UNACCENT(UPPER('{Cliente}'))) OR 
                        (UPPER(COALESCE(CLIENTE.DOCESTRANGEIRO, '')) LIKE UNACCENT(UPPER('{Cliente}'))))");

                if (!string.IsNullOrEmpty(Placa))
                    Filtros.Add($"(UPPER(UNACCENT(MENSALIDADE.PLACA)) LIKE UPPER(UNACCENT('%{Placa}%')))");

                if (!Aberto)
                    Filtros.Add($"(MENSALIDADE.STATUS <> 1)");

                if (!Parcial)
                    Filtros.Add($"(MENSALIDADE.STATUS <> 2)");

                if (!Baixado)
                    Filtros.Add($"(MENSALIDADE.STATUS <> 3)");

                if (!Cancelado)
                    Filtros.Add($"(MENSALIDADE.STATUS <> 0)");

                oSQL.SQL = $@"SELECT DISTINCT MENSALIDADE.IDMENSALIDADE,
                                     MENSALIDADE.IDCLIENTE,
                                     MENSALIDADE.IDVEICULO,
                                     VEICULO.PLACA,
                                     CASE 
                                        WHEN MENSALIDADE.IDCLIENTE IS NULL THEN 'Cliente Não Informado'
                                        WHEN CLIENTE.TIPODOCUMENTO IN (1,2) THEN CLIENTE.NOME
                                        WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.RAZAOSOCIAL
                                     END AS CLIENTE,
                                     MENSALIDADE.PARCELA,
                                     MENSALIDADE.EMISSAO,
                                     MENSALIDADE.VENCIMENTO,                                     
                                     MENSALIDADE.ORIGEM,
                                     MENSALIDADE.COMPLEMENTO,
                                     MENSALIDADE.VALORTOTAL,
                                     CASE
                                       WHEN MENSALIDADE.STATUS = 0 THEN 'Cancelado'
                                       WHEN MENSALIDADE.STATUS = 1 THEN 'Aberto'
                                       WHEN MENSALIDADE.STATUS = 2 THEN 'Parcial'
                                       WHEN MENSALIDADE.STATUS = 3 THEN 'Baixado'
                                     END AS STATUS
                                FROM MENSALIDADE                                  
                                  INNER JOIN CLIENTE ON (MENSALIDADE.IDCLIENTE = CLIENTE.IDCLIENTE)
                                  INNER JOIN VEICULO ON (VEICULO.IDVEICULO = MENSALIDADE.IDVEICULO)
                                  {(Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty)}
                                  ORDER BY MENSALIDADE.VENCIMENTO, MENSALIDADE.PARCELA, CLIENTE, VEICULO.PLACA";

                oSQL.ParamByName["INICIOVENCIMENTO"] = VencimentoInicio;
                oSQL.ParamByName["FIMVENCIMENTO"] = VencimentoFim;
                oSQL.ParamByName["INICIOEMISSAO"] = EmissaoInicio;
                oSQL.ParamByName["FIMEMISSAO"] = EmissaoFim;

                oSQL.Open();
                return oSQL.dtDados;
            }
        }
             
        
        public static Mensalidade GetMensalidade(decimal IDMensalidade)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM MENSALIDADE WHERE IDMENSALIDADE = @IDMENSALIDADE";
                oSQL.ParamByName["IDMENSALIDADE"] = IDMensalidade;
                oSQL.Open();
                return EntityUtil<Mensalidade>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDMensalidade)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM MENSALIDADE WHERE IDMENSALIDADE = @IDMENSALIDADE";
                oSQL.ParamByName["IDMENSALIDADE"] = IDMensalidade;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExistePorPlacaMes(decimal IDVeiculo, DateTime Inicio, DateTime Fim, decimal IDMensalidade)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM MENSALIDADE WHERE IDVEICULO = @IDVEICULO AND (MENSALIDADE.VENCIMENTO::date BETWEEN (@INICIOVENCIMENTO)::date AND (@FIMVENCIMENTO)::date) AND IDMENSALIDADE <> @IDMENSALIDADE";
                oSQL.ParamByName["IDMENSALIDADE"] = IDMensalidade;
                oSQL.ParamByName["IDVEICULO"] = IDVeiculo;
                oSQL.ParamByName["INICIOVENCIMENTO"] = Inicio;
                oSQL.ParamByName["FIMVENCIMENTO"] = Fim;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

    }
}
