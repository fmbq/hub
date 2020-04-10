using System;
using System.Collections.Generic;

namespace FMBQ.Hub.Models
{
    public class CreateTournamentRequest
    {
        /// <summary>
        /// The ID of the season this tournament should belong to.
        /// </summary>
        public string SeasonId { get; set; }

        /// <summary>
        /// The full address of the primary venue the tournament is being held.
        /// </summary>
        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
