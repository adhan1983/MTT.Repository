using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace MTT.IdentityServer.API.ConfigureServices
{
    public static class SwaggeConfigurerServices
    {
        public static IServiceCollection SwaggerConfigure(this IServiceCollection services)
        {
            string ENVIRONMENT = Environment.GetEnvironmentVariable("ENVIRONMENT");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity Server On Line Store - " + ENVIRONMENT, Version = "v1" });
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                c.DocumentFilterDescriptors.AsReadOnly();
                c.CustomSchemaIds(i => i.FullName);
            });

            return services;
        }
    }
}
