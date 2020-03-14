using Microsoft.Extensions.DependencyInjection;
using MTT.Application.AppService.Interfaces;
using MTT.Application.AppService.Services;
using MTT.Application.Domain.Interfaces.Repositories;
using MTT.Application.Domain.Interfaces.Services;
using MTT.Application.Domain.Service;
using MTT.Application.Infra.Repository.Repositories;

namespace MTT.Application.Infra.CrossCutting
{
    public static class DIFactory
    {
        public static void InvokeDIFactory(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDomainService, UserDomainService>();
            services.AddScoped<IUserApplicationService, UserApplicationService>();
        }
    }
}
