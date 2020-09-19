using Johoot.QuestionCrm.ViewModels;
using Johoot.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Johoot.QuestionCrm.Pages
{
  public class QuestionDetailBase : ComponentBase
  {
    [Inject]
    public IQuestionService Service { get; set; }

    [Parameter]
    public long QuestionId { get; set; }
    [Parameter]
    public long QuizeId { get; set; }
    public QuestionViewModel Question { get; set; } = new QuestionViewModel();

    protected override async Task OnInitializedAsync()
    {
      Question = await Service.GetById(Convert.ToInt64(QuestionId));
    }
  }
}
