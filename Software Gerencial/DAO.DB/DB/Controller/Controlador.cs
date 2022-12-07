using AutoDAO.DB.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace AutoDAO.DB.Controller
{
    public enum TipoConfiguracao
    {
        StartIni,
        XML
    }

    public enum TipoCriptografia
    {
        Padrao,
        MD5
    }

    public class Controlador
    {

        #region Fields
        public Dictionary<int, Conexao> Pool { get; set; }
        public static IniFile IniFile { get; set; }

        public DataTable dtConexoesUsuario { get; set; }

        public static int IDConexaoPrimaria
        {
            get { return -1111; }
        }

        public string _DirArquivoConfiguracao { get; set; }
        public string _DirArquivoConfiguracaoLicense { get; set; }
        public TipoConfiguracao _TipoConfiguracao { get; set; }
        public TipoCriptografia _TipoCriptografia { get; set; }
        #endregion

        public bool IsTheUpdater = false;

        #region Constructor
        public Controlador(TipoConfiguracao tipoConfiguracao, TipoCriptografia tipoCriptografia = TipoCriptografia.Padrao)
        {
            if (Pool == null)
                Pool = new Dictionary<int, Conexao>();

            this._TipoConfiguracao = tipoConfiguracao;
            this._TipoCriptografia = tipoCriptografia;
        }

        ~Controlador()
        {
            this.Pool = null;
            this._DirArquivoConfiguracao = null;
            if (this.dtConexoesUsuario != null)
                this.dtConexoesUsuario.Dispose();
            this.dtConexoesUsuario = null;
        }
        #endregion

        #region Inicializa Arquivo De Configuração
        public void Inicializa(string dir)
        {
            IniFile = new IniFile(dir);
            _DirArquivoConfiguracao = dir;
        }

        public void InicializaLicenca(string dir)
        {
            _DirArquivoConfiguracaoLicense = dir;
        }
        #endregion

        #region ConexaoPrimaria
        public void IniciaConexaoPrimaria(string Identificador, string Programa)
        {
            AdicionaConexao_ArquivoConfiguracao(IDConexaoPrimaria, Identificador, Programa);
            Connect(IDConexaoPrimaria);
        }

        public void Conectar(int IDConexao)
        {
            Connect(IDConexao);
        }

        public void DesconectarConexaoPrimaria()
        {
            this.Disconnect(IDConexaoPrimaria);
        }
        public void DesconectarConexao(int IDConexao)
        {
            this.Disconnect(IDConexao);
        }
             
        public void AdicionaConexao_ArquivoConfiguracao(int IDConexao, string Identificador, string Programa)
        {
            string license = string.Empty;
            try
            {
                string vsSGBD = IniFile.GetValue(Identificador, "sgbd").ToUpper();
                string vsUsuario = IniFile.GetValue(Identificador, "usuario");
                string vsSenha = IniFile.GetValue(Identificador, "senha");//Criptografia2.DecodificaSenha(IniFile.GetValue(Identificador, "senha"));
                string pgServer = IniFile.GetValue(Identificador, "servidor");
                string pgPorta = IniFile.GetValue(Identificador, "porta", "5432");
                string pgDatabase = IniFile.GetValue(Identificador, "banco");
                string pgMaxPoolSize = IniFile.GetValue(Identificador, "max_pool_size", "100");
                string pgMinPoolSize = Convert.ToInt32(pgMaxPoolSize) >= 10 ? "10" : Convert.ToInt32(pgMaxPoolSize).ToString();
                string ApplicationName = "";
                ApplicationName = Programa;

                string strPostgres = String.Format("Server={0};Port={1};Database={2};User Id={3};Password={4};MaxPoolSize={5};MinPoolSize={6};CommandTimeout=0;TIMEOUT=60;ApplicationName={7};",
                                                        pgServer, pgPorta, pgDatabase, vsUsuario, vsSenha, pgMaxPoolSize, pgMinPoolSize, ApplicationName);
                if (!string.IsNullOrEmpty(pgDatabase))
                    this.AddConexao(IDConexao, strPostgres);
            }            
            catch (Exception e)
            {
                StreamWriter writer = new StreamWriter(@"Log.txt", true);
                using (writer)
                {
                    writer.WriteLine("Sync Sistemas - Não foi possível encontrar o arquivo : App_Data/Start.ini - " + e.Message);
                }
                writer.Close();
                Environment.Exit(Environment.ExitCode);
            }
        }

        public bool ConexaoPrimariaEstaAtiva()
        {
            foreach (KeyValuePair<int, Conexao> conn in Pool)
                if (conn.Key == IDConexaoPrimaria)
                    return conn.Value.Connection.State == ConnectionState.Open;

            return false;
        }

        public bool ConexaoEstaAtiva(int IDConexao)
        {
            foreach (KeyValuePair<int, Conexao> conn in Pool)
                if (conn.Key == IDConexao)
                    return conn.Value.Connection.State == ConnectionState.Open;

            return false;
        }

        #endregion

        #region Adiciona Conexão
        public void AddConexao(int IDConexao, string ConnectionString)
        {
            if (!ExisteConexao(IDConexao))
                Pool.Add(IDConexao, new Conexao(IDConexao, ConnectionString));
        }

        public void AddConexao(DataRow drConexao)
        {
            int IDConexao = Convert.ToInt32(drConexao["ID_CONEXAO"]);

            if (!ExisteConexao(IDConexao))
                Pool.Add(IDConexao, new Conexao(drConexao));
        }
        #endregion

        #region Remove Conexão
        public void RemoveConexao(int IDConexao)
        {
            if (!ExisteConexao(IDConexao))
                return;

            try
            {
                Disconnect(IDConexao);
            }
            catch { }
            Pool.Remove(IDConexao);
        }
        #endregion

        #region ExisteConexao
        public bool ExisteConexao(int viIDConexao)
        {
            return Pool.ContainsKey(viIDConexao);
        }
        #endregion

        #region BeginTransaction | Commit | Rollback
        public void BeginTransaction(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                Pool[IDConexao].BeginTransaction();
        }

        public bool InTransaction(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                return Pool[IDConexao].Transaction != null;
            return false;
        }

        public bool IsConnected(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                return Pool[IDConexao].Connection.State == ConnectionState.Open;
            return false;
        }

        public void Commit(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                Pool[IDConexao].Commit(this);
        }

        public void AddNotification(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                Pool[IDConexao].AddNotification();
        }

        public void AddNotificationBackup(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                Pool[IDConexao].AddNotificationBackup();
        }

        public void AddNotificationBackupRestart(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                Pool[IDConexao].AddNotificationBackupRestart();
        }

        public void WaitConnection(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                Pool[IDConexao].Wait();
        }

        public bool GetUpdaterStatus(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                return Pool[IDConexao].GetStatusUpdater();
            return false;
        }

        public bool GetStatusConnection(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                return Pool[IDConexao].GetStatusConnection();
            return false;
        }

        public bool GetBackupStatus(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                return Pool[IDConexao].GetBackupStatus();
            return false;
        }

        public bool GetBackupStatusRestart(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                return Pool[IDConexao].GetBackupStatusRestart();
            return false;
        }

        public void Rollback(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao) && Pool[IDConexao].Transaction.Connection != null)
                Pool[IDConexao].Rollback();
        }
        #endregion

        #region Connect | Disconnect
        public void Connect(int IDConexao = -1)
        {
            if (IDConexao == -1)
            {
                foreach (KeyValuePair<int, Conexao> conn in Pool)
                    conn.Value.Connect(true, true);
            }
            else
            {
                if (Pool.ContainsKey(IDConexao))
                    Pool[IDConexao].Connect(true, true);
            }
        }

        public void Disconnect(int IDConexao = -1)
        {
            if (IDConexao == -1)
                foreach (KeyValuePair<int, Conexao> conn in Pool)
                    conn.Value.Disconnect();
            else
                foreach (KeyValuePair<int, Conexao> conn in Pool)
                    if (conn.Key == IDConexao)
                    {
                        conn.Value.Disconnect();
                        break;
                    }
        }
        #endregion    
    }
}
