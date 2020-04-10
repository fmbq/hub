using System;
using System.Collections.Generic;

namespace FMBQ.Hub.Models
{
    public class Team
    {
        public Guid Id { get; set; }

        public Guid TournamentId { get; set; }

        public string DivisionId { get; set; }

        public List<Person> Quizzers { get; set; }
    }
}
