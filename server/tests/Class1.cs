using System;
using System.Threading.Tasks;
using FMBQ.Hub.Database;
using Microsoft.Data.Sqlite;
using Xunit;

namespace FMBQ.Hub.Tests
{
    public class Class1
    {
        [Fact]
        public async Task Instrument()
        {
            using (var connection = new SqliteConnection("Data Source=:memory:"))
            {
                connection.Open();

                await DbInstrumenter.InstrumentIfNeeded(connection);
            }
        }
    }
}
