using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTT.IdentityServer.Infra.CrossCutting.Identity.DbContext;
using MTT.IdentityServer.Service.Domain;

namespace MTT.IdentityServer.Infra.CrossCutting.Identity.AspNetIdentityConfiguration
{
    public static class AspNetIdentityConfigureServices
    {
        public static IServiceCollection AspNetIdentityConfigureService(this IServiceCollection services)
        {
            //string STRCONNECTION = Environment.GetEnvironmentVariable("STRCONNECTION");

            string STRCONNECTION = @"Server=CEPHEUS.cd.com;Port=3306;Database=wz_identityserver;Uid=user_wz_identityserver;Pwd=123987!@#;persistsecurityinfo=True;SslMode=none;";

            services.AddDbContext<ApplicationDbContext>(o => o.UseMySql(STRCONNECTION));

            services.AddIdentity<AspNetIdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddSingleton<UserManager<AspNetIdentityUser>>();

            return services;
        }
    }
}
