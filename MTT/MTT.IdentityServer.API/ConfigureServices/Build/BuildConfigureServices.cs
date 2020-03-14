using Microsoft.Extensions.DependencyInjection;
using MTT.IdentityServer.API.IdentityServer;
using MTT.IdentityServer.Infra.CrossCutting;
using MTT.IdentityServer.Infra.CrossCutting.Identity.AspNetIdentityConfiguration;
using MTT.IdentityServer.Infra.CrossCutting.Identity.IdentityServerConfiguration;

namespace MTT.IdentityServer.API.ConfigureServices.Build
{
    public static class BuildConfigureServices
    {
        public static void Build(this IServiceCollection services) 
        {
            services.AddControllers();
            services.AddScoped<IBuildIdentityServer, BuildIdentityServer>();
            services.SwaggerConfigure().
                     InvokeDIFactory();
                     //AspNetIdentityConfigureService().
                     //IdentityServerConfigureService();
            
            services.AddAuthorization();
        }
    }
}
