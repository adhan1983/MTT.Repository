using Microsoft.Extensions.DependencyInjection;
using MTT.Application.AppService.Interfaces;
using MTT.Application.AppService.Services;
using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Domain.Interfaces.Services;
using MTT.Application.Domain.Service;
using MTT.Application.Infra.Proxy.Interface;
using MTT.Application.Infra.Proxy.Proxy;
using MTT.Application.Infra.Repository.Repositories;

namespace MTT.Application.Infra.CrossCutting
{
    public static class DIFactory
    {
        public static void InvokeDIFactory(this IServiceCollection services)
        {
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<ICategoryApplicationService, CategoryApplicationService>();
            services.AddScoped<IMusterApplicationService, MusterApplicationService>();
            services.AddScoped<IActivityApplicationService, ActivityApplicationService>();

            services.AddScoped<IUserDomainService, UserDomainService>();
            services.AddScoped<ICategoryDomainService, CategoryDomainService>();
            services.AddScoped<IMusterDomainService, MusterDomainService>();
            services.AddScoped<IActivityDomainService, ActivityDomainService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMusterRepository, MusterRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();

            services.AddHttpClient<IIdentityServerProxyClient, IdentityServerProxyClient>();
            

        }
    }
}
