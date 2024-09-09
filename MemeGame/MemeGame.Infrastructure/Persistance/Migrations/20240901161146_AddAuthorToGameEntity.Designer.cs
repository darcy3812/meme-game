﻿// <auto-generated />
using System;
using MemeGame.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MemeGame.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240901161146_AddAuthorToGameEntity")]
    partial class AddAuthorToGameEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MemeGame.Domain.FileMetadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExternalStorage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdInExternalStorage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FilesMetadata");
                });

            modelBuilder.Entity("MemeGame.Domain.GameSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EndGameCondition")
                        .HasColumnType("integer");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("integer");

                    b.Property<int?>("MaxPoints")
                        .HasColumnType("integer");

                    b.Property<int?>("MaxRounds")
                        .HasColumnType("integer");

                    b.Property<int>("SecondsToAnswer")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("GameSettings");
                });

            modelBuilder.Entity("MemeGame.Domain.GameUsers.GameUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAuthor")
                        .HasColumnType("boolean");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameUsers");
                });

            modelBuilder.Entity("MemeGame.Domain.Games.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GameSettingsId")
                        .HasColumnType("integer");

                    b.Property<string>("Hash")
                        .HasColumnType("text");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GameSettingsId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("MemeGame.Domain.Meme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FileMetadataId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FileMetadataId");

                    b.ToTable("Memes");
                });

            modelBuilder.Entity("MemeGame.Domain.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("JudgeId")
                        .HasColumnType("integer");

                    b.Property<int>("SituationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("JudgeId");

                    b.HasIndex("SituationId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("MemeGame.Domain.RoundAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsBest")
                        .HasColumnType("boolean");

                    b.Property<int>("MemeId")
                        .HasColumnType("integer");

                    b.Property<int>("RoundId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MemeId");

                    b.HasIndex("RoundId");

                    b.HasIndex("UserId");

                    b.ToTable("RoundAnswers");
                });

            modelBuilder.Entity("MemeGame.Domain.Situation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Situations");
                });

            modelBuilder.Entity("MemeGame.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MemeGame.Domain.GameUsers.GameUser", b =>
                {
                    b.HasOne("MemeGame.Domain.Games.Game", "Game")
                        .WithMany("GameUsers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MemeGame.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MemeGame.Domain.Games.Game", b =>
                {
                    b.HasOne("MemeGame.Domain.Users.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MemeGame.Domain.GameSetting", "GameSettings")
                        .WithMany()
                        .HasForeignKey("GameSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("GameSettings");
                });

            modelBuilder.Entity("MemeGame.Domain.Meme", b =>
                {
                    b.HasOne("MemeGame.Domain.FileMetadata", "FileMetadata")
                        .WithMany()
                        .HasForeignKey("FileMetadataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileMetadata");
                });

            modelBuilder.Entity("MemeGame.Domain.Round", b =>
                {
                    b.HasOne("MemeGame.Domain.GameUsers.GameUser", "Judge")
                        .WithMany()
                        .HasForeignKey("JudgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MemeGame.Domain.Situation", "Situation")
                        .WithMany()
                        .HasForeignKey("SituationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Judge");

                    b.Navigation("Situation");
                });

            modelBuilder.Entity("MemeGame.Domain.RoundAnswer", b =>
                {
                    b.HasOne("MemeGame.Domain.Meme", "Meme")
                        .WithMany()
                        .HasForeignKey("MemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MemeGame.Domain.Round", "Round")
                        .WithMany("RoundAnswers")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MemeGame.Domain.GameUsers.GameUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meme");

                    b.Navigation("Round");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MemeGame.Domain.Games.Game", b =>
                {
                    b.Navigation("GameUsers");
                });

            modelBuilder.Entity("MemeGame.Domain.Round", b =>
                {
                    b.Navigation("RoundAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}