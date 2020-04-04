using Johoot.Data;
using Johoot.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Infrastructure
{
  public class QuizeRepository : IQuizeRepository
  {
    private readonly JohootContext _context;

    public QuizeRepository(JohootContext context)
    {
      _context = context;
    }

    public async Task<Quize> Create(Quize item)
    {
      var ret = _context.Quizes.Add(item);
      await _context.SaveChangesAsync();
      return ret.Entity;
    }

    public async Task<Quize> FindById(long id)
    {
      var ret = await _context.Quizes.FindAsync(id);
      return ret;
    }

    public async Task<IList<Quize>> GetAll()
    {
      return await _context.Quizes.ToListAsync();
    }

    public async Task<Quize> Update(Quize item, long id)
    {
      if (item is null)
      {
        return null;
      }

      var exist = await FindById(id);
      if (exist != null)
      {
        _context.Entry(exist).CurrentValues.SetValues(item);
        _context.SaveChanges();
      }

      return exist;
    }
  }
}
