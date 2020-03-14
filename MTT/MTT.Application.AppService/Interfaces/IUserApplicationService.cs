using MTT.Application.AppService.Contracts.Requests;
using MTT.Application.AppService.Contracts.Responses;

namespace MTT.Application.AppService.Interfaces
{
    public interface IUserApplicationService
    {
        CreateUserResponse CreateUser(CreateUserRequest request);
    }
}
