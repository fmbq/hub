using System;
using System.Collections.Generic;

namespace FMBQ.Hub.Models
{
    public class CreateTournamentRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// The full address of the primary venue the tournament is being held.
        /// </summary>
        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
