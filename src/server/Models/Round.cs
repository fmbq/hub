using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMBQ.Hub.Models
{
    public enum RoundType
    {
        Team,
        Individuals,
    }

    public class Round
    {
        public RoundType Type { get; set; }
        public Tournament.Division Division { get; set; }
        public bool Freeform { get; set; }
    }

    public class TeamRound : Round
    {
        public List<Team> Teams { get; set; }
    }

    public class IndividualsRound : Round
    {
        public List<Person> Quizzers { get; set; }
    }
}
