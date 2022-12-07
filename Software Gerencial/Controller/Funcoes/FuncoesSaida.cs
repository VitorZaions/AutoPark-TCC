using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesSaida
    {
        public static bool Salvar(Saida _Saida, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO SAIDA(
                                                 IDSAIDA, IDVEICULO, DATASAIDA, TIPO)
                                         VALUES (@IDSAIDA, @IDVEICULO, @DATASAIDA, @TIPO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE SAIDA
                                       SET IDVEICULO = @IDVEICULO,
                                           DATASAIDA = @DATASAIDA,
                                           TIPO = @TIPO
                                     WHERE IDSAIDA = @IDSAIDA";
                        break;
                }
                oSQL.ParamByName["IDSAIDA"] = _Saida.IDSaida;
                oSQL.ParamByName["IDVEICULO"] = _Saida.IDVeiculo;
                oSQL.ParamByName["DATASAIDA"] = _Saida.DataSaida;
                oSQL.ParamByName["TIPO"] = _Saida.Tipo;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static bool Remover(decimal IDSAIDA)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM SAIDA WHERE IDSAIDA = @IDSAIDA";
                oSQL.ParamByName["IDSAIDA"] = IDSAIDA;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static DataTable GetSaidas(decimal? Codigo, string Cliente, string Veiculo, DateTime DataSaidaInicio, DateTime DataSaidaFim, bool Normal, bool OCR)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();

                Filtros.Add($"(SAIDA.DATASAIDA::date BETWEEN (@SAIDAINICIO)::date AND (@SAIDAFIM)::date)");               

                if (Codigo != null)
                    Filtros.Add($"(SAIDA.IDSAIDA = {Codigo})");

                if (!string.IsNullOrEmpty(Cliente))
                    Filtros.Add($@"((UNACCENT(UPPER(COALESCE(CLIENTE.NOME, ''))) LIKE UNACCENT(UPPER('%{Cliente}%'))) OR
                        (UNACCENT(UPPER(COALESCE(CLIENTE.NOMEFANTASIA, ''))) LIKE UNACCENT(UPPER('%{Cliente}%'))) or 
                        (UNACCENT(UPPER(COALESCE(CLIENTE.CPF, ''))) LIKE UNACCENT(UPPER('{Cliente}'))) OR 
                        (UPPER(COALESCE(CLIENTE.CNPJ, '')) LIKE UNACCENT(UPPER('{Cliente}'))) OR 
                        (UPPER(COALESCE(CLIENTE.DOCESTRANGEIRO, '')) LIKE UNACCENT(UPPER('{Cliente}'))))");
                
                if (!string.IsNullOrEmpty(Veiculo))
                    Filtros.Add($"(UPPER(VEICULO.PLACA) LIKE UPPER('%{Veiculo}%'))");
                
                if (!Normal)
                    Filtros.Add($"(SAIDA.TIPO <> 0)");

                if (!OCR)
                    Filtros.Add($"(SAIDA.TIPO <> 1)");

                oSQL.SQL = $@"SELECT SAIDA.IDSAIDA,
                                     VEICULO.PLACA,
                                     VEICULO.IDCLIENTE,
                                     CASE 
                                        WHEN VEICULO.IDCLIENTE IS NULL THEN 'Cliente Não Informado'
                                        WHEN CLIENTE.TIPODOCUMENTO IN (1,2) THEN CLIENTE.NOME
                                        WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.RAZAOSOCIAL
                                     END AS CLIENTE,
                                     SAIDA.DATASAIDA,
                                     CASE
                                       WHEN SAIDA.TIPO = 0 THEN 'Normal'
                                       WHEN SAIDA.TIPO = 1 THEN 'OCR'
                                     END AS TIPO
                                FROM SAIDA
                                  LEFT JOIN VEICULO ON (VEICULO.IDVEICULO = SAIDA.IDVEICULO)
                                  LEFT JOIN CLIENTE ON (CLIENTE.IDCLIENTE = VEICULO.IDCLIENTE)
                                  {(Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty)}
                                  ORDER BY SAIDA.DATASAIDA, CLIENTE, TIPO";

                oSQL.ParamByName["SAIDAINICIO"] = DataSaidaInicio;
                oSQL.ParamByName["SAIDAFIM"] = DataSaidaFim;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static Saida GetSaida(decimal IDSAIDA)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT * FROM SAIDA WHERE IDSAIDA = @IDSAIDA";
                oSQL.ParamByName["IDSAIDA"] = IDSAIDA;
                oSQL.Open();
                return EntityUtil<Saida>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDSAIDA)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM SAIDA WHERE IDSAIDA = @IDSAIDA";
                oSQL.ParamByName["IDSAIDA"] = IDSAIDA;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }          
    }
}
