using Johoot.Data;

using Johoot.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Infrastructure
{
  public class QuizeRepository : IQuizeRepository
  {
    private readonly JohootContext _joContext;

    public QuizeRepository(JohootContext context)
    {
      _joContext = context;
    }

    public async Task<Quize> Create(Quize item)
    {
      var ret = _joContext.Quizes.Add(item);
      await _joContext.SaveChangesAsync();
      return ret.Entity;
    }

    public async Task<Quize> FindById(long id, bool includeAll)
    {
      if (includeAll)
      {
        return
           await _joContext.Quizes
             .Include(q => q.Questions)
             .ThenInclude(q => q.Answers)
             .FirstOrDefaultAsync(q => q.Id == id);
      }
      else
      {
        return
            await _joContext.Quizes.FindAsync(id);

      }
    }

    public async Task<IList<Quize>> GetAll(bool includeAll)
    {
      if (includeAll)
      {
        return
          await _joContext
          .Quizes
          .Include(q => q.Questions)
          .ThenInclude(q => q.Answers)
          .ToListAsync();
      }
      else
      {
        return
          await _joContext
          .Quizes
          .ToListAsync();
      }
    }

    public async Task<Quize> Update(Quize item, long id)
    {
      if (item is null)
      {
        return null;
      }

      var exist = await FindById(id, false);
      if (exist != null)
      {
        _joContext.Entry(exist).CurrentValues.SetValues(item);
        _joContext.SaveChanges();
      }

      return exist;
    }
  }
}
