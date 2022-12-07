using AutoDAO.DB.Controller;
using AutoDAO.DB.Utils;
using AutoDAO.Entidades;
using AutoPark;
using System;
using System.Collections.Generic;
using static AutoDAO.DB.Utils.DBUtils;

namespace PDV.VIEW.App_Context
{
    public class Contexto
    {
        /* VARIAVEIS DO USUÁRIO */

        public static Usuario USUARIOLOGADO;
        public static List<ItemMenu> ITENSMENU;

        /* END VARIAVEIS USUARIO */

        public static Version VERSAO;
        public static Login TELA_LOGIN;

        public static TIPOAMBIENTE AMBIENTE { get { return TIPOAMBIENTE.FORMS; } }

        public static int IDCONEXAO_PRIMARIA { get { return -1111; } }

        public static string CaminhoSolution
        {
            get
            {
                return System.AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public static string CaminhoSchemasMDFe = CaminhoSolution + "MDFe/Schemas";

        private static Controlador _Controller;
        public static Controlador CONTROLADOR
        {
            get
            {
                if (_Controller == null) //FUNÇÃO SUPERCÃO
                {
                    Controlador controlador = new Controlador(TipoConfiguracao.StartIni);
                    controlador.Inicializa(CaminhoSolution + "App_Data/Start.ini");

                    /* Conexao Primária */
                    controlador.IniciaConexaoPrimaria("Conexao_Main", "AutoPark");
                    if (!controlador.ConexaoPrimariaEstaAtiva())
                    {
                        System.Threading.Thread.Sleep(5000);
                        if (!controlador.ConexaoPrimariaEstaAtiva())
                        {
                            controlador.DesconectarConexaoPrimaria();
                            throw new Exception("Não foi possível iniciar a conexão primária com o banco de dados.");
                        }
                    }
                    controlador.DesconectarConexaoPrimaria();

                    _Controller = controlador;
                }
                return _Controller;
            }
        }

        public static void SetConfiguracaoPrimaria()
        {
            DBUtils.AMBIENTE = AMBIENTE;
            DBUtils.IDCONEXAO_PRIMARIA = IDCONEXAO_PRIMARIA;
            DBUtils.CONTROLADOR = CONTROLADOR;
        }
    }
}
