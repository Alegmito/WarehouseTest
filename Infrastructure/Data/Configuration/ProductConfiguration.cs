using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public static readonly int nameLength = 450;
        public static readonly int codeLength = 100;
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasColumnType($"nvarchar({nameLength})");
            // When users added index must be unique for current user
            builder.HasIndex(b => b.Code).IsUnique();
            builder.Property(b => b.Code).HasColumnType($"nvarchar({codeLength})");

            builder.HasMany(b => b.priceListColumnValues)
              .WithOne(b => b.Product);
        }
    }
}
