using System.Threading.Tasks;
using System.Collections.Generic;
using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Domain.Interfaces.Services;

namespace MTT.Application.Domain.Service
{
    public class ActivityDomainService : BaseDomainService<Activity, int>, IActivityDomainService
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityDomainService(IActivityRepository activityRepository)
        => _activityRepository = activityRepository;
        public async Task<bool> InsertAsync(Activity model) => await _activityRepository.InsertAsync(model);
        public async Task<bool> UpdateAsync(Activity model) => await _activityRepository.UpdateAsync(model);
        public async Task<bool> DeleteAsync(Activity model) => await _activityRepository.DeleteAsync(model);
        public async Task<List<Activity>> GetAllAsync() => await _activityRepository.GetAllAsync();        
        public async Task<Activity> GetByIdAsync(int id) => await _activityRepository.GetByIdAsync(id);
        public async Task<Activity> GetActivityById(int id) => await _activityRepository.GetActivityById(id);
    }
}
