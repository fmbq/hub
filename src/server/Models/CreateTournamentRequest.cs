using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMBQ.Hub.Models
{
    public class CreateTournamentRequest
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// The full address of the primary venue the tournament is being held.
        /// </summary>
        public string Location { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
