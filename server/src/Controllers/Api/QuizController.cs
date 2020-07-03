using System;
using System.Threading.Tasks;
using FMBQ.Hub.Auth;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/quiz")]
    [OpenApiTag("quiz")]
    public class QuizController : ControllerBase
    {
        private readonly QuizService quizService;

        public QuizController(QuizService quizService)
        {
            this.quizService = quizService;
        }

        /// <summary>
        /// Create a new quiz.
        /// </summary>
        /// <remarks>
        /// The date and time of the quiz is controlled by the schedule
        /// arrangement of the enclosing tournament.
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<CreateQuizResponse> CreateQuiz([FromBody] CreateQuizRequest request)
        {
            string id = await quizService.Create(request);

            return new CreateQuizResponse
            {
                Id = id,
            };
        }

        /// <summary>
        /// Get quiz
        /// </summary>
        /// <param name="id">
        /// The quiz ID.
        /// </param>
        /// <returns>
        /// Public details about the quiz.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Quiz> GetQuiz(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{quizId}/quizzers/{personId}")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task AddQuizzerToQuiz(string quizId, string personId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{quizId}/quizzers/{personId}")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task RemoveQuizzerFromQuiz(string quizId, string personId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{quizId}/teams/{teamId}")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task AddTeamToQuiz(string quizId, string teamId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{quizId}/teams/{teamId}")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task RemoveTeamFromQuiz(string quizId, string teamId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Regenerate quiz passcode
        /// </summary>
        /// <remarks>
        /// Regenerates the access passcode required to submit results for a
        /// quiz.
        /// </remarks>
        /// <param name="id">
        /// The quiz ID.
        /// </param>
        /// <returns></returns>
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
        /// <param name="id">
        /// The quiz ID.
        /// </param>
        /// <param name="results"></param>
        /// <returns></returns>
        [HttpPost("{id}/questions")]
        public async Task SubmitQuestionResults(string id, [FromBody] Quiz.QuestionResult results)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Begin a scoring session
        /// </summary>
        /// <remarks>
        /// Supply a quiz passcode in order to begin a new scoring session.
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="204">A new session was created tied to a response cookie.</response>
        /// <response code="401">The passcode given is invalid.</response>
        /// <response code="409">An existing session is already active.</response>
        [HttpPost("{id}/scoring-session")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task BeginScoringSession([FromBody] BeginScoringSessionRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// End a scoring session
        /// </summary>
        /// <remarks>
        /// End an existing scoring session identified by a request cookie.
        /// </remarks>
        /// <response code="204">The current session has ended.</response>
        /// <response code="400">The requestor is not the active session.</response>
        [HttpDelete("{id}/scoring-session")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task EndScoringSession()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Publish quiz results
        /// </summary>
        /// <remarks>
        /// When published, a quiz's results can be viewed publicly.
        /// </remarks>
        /// <param name="id">
        /// The quiz ID.
        /// </param>
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
        /// <param name="id">
        /// The quiz ID.
        /// </param>
        [HttpDelete("{id}/results/published")]
        [AuthRequired]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task UnpublishResults(string id)
        {
            throw new NotImplementedException();
        }
    }
}
