using Johoot.Data;
using Johoot.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Johoot.QuizeCrm.Pages
{
  public class QuizeDetailBase : ComponentBase
  {
    [Inject]
    public IQuizeService QuizeService { get; set; }

    [Parameter]
    public string QuizeId { get; set; }

    public Quize Quize { get; set; } = new Quize();

    protected override async Task OnInitializedAsync()
    {
      Quize = await QuizeService.GetById(Convert.ToInt64(QuizeId));
    }
  }
}
