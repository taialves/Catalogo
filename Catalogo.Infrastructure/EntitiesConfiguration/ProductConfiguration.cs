using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // configurando a chave primaria
            builder.HasKey(p => p.Id);

            // configurando o Id para ser gerado autoimaticamente
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            // configura a unicidade do codigo do produto
            builder.HasIndex(p => p.Code)
                .IsUnique();

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(4,2)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.ExpiryDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(p => p.Supplier)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.InitialStock)
                .HasColumnType("integer")
                .HasDefaultValue(1);

            // configurando uma propriedade como chave estrangeira
            builder.HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
