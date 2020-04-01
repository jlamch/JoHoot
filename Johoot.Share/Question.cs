using System.Collections.Generic;

namespace Johoot.Data
{
    public class Question
    {
        public int TimeLimitSeconds { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
        public List<Answer> Answers { get; set; }
        public QuestionOptions Options { get; set; }
        public string ImageUri { get; set; }
        public long Id { get; set; }
    }

    public class QuestionOptions
    {
        public bool HasCorrectAnswer { get; set; }
        public bool Open { get; set; }
    }

    public class Answer
    {
        public string Text { get; set; }
        public bool? IsCorrect { get; set; }
        public long Id { get; set; }
    }

    public class Quize
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
    }
}