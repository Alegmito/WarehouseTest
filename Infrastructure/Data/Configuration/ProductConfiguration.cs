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
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.Property(b => b.Name);
      builder.HasIndex(b => b.Code).IsUnique();

      builder.HasMany(b => b.PriceLists);
      builder.HasMany(b => b.priceListColumns);
    }
  }
}
