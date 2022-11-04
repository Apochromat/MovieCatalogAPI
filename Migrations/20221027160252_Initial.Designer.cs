﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webNET_Hits_backend_aspnet_project_1;

#nullable disable

namespace webNET_Hits_backend_aspnet_project_1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221027160252_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<Guid>("MovieGenresGenreId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MovieGenresMovieId")
                        .HasColumnType("char(36)");

                    b.HasKey("MovieGenresGenreId", "MovieGenresMovieId");

                    b.HasIndex("MovieGenresMovieId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.Property<Guid>("UserFavoritesMovieId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserFavoritesUserId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserFavoritesMovieId", "UserFavoritesUserId");

                    b.HasIndex("UserFavoritesUserId");

                    b.ToTable("MovieUser");
                });

            modelBuilder.Entity("webNET_Hits_backend_aspnet_project_1.Models.Genre", b =>
                {
                    b.Property<Guid>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("webNET_Hits_backend_aspnet_project_1.Models.Movie", b =>
                {
                    b.Property<Guid>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("AgeLimit")
                        .HasColumnType("int");

                    b.Property<int?>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Director")
                        .HasColumnType("longtext");

                    b.Property<int?>("Fees")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PosterLink")
                        .HasColumnType("longtext");

                    b.Property<string>("Tagline")
                        .HasColumnType("longtext");

                    b.Property<int?>("Time")
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("webNET_Hits_backend_aspnet_project_1.Models.Review", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("MovieId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("ReviewId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("webNET_Hits_backend_aspnet_project_1.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AvatarLink")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("webNET_Hits_backend_aspnet_project_1.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("MovieGenresGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webNET_Hits_backend_aspnet_project_1.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieGenresMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.HasOne("webNET_Hits_backend_aspnet_project_1.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("UserFavoritesMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webNET_Hits_backend_aspnet_project_1.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserFavoritesUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webNET_Hits_backend_aspnet_project_1.Models.Review", b =>
                {
                    b.HasOne("webNET_Hits_backend_aspnet_project_1.Models.Movie", null)
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId");

                    b.HasOne("webNET_Hits_backend_aspnet_project_1.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("webNET_Hits_backend_aspnet_project_1.Models.Movie", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
