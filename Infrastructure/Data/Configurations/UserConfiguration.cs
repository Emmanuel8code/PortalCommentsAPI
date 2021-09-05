using ApplicationCore.Entities;
using ApplicationCore.Interfaces.ISecurity;
using Infrastructure.Security;
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

            DataSeeding(builder);
        }

        private static void DataSeeding(EntityTypeBuilder<User> builder)
        {
            IPasswordService passwordService = new PasswordService();
            string[] names = { "admin01", "Alvaro", "Andrea", "random01", "admin02", "Maya", "Emmanuel", "random02" };
            int portalId = 1;
            int roleId;
            for (int i = 0; i < 8; i++)
            {
                if (i > 3) 
                    portalId = 2;
                
                if (i == 0 || i == 4)
                {
                    roleId = 1;
                }
                else
                {
                    roleId = 2;
                }
               
                builder.HasData(
                    new User
                    {
                        Id = i + 1,
                        FirstName = names[i],
                        LastName = $"del portal{portalId}",
                        BirthDate = DateTime.ParseExact("19990501T00:00:00Z", "yyyyMMddTHH:mm:ssZ",
                                    System.Globalization.CultureInfo.InvariantCulture),
                        IsLegalAge = true,
                        Email = $"{names[i]}@example.com",
                        Password = passwordService.Hash("1234"),
                        NickName = names[i],
                        CreatedAt = DateTime.Now,
                        PortalId = portalId,
                        RoleId = roleId
                    });
            }
        }
    }
}
