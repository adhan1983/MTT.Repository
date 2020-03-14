using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTT.Application.Domain.Domain;


namespace MTT.Application.Infra.Repository.Configurations
{
    public class CategoryConfiguration
    {
        public static Action<EntityTypeBuilder<Category>> ConfigureMap() 
        {
            return (e =>
            {
                e.ToTable("Category");
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();
                e.Property(x => x.Name).IsRequired();

                e.HasMany(x => x.Musters);
            });
        }
    }
}
