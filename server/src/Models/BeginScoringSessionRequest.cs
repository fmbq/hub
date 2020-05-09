using System.ComponentModel.DataAnnotations;

namespace FMBQ.Hub.Models
{
    public class BeginScoringSessionRequest
    {
        /// <summary>
        /// The required passcode to gain access to scoring a quiz.
        /// </summary>
        [Required]
        public string Passcode { get; set; }
    }
}
