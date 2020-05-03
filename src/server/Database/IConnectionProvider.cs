using System.Data.Common;

namespace FMBQ.Hub.Database
{
    public interface IConnectionProvider
    {
        DbConnection Connection { get; }

        DbCommand CreateCommand(string query)
        {
            var command = Connection.CreateCommand();
            command.CommandText = query;

            return command;
        }
    }
}
