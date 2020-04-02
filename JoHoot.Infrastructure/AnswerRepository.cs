using Johoot.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Domain
{
    public class AnswerRepository : IAnswerRepository
    {
        Task<IList<Answer>> IAnswerRepository.GetAll()
        {
            throw new System.NotImplementedException();
        }

        Task<Answer> IAnswerRepository.FindById(long id)
        {
            throw new System.NotImplementedException();
        }

        Task<Answer> IAnswerRepository.Create(Answer item)
        {
            throw new System.NotImplementedException();
        }

        Task<Answer> IAnswerRepository.Update(Answer item)
        {
            throw new System.NotImplementedException();
        }
    }
}
