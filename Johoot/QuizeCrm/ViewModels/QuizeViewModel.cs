using Johoot.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Johoot.QuizeCrm.ViewModels
{
  public class QuizeViewModel : Quize
  {
    public QuizeViewModel() : base()
    {
    }

    public override long Id { get; set; }
    [Required]
    [MinLength(1)]
    public override string Name { get; set; }
    [Required]
    [MinLength(1)]
    public override string Description { get; set; }
    public override List<Question> Questions { get; set; }
  }
}