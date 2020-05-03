using System;
using System.Threading.Tasks;
using FMBQ.Hub.Database;
using FMBQ.Hub.Models;
using Microsoft.Extensions.Logging;

namespace FMBQ.Hub
{
    public class UserService
    {
        private readonly IConnectionProvider connectionProvider;
        private readonly ILogger logger;

        public UserService(IConnectionProvider connectionProvider, ILogger<UserService> logger)
        {
            this.connectionProvider = connectionProvider;
            this.logger = logger;
        }

        public async Task<long?> ValidateCredentials(string email, string password)
        {
            try
            {
                using (var command = connectionProvider.CreateCommand("SELECT rowid, password FROM users WHERE email = @email"))
                {
                    command.AddParameter("@email", email);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            long? id = reader.GetInt64(0);
                            string hash = reader.GetString(1);

                            return BCrypt.Net.BCrypt.Verify(password, hash) ? id : null;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error checking user credentials.");
            }

            return null;
        }
    }
}
