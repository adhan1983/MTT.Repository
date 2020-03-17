using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTT.Application.Domain.Service
{
    public class MusterDomainService : BaseDomainService<Muster, int>, IMusterDomainService
    {
        private readonly IMusterRepository _musterRepository;
        public MusterDomainService(IMusterRepository musterRepository)
        => _musterRepository = musterRepository;
        public async Task<bool> InsertAsync(Muster model) => await _musterRepository.InsertAsync(model);
        public async Task<bool> UpdateAsync(Muster model) => await _musterRepository.UpdateAsync(model);
        public async Task<bool> DeleteAsync(Muster model) => await _musterRepository.DeleteAsync(model);
        public async Task<List<Muster>> GetAllAsync()     => await _musterRepository.GetAllAsync();
        public async Task<Muster> GetMusterByIdWithCategory(int id) => await _musterRepository.GetMusterByIdWithCategory(id);
        public async Task<Muster> GetByIdAsync(int id)    => await _musterRepository.GetByIdAsync(id);
        public async Task<List<Muster>> GetAllByFilter(Expression<Func<Muster, bool>> predicate)
        => await _musterRepository.GetAllByFilter(predicate);
    }
}
