using System;
using System.Threading.Tasks;
using FMBQ.Hub.Auth;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/rounds")]
    [OpenApiTag("rounds")]
    public class RoundController : ControllerBase
    {
        [HttpPut("{roundId}/teams/{teamId}/quiz")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task SetQuizForTeamInRound(string roundId, string teamId, [FromBody] string quizId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{roundId}/teams/{teamId}/quiz")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task RemoveQuizForTeamInRound(string roundId, string teamId)
        {
            throw new NotImplementedException();
        }
    }
}
