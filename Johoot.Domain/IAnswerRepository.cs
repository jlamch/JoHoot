using Johoot.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Domain
{
  public interface IAnswerRepository
  {
    Task<ICollection<Answer>> GetAll();

    Task<Answer> FindById(long id);

    Task<Answer> Create(Answer item);

    Task<Answer> Update(Answer item, long id);
  }
}
