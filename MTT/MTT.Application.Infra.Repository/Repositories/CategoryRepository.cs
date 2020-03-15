
using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Repositories;

namespace MTT.Application.Infra.Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
    }
}
