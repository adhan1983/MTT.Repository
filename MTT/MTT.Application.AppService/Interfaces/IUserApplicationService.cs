using MTT.Application.AppService.Contracts.Requests;
using MTT.Application.AppService.Contracts.Responses;
using System.Threading.Tasks;

namespace MTT.Application.AppService.Interfaces
{
    public interface IUserApplicationService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
        Task<GetUserResponse> GetUserAsync(GetUserRequest request);
        Task<ListUserResponse> ListUserAsync(ListUserRequest request);
        Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request);
        Task<GetTokenResponse> GetToken(GetTokenRequest request);
    }
}
