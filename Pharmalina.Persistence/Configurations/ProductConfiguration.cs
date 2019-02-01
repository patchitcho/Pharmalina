using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmalina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmalina.Persistence.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);

            builder.Property(e => e.ProductId).ValueGeneratedOnAdd();//.ValueGeneratedNever();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Dernierprixdachat);

            builder.Property(e => e.Designation)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Fulldesignation).IsRequired();

            builder.Property(e => e.Pmp);

            builder.Property(e => e.Prixdachatmax);

            builder.Property(e => e.Prixdachatmin);

            builder.Property(e => e.Prixdevente);

            builder.Property(e => e.Prixdeventemax);

            builder.Property(e => e.Prixdeventemin);

            builder.Property(e => e.Reference)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Remarque)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Unite)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
