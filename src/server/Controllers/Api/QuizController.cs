using System;
using System.Threading.Tasks;
using FMBQ.Hub.Auth;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/quiz")]
    public class QuizController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<Quiz> Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}/passcode")]
        [AuthRequired]
        public async Task<RegenerateQuizPasscodeResponse> RegeneratePasscode(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Submit question results
        /// </summary>
        /// <remarks>
        /// Requires an authorization cookie.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        [HttpPost("{id}/questions")]
        [AuthRequired]
        public async Task SubmitQuestionResults(string id, [FromBody] Quiz.QuestionResult results)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Publish quiz results
        /// </summary>
        /// <remarks>
        /// When published, a quiz's results can be viewed publicly.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/results/published")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task PublishResults(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unpublish quiz results
        /// </summary>
        /// <remarks>
        /// When published, a quiz's results can be viewed publicly.
        /// </remarks>
        /// <param name="id"></param>
        [HttpDelete("{id}/results/published")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task UnpublishResults(string id)
        {
            throw new NotImplementedException();
        }
    }
}
