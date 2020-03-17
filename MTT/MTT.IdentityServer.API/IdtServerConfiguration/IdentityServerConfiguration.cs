using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MTT.IdentityServer.API.IdtServerConfiguration
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()        
            => new List<IdentityResource>() { new IdentityResources.OpenId(), new IdentityResources.Email(), new IdentityResources.Profile() };
        
        public static IEnumerable<ApiResource> GetApiResources() => 
            new List<ApiResource>() { new ApiResource("MTTAPI", "MTT Api Resources") };
        
        public static IEnumerable<Client> GetClientScope()
        {
           return new List<Client>()
           {
               new Client()
               {
                   ClientId = "MTTAPI",
                   ClientName = "MTTAPI",
                   AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                   AllowOfflineAccess = true,
                   ClientSecrets =
                   {
                       new Secret("A3M3SL7WqnqyxBDX".Sha256())
                   },
                   AllowedScopes =
                   {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "MTTAPI"
                   },
               }
           };
        }
    }
}
