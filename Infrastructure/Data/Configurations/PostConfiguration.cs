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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(e => e.Portal)
                .WithMany()
                .HasForeignKey(e => e.PortalId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            DataSeeding(builder);
        }

        private static void DataSeeding(EntityTypeBuilder<Post> builder)
        {
            List<Post> posts = new();
            for (int i = 1; i <= 10; i++)
            {
                int portalId = 1;
                if (i > 5) portalId = 2;
                
                posts.Add(new Post { Id = i, Description = "Agregado con data seeding" + i, PortalId = portalId });
            }

            builder.HasData(posts);
        }
    }
}
