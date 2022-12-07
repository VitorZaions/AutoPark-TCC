using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesEntrada
    {
        public static bool Salvar(Entrada _Entrada, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO ENTRADA(
                                                 IDENTRADA, IDVEICULO, DATAENTRADA, TEMPO, TIPO)
                                         VALUES (@IDENTRADA, @IDVEICULO, @DATAENTRADA, @TEMPO, @TIPO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE ENTRADA
                                       SET IDVEICULO = @IDVEICULO,
                                           DATAENTRADA = @DATAENTRADA, 
                                           TEMPO = @TEMPO,
                                           TIPO = @TIPO
                                     WHERE IDENTRADA = @IDENTRADA";
                        break;
                }
                oSQL.ParamByName["IDENTRADA"] = _Entrada.IDEntrada;
                oSQL.ParamByName["IDVEICULO"] = _Entrada.IDVeiculo;
                oSQL.ParamByName["DATAENTRADA"] = _Entrada.DataEntrada;
                oSQL.ParamByName["TEMPO"] = _Entrada.Tempo;
                oSQL.ParamByName["TIPO"] = _Entrada.Tipo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDENTRADA)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM ENTRADA WHERE IDENTRADA = @IDENTRADA";
                oSQL.ParamByName["IDENTRADA"] = IDENTRADA;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static DataTable GetEntradas(decimal? Codigo, string Cliente, string Veiculo, DateTime DataEntradaInicio, DateTime DataEntradaFim, bool Aberto, bool Parcial, bool Baixado, bool Cancelado, bool Nulo, bool Normal, bool OCR)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();

                Filtros.Add($"(ENTRADA.DATAENTRADA::date BETWEEN (@ENTRADAINICIO)::date AND (@ENTRADAFIM)::date)");
               

                if (Codigo != null)
                    Filtros.Add($"(ENTRADA.IDENTRADA = {Codigo})");

                if (!string.IsNullOrEmpty(Cliente))
                    Filtros.Add($@"((UNACCENT(UPPER(COALESCE(CLIENTE.NOME, ''))) LIKE UNACCENT(UPPER('%{Cliente}%'))) OR
                        (UNACCENT(UPPER(COALESCE(CLIENTE.NOMEFANTASIA, ''))) LIKE UNACCENT(UPPER('%{Cliente}%'))) or 
                        (UNACCENT(UPPER(COALESCE(CLIENTE.CPF, ''))) LIKE UNACCENT(UPPER('{Cliente}'))) OR 
                        (UPPER(COALESCE(CLIENTE.CNPJ, '')) LIKE UNACCENT(UPPER('{Cliente}'))) OR 
                        (UPPER(COALESCE(CLIENTE.DOCESTRANGEIRO, '')) LIKE UNACCENT(UPPER('{Cliente}'))))");
                
                if (!string.IsNullOrEmpty(Veiculo))
                    Filtros.Add($"(UPPER(VEICULO.PLACA) LIKE UPPER('%{Veiculo}%'))");
                
                if (!Aberto)
                    Filtros.Add($"(COALESCE(STATUS, -1) <> 1)");

                if (!Parcial)
                    Filtros.Add($"(COALESCE(STATUS, -1) <> 2)");

                if (!Baixado)
                    Filtros.Add($"(COALESCE(STATUS, -1) <> 3)");

                if (!Cancelado)
                    Filtros.Add($"(COALESCE(STATUS, -1) <> 0)");

                if (!Nulo)
                    Filtros.Add($"(COALESCE(STATUS, -1) <> -1)");

                if (!Normal)
                    Filtros.Add($"(ENTRADA.TIPO <> 0)");

                if (!OCR)
                    Filtros.Add($"(ENTRADA.TIPO <> 1)");

                oSQL.SQL = $@"SELECT ENTRADA.IDENTRADA,
                                     VEICULO.PLACA,
                                     VEICULO.IDCLIENTE,
                                     CASE 
                                        WHEN VEICULO.IDCLIENTE IS NULL THEN 'Cliente Não Informado'
                                        WHEN CLIENTE.TIPODOCUMENTO IN (1,2) THEN CLIENTE.NOME
                                        WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.RAZAOSOCIAL
                                     END AS CLIENTE,
                                     COALESCE(CONTARECEBER.VALORTOTAL,0),
                                     CASE
                                       WHEN ENTRADA.TIPO = 1 THEN 'Mensalista'
                                       WHEN CONTARECEBER.STATUS IS NULL THEN 'Nulo'
                                       WHEN CONTARECEBER.STATUS = 0 THEN 'Cancelado'
                                       WHEN CONTARECEBER.STATUS = 1 THEN 'Aberto'
                                       WHEN CONTARECEBER.STATUS = 2 THEN 'Parcial'
                                       WHEN CONTARECEBER.STATUS = 3 THEN 'Baixado'
                                       WHEN CONTARECEBER.STATUS = 4 THEN 'Renegociado'
                                     END AS STATUS,
                                     ENTRADA.DATAENTRADA,
                                     CASE
                                       WHEN ENTRADA.TIPO = 0 THEN 'Normal'
                                       WHEN ENTRADA.TIPO = 1 THEN 'OCR'
                                     END AS TIPO
                                FROM ENTRADA                                  
                                  LEFT JOIN CONTARECEBER ON (CONTARECEBER.IDENTRADA = ENTRADA.IDENTRADA)
                                  LEFT JOIN VEICULO ON (VEICULO.IDVEICULO = ENTRADA.IDVEICULO)
                                  LEFT JOIN CLIENTE ON (CLIENTE.IDCLIENTE = VEICULO.IDCLIENTE)
                                  {(Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty)}
                                  ORDER BY ENTRADA.DATAENTRADA, CLIENTE, STATUS, TIPO";

                oSQL.ParamByName["ENTRADAINICIO"] = DataEntradaInicio;
                oSQL.ParamByName["ENTRADAFIM"] = DataEntradaFim;

                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        

        public static Entrada GetEntrada(decimal IDENTRADA)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM ENTRADA WHERE IDENTRADA = @IDENTRADA";
                oSQL.ParamByName["IDENTRADA"] = IDENTRADA;
                oSQL.Open();
                return EntityUtil<Entrada>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDENTRADA)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM ENTRADA WHERE IDENTRADA = @IDENTRADA";
                oSQL.ParamByName["IDENTRADA"] = IDENTRADA;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }          
    }
}
