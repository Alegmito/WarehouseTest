using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IWarehouseDbContext
    {
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PriceListColumn> PriceListColumns { get; set; }
        public DbSet<PriceListColValue> PriceListColValues { get; set; }
    }
}
