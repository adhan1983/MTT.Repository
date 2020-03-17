using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTT.Application.Domain.Service
{
    public class UserDomainService : BaseDomainService<User, int>, IUserDomainService
    {
        private readonly IUserRepository _userRepository;
        public UserDomainService(IUserRepository userRepository)
        => _userRepository = userRepository;
        public async Task<bool> InsertAsync(User model) => await _userRepository.InsertAsync(model);
        public async Task<bool> UpdateAsync(User model) => await _userRepository.UpdateAsync(model);
        public async Task<bool> DeleteAsync(User model) => await _userRepository.DeleteAsync(model);
        public async Task<List<User>> GetAllAsync()     => await _userRepository.GetAllAsync();
        public async Task<User> GetByIdAsync(int id)    => await _userRepository.GetByIdAsync(id);
        public async Task<List<User>> GetAllByFilter(Expression<Func<User, bool>> predicate)
        => await _userRepository.GetAllByFilter(predicate);
    }
}
