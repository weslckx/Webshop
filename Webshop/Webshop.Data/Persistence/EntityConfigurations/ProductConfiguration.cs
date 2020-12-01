using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;

namespace Webshop.Data.Persistence.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        // Not in constructor. Added to ModelBuilder using ApplyConfiguration in ShopDbContext
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(t => t.Name)
                .HasColumnName("Productnaam")
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(t => t.DescriptionShort)
                .HasColumnName("Korte omschrijving")
                .HasMaxLength(550)
                .IsRequired();
            builder
                .Property(t => t.Price)
                .HasColumnName("Prijs")
                .HasColumnType("decimal(5,2)")
                .IsRequired();
            builder
                .Property(t => t.DescriptionLong)
                .HasColumnName("Omschrijving");
            builder
                .Property(t => t.ImageUrl)
                .HasColumnName("Link naar afbeelding");


            
            

        }
    }
}
