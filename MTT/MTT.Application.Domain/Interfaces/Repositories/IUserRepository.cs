using MTT.Application.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTT.Application.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        Task<List<User>> GetAllByFilter(Expression<Func<User, bool>> filter);
    }
}
