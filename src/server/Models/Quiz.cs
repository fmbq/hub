using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMBQ.Hub.Models
{
    public class Quiz
    {
        private const int passcodeLength = 8;
        internal static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public Guid Id { get; set; }

        public string Room { get; set; }

        public List<QuestionResult> Results { get; set; }

        internal string Passcode { get; private set; } = GeneratePasscode();

        public void RegeneratePasscode()
        {
            Passcode = GeneratePasscode();
        }

        private static string GeneratePasscode()
        {
            var stringChars = new StringBuilder(passcodeLength);
            var random = new Random();

            foreach (int i in Enumerable.Range(0, passcodeLength))
            {
                stringChars.Append(chars[random.Next(chars.Length)]);
            }

            return stringChars.ToString();
        }

        public class QuestionResult
        {
            public int Number { get; set; }
            public Dictionary<string, int> Scores { get; set; }
        }
    }
}
