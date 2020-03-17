using MTT.Application.Infra.Proxy.Contract;
using System.Threading.Tasks;

namespace MTT.Application.Infra.Proxy.Interface
{
    public interface IIdentityServerProxyClient
    {
        Task<LoginProxyResponse> GetToken();
    }
}
