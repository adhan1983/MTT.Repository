using IdentityModel.Client;
using MTT.Application.Infra.Proxy.Contract;
using MTT.Application.Infra.Proxy.Contract.Messages;
using MTT.Application.Infra.Proxy.Contract.Messages.IdentityServer;
using MTT.Application.Infra.Proxy.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MTT.Application.Infra.Proxy.Proxy
{
    public class IdentityServerProxyClient : IIdentityServerProxyClient
    {
        private readonly HttpClient _proxy;
        public IdentityServerProxyClient(HttpClient proxy) 
        {
            _proxy = proxy;
            _proxy.DefaultRequestHeaders.Clear();
            _proxy.DefaultRequestHeaders.Add("Accept", "application/json; charset=utf-8");
        }
        public async Task<LoginProxyResponse> GetToken() 
        {
            Dictionary<string, string> error = new Dictionary<string, string>();

            string DISCOVERYIDENTITYSERVER = "https://localhost:5003/.well-known/openid-configuration";

            var discoveryEndPoint = await _proxy.GetDiscoveryDocumentAsync(DISCOVERYIDENTITYSERVER);

            if (discoveryEndPoint.IsError)
            {
                error.Add("Error", "You can not request token!");
                return new LoginProxyResponse(false, error);
            }
            
            ClientIdentityServer clientIdentityServer = new ClientIdentityServer();

            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();
            
            clientCredentialsTokenRequest.Scope = clientIdentityServer.Scope;
            clientCredentialsTokenRequest.ClientId = clientIdentityServer.ClientId;
            clientCredentialsTokenRequest.RequestUri = new Uri(discoveryEndPoint.TokenEndpoint);
            clientCredentialsTokenRequest.ClientSecret = clientIdentityServer.ClientSecret;

            TokenResponse tokenResponse =
                await _proxy.
                RequestClientCredentialsTokenAsync(
                    clientCredentialsTokenRequest
                );

            if (!tokenResponse.IsError)
            {
                LoginProxyMessage tokenMessage = new LoginProxyMessage()
                {
                    ExpiresIn = tokenResponse.ExpiresIn,
                    TokenType = tokenResponse.TokenType,
                    Token = tokenResponse.AccessToken
                };
                return new LoginProxyResponse(true, tokenMessage);
            }
            else
                return new LoginProxyResponse(false);

        }

    }
}
