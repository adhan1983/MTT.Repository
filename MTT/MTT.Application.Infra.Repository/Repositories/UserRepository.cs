using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Infra.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTT.Application.Infra.Repository.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public async Task<List<User>> GetAllByFilter(Expression<Func<User, bool>> predicate)
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                var lst = ctx.User.Where(predicate).ToList();
                
                return await Task.FromResult(lst);
            }
        }
    }
}
