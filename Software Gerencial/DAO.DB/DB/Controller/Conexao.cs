using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace AutoDAO.DB.Controller
{
    public class Conexao
    {
        #region Fields
        public bool UpdaterStats { get; set; }
        public bool BackupStats { get; set; }
        public bool BackupRestartStats { get; set; }
        public int IDConexao { get; set; }
        public String ConnectionString { get; set; }
        public IDbTransaction Transaction { get; set; }
        //public IDbConnection Connection { get; set; }        
        public NpgsqlConnection Connection { get; set; }

        //Devart.Data.PostgreSql.PgSqlConnection

        #endregion

        #region Constructor
        public Conexao(int IDConexao, string ConnStr)
        {
            this.IDConexao = IDConexao;
            this.ConnectionString = ConnStr;
            // var Connection = new NpgsqlConnection("Connection String");
            // this.Connection = ConnectionFactory.CreateConnection(this.ConnectionString);
            this.Connection = new NpgsqlConnection(ConnectionString);
        }

        public Conexao(DataRow drConexao)
           // : this(Convert.ToInt32(drConexao["ID_CONEXAO"]), ConnectionFactory.CreateConnectionString(drConexao))
           : this(Convert.ToInt32(drConexao["ID_CONEXAO"]), ConnectionFactory.CreateConnectionString(drConexao))
        {
        }
        #endregion

        #region BeginTransaction | Commit | Rollback
        public void BeginTransaction()
        {
            if (Connection.State != ConnectionState.Open)
            {
                this.Connect(false, true);
            }
            Transaction = Connection.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Commit(Controlador controlador)
        {
            try
            {
                if (Transaction == null)
                    return;

                Transaction.Commit();
                Transaction = null;
            }
            finally
            {
                this.Disconnect();
            }
        }

        public void Rollback()
        {
            try
            {
                if (Transaction != null)
                    Transaction.Rollback();
                Transaction = null;
            }
            finally
            {
                this.Disconnect();
            }
        }
        #endregion

        public void Wait()
        {
            if (Connection.State != ConnectionState.Open)
            {
                this.Connect(false, false);
            }
            try
            {
                Connection.Wait(); //
            }
            catch
            {
                StreamWriter writer = new StreamWriter(@"Log.txt", true);
                using (writer)
                {
                    writer.WriteLine("Sync Sistemas - Erro de Conexão com o Banco de Dados");
                }
                writer.Close();
            }
        }

        public bool GetStatusUpdater()
        {
            return UpdaterStats;
        }

        public bool GetStatusConnection()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                {
                    this.Connect(false, false);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool GetBackupStatus()
        {
            return BackupStats;
        }

        public bool GetBackupStatusRestart()
        {
            return BackupRestartStats;
        }

        public void AddNotification()
        {
            if (Connection.State != ConnectionState.Open)
            {
                this.Connect(true, true);
            }

            Connection.Notification += (o, e) =>
            {
                if (e.AdditionalInformation == "t")
                {
                    UpdaterStats = true;
                }
                else
                {
                    UpdaterStats = false;
                }
            };
        }

        public void AddNotificationBackup()
        {
            if (Connection.State != ConnectionState.Open)
            {
                this.Connect(true, true);
            }

            Connection.Notification += (o, e) =>
            {
                if (e.AdditionalInformation == "t")
                {
                    BackupStats = true;
                }
                else
                {
                    BackupStats = false;
                }
            };
        }

        public void AddNotificationBackupRestart()
        {
            if (Connection.State != ConnectionState.Open)
            {
                this.Connect(true, true);
            }

            Connection.Notification += (o, e) =>
            {
                if (e.AdditionalInformation == "t")
                {
                    BackupRestartStats = true;
                }
                else
                {
                    BackupRestartStats = false;
                }
            };
        }

        #region Connect | Disconnect
        public void Connect(bool IsClose, bool IsLog)
        {
            if (Connection.State == System.Data.ConnectionState.Open)
                return;

            try
            {
                Connection.Open();
            }
            catch
            {
                if (IsLog)
                {
                    StreamWriter writer = new StreamWriter(@"Log.txt", true);
                    using (writer)
                    {
                        writer.WriteLine("Sync Sistemas - Falha na conexão com o banco de dados, id da conexão: " + IDConexao);
                    }
                    writer.Close();
                }

                if (IsClose == true)
                    Environment.Exit(Environment.ExitCode);
            }
        }

        public void Disconnect()
        {
            try
            {
                if (Transaction != null)
                    Transaction.Rollback();
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        #endregion

        #region GetCommand
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public IDbCommand GetCommand(string strSQL, IDbConnection objConnection)
        {
            return new NpgsqlCommand(strSQL, (NpgsqlConnection)Connection);
        }
        #endregion

        public IDataReader GetDataReader(IDbCommand objCommand)
        {
            return (objCommand as NpgsqlCommand).ExecuteReader();
        }

        #region GetDataAdapter
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public IDbDataAdapter GetDataAdapter(string strSQL)
        {
            return new NpgsqlDataAdapter(strSQL, ConnectionString);
        }
        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private void AtualizaParametros(SQLQuery oSQL, IDbCommand objCommand)
        {
            foreach (KeyValuePair<string, object> param in oSQL.ParamByName)
            {
                /***************
                * Parâmetro IN
                ***************/
                if (param.Value != null &&
                    param.Value != DBNull.Value &&
                    (((System.Type)param.Value.GetType()) == typeof(int[]) ||
                    ((System.Type)param.Value.GetType()) == typeof(string[]) ||
                    ((System.Type)param.Value.GetType()) == typeof(double[]) ||
                    ((System.Type)param.Value.GetType()) == typeof(float[]) ||
                    ((System.Type)param.Value.GetType()) == typeof(char[])))
                {
                    object[] paramIN = (object[])param.Value;
                    string[] paramNames = paramIN.Select(
                        (s, i) => String.Format("@{0}{1}", param.Key, i)
                    ).ToArray();

                    string vsIN = string.Join(",", paramNames);

                    for (int i = 0; i < paramNames.Length; i++)
                    {
                        IDbDataParameter parametro = objCommand.CreateParameter();
                        parametro.ParameterName = paramNames[i];
                        parametro.Value = paramIN[i];
                        objCommand.Parameters.Add(parametro);
                    }
                    objCommand.CommandText = objCommand.CommandText.Replace("@" + param.Key, vsIN);
                }
                else
                {
                    IDbDataParameter parametro = objCommand.CreateParameter();
                    parametro.ParameterName = param.Key;
                    parametro.Value = param.Value;
                    objCommand.Parameters.Add(parametro);
                }
            }
        }


    }
}
