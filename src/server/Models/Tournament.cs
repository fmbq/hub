using System;
using System.Collections.Generic;

namespace FMBQ.Hub.Models
{
    public class Tournament
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// The full address of the primary venue the tournament is being held.
        /// </summary>
        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        /// <summary>
        /// Map of divisions by their IDs.
        /// </summary>
        public Dictionary<string, Division> Divisions { get; set; }

        public class Division
        {
            public bool Custom { get; set; }
        }
    }
}
