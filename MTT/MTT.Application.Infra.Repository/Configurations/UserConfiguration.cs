using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTT.Application.Domain.Domain;
using System;

namespace MTT.Application.Infra.Repository.Configurations
{
    public class UserConfiguration
    {
        public static Action<EntityTypeBuilder<User>> ConfigureMap() 
        {
            return (e =>
            {
                e.ToTable("User");
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();
                e.Property(x => x.Email).IsRequired();
                e.Property(x => x.Name);
                e.Property(x => x.Password).IsRequired();
                
                e.HasMany(x => x.Activities);
            });
        }
    }
}
