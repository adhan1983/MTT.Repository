using Microsoft.Extensions.DependencyInjection;
using MTT.IdentityServer.Infra.CrossCutting.Identity.Repositories;
using MTT.IdentityServer.Service.Interfaces.CrossCuttingAspNetIdentity;
using MTT.IdentityServer.Service.Interfaces.CrossCuttingIdentityServer;

namespace MTT.IdentityServer.Infra.CrossCutting
{
    public static class DIFactory
    {
        public static IServiceCollection InvokeDIFactory(this IServiceCollection services) 
        {
            services.AddScoped<IIdentityServerMockRepository, IdentityServerMockRepository>();
            //services.AddScoped<IAspNetIdentityUserRepository, AspNetIdentityUserRepository>();
            
            return services;
        }
    }
}
