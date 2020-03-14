using Microsoft.AspNetCore.Builder;

namespace MTT.IdentityServer.API.ConfigureApplication.Build
{
    public static class BuildConfigureApplication
    {
        public static void BuildApp(this IApplicationBuilder app) 
        {         
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.IdentityServerConfigure();
            app.UseAuthorization();
            app.SwaggerConfigure();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
