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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(e => e.Content)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Post)
                .WithMany()
                .HasForeignKey(e => e.PostId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.UpdateAt);

            builder.Property(e => e.DeletedAt);

            DataSeeding(builder);
        }

        private static void DataSeeding(EntityTypeBuilder<Comment> builder)
        {
            string[] names = { "admin01", "Alvaro", "Andrea", "random01", "admin02", "Maya", "Emmanuel", "random02" };
            int postId;
            var rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                if (i > 3)
                {
                    postId = rand.Next(7, 9);
                }
                else
                {
                    postId = rand.Next(3, 5);
                }
                builder.HasData(
                    new Comment { Id = i+1, Title = $"Comentario{i + 1}", Content = $"Hola, soy {names[i]}", UserId = i + 1, PostId = postId, CreatedAt = DateTime.Now },
                    new Comment { Id = i+11, Title = $"Comentario{i + 11}", Content = $"Lorem ipsum prueba, {postId}", UserId = i + 1, PostId = postId, CreatedAt = DateTime.Now }
                );
            }
            
            
        }
    }
}
