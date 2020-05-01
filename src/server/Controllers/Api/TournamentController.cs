using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FMBQ.Hub.Auth;
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
        /// <param name="seasonId">The season ID the tournament belongs to</param>
        [HttpPost("/api/seasons/{seasonId}/tournaments")]
        public async Task Create(string seasonId, [FromBody] CreateTournamentRequest request) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List all tournaments
        /// </summary>
        [HttpGet]
        [AuthRequired]
        public async Task<List<Tournament>> List()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a tournament
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpGet("{id}")]
        public async Task<Tournament> Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit a tournament
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpPatch("{id}")]
        [AuthRequired]
        public async Task Edit(string id, [FromBody] EditTournamentRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get tournament quizzers
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpGet("{id}/quizzers")]
        public async Task<List<Person>> GetQuizzers(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get tournament rounds
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpGet("{id}/rounds")]
        public async Task<List<Round>> GetRounds(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set tournament rounds
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpPut("{id}/rounds")]
        [AuthRequired]
        public async Task SetRounds(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get tournament teams
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpGet("{id}/teams")]
        public async Task<List<Team>> GetTeams(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a tournament
        /// </summary>
        /// <param name="id">The tournament ID</param>
        [HttpDelete("{id}")]
        [AuthRequired]
        public async Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
