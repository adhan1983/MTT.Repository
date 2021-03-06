﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MTT.IdentityServer.API.DbContext;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.EntityFramework.DbContexts;
using MTT.IdentityServer.API.IdtServerConfiguration;

namespace MTT.IdentityServer.API
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            //PerformMigrations(serviceProvider);
            EnsureSeedData(serviceProvider.GetRequiredService<ConfigurationDbContext>());
        }
        private static void PerformMigrations(IServiceProvider serviceProvider)
        {
            serviceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
            serviceProvider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
            serviceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
        }
        private static void EnsureSeedData(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                foreach (var client in IdentityServerConfiguration.GetClientScope().ToList())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in IdentityServerConfiguration.GetIdentityResources().ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in IdentityServerConfiguration.GetApiResources().ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

        }
    }
}
