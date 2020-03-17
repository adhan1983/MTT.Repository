using Microsoft.AspNetCore.Builder;

namespace MTT.IdentityServer.API.ConfigureApplication
{
    public static class SwaggerApplication
    {
        public static void SwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "MTT Identity Server v1");
                c.DefaultModelExpandDepth(0);
                c.DefaultModelsExpandDepth(-1);
            });
        }
    }
}
