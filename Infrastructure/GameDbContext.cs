using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class GameDbContext : DbContext
    {
        public DbSet<Coach> Coaches { get; set; }
        
        public GameDbContext(DbContextOptions<GameDbContext> contextOptions) : base(contextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coach>().HasData(
                new Coach() {Id = 1, Name = "Tim"},
                new Coach() {Id = 2, Name = "Iris"});
        }
    }
}