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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // definindo a chave primaria
            builder.HasKey(c => c.Id);

            // definindo o auto-incremento
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);

            // Definindo indice unico para a coluna Name
            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Frutas"),
                new Category(3, "Bebida")
                );
        }
    }
}
