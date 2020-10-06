﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(GameDbContext))]
    partial class GameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Domain.CareTaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EMailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("HasCar")
                        .HasColumnType("bit");

                    b.Property<bool>("HasPassedTrainingScoringTable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("CareTakers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HasCar = true,
                            HasPassedTrainingScoringTable = false,
                            Name = "Johan",
                            PhoneNumber = 0,
                            PlayerId = 1
                        },
                        new
                        {
                            Id = 2,
                            HasCar = true,
                            HasPassedTrainingScoringTable = false,
                            Name = "Manuela",
                            PhoneNumber = 0,
                            PlayerId = 1
                        },
                        new
                        {
                            Id = 3,
                            HasCar = false,
                            HasPassedTrainingScoringTable = false,
                            Name = "Inge",
                            PhoneNumber = 0,
                            PlayerId = 2
                        });
                });

            modelBuilder.Entity("Core.Domain.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coaches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tim"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Iris"
                        });
                });

            modelBuilder.Entity("Core.Domain.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoachId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsHomeGame")
                        .HasColumnType("bit");

                    b.Property<int?>("LaundryDutyId")
                        .HasColumnType("int");

                    b.Property<int?>("OpponentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlayTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("LaundryDutyId");

                    b.HasIndex("OpponentId");

                    b.HasIndex("TeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Core.Domain.Opponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Opponents");
                });

            modelBuilder.Entity("Core.Domain.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerNumber")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gender = 0,
                            Name = "Agnes",
                            PlayerNumber = 10,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            Gender = 0,
                            Name = "Linda",
                            PlayerNumber = 2,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 3,
                            Gender = 0,
                            Name = "Debbie",
                            PlayerNumber = 3,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 4,
                            Gender = 0,
                            Name = "Sena",
                            PlayerNumber = 4,
                            TeamId = 1
                        });
                });

            modelBuilder.Entity("Core.Domain.PlayerGame", b =>
                {
                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.HasKey("PlayerID", "GameID");

                    b.HasIndex("GameID");

                    b.ToTable("PlayerGames");
                });

            modelBuilder.Entity("Core.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "VU16"
                        });
                });

            modelBuilder.Entity("Core.Domain.CareTaker", b =>
                {
                    b.HasOne("Core.Domain.Game", null)
                        .WithMany("Drivers")
                        .HasForeignKey("GameId");

                    b.HasOne("Core.Domain.Player", "Player")
                        .WithMany("CareTakers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.Game", b =>
                {
                    b.HasOne("Core.Domain.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId");

                    b.HasOne("Core.Domain.CareTaker", "LaundryDuty")
                        .WithMany()
                        .HasForeignKey("LaundryDutyId");

                    b.HasOne("Core.Domain.Opponent", "Opponent")
                        .WithMany()
                        .HasForeignKey("OpponentId");

                    b.HasOne("Core.Domain.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Core.Domain.Opponent", b =>
                {
                    b.OwnsOne("Core.Domain.Address", "PlayingAddress", b1 =>
                        {
                            b1.Property<int>("OpponentId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Extension")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Number")
                                .HasColumnType("int");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OpponentId");

                            b1.ToTable("Opponents");

                            b1.WithOwner()
                                .HasForeignKey("OpponentId");
                        });
                });

            modelBuilder.Entity("Core.Domain.Player", b =>
                {
                    b.HasOne("Core.Domain.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.PlayerGame", b =>
                {
                    b.HasOne("Core.Domain.Game", "Game")
                        .WithMany("PlayerGames")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Player", "Player")
                        .WithMany("PlayerGames")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
