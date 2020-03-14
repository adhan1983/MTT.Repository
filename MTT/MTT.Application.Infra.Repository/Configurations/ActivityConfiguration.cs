using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTT.Application.Domain.Domain;
using System;


namespace MTT.Application.Infra.Repository.Configurations
{
    public class ActivityConfiguration
    {
        public static Action<EntityTypeBuilder<Activity>> ConfigureMap()
        {
            return (e =>
            {
                e.ToTable("Activity");
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();
                e.Property(x => x.Id).IsRequired();
                e.Property(x => x.MusterId).IsRequired();
                e.Property(x => x.Name).IsRequired();
                e.Property(x => x.UserId).IsRequired();
                e.Property(x => x.WasConcluded);
                
                e.HasOne(x => x.User);
                e.HasOne(x => x.Muster);
            });
        }
    }
}
