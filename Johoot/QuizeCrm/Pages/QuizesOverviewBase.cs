using Johoot.Data;
using Johoot.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.QuizeCrm.Pages
{
  public class QuizesOverviewBase : ComponentBase
  {
    [Inject]
    public IQuizeService QuizeService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public IList<Quize> Quizes { get; set; }

    protected override async Task OnInitializedAsync()
    {
      Quizes = await QuizeService.GetAll();
    }

    public void CreateQuize()
    {
      NavigationManager.NavigateTo($"/quizeedit/0");
    }
  }
}
