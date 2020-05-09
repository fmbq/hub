using System;
using System.Data.Common;
using System.IO;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace FMBQ.Hub.Database
{
    public class SqliteConnectionProvider : IConnectionProvider, IDisposable
    {
        private SqliteConnection connection;

        public DbConnection Connection => connection;

        public SqliteConnectionProvider(IConfiguration configuration)
        {
            string path = configuration["SqlitePath"];

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            connection = new SqliteConnection(new SqliteConnectionStringBuilder
            {
                DataSource = path
            }.ToString());

            connection.Open();
        }

        public void Dispose()
        {
            connection?.Dispose();
        }
    }
}
