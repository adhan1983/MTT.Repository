using Microsoft.Extensions.Hosting;

namespace MTT.IdentityServer.API.IdentityServer
{
    public interface IBuildIdentityServer
    {
        IHost Build(IHost host);
    }
}
