using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using FMBQ.Hub.Database;
using FMBQ.Hub.Models;
using System.Text.Json;

namespace FMBQ.Hub
{
    public class RoundService
    {
        private readonly IConnectionProvider connectionProvider;

        public RoundService(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public async Task<string> CreateRound(
            string tournamentId,
            RoundType type,
            bool freeform = false
        )
        {
            using (var command = connectionProvider.CreateCommand(@"
                INSERT INTO Round (id, tournamentId, type, freeform)
                VALUES (@id, @tournamentId, @type, @freeform)
            "))
            {
                string id = Guid.NewGuid().ToString();

                command.AddParameter("@id", id);
                command.AddParameter("@tournamentId", tournamentId);
                command.AddParameter("@type", type.ToString().ToLower());
                command.AddParameter("@freeform", freeform);

                await command.ExecuteNonQueryAsync();

                return id;
            }
        }

        public async Task<Round> Get(string id)
        {
            using (var command = connectionProvider.CreateCommand(@"
                SELECT round.id, round.type, json_group_array(quiz.id) AS quizIds
                FROM Round round
                WHERE id = @id
                JOIN Quiz quiz ON quiz.roundId = round.id
            "))
            {
                command.AddParameter("@id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    id = reader.GetString(0);
                    string type = reader.GetString(1);
                    List<string> quizIds = JsonSerializer.Deserialize<List<string>>(reader.GetString(2));

                    if (type == "team")
                    {
                        return new TeamRound
                        {
                            Id = id,
                            QuizIds = quizIds,
                        };
                    }
                    else
                    {
                        return new IndividualsRound
                        {
                            Id = id,
                            QuizIds = quizIds,
                        };
                    }
                }
            }
        }

        public async Task<bool> AssignTeamToQuiz(string roundId, string teamId, string quizId)
        {
            using (var transaction = await connectionProvider.Connection.BeginTransactionAsync())
            {
                // Ensure the given quiz actually belongs to the given round.
                using (var command = connectionProvider.CreateCommand(@"
                    SELECT roundId == @roundId
                    FROM Quiz
                    WHERE id = @quizId
                "))
                {
                    command.Transaction = transaction;
                    command.AddParameter("@roundId", roundId);
                    command.AddParameter("@quizId", quizId);

                    if (await command.ExecuteScalarAsync<long?>() != 1)
                    {
                        throw new ApplicationException($"Can't assign team {teamId} to quiz {quizId} because the quiz does not belong to round {roundId}.");
                    }
                }

                // Ensure the given team belongs to the same tournament as the given round.
                using (var command = connectionProvider.CreateCommand(@"
                    SELECT round.tournamentId == team.tournamentId
                    FROM Round round
                        JOIN Team team ON team.id = @teamId
                    WHERE round.id = @roundId
                "))
                {
                    command.Transaction = transaction;
                    command.AddParameter("@roundId", roundId);
                    command.AddParameter("@teamId", teamId);

                    if (await command.ExecuteScalarAsync<long?>() != 1)
                    {
                        throw new ApplicationException($"Can't assign team {teamId} to quiz {quizId} because the team does not belong to the same tournament.");
                    }
                }

                using (var command = connectionProvider.CreateCommand(@"
                    INSERT INTO TeamRoundAssignment (roundId, teamId, quizId)
                    VALUES (@roundId, @teamId, @quizId)
                    ON CONFLICT (roundId, teamId) DO
                        UPDATE SET quizId = @quizId
                "))
                {
                    command.Transaction = transaction;
                    command.AddParameter("@roundId", roundId);
                    command.AddParameter("@teamId", teamId);
                    command.AddParameter("@quizId", quizId);

                    if (await command.ExecuteNonQueryAsync() > 0)
                    {
                        await transaction.CommitAsync();
                        return true;
                    }

                    return false;
                }
            }
        }

        public async Task<bool> AssignIndividualToQuiz(string roundId, string personId, string quizId)
        {
            using (var command = connectionProvider.CreateCommand(@"
                INSERT INTO IndividualRoundAssignment (roundId, personId, quizId)
                VALUES (@roundId, @personId, @quizId)
                ON CONFLICT (roundId, personId) DO
                    UPDATE SET quizId = @quizId
            "))
            {
                command.AddParameter("@roundId", roundId);
                command.AddParameter("@personId", personId);
                command.AddParameter("@quizId", quizId);

                return await command.ExecuteNonQueryAsync() > 0;
            }
        }
    }
}
