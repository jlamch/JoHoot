using Johoot.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Pages
{
  public class QuizesOverviewBase : ComponentBase
  {
    public IList<Quize> Quizes { get; set; }

    protected override Task OnInitializedAsync()
    {
      //initialize 
      Quizes = new List<Quize>();
      return base.OnInitializedAsync();
    }
  }
}
