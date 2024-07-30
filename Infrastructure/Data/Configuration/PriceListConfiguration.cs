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
  public class PriceListConfiguration : IEntityTypeConfiguration<PriceList>
  {
    public void Configure(EntityTypeBuilder<PriceList> builder)
    {
      builder.Property(b => b.Name).IsRequired();

      builder
        .OwnsMany(b => b.Products);

      builder
        .OwnsMany(b => b.Columns);
    }
  }
}
