using System.ComponentModel.DataAnnotations;

namespace FMBQ.Hub.Models
{
    /// <summary>
    /// Create a new quiz within a tournament.
    /// </summary>
    public class CreateQuizRequest
    {
        /// <summary>
        /// ID of the tournament this quiz is associated with.
        ///
        /// Quizzes are always associated with a tournament, which cannot be
        /// changed after creation.
        /// </summary>
        [Required]
        public string TournamentId { get; set; }

        /// <summary>
        /// The type of quiz this is.
        /// </summary>
        [Required]
        public QuizType Type { get; set; }

        public string Room { get; set; }
    }
}
