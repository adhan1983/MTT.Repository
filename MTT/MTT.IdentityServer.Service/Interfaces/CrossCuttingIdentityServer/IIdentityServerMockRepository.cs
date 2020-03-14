using System;

namespace MTT.IdentityServer.Service.Interfaces.CrossCuttingIdentityServer
{
    public interface IIdentityServerMockRepository
    {
        void Execute(IServiceProvider serviceProvider);
    }
}
