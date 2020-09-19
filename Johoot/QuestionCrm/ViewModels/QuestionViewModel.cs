using Johoot.Data;
using System.ComponentModel.DataAnnotations;

namespace Johoot.QuestionCrm.ViewModels
{
  public class QuestionViewModel
  {
    public QuestionViewModel() : base()
    {
    }

    public long Id { get; set; }

    public Quize Quize { get; set; }
    public long QuizeId { get; set; }

    public int TimeLimitSeconds { get; set; } = 30;
    [Required]
    [MinLength(1)]
    public string Text { get; set; }
    public int Points { get; set; } = 100;
    //public List<Answer> Answers { get; set; }

    public bool HasCorrectAnswer { get; set; }
    public bool IsOpenQuestion { get; set; }

    //public string ImageUri { get; set; }
  }
}