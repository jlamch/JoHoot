using Johoot.Data;
using Johoot.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Johoot.Pages
{
  public class QuizeEditBase : ComponentBase
  {
    [Inject]
    public IQuizeService QuizeService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }


    [Parameter]
    public string QuizeId { get; set; }

    public Quize Quize { get; set; } = new Quize();

    protected bool Saved;
    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;


    protected override async Task OnInitializedAsync()
    {

      int.TryParse(QuizeId, out var quizeId);

      if (quizeId == 0) //new Quize is being created
      {
        //add some defaults
        Quize = new Quize { Id = 0 };
      }
      else
      {
        Quize = await QuizeService.GetById(quizeId);
      }
    }

    protected async Task HandleValidSubmit()
    {
      Saved = false;

      if (Quize.Id == 0) //new
      {
        var addedQuize = await QuizeService.Create(Quize);
        if (addedQuize != null)
        {
          //StatusClass = "alert-success";
          //Message = "New Quize added successfully.";
          Saved = true;
          Quize = addedQuize;
        }
        else
        {
          //StatusClass = "alert-danger";
          //Message = "Something went wrong adding the new Quize. Please try again.";
          Saved = false;
        }
      }
      else
      {
        await QuizeService.Update(Quize);
        //StatusClass = "alert-success";
        //Message = "Quize updated successfully.";
        Saved = true;
      }
    }
    //protected async Task DeleteQuize()
    //{
    //  await QuizeService.DeleteEmployee(Quize.Id);

    //  StatusClass = "alert-success";
    //  Message = "Deleted successfully";

    //  Saved = true;
    //}


    protected void NavigateToOverview()
    {
      NavigationManager.NavigateTo($"/quizedetail/{Quize.Id}");
    }
  }
}
