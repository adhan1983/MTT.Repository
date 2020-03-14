using MTT.Application.AppService.Contracts.Requests;
using MTT.Application.AppService.Contracts.Responses;
using MTT.Application.AppService.Interfaces;
using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Services;

namespace MTT.Application.AppService.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserDomainService _userDomainService;
        public UserApplicationService(IUserDomainService userDomainService)
        => _userDomainService = userDomainService;
        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            var model = new User { Name = request.Name, Email = request.Email, Password = request.Password };

            _userDomainService.Insert(model);

            return new CreateUserResponse(true, model.Id);
        }
    }
}
