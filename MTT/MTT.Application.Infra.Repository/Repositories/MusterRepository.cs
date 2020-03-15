using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using MTT.Application.Infra.Repository.Contexts;
using System.Linq;

namespace MTT.Application.Infra.Repository.Repositories
{
    public class MusterRepository : BaseRepository<Muster, int>, IMusterRepository
    {
        public async Task<List<Muster>> GetAllByFilter(Expression<Func<Muster, bool>> predicate) 
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                var musters = ctx.Muster.
                            Include("Category").
                            Where(predicate).
                            ToList();

                return await Task.FromResult(musters);
            }
        }
    }
}
