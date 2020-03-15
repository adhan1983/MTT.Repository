using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTT.Application.Domain.Interfaces.Repositories
{
    public interface IMusterRepository : IBaseRepository<Muster, int>
    {
        Task<List<Muster>> GetAllByFilter(Expression<Func<Muster, bool>> predicate);
    }
}
