﻿using Johoot.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Domain
{
    public interface IQuizeRepository
    {
        Task<IList<Quize>> GetAll();

        Task<Quize> FindById(long id);

        Task<Quize> Create(Quize item);

        Task<Quize> Update(Quize item);
    }
}