using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Services;

namespace MTT.Application.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseDomainService<Category, int>
    {
    }
}
