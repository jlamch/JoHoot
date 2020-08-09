using Johoot.Data;
using Johoot.QuizeCrm.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Services
{
  public interface IQuizeService
  {
    Task<IList<Quize>> GetAll(bool includeAll = true);
    Task<Quize> GetById(long id);
    Task<QuizeViewModel> GetVmById(long id);
    Task<QuizeViewModel> Create(QuizeViewModel item);
    Task Update(Quize item);
  }
}