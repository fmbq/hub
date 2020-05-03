using System;
using System.Collections.Generic;

namespace FMBQ.Hub.Models
{
    public class Team
    {
        public Guid Id { get; set; }

        public Guid TournamentId { get; set; }

        /// <summary>
        /// A user-facing name for the team.
        /// </summary>
        public string Name { get; set; }

        public string DivisionId { get; set; }

        /// <summary>
        /// A list of quizzers who are members of the team.
        /// </summary>
        /// <value></value>
        public List<Person> Quizzers { get; set; }
    }
}
