using System.Threading.Tasks;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FMBQ.Hub.Tests
{
    public class QuizTest : IntegrationTest
    {
        public QuizTest(WebApplicationFactory<Application> factory) : base(factory)
        {
        }

        [Fact]
        public async Task HappyPath()
        {
            // Create a tournament
            var (_, createTournamentResponse) = await Post<CreateTournamentResponse>("/api/tournaments", new CreateTournamentRequest
            {
                SeasonId = 2020,
                Title = "My First Tourney",
            });

            Assert.NotNull(createTournamentResponse.TournamentId);

            // Create a quiz
            var (_, createQuizResponse) = await Post<CreateQuizResponse>("/api/quiz", new CreateQuizRequest
            {
                TournamentId = createTournamentResponse.TournamentId,
                Type = QuizType.Individuals,
                Room = "A",
            });

            Assert.NotNull(createQuizResponse.Id);
        }
    }
}
