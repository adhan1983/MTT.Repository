using System.Collections.Generic;

namespace MTT.Application.Domain.Interfaces.Repositories
{
    public interface IBaseRepository <TEntity, Tkey> where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        List<TEntity> GetAll();
        TEntity GetById(Tkey id);
    }
}
