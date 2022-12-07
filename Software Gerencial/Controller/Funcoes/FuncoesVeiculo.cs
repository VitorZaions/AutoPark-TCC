using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesVeiculo
    {
        public static bool ExisteVeiculo(decimal IDVeiculo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM VEICULO WHERE IDVEICULO = @IDVEICULO";
                oSQL.ParamByName["IDVEICULO"] = IDVeiculo;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExisteVeiculoPorPlaca(decimal IDVEICULO, string Placa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM VEICULO                           
                            WHERE PLACA = @PLACA 
                            AND IDVEICULO <> @IDVEICULO";
                oSQL.ParamByName["IDVEICULO"] = IDVEICULO;
                oSQL.ParamByName["PLACA"] = Placa;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Veiculo GetVeiculo(decimal IDVeiculo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT VEICULO.IDVEICULO,
                                    VEICULO.IDCLIENTE,
                                    VEICULO.DESCRICAO,
                                    VEICULO.PLACA,
                                    VEICULO.IDUNIDADEFEDERATIVA,
                                    VEICULO.ATIVO,
                                    VEICULO.IDPAIS,
                                    VEICULO.TIPO,
                                    CASE WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.RAZAOSOCIAL ELSE CLIENTE.NOME END AS CLIENTE
                             FROM VEICULO
                               LEFT JOIN CLIENTE ON (CLIENTE.IDCLIENTE = VEICULO.IDCLIENTE)
                               WHERE VEICULO.IDVEICULO = @IDVEICULO";
                oSQL.ParamByName["IDVEICULO"] = IDVeiculo;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Veiculo>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
      
              

        public static DataTable GetVeiculos(string Descricao, string Cliente, string Placa, bool Ativo, bool Inativo, bool Leve, bool Pesado)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(VEICULO.DESCRICAO)) LIKE UNACCENT(UPPER('%{0}%')))", Descricao));

                if (!string.IsNullOrEmpty(Placa))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(VEICULO.PLACA)) LIKE UNACCENT(UPPER('%{0}%')))", Placa));

                if (!string.IsNullOrEmpty(Cliente))
                    Filtros.Add(string.Format($"(UNACCENT(UPPER(CLIENTE.RAZAOSOCIAL)) LIKE UNACCENT(UPPER('%{Cliente}%')) OR UNACCENT(UPPER(CLIENTE.NOME)) LIKE UNACCENT(UPPER('%{Cliente}%')) OR UNACCENT(UPPER(CLIENTE.CNPJ)) LIKE UNACCENT(UPPER('{Cliente}')) OR UNACCENT(UPPER(CLIENTE.CPF)) LIKE UNACCENT(UPPER('{Cliente}')))"));

                if (!Ativo)
                    Filtros.Add(string.Format("(VEICULO.ATIVO <> 1)"));

                if (!Inativo)
                    Filtros.Add(string.Format("(VEICULO.ATIVO <> 0)"));

                if (!Leve)
                    Filtros.Add(string.Format("(VEICULO.TIPO <> 0)"));

                if (!Pesado)
                    Filtros.Add(string.Format("(VEICULO.TIPO <> 1)"));

                oSQL.SQL = string.Format(@"SELECT VEICULO.IDVEICULO,     
                                                  VEICULO.DESCRICAO,
                                                  VEICULO.PLACA,
                                                  VEICULO.IDUNIDADEFEDERATIVA,
                                                  VEICULO.ATIVO,
                                                  VEICULO.IDPAIS,
                                                  CASE WHEN VEICULO.TIPO = 0 THEN 'Leve' ELSE 'Pesado' END AS TIPO,
                                                  CASE WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.RAZAOSOCIAL ELSE CLIENTE.NOME END AS CLIENTE,
                                                  VEICULO.IDCLIENTE
                                           FROM VEICULO 
                                           LEFT JOIN CLIENTE ON (CLIENTE.IDCLIENTE = VEICULO.IDCLIENTE)
                                            {0}
                                           ORDER BY RAZAOSOCIAL, NOME", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
                

        public static bool Salvar(Veiculo _Veiculo, TipoOperacao _Operacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (_Operacao)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO VEICULO
                                       (IDVEICULO, DESCRICAO, PLACA, IDUNIDADEFEDERATIVA, ATIVO, IDPAIS, IDCLIENTE, TIPO)
                                     VALUES
                                       (@IDVEICULO, @DESCRICAO, @PLACA, @IDUNIDADEFEDERATIVA, @ATIVO, @IDPAIS, @IDCLIENTE, @TIPO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE VEICULO
                                       SET DESCRICAO = @DESCRICAO, 
                                           PLACA = @PLACA,
                                           IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA,
                                           ATIVO = @ATIVO,
                                           IDPAIS = @IDPAIS,
                                           IDCLIENTE = @IDCLIENTE,
                                           TIPO = @TIPO
                                     WHERE IDVEICULO = @IDVEICULO";
                        break;
                }
                oSQL.ParamByName["IDVEICULO"] = _Veiculo.IDVeiculo;
                oSQL.ParamByName["DESCRICAO"] = _Veiculo.Descricao;
                oSQL.ParamByName["PLACA"] = _Veiculo.Placa;
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = _Veiculo.IDUnidadeFederativa;
                oSQL.ParamByName["ATIVO"] = _Veiculo.Ativo;
                oSQL.ParamByName["IDPAIS"] = _Veiculo.IDPais;
                oSQL.ParamByName["IDCLIENTE"] = _Veiculo.IDCLIENTE;
                oSQL.ParamByName["TIPO"] = _Veiculo.Tipo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDVeiculo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                //oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM VEICULO WHERE IDVEICULO = @IDVEICULO";
                oSQL.ParamByName["IDVEICULO"] = IDVeiculo;
                if (oSQL.ExecSQL() != 1)
                    throw new Exception();

                return true;
            }
        }
    }
}
