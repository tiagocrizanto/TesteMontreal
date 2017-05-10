using System;
using System.Data;
using System.Data.SqlClient;

namespace Montreal.NomeSistema.Core.Domain.Helpers.Database
{
    public class SqlConnectionHelper : IDbConnection
    {
        public SqlConnection conn;

        public SqlConnectionHelper(string connectionString)
        {
            if (conn == null)
            {
                conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco", ex);
                }
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return conn;
            }
        }

        public string ConnectionString
        {
            get
            {
                return ((IDbConnection)conn).ConnectionString;
            }

            set
            {
                ((IDbConnection)conn).ConnectionString = value;
            }
        }

        public int ConnectionTimeout
        {
            get
            {
                return ((IDbConnection)conn).ConnectionTimeout;
            }
        }

        public string Database
        {
            get
            {
                return ((IDbConnection)conn).Database;
            }
        }

        public ConnectionState State
        {
            get
            {
                return ((IDbConnection)conn).State;
            }
        }

        public IDbTransaction BeginTransaction()
        {
            return ((IDbConnection)conn).BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return ((IDbConnection)conn).BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            ((IDbConnection)conn).ChangeDatabase(databaseName);
        }

        public void Close()
        {
            ((IDbConnection)conn).Close();
        }

        public IDbCommand CreateCommand()
        {
            return ((IDbConnection)conn).CreateCommand();
        }

        public void Dispose()
        {
            conn.Dispose();
        }

        public void Open()
        {
            ((IDbConnection)conn).Open();
        }
    }
}