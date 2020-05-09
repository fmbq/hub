using System.Data.Common;

namespace FMBQ.Hub.Database
{
    public interface IConnectionProvider
    {
        DbConnection Connection { get; }

        DbCommand CreateCommand(string query)
        {
            return Connection.CreateCommand(query);
        }
    }
}
