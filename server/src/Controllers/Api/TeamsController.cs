using System;
using System.Threading.Tasks;
using FMBQ.Hub.Auth;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/teams")]
    [OpenApiTag("teams")]
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
        [AuthRequired]
        public async Task<CreateTeamResponse> CreateTeam(string tournamentId, [FromBody] CreateTeamRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a quiz team
        /// </summary>
        /// <remarks>
        /// Get information about a quiz team by its ID.
        /// </remarks>
        /// <param name="id">
        /// The team unique ID.
        /// </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Team> GetTeam(string id)
        {
            return null;
        }

        /// <summary>
        /// Edit a team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task UpdateTeam(string id, [FromBody] EditTeamRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a team
        /// </summary>
        /// <param name="id">The team ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteTeam(string id)
        {
            throw new NotImplementedException();
        }
    }
}
