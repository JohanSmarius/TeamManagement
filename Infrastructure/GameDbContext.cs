﻿using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class GameDbContext : DbContext
    {
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Opponent> Opponents { get; set; }
        
        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<PlayerGame> PlayerGames { get; set; }

        public DbSet<CareTaker> CareTakers { get; set; }
        
        public GameDbContext(DbContextOptions<GameDbContext> contextOptions) : base(contextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coach>().HasData(
                new Coach() {Id = 1, Name = "Tim"},
                new Coach() {Id = 2, Name = "Iris"});

            modelBuilder.Entity<Opponent>().HasIndex(o => o.Name).IsUnique();
            modelBuilder.Entity<Opponent>().OwnsOne<Address>(o => o.PlayingAddress);

            modelBuilder.Entity<Team>().HasData(
                new Team {Id = 1, Name = "VU16"});

            modelBuilder.Entity<PlayerGame>().HasKey(pg => new {pg.PlayerID, pg.GameID});
            modelBuilder.Entity<PlayerGame>().HasOne(pg => pg.Game).WithMany(game => game.PlayerGames);
            modelBuilder.Entity<PlayerGame>().HasOne(pg => pg.Player).WithMany(player => player.PlayerGames);

            modelBuilder.Entity<Player>().HasData(
                new Player {Id = 1, TeamId = 1, Name = "Agnes", PlayerNumber = 1},
                new Player {Id = 2, TeamId = 1, Name = "Linda", PlayerNumber = 2},
                new Player {Id = 3, TeamId = 1, Name = "Debbie", PlayerNumber = 3},
                new Player {Id = 4, TeamId = 1, Name = "Sena", PlayerNumber = 4}

            );

        }
    }
}