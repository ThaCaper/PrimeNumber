using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PrimeDataHelper.Models
{
    public partial class PrimeDBContext : DbContext
    {
        public PrimeDBContext()
        {
        }

        public PrimeDBContext(DbContextOptions<PrimeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Prime> IsPrimes { get; set; }
        public virtual DbSet<PrimeRange> NumOfPrimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3H3D783;Database=PrimeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Prime>(entity =>
            {
                entity.ToTable("IsPrime");

                entity.Property(e => e.IsPrime).HasColumnName("IsPrime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
