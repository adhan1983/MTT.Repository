using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MTT.IdentityServer.Service.Domain;

namespace MTT.IdentityServer.Infra.CrossCutting.Identity.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<AspNetIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder) { base.OnModelCreating(builder); }
    }
}
