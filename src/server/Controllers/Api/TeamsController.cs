using System;
using System.Threading.Tasks;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/teams")]
    public class TeamsController : ControllerBase
    {
        /// <summary>
        /// Create a quiz team
        /// </summary>
        /// <param name="tournamentId">
        /// The ID of the tournament this team is a part of.
        /// </param>
        /// <returns></returns>
        [HttpPost("/api/tournaments/{tournamentId}/teams")]
        public async Task<CreateTeamResponse> Create(string tournamentId, [FromBody] CreateTeamRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<Team> Get(string id)
        {
            return null;
        }

        /// <summary>
        /// Edit a team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task Edit(string id, [FromBody] EditTeamRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a team
        /// </summary>
        /// <param name="id">The team ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
