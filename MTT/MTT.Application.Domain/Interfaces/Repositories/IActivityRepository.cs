using MTT.Application.Domain.Domain;
using System.Threading.Tasks;

namespace MTT.Application.Domain.Interfaces.Repositories
{
    public interface IActivityRepository : IBaseRepository<Activity, int>
    {
        Task<Activity> GetActivityById(int id);
    }
}
