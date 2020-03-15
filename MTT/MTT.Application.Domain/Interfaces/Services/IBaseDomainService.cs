using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTT.Application.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity, Tkey> where TEntity : class
    {
        Task<bool> InsertAsync(TEntity obj);
        Task<bool> UpdateAsync(TEntity obj);
        Task<bool> DeleteAsync(TEntity obj);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Tkey id);
    }
}
