using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTT.Application.Domain.Service
{
    public class BaseDomainService<TEntity, TKey> : IBaseDomainService<TEntity, TKey> where TEntity : class
    {
        private readonly IBaseRepository<TEntity, TKey> _baseRepository;
        public async Task<bool> InsertAsync(TEntity obj) => await this._baseRepository.InsertAsync(obj);
        public async Task<bool> DeleteAsync(TEntity obj) => await this._baseRepository.DeleteAsync(obj);
        public async Task<List<TEntity>> GetAllAsync()   => await this._baseRepository.GetAllAsync();
        public async Task<TEntity> GetByIdAsync(TKey id) => await this._baseRepository.GetByIdAsync(id);
        public async Task<bool> UpdateAsync(TEntity obj) => await this._baseRepository.UpdateAsync(obj);
    }
}
