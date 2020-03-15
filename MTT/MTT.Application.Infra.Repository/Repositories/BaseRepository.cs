using Microsoft.EntityFrameworkCore;
using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Infra.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTT.Application.Infra.Repository.Repositories
{
    public class BaseRepository<TEntity, Tkey> : IBaseRepository<TEntity, Tkey> where TEntity : class
    {
        public async Task<bool> DeleteAsync(TEntity obj)
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                bool wasDeleted = false;
                ctx.Entry(obj).State = EntityState.Deleted;
                wasDeleted =  await ctx.SaveChangesAsync() == 1 ? true : false;
                return await Task.FromResult(wasDeleted);
            }
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                var lst = ctx.Set<TEntity>().ToList();
                
                return await Task.FromResult(lst);
            }
        }
        public async Task<TEntity> GetByIdAsync(Tkey id)
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                return await ctx.Set<TEntity>().FindAsync(id);
            }
        }
        public async Task<bool> InsertAsync(TEntity obj)
        {            
            using (var ctx = new MTTApplicationDbContext())
            {
                var wasInserted = false;
                ctx.Entry(obj).State = EntityState.Added;
                wasInserted = Convert.ToBoolean(ctx.SaveChangesAsync().Result);
                return await Task.FromResult(wasInserted);
            }
        }
        public async Task<bool> UpdateAsync(TEntity obj)
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                bool waUpdated = false;
                ctx.Entry(obj).State = EntityState.Modified;
                waUpdated = Convert.ToBoolean(ctx.SaveChangesAsync());
                return await Task.FromResult(waUpdated);
            }

        }
    }
}
