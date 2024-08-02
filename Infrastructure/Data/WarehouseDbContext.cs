using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
	public class WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : DbContext(options)
	{
		public DbSet<PriceList> PriceLists { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<PriceListColumn> PriceListColumns { get; set; }
		public DbSet<PriceListColValueString> PriceListColValuesInt { get; set; }
		public DbSet<PriceListColValueInt> PriceListColValuesString { get; set; }
		public DbSet<PriceListColValueText> PriceListColValuesText { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			new PriceListConfiguration().Configure(modelBuilder.Entity<PriceList>());
			new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
			new PriceListColumnConfiguration().Configure(modelBuilder.Entity<PriceListColumn>());
            new PriceListColumnValueConfiguration().Configure(modelBuilder.Entity<PriceListColValue>());

			modelBuilder.Entity<PriceListColValueString>()
				.Property(x => x.Value)
				.HasColumnType($"nvarchar({PriceListColumnValueConfiguration.stringValueLength})");
			modelBuilder.Entity<PriceListColValueString>()
				.Property(x => x.Value)
				.HasColumnName("value" + nameof(PriceListColValType.String));

            modelBuilder.Entity<PriceListColValueText>()
                .Property(x => x.Value)
                .HasColumnType($"nvarchar({PriceListColumnValueConfiguration.textValueLength})");
			modelBuilder.Entity<PriceListColValueText>()
				.Property(x => x.Value)
				.HasColumnName("value" + nameof(PriceListColValType.Text));

			modelBuilder.Entity<PriceListColValueInt>()
				.Property(x => x.Value)
				.HasColumnName("value" + nameof(PriceListColValType.Int));

            modelBuilder.Entity<PriceListColValue>()
              .HasDiscriminator<string>("value_type")
              .HasValue<PriceListColValueInt>(nameof(PriceListColValType.Int))
              .HasValue<PriceListColValueText>(nameof(PriceListColValType.Text))
              .HasValue<PriceListColValueString>(nameof(PriceListColValType.String));

        }
    }
}
