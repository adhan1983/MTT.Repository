using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MTT.Application.Infra.CrossCutting;
using MTT.Application.Presentation.API.Configurations;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace MTT.Application.Presentation.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.InvokeDIFactory();

            var lst = new List<string>();
            
            lst.Add("Bearer");

            var openApiSecurityScheme = new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer",
                BearerFormat  = "JWT",
                
            };
            var openApiSecurityRequirement = new OpenApiSecurityRequirement();
            
            openApiSecurityRequirement.Add(openApiSecurityScheme, lst);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MTT Application", Version = "v1" });
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                c.DocumentFilterDescriptors.AsReadOnly();
                c.CustomSchemaIds(i => i.FullName);
                c.OperationFilter<AuthOperationFilter>();
                c.AddSecurityDefinition("bearer", openApiSecurityScheme);
                c.AddSecurityRequirement(openApiSecurityRequirement);
            });


            services.AddAuthentication("Bearer")
               .AddJwtBearer("Bearer", o =>
               {
                   o.Authority = "https://localhost:5003";
                   o.RequireHttpsMetadata = true;
                   o.Audience = "MTTAPI";                  

               });

        }        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "MTTApplication.API v1");
                c.DefaultModelExpandDepth(0);
                c.DefaultModelsExpandDepth(-1);                
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
