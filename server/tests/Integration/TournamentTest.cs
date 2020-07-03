using System.Threading.Tasks;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FMBQ.Hub.Tests
{
    public class TournamentTest : IntegrationTest
    {
        public TournamentTest(WebApplicationFactory<Application> factory) : base(factory)
        {
        }

        [Fact]
        public async Task CreateTournament()
        {
            var (response, body) = await Post<CreateTournamentResponse>("/api/tournaments", new CreateTournamentRequest
            {
                SeasonId = 2020,
                Title = "My First Tourney",
            });

            Assert.NotNull(body.TournamentId);

            var (_, tournament) = await Get<Tournament>($"/api/tournaments/{body.TournamentId}");

            Assert.Equal(tournament.Id.ToString(), body.TournamentId);
            Assert.Equal(tournament.Title, "My First Tourney");
        }
    }
}
