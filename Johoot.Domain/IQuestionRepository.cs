using Johoot.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Domain
{
  public interface IQuestionRepository
  {
    Task<ICollection<Question>> GetAll();

    Task<Question> FindById(long id);

    Task<Question> Create(Question item);

    Task<Question> Update(Question item, long id);
  }
}
