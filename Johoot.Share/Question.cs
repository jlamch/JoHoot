using System.Collections.Generic;

namespace Johoot.Data
{
    public class Question
    {
        public int TimeLimitSeconds { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
        public List<Answer> Answers { get; set; }

        public bool HasCorrectAnswer { get; set; }
        public bool IsOpenQuestion { get; set; }

        public string ImageUri { get; set; }
        public long Id { get; set; }
    }
}