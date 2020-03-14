using Microsoft.Extensions.Hosting;
using MTT.IdentityServer.Service.Interfaces.CrossCuttingIdentityServer;

namespace MTT.IdentityServer.API.IdentityServer
{
    public class BuildIdentityServer : IBuildIdentityServer
    {
        private readonly IIdentityServerMockRepository _identityServerMockRepository;
        public BuildIdentityServer(IIdentityServerMockRepository identityServerMockRepository)
        => _identityServerMockRepository = identityServerMockRepository;
        public IHost Build(IHost host)
        {
            _identityServerMockRepository.Execute(host.Services);

            return host;
        }
    }
}
