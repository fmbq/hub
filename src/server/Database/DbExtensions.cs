using System.Data;
using System.Data.Common;

namespace FMBQ.Hub.Database
{
    /// <summary>
    /// Extensions to the base ADO.NET interface which is pretty bland.
    /// </summary>
    public static class DbExtensions
    {
        public static void AddParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
    }
}
