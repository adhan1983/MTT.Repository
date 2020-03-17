using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTT.Application.Domain.Service
{
    public class CategoryDomainService : BaseDomainService<Category, int>, ICategoryDomainService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryDomainService(ICategoryRepository categoryRepository)
        => _categoryRepository = categoryRepository;
        public async Task<bool> InsertAsync(Category model) => await _categoryRepository.InsertAsync(model);
        public async Task<bool> UpdateAsync(Category model) => await _categoryRepository.UpdateAsync(model);
        public async Task<bool> DeleteAsync(Category model) => await _categoryRepository.DeleteAsync(model);
        public async Task<List<Category>> GetAllAsync() => await _categoryRepository.GetAllAsync();
        public async Task<Category> GetByIdAsync(int id) => await _categoryRepository.GetByIdAsync(id);
    }
}
