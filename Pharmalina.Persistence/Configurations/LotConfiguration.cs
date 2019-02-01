using Microsoft.EntityFrameworkCore;
using Pharmalina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmalina.Persistence.Configurations
{
    class LotConfiguration : IEntityTypeConfiguration<Lot>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Lot> builder)
        {
            builder.HasKey(e => e.lotId);

            builder.Property(e => e.lotId).ValueGeneratedNever();

            builder.Property(e => e.Codelot)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Dateexp);

            builder.Property(e => e.Nlot)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Ppa);

            builder.Property(e => e.Prixdachat);

            builder.Property(e => e.Prixgros);

            builder.Property(e => e.Prixvente);

            builder.Property(e => e.Shp);

            builder.HasOne(d => d.CleproduitNavigation)
                .WithMany(p => p.Lot)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
