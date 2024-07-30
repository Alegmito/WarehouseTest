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
  internal class PriceListColumnConfiguration : IEntityTypeConfiguration<PriceListColumn>
  {
    public void Configure(EntityTypeBuilder<PriceListColumn> builder)
    {
      builder.Property(t => t.Name)
        .IsRequired();

      builder.HasOne(b => b.Product);
      builder.HasOne(b => b.PriceList);
    }
  }
}
