using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.Data.Configuration
{
    public class PriceListConfiguration : IEntityTypeConfiguration<PriceList>
    {
        public static readonly int NameLength = 450;
        public void Configure(EntityTypeBuilder<PriceList> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasColumnType($"nvarchar({NameLength})");
            builder.Property(b => b.TimeCreated).IsRequired();

            builder
              .HasMany(b => b.Products)
              .WithMany(b => b.PriceLists);

            builder
              .HasMany(b => b.Columns)
              .WithOne(b => b.PriceList);
        }
    }
}
