using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MTT.IdentityServer.Service.Domain;
using MTT.IdentityServer.Service.Interfaces.CrossCuttingAspNetIdentity;

namespace MTT.IdentityServer.Infra.CrossCutting.Identity.Repositories
{
    public class AspNetIdentityUserRepository : IAspNetIdentityUserRepository
    {
        private UserManager<AspNetIdentityUser> _userManager;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public AspNetIdentityUserRepository(IServiceScopeFactory serviceScopeFactory) 
        {
            _serviceScopeFactory = serviceScopeFactory;
            using (var factoryScope = _serviceScopeFactory.CreateScope())
            _userManager = factoryScope.ServiceProvider.GetRequiredService<UserManager<AspNetIdentityUser>>();
        }
    }
}
