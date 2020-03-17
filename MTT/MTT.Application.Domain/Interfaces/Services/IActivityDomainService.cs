using MTT.Application.Domain.Domain;
using System.Threading.Tasks;

namespace MTT.Application.Domain.Interfaces.Services
{
    public interface IActivityDomainService : IBaseDomainService<Activity, int>
    {
        Task<Activity> GetActivityById(int id);
    }
}
