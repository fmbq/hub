using System;
using System.Threading.Tasks;
using FMBQ.Hub.Database;
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

        public async Task<bool> IsValidUser(string id)
        {
            using (var command = connectionProvider.CreateCommand("SELECT COUNT(*) FROM User WHERE id = @id"))
            {
                command.AddParameter("@id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    return await command.ExecuteScalarAsync<long?>() > 0;
                }
            }
        }

        public async Task<string> ValidateCredentials(string email, string password)
        {
            try
            {
                using (var command = connectionProvider.CreateCommand("SELECT id, password FROM User WHERE email = @email"))
                {
                    command.AddParameter("@email", email);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            string id = reader.GetString(0);
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
