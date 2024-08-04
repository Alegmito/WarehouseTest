using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configuration
{
    public class PriceListColumnConfiguration : IEntityTypeConfiguration<PriceListColumn>
    {
        public readonly int nameLength = 450;
        public void Configure(EntityTypeBuilder<PriceListColumn> builder)
        {
            builder.Property(t => t.Name)
              .IsRequired().HasColumnType($"nvarchar({nameLength})");
            builder.Property(t => t.PriceListColValType).HasDefaultValue(PriceListColValType.Int).IsRequired();

            builder.HasOne(b => b.PriceList);

            builder.HasMany(b => b.PriceListColValues)
                .WithOne(b => b.PriceListColumn)
                .HasForeignKey(b => b.PriceListColumnId)
                .IsRequired();
        }
    }
}
