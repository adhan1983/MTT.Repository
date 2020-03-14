using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTT.IdentityServer.Infra.CrossCutting.Identity.Repositories;
using MTT.IdentityServer.Service.Domain;
using System;
using System.Reflection;

namespace MTT.IdentityServer.Infra.CrossCutting.Identity.IdentityServerConfiguration
{
    public static class IdentityServerConfigureServices
    {
        public static IServiceCollection IdentityServerConfigureService(this IServiceCollection services)
        {
            //string STRCONNECTION = Environment.GetEnvironmentVariable("STRCONNECTION");
            
            string STRCONNECTION = @"Data Source=.\SQLEXPRESS;Initial Catalog=IdentityServer;Persist Security Info=True;User ID=aom_identityserver;Password=***********;";

            var migrationsAssembly = typeof(IdentityServerMockRepository).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddAspNetIdentity<AspNetIdentityUser>()
                    .AddConfigurationStore(configStore => { configStore.ConfigureDbContext = builder => builder.UseMySql(STRCONNECTION, db => db.MigrationsAssembly(migrationsAssembly)); })
                    .AddOperationalStore(operationStore => { operationStore.ConfigureDbContext = builder => builder.UseMySql(STRCONNECTION, db => db.MigrationsAssembly(migrationsAssembly)); });
            
            return services;       
        }
    }
}
