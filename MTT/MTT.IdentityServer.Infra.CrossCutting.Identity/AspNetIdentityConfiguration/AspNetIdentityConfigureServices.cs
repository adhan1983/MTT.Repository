using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTT.IdentityServer.Infra.CrossCutting.Identity.DbContext;
using MTT.IdentityServer.Service.Domain;
using System;

namespace MTT.IdentityServer.Infra.CrossCutting.Identity.AspNetIdentityConfiguration
{
    public static class AspNetIdentityConfigureServices
    {
        public static IServiceCollection AspNetIdentityConfigureService(this IServiceCollection services)
        {
            //string STRCONNECTION = Environment.GetEnvironmentVariable("STRCONNECTION");

            string STRCONNECTION = @"Data Source=.\SQLEXPRESS;Initial Catalog=IdentityServer;Persist Security Info=True;User ID=aom_identityserver;Password=***********;";

            services.AddDbContext<ApplicationDbContext>(o => o.UseMySql(STRCONNECTION));

            services.AddIdentity<AspNetIdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddSingleton<UserManager<AspNetIdentityUser>>();

            return services;
        }
    }
}
