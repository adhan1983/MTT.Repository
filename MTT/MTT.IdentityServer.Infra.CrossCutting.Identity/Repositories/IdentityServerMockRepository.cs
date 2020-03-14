using System;
using System.Linq;
using IdentityServer4;
using System.Collections.Generic;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTT.IdentityServer.Service.Interfaces.CrossCuttingIdentityServer;
using MTT.IdentityServer.Infra.CrossCutting.Identity.DbContext;

namespace MTT.IdentityServer.Infra.CrossCutting.Identity.Repositories
{
    public class IdentityServerMockRepository : IIdentityServerMockRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public IdentityServerMockRepository(IServiceScopeFactory serviceScopeFactory)
        => _serviceScopeFactory = serviceScopeFactory;
        public void Execute(IServiceProvider serviceProvider)
        {
            using (var factoryScope = _serviceScopeFactory.CreateScope())
            {
                var applicationDbContext = serviceProvider
                    .GetRequiredService<ApplicationDbContext>();

                applicationDbContext.Database.Migrate();

                var persistedGrantDbContext = serviceProvider
                    .GetRequiredService<PersistedGrantDbContext>();

                persistedGrantDbContext.Database.Migrate();

                var configurationDbContext = serviceProvider.
                    GetRequiredService<ConfigurationDbContext>();

                configurationDbContext.Database.Migrate();

                this.SyncDataContext(configurationDbContext);                

            }
        }
        private async void SyncDataContext(ConfigurationDbContext context)
        {
            this.GetClientScopes().ToList().ForEach(cl =>
            {
                if (!context.Clients.Any(c => c.ClientName == cl.ClientName))
                    context.Clients.Add(cl.ToEntity());
            });

            this.GetIdentityResources().ToList().ForEach(idt =>
            {
                if (!context.IdentityResources.Any(i => i.Name == idt.Name))
                    context.IdentityResources.Add(idt.ToEntity());
            });

            this.GetApiResources().ToList().ForEach(api =>
            {
                if (!context.IdentityResources.Any(i => i.Name == api.Name))
                    context.ApiResources.Add(api.ToEntity());
            });

            await context.SaveChangesAsync();
        }
        private void RemoveDataContext(ConfigurationDbContext context)
        {
            foreach (var client in context.Clients.ToList())
                context.Remove(client);

            foreach (var identityResources in context.IdentityResources.ToList())
                context.Remove(identityResources);

            foreach (var apiResources in context.ApiResources.ToList())
                context.Remove(apiResources);

            context.SaveChanges();
        }
        private IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        }
        private IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> apiResourcesMTTAPI = new List<ApiResource>();

            ApiResource mttAPI = new ApiResource() { Name = "MTTAPI", DisplayName = "MTT Api Resources" };

            apiResourcesMTTAPI.Add(mttAPI);

            return apiResourcesMTTAPI;
        }
        private IEnumerable<Client> GetClientScopes()
        {
            List<Client> clients = new List<Client>();

            var mttClient = new Client()
            {
                ClientId = "MTTAPI",
                ClientName = "MTTAPI",
                AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                AllowOfflineAccess = true,
                RequireConsent = false,
                AllowAccessTokensViaBrowser = true,
                ClientSecrets = { new Secret("7fp<X$zvDJ?-jw^^".Sha256()) },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Address,
                    "MTTAPI"
                },
                AccessTokenLifetime = 10800,
                AccessTokenType = AccessTokenType.Jwt
            };

            clients.Add(mttClient);

            return clients;


        }

    }
}
