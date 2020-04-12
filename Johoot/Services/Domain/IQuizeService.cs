using Johoot.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Services
{
  public interface IQuizeService
  {
    Task<IList<Quize>> GetAll(bool includeAll = true);
    Task<Quize> GetById(long id);
    Task<Quize> Create(Quize item);
    Task Update(Quize item);
  }
}