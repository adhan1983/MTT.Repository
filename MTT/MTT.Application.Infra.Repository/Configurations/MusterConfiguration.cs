
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTT.Application.Domain.Domain;
using System;

namespace MTT.Application.Infra.Repository.Configurations
{
    public class MusterConfiguration
    {
        public static Action<EntityTypeBuilder<Muster>> ConfigureMap() 
        {
            return (e =>
            {
                e.ToTable("Muster");
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();
                e.Property(x => x.Name).IsRequired();
                e.Property(x => x.WasConcluded);
                
                e.HasOne(x => x.Category);
                e.HasMany(x => x.Activities);
            });
        }
    }
}
