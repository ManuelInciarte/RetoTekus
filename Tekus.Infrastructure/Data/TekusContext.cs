using Microsoft.EntityFrameworkCore;
using Tekus.Core.Entities;

#nullable disable

namespace Tekus.Infrastructure.Data
{
    public partial class TekusContext : DbContext
    {
        public TekusContext()
        {
        }

        public TekusContext(DbContextOptions<TekusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblProvider> TblProviders { get; set; }
        public virtual DbSet<TblService> TblServices { get; set; }
        public virtual DbSet<TblServiceProvider> TblServiceProviders { get; set; }

  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TblProvider>(entity =>
            {
                entity.ToTable("tblProvider");

                entity.Property(e => e.AddressProvider)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmailProvider)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NameProvider)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TelfProvider)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblService>(entity =>
            {
                entity.ToTable("tblService");

                entity.Property(e => e.NameService)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblServiceProvider>(entity =>
            {
                entity.ToTable("tblServiceProvider");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CostHour).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.CountryAvailable)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.TblServiceProviders)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("provider-service");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.TblServiceProviders)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("service-provider");
            });

  
        }

      }
}
