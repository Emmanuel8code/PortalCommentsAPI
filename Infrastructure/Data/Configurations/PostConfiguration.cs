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
        }
    }
}
