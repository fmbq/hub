using System;
using System.Collections.Generic;

namespace FMBQ.Hub.Models
{
    public class Quiz
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the room this quiz is scheduled to take place in.
        /// </summary>
        public string Room { get; set; }

        public List<QuestionResult> Results { get; set; }

        /// <summary>
        /// The unique passcode for this quiz for recording results. Can only
        /// be seen by admins.
        /// </summary>
        internal string Passcode { get; private set; }

        public class QuestionResult
        {
            public int Number { get; set; }
            public Dictionary<string, int> Scores { get; set; }
        }
    }
}
