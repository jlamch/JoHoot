using Johoot.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Domain
{
    public class QuestionRepository : IQuestionRepository
    {
        Task<IList<Question>> IQuestionRepository.GetAll()
        {
            throw new System.NotImplementedException();
        }

        Task<Question> IQuestionRepository.FindById(long id)
        {
            throw new System.NotImplementedException();
        }

        Task<Question> IQuestionRepository.Create(Question item)
        {
            throw new System.NotImplementedException();
        }

        Task<Question> IQuestionRepository.Update(Question item)
        {
            throw new System.NotImplementedException();
        }
    }
}
