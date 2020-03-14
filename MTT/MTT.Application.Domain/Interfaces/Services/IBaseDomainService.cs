using System;
using System.Collections.Generic;
using System.Text;

namespace MTT.Application.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity, Tkey> where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        List<TEntity> GetAll();
        TEntity GetById(Tkey id);
    }
}
