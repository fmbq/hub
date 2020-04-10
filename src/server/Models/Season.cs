using System.Collections.Generic;

namespace FMBQ.Hub.Models
{
    public class Season
    {
        public int StartingYear { get; set; }
        public int EndingYear { get; set; }
        public List<Tournament> Tournaments { get; set; }
    }
}
