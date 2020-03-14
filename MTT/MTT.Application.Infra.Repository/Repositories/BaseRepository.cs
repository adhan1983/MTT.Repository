using Microsoft.EntityFrameworkCore;
using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Infra.Repository.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace MTT.Application.Infra.Repository.Repositories
{
    public class BaseRepository<TEntity, Tkey> : IBaseRepository<TEntity, Tkey> where TEntity : class
    {
        public void Delete(TEntity obj)
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                ctx.Entry(obj).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                return ctx.Set<TEntity>().ToList();
            }

        }

        public TEntity GetById(Tkey id)
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                return ctx.Set<TEntity>().Find(id);
            }
        }

        public void Insert(TEntity obj)
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                ctx.Entry(obj).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void Update(TEntity obj)
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                ctx.Entry(obj).State = EntityState.Modified;
                ctx.SaveChanges();
            }

        }
    }
}
