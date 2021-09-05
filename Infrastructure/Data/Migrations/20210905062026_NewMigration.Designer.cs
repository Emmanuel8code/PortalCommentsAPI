﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210905062026_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Hola, soy admin01",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(66),
                            PostId = 3,
                            Title = "Comentario1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 11,
                            Content = "Lorem ipsum prueba, 3",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(159),
                            PostId = 3,
                            Title = "Comentario11",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Hola, soy Alvaro",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(853),
                            PostId = 4,
                            Title = "Comentario2",
                            UserId = 2
                        },
                        new
                        {
                            Id = 12,
                            Content = "Lorem ipsum prueba, 4",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(869),
                            PostId = 4,
                            Title = "Comentario12",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "Hola, soy Andrea",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(894),
                            PostId = 4,
                            Title = "Comentario3",
                            UserId = 3
                        },
                        new
                        {
                            Id = 13,
                            Content = "Lorem ipsum prueba, 4",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1117),
                            PostId = 4,
                            Title = "Comentario13",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Content = "Hola, soy random01",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1165),
                            PostId = 3,
                            Title = "Comentario4",
                            UserId = 4
                        },
                        new
                        {
                            Id = 14,
                            Content = "Lorem ipsum prueba, 3",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1177),
                            PostId = 3,
                            Title = "Comentario14",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Content = "Hola, soy admin02",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1198),
                            PostId = 7,
                            Title = "Comentario5",
                            UserId = 5
                        },
                        new
                        {
                            Id = 15,
                            Content = "Lorem ipsum prueba, 7",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1210),
                            PostId = 7,
                            Title = "Comentario15",
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            Content = "Hola, soy Maya",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1234),
                            PostId = 7,
                            Title = "Comentario6",
                            UserId = 6
                        },
                        new
                        {
                            Id = 16,
                            Content = "Lorem ipsum prueba, 7",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1247),
                            PostId = 7,
                            Title = "Comentario16",
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            Content = "Hola, soy Emmanuel",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1265),
                            PostId = 7,
                            Title = "Comentario7",
                            UserId = 7
                        },
                        new
                        {
                            Id = 17,
                            Content = "Lorem ipsum prueba, 7",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1276),
                            PostId = 7,
                            Title = "Comentario17",
                            UserId = 7
                        },
                        new
                        {
                            Id = 8,
                            Content = "Hola, soy random02",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1293),
                            PostId = 8,
                            Title = "Comentario8",
                            UserId = 8
                        },
                        new
                        {
                            Id = 18,
                            Content = "Lorem ipsum prueba, 8",
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1304),
                            PostId = 8,
                            Title = "Comentario18",
                            UserId = 8
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.Portal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLegalAgeRequired")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Portals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 429, DateTimeKind.Local).AddTicks(128),
                            IsLegalAgeRequired = true,
                            Name = "Faceback"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 432, DateTimeKind.Local).AddTicks(8314),
                            IsLegalAgeRequired = true,
                            Name = "Instaclan"
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PortalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PortalId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Agregado con data seeding1",
                            PortalId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Agregado con data seeding2",
                            PortalId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Agregado con data seeding3",
                            PortalId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Agregado con data seeding4",
                            PortalId = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Agregado con data seeding5",
                            PortalId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Agregado con data seeding6",
                            PortalId = 2
                        },
                        new
                        {
                            Id = 7,
                            Description = "Agregado con data seeding7",
                            PortalId = 2
                        },
                        new
                        {
                            Id = 8,
                            Description = "Agregado con data seeding8",
                            PortalId = 2
                        },
                        new
                        {
                            Id = 9,
                            Description = "Agregado con data seeding9",
                            PortalId = 2
                        },
                        new
                        {
                            Id = 10,
                            Description = "Agregado con data seeding10",
                            PortalId = 2
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Registered"
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsLegalAge")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PortalId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PortalId");

                    b.HasIndex("RoleId");

                    b.HasIndex("NickName", "Email", "PortalId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 523, DateTimeKind.Local).AddTicks(8632),
                            Email = "admin01@example.com",
                            FirstName = "admin01",
                            IsLegalAge = true,
                            LastName = "del portal1",
                            NickName = "admin01",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            PortalId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(4695),
                            Email = "Alvaro@example.com",
                            FirstName = "Alvaro",
                            IsLegalAge = true,
                            LastName = "del portal1",
                            NickName = "Alvaro",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            PortalId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(4991),
                            Email = "Andrea@example.com",
                            FirstName = "Andrea",
                            IsLegalAge = true,
                            LastName = "del portal1",
                            NickName = "Andrea",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            PortalId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(5293),
                            Email = "random01@example.com",
                            FirstName = "random01",
                            IsLegalAge = true,
                            LastName = "del portal1",
                            NickName = "random01",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            PortalId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(5554),
                            Email = "admin02@example.com",
                            FirstName = "admin02",
                            IsLegalAge = true,
                            LastName = "del portal2",
                            NickName = "admin02",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            PortalId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(5869),
                            Email = "Maya@example.com",
                            FirstName = "Maya",
                            IsLegalAge = true,
                            LastName = "del portal2",
                            NickName = "Maya",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            PortalId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(6068),
                            Email = "Emmanuel@example.com",
                            FirstName = "Emmanuel",
                            IsLegalAge = true,
                            LastName = "del portal2",
                            NickName = "Emmanuel",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            PortalId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(6256),
                            Email = "random02@example.com",
                            FirstName = "random02",
                            IsLegalAge = true,
                            LastName = "del portal2",
                            NickName = "random02",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            PortalId = 2,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.Comment", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Post", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Portal", "Portal")
                        .WithMany()
                        .HasForeignKey("PortalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portal");
                });

            modelBuilder.Entity("ApplicationCore.Entities.User", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Portal", "Portal")
                        .WithMany()
                        .HasForeignKey("PortalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portal");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
