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
    public class PriceListColumnValueConfiguration : IEntityTypeConfiguration<PriceListColValue>
    {
        public static readonly int stringValueLength = 450;
        public static readonly int textValueLength = 2000;

        public void Configure(EntityTypeBuilder<PriceListColValue> builder)
        {
            builder.Property(p => p.PriceListColValueType).IsRequired();
            builder.Property(p => p.Value).IsRequired().HasColumnType($"nvarchar").HasMaxLength(textValueLength);
            builder.Ignore(p => p.ObjectValue);
        }
    }
}
