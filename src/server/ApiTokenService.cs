using System.Threading.Tasks;
using FMBQ.Hub.Database;
using FMBQ.Hub.Models;

namespace FMBQ.Hub
{
    public class ApiTokenService
    {
        private readonly IConnectionProvider connectionProvider;

        public ApiTokenService(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        /// <summary>
        /// Validate the given API token.
        /// </summary>
        /// <param name="token">
        /// The API token to validate.
        /// </param>
        /// <returns>
        /// True if the given token is valid. False is returned if the token is
        /// not recognized or expired.
        /// </returns>
        public async Task<bool> Validate(string token)
        {
            using (var command = connectionProvider.CreateCommand(
                "SELECT COUNT(*) FROM apiTokens WHERE token = @token AND expired IS NULL"
            ))
            {
                command.AddParameter("@token", token);

                return (long)await command.ExecuteScalarAsync() > 0;
            }
        }
    }
}
