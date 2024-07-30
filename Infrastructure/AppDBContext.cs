using Domain.Entities;
using Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
  public class AppDBContext : DbContext
  {
    public DbSet<PriceList> PriceLists { get; set; }
    public DbSet<Product> Products {  get; set; }
    public DbSet<PriceListColumn> Columns { get; set; }

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      new PriceListConfiguration().Configure(modelBuilder.Entity<PriceList>());
      new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
      new PriceListColumnConfiguration().Configure(modelBuilder.Entity<PriceListColumn>());
    }
  }
}
