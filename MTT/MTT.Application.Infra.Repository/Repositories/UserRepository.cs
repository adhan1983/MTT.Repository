using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Repositories;

namespace MTT.Application.Infra.Repository.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {

    }
}
