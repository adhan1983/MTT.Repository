using Microsoft.EntityFrameworkCore;
using MTT.Application.Domain.Domain;
using MTT.Application.Infra.Repository.Configurations;
using System.Reflection;

namespace MTT.Application.Infra.Repository.Contexts
{
    public class MTTApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var migrationsAssembly = typeof(MTTApplicationDbContext).GetTypeInfo().Assembly.GetName().Name;
            string STRCONNECTION = @"Server=CEPHEUS.cd.com;Port=3306;Database=wz_identityserver;Uid=user_wz_identityserver;Pwd=123987!@#;persistsecurityinfo=True;SslMode=none;";
            optionsBuilder.UseMySql(STRCONNECTION, x => x.MigrationsAssembly(migrationsAssembly));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity(ActivityConfiguration.ConfigureMap());
            modelBuilder.Entity(CategoryConfiguration.ConfigureMap());
            modelBuilder.Entity(MusterConfiguration.ConfigureMap());
            modelBuilder.Entity(UserConfiguration.ConfigureMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Muster> Muster { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Activity> Activity { get; set; }

    }
}
