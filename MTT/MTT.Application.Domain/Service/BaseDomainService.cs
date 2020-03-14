using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace MTT.Application.Domain.Service
{
    public class BaseDomainService<TEntity, TKey> : IBaseDomainService<TEntity, TKey> where TEntity : class
    {
        private readonly IBaseRepository<TEntity, TKey> _baseRepository;
        public void Insert(TEntity obj) => this._baseRepository.Insert(obj);
        public void Delete(TEntity obj) => this._baseRepository.Delete(obj);
        public List<TEntity> GetAll()   => this._baseRepository.GetAll();
        public TEntity GetById(TKey id) => this._baseRepository.GetById(id);
        public void Update(TEntity obj) => this._baseRepository.Update(obj);
    }
}
