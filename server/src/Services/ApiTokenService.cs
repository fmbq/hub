using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FMBQ.Hub.Database;
using FMBQ.Hub.Models;
using Microsoft.Data.Sqlite;

namespace FMBQ.Hub
{
    public class ApiTokenService : IDisposable
    {
        private readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private readonly IConnectionProvider connectionProvider;

        public ApiTokenService(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        /// <summary>
        /// Get info about all API tokens.
        /// </summary>
        /// <returns>
        /// A collection of API token objects.
        /// </returns>
        public async IAsyncEnumerable<ApiToken> GetAll()
        {
            using (var command = connectionProvider.CreateCommand("SELECT (id, name) FROM ApiToken WHERE deleted IS NULL"))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    yield return new ApiToken
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                    };
                }
            }
        }

        /// <summary>
        /// Creates a new API token.
        /// </summary>
        /// <param name="name">
        /// A human-readable name for the token.
        /// </param>
        /// <returns>
        /// The token ID and the unencrypted token.
        /// </returns>
        public async Task<(string, string)> CreateToken(string name)
        {
            using (var command = connectionProvider.CreateCommand(
                "INSERT INTO ApiToken (id, token, name) VALUES (@id, @token, @name)"
            ))
            {
                string id = Guid.NewGuid().ToString();

                // API tokens must be unique, so try 10 times to randomly
                // generate a new one.
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        // Generate a new token.
                        string token = GenerateToken();

                        // Store just the secure one-way hash of the token.
                        command.AddParameter("@token", BCrypt.Net.BCrypt.HashPassword(token));
                        command.AddParameter("@id", id);
                        command.AddParameter("@name", name);

                        await command.ExecuteNonQueryAsync();

                        // Return the unencrypted token for display.
                        return (id, token);
                    }
                    // Constraint exception, generate new token and try again.
                    catch (SqliteException e) when (e.SqliteErrorCode == 19)
                    {
                        command.Parameters.Clear();
                    }
                }

                throw new ApplicationException("Could not generate a new unique token after 10 tries.");
            }
        }

        /// <summary>
        /// Validates the given API token.
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
                "SELECT COUNT(*) FROM ApiToken WHERE token = @token AND deleted IS NULL"
            ))
            {
                command.AddParameter("@token", token);

                return await command.ExecuteScalarAsync<long?>() > 0;
            }
        }

        /// <summary>
        /// Delete an API token by its ID.
        /// </summary>
        /// <param name="id">
        /// The token ID.
        /// </param>
        /// <returns>
        /// True if the token was deleted.
        /// </returns>
        public async Task<bool> DeleteToken(string id)
        {
            using (var command = connectionProvider.CreateCommand(@"
                UPDATE ApiToken
                SET deleted = datetime('now')
                WHERE id = @id AND deleted IS NULL
            "))
            {
                command.AddParameter("@id", id);

                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public void Dispose()
        {
            rng.Dispose();
        }

        private string GenerateToken()
        {
            byte[] bytes = new byte[128];
            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }
    }
}
