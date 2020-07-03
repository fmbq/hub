using System;
using System.Threading.Tasks;
using FMBQ.Hub.Database;
using FMBQ.Hub.Models;

namespace FMBQ.Hub
{
    public class TournamentService
    {
        private readonly IConnectionProvider connectionProvider;

        public TournamentService(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public async Task<string> CreateTournament(CreateTournamentRequest request)
        {
            using (var command = connectionProvider.CreateCommand(@"
                INSERT INTO Tournament (
                    id,
                    season,
                    title,
                    description,
                    location,
                    startDate,
                    endDate
                )
                VALUES (
                    @id,
                    @season,
                    @title,
                    @description,
                    @location,
                    @startDate,
                    @endDate
                )
            "))
            {
                string id = Guid.NewGuid().ToString();

                command.AddParameter("@id", id);
                command.AddParameter("@season", request.SeasonId);
                command.AddParameter("@title", request.Title);
                command.AddParameter("@description", request.Description);
                command.AddParameter("@location", request.Location);
                command.AddParameter("@startDate", request.StartDate);
                command.AddParameter("@endDate", request.EndDate);

                await command.ExecuteNonQueryAsync();

                return id;
            }
        }

        public async Task<Tournament> Get(string id)
        {
            using (var command = connectionProvider.CreateCommand(@"
                SELECT id, title, description, location FROM Tournament
                WHERE id = @id
            "))
            {
                command.AddParameter("@id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Tournament
                        {
                            Id = reader.GetGuid(0),
                            Title = reader.GetStringOrNull(1),
                            Description = reader.GetStringOrNull(2),
                            Location = reader.GetStringOrNull(3),
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
