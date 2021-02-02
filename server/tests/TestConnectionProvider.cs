using System;
using System.Data.Common;
using System.Threading.Tasks;
using FMBQ.Hub.Database;
using Microsoft.Data.Sqlite;

namespace FMBQ.Hub.Tests
{
    public class TestConnectionProvider : IConnectionProvider, IDisposable
    {
        private readonly DbConnection connection;

        public TestConnectionProvider()
        {
            connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            DbInstrumenter.InstrumentIfNeeded(connection).Wait();
        }

        DbConnection IConnectionProvider.Connection => connection;

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
