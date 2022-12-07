﻿using AutoDAO.DB.Controller;
using AutoDAO.DB.Utils;
using System.Data;
using AutoDAO.Custom;
using AutoDAO.Entidades;

namespace AutoController.Funcoes
{
    public class FuncoesConfiguracao
    {
        public static bool Salvar(string Chave, byte[] Valor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM CONFIGURACAO WHERE CHAVE = @CHAVE";
                oSQL.ParamByName["CHAVE"] = Chave;
                oSQL.Open();
                if (oSQL.IsEmpty)
                {
                    oSQL.ClearAll();
                    oSQL.SQL = "INSERT INTO CONFIGURACAO (IDCONFIGURACAO, CHAVE, VALOR) VALUES (@IDCONFIGURACAO, @CHAVE, @VALOR)";
                    oSQL.ParamByName["IDCONFIGURACAO"] = Sequence.GetNextID("CONFIGURACAO", "IDCONFIGURACAO");
                    oSQL.ParamByName["CHAVE"] = Chave;
                    oSQL.ParamByName["VALOR"] = Valor;
                }
                else
                {
                    oSQL.ClearAll();
                    oSQL.SQL = "UPDATE CONFIGURACAO SET VALOR = @VALOR WHERE CHAVE = @CHAVE";
                    oSQL.ParamByName["CHAVE"] = Chave;
                    oSQL.ParamByName["VALOR"] = Valor;
                }
                return oSQL.ExecSQL() == 1;
            }
        }

        public static Configuracao GetConfiguracao(string Chave)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT C.* FROM CONFIGURACAO C WHERE CHAVE = @CHAVE";
                oSQL.ParamByName["CHAVE"] = Chave;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Configuracao>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(string Chave)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM CONFIGURACAO WHERE CHAVE = @CHAVE";
                oSQL.ParamByName["CHAVE"] = Chave;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static DataTable GetConfiguracoesEmail()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONFIGURACAO, CHAVE, VALOR FROM CONFIGURACAO WHERE CHAVE = 'CONFIG_EMAIL_SMTP'
                               UNION
                             SELECT IDCONFIGURACAO, CHAVE, VALOR FROM CONFIGURACAO WHERE CHAVE = 'CONFIG_EMAIL_PORTA'
                               UNION
                             SELECT IDCONFIGURACAO, CHAVE, VALOR FROM CONFIGURACAO WHERE CHAVE = 'CONFIG_EMAIL_SSL'
                               UNION
                             SELECT IDCONFIGURACAO, CHAVE, VALOR FROM CONFIGURACAO WHERE CHAVE = 'CONFIG_EMAIL_TSL'
                               UNION
                             SELECT IDCONFIGURACAO, CHAVE, VALOR FROM CONFIGURACAO WHERE CHAVE = 'CONFIG_EMAIL_AUTO'
                               UNION
                             SELECT IDCONFIGURACAO, CHAVE, VALOR FROM CONFIGURACAO WHERE CHAVE = 'CONFIG_EMAIL_EMAIL'
                               UNION
                             SELECT IDCONFIGURACAO, CHAVE, VALOR FROM CONFIGURACAO WHERE CHAVE = 'CONFIG_EMAIL_SENHA'
                               UNION
                             SELECT IDCONFIGURACAO, CHAVE, VALOR FROM CONFIGURACAO WHERE CHAVE = 'CONFIG_EMAIL_REMETENTE'
                               UNION
                             SELECT IDCONFIGURACAO, CHAVE, VALOR FROM CONFIGURACAO WHERE CHAVE = 'CONFIG_EMAIL_NOME_REMETENTE'
                               UNION
                             SELECT IDCONFIGURACAO, CHAVE, VALOR FROM CONFIGURACAO WHERE CHAVE = 'CONFIG_EMAIL_TIMEOUT'";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
