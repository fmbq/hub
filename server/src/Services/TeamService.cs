using System.Data.Common;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using FMBQ.Hub.Database;
using FMBQ.Hub.Models;

namespace FMBQ.Hub
{
    public class TeamService
    {
        private readonly IConnectionProvider connectionProvider;

        public TeamService(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public async Task<string> CreateTeam(string tournamentId, CreateTeamRequest request)
        {
            using var transaction = await connectionProvider.Connection.BeginTransactionAsync();

            string id = Guid.NewGuid().ToString();

            using (var command = connectionProvider.CreateCommand(@"
                INSERT INTO Team (
                    id,
                    tournamentId,
                    name
                )
                VALUES (
                    @id,
                    @tournamentId,
                    @name
                )
            "))
            {

                command.Transaction = transaction;
                command.AddParameter("@id", id);
                command.AddParameter("@tournamentId", tournamentId);
                command.AddParameter("@name", request.Name);

                await command.ExecuteNonQueryAsync();
            }

            if (request.Quizzers != null)
            {
                foreach (string personId in request.Quizzers)
                {
                    await AddPersonToTeam(id, personId, transaction);
                }
            }

            await transaction.CommitAsync();

            return id;
        }

        public async Task<bool> AddPersonToTeam(string teamId, string personId)
        {
            return await AddPersonToTeam(teamId, personId, null);
        }

        private async Task<bool> AddPersonToTeam(string teamId, string personId, DbTransaction transaction)
        {
            // TODO: Limit hoe many teams someone is on for a tournament?

            using (var command = connectionProvider.CreateCommand(@"
                INSERT INTO TeamAssignment (teamId, personId)
                VALUES (@teamId, @personId)
                ON CONFLICT (teamId, personId) DO NOTHING
            "))
            {
                command.Transaction = transaction;
                command.AddParameter("@teamId", teamId);
                command.AddParameter("@personId", personId);

                return await command.ExecuteNonQueryAsync() > 0;
            }
        }
    }
}
