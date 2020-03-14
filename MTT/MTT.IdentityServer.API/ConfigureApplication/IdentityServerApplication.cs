using Microsoft.AspNetCore.Builder;

namespace MTT.IdentityServer.API.ConfigureApplication
{
    public static class IdentityServerApplication
    {
        public static void IdentityServerConfigure(this IApplicationBuilder app)
        {
            //app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
