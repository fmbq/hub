using System.Threading.Tasks;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/quiz")]
    public class QuizController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<Quiz> Get(string id)
        {
            return null;
        }

        [HttpPost("{id}/questions")]
        public async Task SubmitQuestionResults(string id, [FromBody] Quiz.QuestionResult results)
        {
        }
    }
}
