using System.Data.Common;
using System.Threading.Tasks;

namespace FMBQ.Hub.Database
{
    public class DbInstrumenter
    {
        public static async Task InstrumentIfNeeded(DbConnection connection)
        {
            if (await GetUserVersion(connection) < 1)
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = Resources.GetString("schema.sql");
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private static async Task<long> GetUserVersion(DbConnection connection)
        {
            using (var command = connection.CreateCommand("PRAGMA user_version"))
            {
                return await command.ExecuteScalarAsync<long>();
            }
        }
    }
}
