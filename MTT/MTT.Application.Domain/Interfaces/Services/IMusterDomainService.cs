using MTT.Application.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTT.Application.Domain.Interfaces.Services
{
    public interface IMusterDomainService : IBaseDomainService<Muster, int>
    {
        Task<List<Muster>> GetAllByFilter(Expression<Func<Muster, bool>> predicate);
        Task<Muster> GetMusterByIdWithCategory(int id);        
    }
}
