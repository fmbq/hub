using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FMBQ.Hub.Database;
using FMBQ.Hub.Models;
using Microsoft.Data.Sqlite;

namespace FMBQ.Hub
{
    public class QuizService
    {
        private const int passcodeLength = 8;
        private readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        private readonly Random rng = new Random();
        private readonly IConnectionProvider connectionProvider;

        public QuizService(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public async Task<Quiz> Get(string id)
        {
            using (var command = connectionProvider.CreateCommand("SELECT id FROM Quiz WHERE id = @id"))
            {
                command.AddParameter("@id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    return new Quiz
                    {
                        Id = new Guid(reader.GetString(0)),
                    };
                }
            }
        }

        public async Task<bool> AddQuizzerToQuiz(string quizId, string personId)
        {
            using (var transaction = await connectionProvider.Connection.BeginTransactionAsync())
            {
                string roundId = await GetRoundIdForQuiz(quizId, transaction);

                using (var command = connectionProvider.CreateCommand(@"
                    SELECT quizId FROM IndividualRoundAssignment
                    WHERE roundId = @roundId
                    AND personId = @personId
                "))
                {
                    command.Transaction = transaction;
                    command.AddParameter("@roundId", roundId);
                    command.AddParameter("@personId", personId);

                    await command.ExecuteNonQueryAsync();
                }

                using (var command = connectionProvider.CreateCommand(@"
                    INSERT INTO IndividualRoundAssignment (roundId, personId, quizId)
                    VALUES (@roundId, @personId, @quizId)
                "))
                {
                    command.Transaction = transaction;
                    command.AddParameter("@roundId", roundId);
                    command.AddParameter("@personId", personId);
                    command.AddParameter("@quizId", quizId);

                    await command.ExecuteNonQueryAsync();
                }

                try
                {
                    await transaction.CommitAsync();
                    return true;
                }
                catch (SqliteException e) when (e.SqliteErrorCode == 19)
                {
                    throw new ApplicationException("Quizzer already assigned to a quiz this round.");
                }
            }
        }

        public async Task<bool> RemoveQuizzerFromQuiz(string quizId, string personId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddTeamToQuiz(string quizId, string teamId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveTeamFromQuiz(string quizId, string teamId)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GetRoundIdForQuiz(string id, DbTransaction transaction = null)
        {
            using (var command = connectionProvider.CreateCommand("SELECT roundId FROM Quiz WHERE id = @id"))
            {
                command.Transaction = transaction;
                command.AddParameter("@id", id);
                return await command.ExecuteScalarAsync<string>();
            }
        }

        /// <summary>
        /// Regenerate the passcode for a quiz.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RegeneratePasscode(string id)
        {
            using (var command = connectionProvider.CreateCommand(@"
                UPDATE Quiz
                SET passcode = @passcode
                WHERE id = @id
            "))
            {
                command.AddParameter("@id", id);
                command.AddParameter("@passcode", GeneratePasscode());

                await command.ExecuteNonQueryAsync();
            }
        }

        private string GeneratePasscode()
        {
            var stringChars = new StringBuilder(passcodeLength);

            foreach (int i in Enumerable.Range(0, passcodeLength))
            {
                stringChars.Append(chars[rng.Next(chars.Length)]);
            }

            return stringChars.ToString();
        }
    }
}
