using Microsoft.AspNetCore.Components;

namespace Johoot.Pages
{
  public class QuizeDetailBase : ComponentBase
  {
    [Parameter]
    public string QuizeId { get; set; }

  }
}
