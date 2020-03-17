using MTT.Application.AppService.Contracts.Messages;
using MTT.Application.AppService.Contracts.Requests;
using MTT.Application.AppService.Contracts.Responses;
using MTT.Application.AppService.Interfaces;
using MTT.Application.AppService.Mappers;
using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Services;
using MTT.Application.Domain.Utilities;
using MTT.Application.Infra.Proxy.Interface;
using System.Collections.Generic;
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
            var model = new User();           

            model.Add(request.Name, request.Email, request.Password);
            
            var result = await _userDomainService.InsertAsync(model);
            
            if (result)
            {
                string token = _identityServerProxyClient.GetToken().Result.Result.Token;
                
                using (UserMapper mapper = new UserMapper())
                {
                    GetUseMessage user = new GetUseMessage();

                    mapper.ToUserMessageByToken(model, user, token);

                    return new CreateUserResponse(true, user);
                }
            }
            else
                return new CreateUserResponse(true, error: "Fail to CreateUser");
        }
        public async Task<GetTokenResponse> GetToken(GetTokenRequest request)
        {            
            var resultIsExistUser = await _userDomainService.GetUserByEmail(request.Email);

            if (resultIsExistUser != null && resultIsExistUser.Id > 0)
            {                               
                var samePassword = resultIsExistUser.VerifyPassword(resultIsExistUser.Password, request.Password);

                if (samePassword)
                {
                    string token = _identityServerProxyClient.GetToken().Result.Result.Token;

                    return new GetTokenResponse(true, token);
                }
                else
                    return new GetTokenResponse(true, error: "Fail to Authenticate this user");
            }            
            else
                return new GetTokenResponse(true, error: "Fail to Authenticate this user");
        }
        public async Task<GetUserResponse> GetUserAsync(GetUserRequest request)
        {
            User model = await _userDomainService.GetByIdAsync(request.Id);

            if (model != null && model.Id > 0)
            {
                using (UserMapper mapper = new UserMapper())
                {
                    GetUseMessage user = new GetUseMessage();

                    mapper.ToUserMessage(model, user);

                    return new GetUserResponse(true, user);
                }
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
                    using (UserMapper mapper = new UserMapper()) 
                    {
                        List<ListUserMessage> lstUsers = mapper.ToListUserMessage(lst);

                        var success = (lstUsers != null && lstUsers.Count() > 0) ? true : false;

                        return new ListUserResponse(success, (success ? lstUsers : null), (success ? "" : "Fail to list users"));
                    }
                }
                else
                    return new ListUserResponse(false, error: "Fail to list users");
            }
            else
            {
                using (UserMapper mapper = new UserMapper())
                {
                    var lst = await _userDomainService.GetAllAsync();                    

                    List<ListUserMessage> lstUsers = mapper.ToListUserMessage(lst);

                    var success = (lstUsers != null && lstUsers.Count() > 0) ? true : false;

                    return new ListUserResponse(success, (success ? lstUsers : null), (success ? "" : "Fail to list users"));                    
                }                
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
