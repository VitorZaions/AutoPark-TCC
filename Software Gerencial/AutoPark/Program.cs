using AutoController.Funcoes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PDV.VIEW.App_Context;
using System.Diagnostics;
using System.Reflection;

namespace AutoPark
{
    internal static class Program
    {
        public static string Version;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            VerificarMultiplaExecução();

            Contexto.SetConfiguracaoPrimaria();

            Contexto.VERSAO = new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(Path.GetFullPath(".") + "/AutoPark.exe").ProductVersion);

            Version = Contexto.VERSAO.ToString();
            // Abertura da tela de login e set de algumas informações
            Login Log = new Login();
            Log.WindowState = FormWindowState.Minimized;
            Log.Shown += delegate (Object sender, EventArgs e)
            {
                ((Form)sender).WindowState = FormWindowState.Normal;                
            };

            Application.Run(Log);

            if (Log.Logado != null)
            {
                if (Log.Logado.Root == 1)
                {
                    Contexto.USUARIOLOGADO = Log.Logado;
                    Contexto.ITENSMENU = null;
                    Contexto.TELA_LOGIN = Log;
                    Contexto.TELA_LOGIN.Visible = false;
                    Application.Run(new Inicial());
                }
                else
                {
                    Contexto.USUARIOLOGADO = Log.Logado;
                    Contexto.ITENSMENU = FuncoesPerfilAcesso.GetItensMenuPorPerfilAcesso(Log.Logado.IDPerfilAcesso);
                    Contexto.TELA_LOGIN = Log;
                    Contexto.TELA_LOGIN.Visible = false;
                    Application.Run(new Inicial());
                }
            }
            else
                Environment.Exit(Environment.ExitCode);
        }

        private static void VerificarMultiplaExecução()
        {
            string thisprocessname = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                Environment.Exit(Environment.ExitCode);
        }

    }
}