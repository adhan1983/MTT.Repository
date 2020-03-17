using MTT.Application.AppService.Contracts.Messages;
using MTT.Application.AppService.Contracts.Requests;
using MTT.Application.AppService.Contracts.Responses;
using MTT.Application.AppService.Interfaces;
using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Services;
using MTT.Application.Domain.Utilities;
using MTT.Application.Infra.Proxy.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace MTT.Application.AppService.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserDomainService _userDomainService;
        private readonly IIdentityServerProxyClient _identityServerProxyClient;
        public UserApplicationService(IUserDomainService userDomainService, IIdentityServerProxyClient identityServerProxyClient)
        {
            _userDomainService = userDomainService;
            _identityServerProxyClient = identityServerProxyClient;
        }
        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            var model = new User { Name = request.Name, Email = request.Email, Password = request.Password };

            var result = await _userDomainService.InsertAsync(model);
            if (result)
            {
                string token = _identityServerProxyClient.GetToken().Result.Result.Token;
                GetUseMessage user = new GetUseMessage();
                user.Id = model.Id;
                user.Email = model.Email;
                user.Name = model.Name;
                user.Token = token;

                return new CreateUserResponse(true, user);
            }
            else
                return new CreateUserResponse(true, error: "Fail to CreateUser");
        }
        public async Task<GetUserResponse> GetUserAsync(GetUserRequest request)
        {
            User model = await _userDomainService.GetByIdAsync(request.Id);

            if (model != null && model.Id > 0)
            {
                GetUseMessage user = new GetUseMessage() { Id = model.Id, Email = model.Email, Name = model.Name };                
                
                return new GetUserResponse(true, user);
            }
            else
                return new GetUserResponse(false, error: "Fail to get user");
        }
        public async Task<ListUserResponse> ListUserAsync(ListUserRequest request) 
        {
            if (!string.IsNullOrEmpty(request.Email))
            {
                var predicate = PredicateBuilder.True<User>();

                predicate = predicate.And(u => u.Email.Contains(request.Email));

                var lst = await _userDomainService.GetAllByFilter(predicate);

                if (lst != null && lst.Count() > 0)
                {
                    var lstUsers = lst.Select(model => new ListUserMessage { Id = model.Id, Email = model.Email, Name = model.Name }).ToList();

                    return new ListUserResponse(true, lstUsers);
                }
                else
                    return new ListUserResponse(false, error: "Fail to list users");

            }
            else
            {
                var lstUsers = _userDomainService.
                    GetAllAsync().
                    Result.
                    Select(model => new ListUserMessage { Id = model.Id, Email = model.Email, Name = model.Name }).ToList();
                
                var success = (lstUsers != null && lstUsers.Count() > 0) ? true: false;
                
                return  new ListUserResponse(success, (success ? lstUsers : null), (success ? "" : "Fail to list users"));
            }

        }
        public async Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request) 
        {
            var model = await _userDomainService.GetByIdAsync(request.Id);

            if (model != null && model.Id > 0 && await _userDomainService.DeleteAsync(model))
                return new DeleteUserResponse(true);
            else
                return new DeleteUserResponse(false, error: "Fail to delete user!");
        }
    }
}
