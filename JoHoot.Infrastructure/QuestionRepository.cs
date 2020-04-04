using Johoot.Data;
using Johoot.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Infrastructure
{
  public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
  {
    public QuestionRepository(JohootContext context) : base(context)
    {
    }

    public async Task<Question> Create(Question item)
    {
      return await base.AddAsyn(item);
    }

    public async Task<Question> FindById(long id)
    {
      return await base.FindAsync(q => q.Id == id);
    }

    public async Task<Question> Update(Question item, long id)
    {
      return await base.UpdateAsync(item, id);
    }

    public async Task<ICollection<Question>> GetAll()
    {
      return await base.GetAllAsync();
    }
  }
}
