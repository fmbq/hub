using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace FMBQ.Hub.Database
{
    public class SqliteConnectionProvider : IConnectionProvider, IDisposable
    {
        private SqliteConnection connection;

        public DbConnection Connection => connection;

        public SqliteConnectionProvider()
        {
            connection = new SqliteConnection(new SqliteConnectionStringBuilder
            {
                DataSource = "data.db"
            }.ToString());

            connection.Open();
        }

        public void Dispose()
        {
            connection?.Dispose();
        }
    }
}
