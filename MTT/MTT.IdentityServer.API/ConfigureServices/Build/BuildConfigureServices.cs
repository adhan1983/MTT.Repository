using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTT.IdentityServer.API.DbContext;
using MTT.IdentityServer.API.Model;
using System.Reflection;

namespace MTT.IdentityServer.API.ConfigureServices.Build
{
    public static class BuildConfigureServices
    {
        public static void Build(this IServiceCollection services)
        {
            services.AddControllers();
            services.SwaggerConfigure();
            services.AddAuthorization();
            string STRCONNECTION = @"***";

            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(STRCONNECTION));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddAspNetIdentity<ApplicationUser>()
                    .AddConfigurationStore(configStore => { configStore.ConfigureDbContext = builder => builder.UseMySql(STRCONNECTION, db => db.MigrationsAssembly(migrationsAssembly)); })
                    .AddOperationalStore(operationStore => { operationStore.ConfigureDbContext = builder => builder.UseMySql(STRCONNECTION, db => db.MigrationsAssembly(migrationsAssembly)); });




        }
    }
}
