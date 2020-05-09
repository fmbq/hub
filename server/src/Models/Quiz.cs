using System;
using System.Collections.Generic;

namespace FMBQ.Hub.Models
{
    public class Quiz
    {
        public Guid Id { get; set; }

        public string Room { get; set; }

        public List<QuestionResult> Results { get; set; }

        internal string Passcode { get; private set; }

        public class QuestionResult
        {
            public int Number { get; set; }
            public Dictionary<string, int> Scores { get; set; }
        }
    }
}
