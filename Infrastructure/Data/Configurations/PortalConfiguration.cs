using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class PortalConfiguration : IEntityTypeConfiguration<Portal>
    {
        public void Configure(EntityTypeBuilder<Portal> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(25)
                .IsRequired();

            builder.HasIndex(e => e.Name)
                .IsUnique();

            builder.Property(e => e.IsLegalAgeRequired)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            DataSeeding(builder);
        }

        private static void DataSeeding(EntityTypeBuilder<Portal> builder)
        {
            builder.HasData(
                new Portal { Id = 1, Name = "Faceback", IsLegalAgeRequired = true, CreatedAt = DateTime.Now },
                new Portal { Id = 2, Name = "Instaclan", IsLegalAgeRequired = true, CreatedAt = DateTime.Now }
                );
        }
    }
}
