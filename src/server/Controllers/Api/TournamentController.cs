using System.Collections.Generic;
using System.Threading.Tasks;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/tournaments")]
    public class TournamentController : ControllerBase
    {
        /// <summary>
        /// Create a tournament
        /// </summary>
        /// <remarks>
        /// Creates a new tournament.
        /// </remarks>
        [HttpPost]
        public async Task Create([FromBody] CreateTournamentRequest request) {

        }

        /// <summary>
        /// List all tournaments
        /// </summary>
        [HttpGet]
        public async Task<List<Tournament>> List()
        {
            return null;
        }

        /// <summary>
        /// Get a tournament
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpGet("{id}")]
        public async Task<Tournament> Get(string id)
        {
            return null;
        }

        /// <summary>
        /// Get tournament quizzers
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpGet("{id}/quizzers")]
        public async Task<List<Person>> GetQuizzers(string id)
        {
            return null;
        }

        /// <summary>
        /// Get tournament teams
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpGet("{id}/teams")]
        public async Task<List<Team>> GetTeams(string id)
        {
            return null;
        }

        /// <summary>
        /// Delete a tournament
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
        }
    }
}
