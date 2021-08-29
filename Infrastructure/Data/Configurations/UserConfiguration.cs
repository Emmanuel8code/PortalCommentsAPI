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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.NickName)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Password)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.BirthDate)
                 .IsRequired();

            builder.Property(e => e.IsLegalAge)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.UpdateAt);

            builder.Property(e => e.DeletedAt);

            builder.HasOne(e => e.Portal)
                .WithMany()
                .HasForeignKey(e => e.PortalId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); ;

            builder.HasIndex(e => new { e.NickName, e.Email, e.PortalId })
                .IsUnique();
        }
    }
}
