using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace FMBQ.Hub.Database
{
    /// <summary>
    /// Extensions to the base ADO.NET interface which is pretty bland.
    /// </summary>
    public static class DbExtensions
    {
        public static DbCommand CreateCommand(this DbConnection connection, string query)
        {
            var command = connection.CreateCommand();
            command.CommandText = query;

            return command;
        }

        public static void AddParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }

        public static async Task<T> ExecuteScalarAsync<T>(this DbCommand command)
        {
            object result = await command.ExecuteScalarAsync();

            if (result == null || result == DBNull.Value)
            {
                return default(T);
            }

            return (T)result;
        }

        public static string GetStringOrNull(this DbDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }
    }
}
