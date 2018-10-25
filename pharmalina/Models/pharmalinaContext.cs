using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pharmalina.Models
{
    public partial class PharmalinaContext : DbContext
    {
        public PharmalinaContext()
        {
        }

        public PharmalinaContext(DbContextOptions<PharmalinaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lot> Lot { get; set; }
        public virtual DbSet<Produit> Produit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=pharmalina;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lot>(entity =>
            {
                entity.HasKey(e => e.Clelot);

                entity.Property(e => e.Clelot).ValueGeneratedNever();

                entity.Property(e => e.Codelot)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Dateexp).HasColumnType("date");

                entity.Property(e => e.Nlot)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ppa).HasColumnType("money");

                entity.Property(e => e.Prixdachat).HasColumnType("money");

                entity.Property(e => e.Prixgros).HasColumnType("money");

                entity.Property(e => e.Prixvente).HasColumnType("money");

                entity.Property(e => e.Shp).HasColumnType("money");

                entity.HasOne(d => d.CleproduitNavigation)
                    .WithMany(p => p.Lot)
                    .HasForeignKey(d => d.Cleproduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cleproduit");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.Cleproduit);

                entity.Property(e => e.Cleproduit).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Dernierprixdachat).HasColumnType("money");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fulldesignation).IsRequired();

                entity.Property(e => e.Pmp).HasColumnType("money");

                entity.Property(e => e.Prixdachatmax).HasColumnType("money");

                entity.Property(e => e.Prixdachatmin).HasColumnType("money");

                entity.Property(e => e.Prixdevente).HasColumnType("money");

                entity.Property(e => e.Prixdeventemax).HasColumnType("money");

                entity.Property(e => e.Prixdeventemin).HasColumnType("money");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remarque)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Unite)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
