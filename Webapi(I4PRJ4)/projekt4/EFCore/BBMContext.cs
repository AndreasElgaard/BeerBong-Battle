using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using projekt4.Model;

namespace projekt4.EFCore
{
    public partial class BBMContext : IdentityDbContext<IdentityUser>
    {

        public BBMContext(DbContextOptions<BBMContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bruger>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Bruger>()
                .HasIndex(b => b.UserName)
                .IsUnique();

            modelBuilder.Entity<Bruger>()
                .HasIndex(b => b.PassWord)
                .IsUnique();

            //modelBuilder.Entity<Queue>()
            //    .Property(q => q.TimeStamp)
            //    .HasDefaultValueSql("GETDATE()");
        }

       

        public DbSet<Bruger> Brguers { get; set; }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Queue> Queues { get; set; }
    }
}
