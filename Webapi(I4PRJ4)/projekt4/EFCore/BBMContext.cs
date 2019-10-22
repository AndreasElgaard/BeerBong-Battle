using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using projekt4.Model;

namespace projekt4.Model
{
    public partial class BBMContext : DbContext
    {
        public BBMContext(DbContextOptions<BBMContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Bruger> Bruger { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:bbm.database.windows.net,1433;Initial Catalog=Projekti4;Persist Security Info=False;User ID=au592631;Password=Xantos2012;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bruger>(entity =>
            {
                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Register> Register { get; set; }
        public DbSet<Bruger> Brguers { get; set; }
    }
}
