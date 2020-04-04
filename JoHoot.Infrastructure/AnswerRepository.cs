using Johoot.Data;
using Johoot.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Infrastructure
{
  public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
  {
    public AnswerRepository(JohootContext context) : base(context)
    {
    }

    public async Task<Answer> Create(Answer item)
    {
      return await base.AddAsyn(item);
    }

    public async Task<Answer> FindById(long id)
    {
      return await base.FindAsync(q => q.Id == id);
    }

    public async Task<Answer> Update(Answer item, long id)
    {
      return await base.UpdateAsync(item, id);
    }

    public async Task<ICollection<Answer>> GetAll()
    {
      return await base.GetAllAsync();
    }
  }
}
