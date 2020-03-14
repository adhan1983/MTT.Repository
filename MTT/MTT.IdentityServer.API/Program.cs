using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MTT.IdentityServer.API.IdentityServer;

namespace MTT.IdentityServer.API
{
    public class Program
    {      
        public static void Main(string[] args)
        {                     
            IHost host = CreateHostBuilder(args).Build();
            
            //var scope = host.Services.CreateScope();
            
            //var _buildIdentityServer = scope.ServiceProvider.GetRequiredService<IBuildIdentityServer>();
            
            //host = _buildIdentityServer.Build(host);

            host.Run();            
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
