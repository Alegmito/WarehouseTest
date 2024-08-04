using Application;
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
	public class WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : DbContext(options), IWarehouseDbContext
	{
		public DbSet<PriceList> PriceLists { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<PriceListColumn> PriceListColumns { get; set; }
		public DbSet<PriceListColValue> PriceListColValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			new PriceListConfiguration().Configure(modelBuilder.Entity<PriceList>());
			new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
			new PriceListColumnConfiguration().Configure(modelBuilder.Entity<PriceListColumn>());
            new PriceListColumnValueConfiguration().Configure(modelBuilder.Entity<PriceListColValue>());
        }
    }
}
