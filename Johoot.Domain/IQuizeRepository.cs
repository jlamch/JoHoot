using Johoot.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Domain
{
    public interface IQuizeRepository
    {
        Task<IList<Quize>> GetAll();

        Task<Quize> GetQuize(long id);

        Task<Quize> CreateQuize(Quize item);

        Task<Quize> UpdateQuize(Quize item);
    }
}
