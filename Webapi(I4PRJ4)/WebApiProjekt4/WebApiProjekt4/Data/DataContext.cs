using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiProjekt4.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Stats> Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stats>()
                .Property(s => s.DateTime)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Queue>()
                .HasMany(b => b.Players)
                .WithOne(p => p.Queue)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Game>()
                .HasMany(c => c.Players)
                .WithOne(c => c.Game)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Player>()
                .HasMany(c => c.Stats)
                .WithOne(c => c.Player)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LeaderBoard>()
                .HasMany(l => l.Players)
                .WithOne(c => c.LeaderBoard)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
