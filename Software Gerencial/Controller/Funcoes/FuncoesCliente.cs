using AutoDAO.Custom;
using AutoDAO.DB.Controller;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoDAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoController.Funcoes
{
    public class FuncoesCliente
    {
        public static bool ExisteCliente(decimal IDCliente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExisteClientePorCNPJ(string CNPJ, decimal IDCLIENTE)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CLIENTE WHERE UPPER(CNPJ) = UPPER(@CNPJ) AND IDCLIENTE <> @IDCLIENTE";
                oSQL.ParamByName["CNPJ"] = CNPJ;
                oSQL.ParamByName["IDCLIENTE"] = IDCLIENTE;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExisteClientePorCPF(string CPF, decimal IDCLIENTE)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CLIENTE WHERE UPPER(CPF) = UPPER(@CPF) AND IDCLIENTE <> @IDCLIENTE";
                oSQL.ParamByName["CPF"] = CPF;
                oSQL.ParamByName["IDCLIENTE"] = IDCLIENTE;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExisteClientePorDocEstrangeiro(string DOCESTRANGEIRO, decimal IDCLIENTE)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CLIENTE WHERE UPPER(DOCESTRANGEIRO) = UPPER(@DOCESTRANGEIRO) AND IDCLIENTE <> @IDCLIENTE";
                oSQL.ParamByName["DOCESTRANGEIRO"] = DOCESTRANGEIRO;
                oSQL.ParamByName["IDCLIENTE"] = IDCLIENTE;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExisteClienteCPF(string CPF)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CLIENTE WHERE CPF = @CPF";
                oSQL.ParamByName["CPF"] = CPF;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExisteClienteCNPJ(string CNPJ)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CLIENTE WHERE CNPJ = @CNPJ";
                oSQL.ParamByName["CNPJ"] = CNPJ;
                oSQL.Open();
                //Console.WriteLine("COMANDO ENVIADO : " + oSQL);
                return !oSQL.IsEmpty;
            }
        }


        public static DataTable GetClientes(string Nome_RazaoSocial, string CPF_CNPJ, bool Ativo, bool Inativo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Nome_RazaoSocial))
                    Filtros.Add(string.Format("(UNACCENT(UPPER(RAZAOSOCIAL)) LIKE UNACCENT(UPPER('%{0}%')) OR UNACCENT(UPPER(NOME)) LIKE UNACCENT(UPPER('%{0}%')))", Nome_RazaoSocial));

                if (!string.IsNullOrEmpty(CPF_CNPJ))
                    Filtros.Add(string.Format("(CNPJ LIKE UNACCENT(UPPER('%{0}%')) OR CPF LIKE UNACCENT(UPPER('%{0}%')))", CPF_CNPJ));

                if (Ativo == false)
                    Filtros.Add(string.Format("(CLIENTE.ATIVO <> 1)"));

                if (Inativo == false)
                    Filtros.Add(string.Format("(CLIENTE.ATIVO <> 0)"));


                oSQL.SQL = string.Format(@"SELECT CLIENTE.IDCLIENTE, CLIENTE.IDENDERECO, CLIENTE.IDCONTATO, ENDERECO.IDUNIDADEFEDERATIVA, ENDERECO.IDMUNICIPIO,
                                                  CASE WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.RAZAOSOCIAL ELSE CLIENTE.NOME END AS DESCRICAO,
                                                  CASE WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.CNPJ WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.CPF ELSE CLIENTE.DOCESTRANGEIRO END AS NUMERODOCUMENTO,
                                                  CASE WHEN CLIENTE.TIPODOCUMENTO = 0 THEN 'Jurídica' ELSE 'Física' END::VARCHAR(10) AS TIPO,
                                                  CASE WHEN CLIENTE.ATIVO = 0 THEN 'Não' ELSE 'Sim' END AS ATIVO 
                                           FROM CLIENTE 
                                           LEFT JOIN ENDERECO ON ENDERECO.IDENDERECO = CLIENTE.IDENDERECO
                                           {0}
                                           ORDER BY RAZAOSOCIAL, NOME", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataRow GetClientePorTipoEDocumento(decimal TipoDocumento, string Documento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT CLIENTE.IDCLIENTE,
                                    COALESCE(CLIENTE.NOME, RAZAOSOCIAL) AS NOME,
                                    COALESCE(CPF, CNPJ) AS DOCUMENTO,
                                    CONTATO.EMAIL
                               FROM CLIENTE
                                 LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO)
                              WHERE TIPODOCUMENTO = @TIPODOCUMENTO
                                AND COALESCE(CPF, CNPJ) = @DOCUMENTO";
                oSQL.ParamByName["TIPODOCUMENTO"] = TipoDocumento;
                oSQL.ParamByName["DOCUMENTO"] = Documento;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return oSQL.dtDados.Rows[0];
            }
        }

        public static Cliente GetClientePorDocumento(string Documento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CLIENTE.*
                               FROM CLIENTE
                                 LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO)
                              WHERE COALESCE(CPF, CNPJ, DOCESTRANGEIRO) = @DOCUMENTO";
                oSQL.ParamByName["DOCUMENTO"] = Documento;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }


        public static Cliente GetClientePorCPF(string CPF)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CLIENTE.*
                               FROM CLIENTE
                                 LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO)
                              WHERE CPF = @CPF";
                oSQL.ParamByName["CPF"] = CPF;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Cliente GetClientePorCNPJ(string CNPJ)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CLIENTE.*
                               FROM CLIENTE
                                 LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO)
                              WHERE CNPJ = @CNPJ";
                oSQL.ParamByName["CNPJ"] = CNPJ;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Cliente GetCliente(decimal IDCliente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCLIENTE,
                                    ATIVO,
                                    TIPODOCUMENTO,
                                    CNPJ,
                                    CPF,
                                    RAZAOSOCIAL,
                                    IDENDERECO,
                                    IDCONTATO,
                                    NOME,
                                    NOMEFANTASIA,
                                    DOCESTRANGEIRO
                             FROM CLIENTE
                             WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Salvar(Cliente _Cliente, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CLIENTE (IDCLIENTE, NOME, TIPODOCUMENTO, CNPJ, CPF, RAZAOSOCIAL, IDENDERECO, IDCONTATO, NOMEFANTASIA, ATIVO, DOCESTRANGEIRO)
                                      VALUES (@IDCLIENTE, @NOME, @TIPODOCUMENTO, @CNPJ, @CPF, @RAZAOSOCIAL, @IDENDERECO, @IDCONTATO, @NOMEFANTASIA, @ATIVO, @DOCESTRANGEIRO)";

                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CLIENTE
                                       SET TIPODOCUMENTO = @TIPODOCUMENTO,
                                           CNPJ = @CNPJ,
                                           CPF = @CPF,
                                           RAZAOSOCIAL = @RAZAOSOCIAL,
                                           IDENDERECO = @IDENDERECO,
                                           IDCONTATO = @IDCONTATO,
                                           NOME = @NOME,
                                           NOMEFANTASIA = @NOMEFANTASIA,
                                           ATIVO = @ATIVO,
                                           DOCESTRANGEIRO = @DOCESTRANGEIRO
                                       WHERE IDCLIENTE = @IDCLIENTE";
                        break;
                }
                oSQL.ParamByName["IDCLIENTE"] = _Cliente.IDCliente;
                oSQL.ParamByName["TIPODOCUMENTO"] = _Cliente.TipoDocumento;
                oSQL.ParamByName["CNPJ"] = _Cliente.CNPJ;
                oSQL.ParamByName["CPF"] = _Cliente.CPF;
                oSQL.ParamByName["RAZAOSOCIAL"] = _Cliente.RazaoSocial;
                oSQL.ParamByName["NOME"] = _Cliente.Nome;
                oSQL.ParamByName["NOMEFANTASIA"] = _Cliente.NomeFantasia;
                oSQL.ParamByName["ATIVO"] = _Cliente.Ativo;
                oSQL.ParamByName["DOCESTRANGEIRO"] = _Cliente.DocEstrangeiro;
                oSQL.ParamByName["IDENDERECO"] = _Cliente.IDEndereco;
                oSQL.ParamByName["IDCONTATO"] = _Cliente.IDContato;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDCliente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                decimal? IDEndereco = null;
                decimal? IDContato = null;

                oSQL.SQL = "SELECT IDENDERECO FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    IDEndereco = Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDENDERECO"]);

                oSQL.ClearAll();
                oSQL.SQL = "SELECT IDCONTATO FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    IDContato = Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDCONTATO"]);

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                if (oSQL.ExecSQL() != 1)
                    throw new Exception();

                if (IDEndereco.HasValue)
                {
                    oSQL.ClearAll();
                    oSQL.SQL = "DELETE FROM ENDERECO WHERE IDENDERECO = @IDENDERECO";
                    oSQL.ParamByName["IDENDERECO"] = IDEndereco.Value;
                    if (oSQL.ExecSQL() != 1)
                        throw new Exception();
                }

                if (IDContato.HasValue)
                {
                    oSQL.ClearAll();
                    oSQL.SQL = "DELETE FROM CONTATO WHERE IDCONTATO = @IDCONTATO";
                    oSQL.ParamByName["IDCONTATO"] = IDContato.Value;
                    if (oSQL.ExecSQL() != 1)
                        throw new Exception();
                }
                return true;
            }
        }

        public static bool SalvarAtualizarClienteNFCe(decimal IDCliente, string EmailCliente, string CPFCNPJ, decimal TipoDocumento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (!ExisteCliente(IDCliente))
                {
                    decimal _IDContato = Sequence.GetNextID("CONTATO", "IDCONTATO");
                    oSQL.SQL = "INSERT INTO CONTATO (IDCONTATO, EMAIL) VALUES (@IDCONTATO, @EMAIL)";
                    oSQL.ParamByName["EMAIL"] = EmailCliente;
                    oSQL.ParamByName["IDCONTATO"] = _IDContato;
                    oSQL.ExecSQL();

                    oSQL.ClearAll();

                    oSQL.SQL = @"INSERT INTO CLIENTE (IDCLIENTE, CPF, CNPJ, NOME, RAZAOSOCIAL, TIPODOCUMENTO, IDCONTATO, ATIVO)
                                          VALUES (@IDCLIENTE, @CPF, @CNPJ, @NOME, @RAZAOSOCIAL, @TIPODOCUMENTO, @IDCONTATO, @ATIVO)";
                    oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                    oSQL.ParamByName["CPF"] = TipoDocumento == 0 ? string.Empty : CPFCNPJ;
                    oSQL.ParamByName["CNPJ"] = TipoDocumento == 0 ? CPFCNPJ : string.Empty;
                    oSQL.ParamByName["NOME"] = TipoDocumento == 0 ? string.Empty : CPFCNPJ;
                    oSQL.ParamByName["RAZAOSOCIAL"] = TipoDocumento == 0 ? CPFCNPJ : string.Empty;
                    oSQL.ParamByName["TIPODOCUMENTO"] = TipoDocumento;
                    oSQL.ParamByName["IDCONTATO"] = _IDContato;
                    oSQL.ParamByName["ATIVO"] = 1;
                    return oSQL.ExecSQL() == 1;
                }
                else
                {
                    Cliente _Cliente = GetCliente(IDCliente);
                    oSQL.SQL = @"UPDATE CONTATO SET EMAIL = @EMAIL WHERE IDCONTATO = @IDCONTATO";
                    oSQL.ParamByName["IDCONTATO"] = _Cliente.IDContato;
                    oSQL.ParamByName["EMAIL"] = EmailCliente;
                    return oSQL.ExecSQL() == 1;
                }
            }
        }

        public static bool SalvarAtualizarClientePedido(decimal IDCliente, string EmailCliente, string CPFCNPJ, decimal TipoDocumento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (!ExisteCliente(IDCliente))
                {
                    decimal _IDContato = Sequence.GetNextID("CONTATO", "IDCONTATO");
                    oSQL.SQL = "INSERT INTO CONTATO (IDCONTATO, EMAIL) VALUES (@IDCONTATO, @EMAIL)";
                    oSQL.ParamByName["EMAIL"] = EmailCliente;
                    oSQL.ParamByName["IDCONTATO"] = _IDContato;
                    oSQL.ExecSQL();

                    oSQL.ClearAll();

                    oSQL.SQL = @"INSERT INTO CLIENTE (IDCLIENTE, CPF, CNPJ, NOME, RAZAOSOCIAL, TIPODOCUMENTO, IDCONTATO, ATIVO)
                                          VALUES (@IDCLIENTE, @CPF, @CNPJ, @NOME, @RAZAOSOCIAL, @TIPODOCUMENTO, @IDCONTATO, @ATIVO)";
                    oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                    oSQL.ParamByName["CPF"] = TipoDocumento == 0 ? string.Empty : CPFCNPJ;
                    oSQL.ParamByName["CNPJ"] = TipoDocumento == 0 ? CPFCNPJ : string.Empty;
                    oSQL.ParamByName["NOME"] = TipoDocumento == 0 ? string.Empty : CPFCNPJ;
                    oSQL.ParamByName["RAZAOSOCIAL"] = TipoDocumento == 0 ? CPFCNPJ : string.Empty;
                    oSQL.ParamByName["TIPODOCUMENTO"] = TipoDocumento;
                    oSQL.ParamByName["IDCONTATO"] = _IDContato;
                    oSQL.ParamByName["ATIVO"] = 1;
                    return oSQL.ExecSQL() == 1;
                }
                else
                {
                    Cliente _Cliente = FuncoesCliente.GetCliente(IDCliente);
                    oSQL.SQL = @"UPDATE CONTATO SET EMAIL = @EMAIL WHERE IDCONTATO = @IDCONTATO";
                    oSQL.ParamByName["IDCONTATO"] = _Cliente.IDContato;
                    oSQL.ParamByName["EMAIL"] = EmailCliente;
                    return oSQL.ExecSQL() == 1;
                }
            }
        }

        public static DataTable GetClientesNFe(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT COALESCE(CLIENTE.NOME, CLIENTE.NOMEFANTASIA) AS NOME,
                                                  COALESCE(CLIENTE.CPF, CLIENTE.CNPJ) AS DOCUMENTO,
                                                  CLIENTE.IDCLIENTE,
                                                  ENDERECO.IDENDERECO,
                                                  UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                                  MUNICIPIO.IDMUNICIPIO,
                                                  CONTATO.IDCONTATO
                                           FROM CLIENTE
                                              INNER JOIN ENDERECO ON (CLIENTE.IDENDERECO = ENDERECO.IDENDERECO)
                                              INNER JOIN UNIDADEFEDERATIVA ON (ENDERECO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                                              INNER JOIN MUNICIPIO ON (MUNICIPIO.IDMUNICIPIO = ENDERECO.IDMUNICIPIO)
                                               LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO)
                                           WHERE UNACCENT(UPPER(COALESCE(CLIENTE.NOME, CLIENTE.NOMEFANTASIA))) LIKE UNACCENT(UPPER('%{0}%'))", Descricao.ToUpper());
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

    }
}
