using Microsoft.EntityFrameworkCore;
using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Infra.Repository.Contexts;
using System.Threading.Tasks;

namespace MTT.Application.Infra.Repository.Repositories
{
    public class ActivityRepository : BaseRepository<Activity, int>, IActivityRepository
    {
        public async Task<Activity> GetActivityById(int id)
        {
            using (var ctx = new MTTApplicationDbContext())
            {
                var entity = ctx.Activity.
                            Include("User").
                            Include("Muster").
                            Include("Muster.Category").
                            FirstOrDefaultAsync(ac => ac.Id == id);

                return await Task.FromResult(entity.Result);                
            }
        }

    }
}
