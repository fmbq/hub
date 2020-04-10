using System.Data.Common;

namespace FMBQ.Hub.Database
{
    public interface IConnectionProvider
    {
        DbConnection Connection { get; }
    }
}
