using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;



namespace Infrastructure.Data
{

	public static class InitializerExtenstions
	{
		public static async Task InitialiseDatabaseAsync(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var initializer = scope.ServiceProvider.GetRequiredService<WarehouseDbContextInitialiser>();
			await initializer.InitialiseAsync();
			await initializer.TrySeedAsync();
		}		 
	}

	public class WarehouseDbContextInitialiser(
          WarehouseDbContext context
        )
    {
		private readonly WarehouseDbContext _context = context;

        public async Task InitialiseAsync()
		{
			try
			{
				await _context.Database.MigrateAsync();
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public async Task TrySeedAsync()
		{
			if (await _context.PriceLists.AnyAsync() is true ||
			  await _context.Products.AnyAsync() is true)
				return;

			PriceList[] priceLists =
			{
		new PriceList()
		{
		  Name = "AlphaFestival",
		  TimeCreated = DateTime.Parse("2024-07-31"),
		},
		new PriceList()
		{
		  Name = "ComicCon2024",
		  TimeCreated = DateTime.Parse("2024-02-01"),
		}
	  };
			Product[] products =
			{
		new Product()
		{
		  Name = "Hudozhestvennii film Snatch, blu-ray",
		  Code = "00001",
		},
		new Product()
		{
		  Name = "Hateful eight",
		  Code = "00002",
		},
		new Product()
		{
		  Name = "Factorio: digital steam Key",
		  Code = "00003",
		},
		new Product()
		{
		  Name = "Mechanichal keyboard: RedSquare KeyroxTKL",
		  Code = "00004",
		},
		new Product()
		{
		  Name = "GameCartridge: Super mario 64",
		  Code = "00005",
		},
		new Product()
		{
		  Name = "Books: Song Of fire and Ice",
		  Code = "00006",
		},
		new Product()
		{
		  Name = "Figurka Guts Berserk",
		  Code = "00007",
		},
		new Product()
		{
		  Name = "Figurka Sinji Evangelion",
		  Code = "00008",
		},
		new Product()
		{
		  Name = "DDT: Prosvistiela Vynil",
		  Code = "00009",
		},
		new Product()
		{
		  Name = "Figurka Sinji Evangelion",
		  Code = "00010",
		},
	  };
			for (int i = 0; i < products.Length; i++)
			{
				Product product = products[i];
				product.PriceLists.Add(priceLists[0]);
			}

			for (int i = 0; i < products.Length / 4; i++)
			{
				Product product = products[i];
				product.PriceLists.Add(priceLists[0]);
			}

			PriceListColumn[] priceListColumns =
			{
		new PriceListColumn() {
		  Name = "TextColumn1",
		  PriceListColValType = Domain.Enums.PriceListColValType.Text,
		},
		new PriceListColumn() {
		  Name = "NumberColumn1",
		  PriceListColValType = Domain.Enums.PriceListColValType.String,
		},
		new PriceListColumn() {
		  Name = "StringColumn1",
		  PriceListColValType = Domain.Enums.PriceListColValType.String,
		},
	  };
			priceLists[0].Columns.AddRange(priceListColumns.Take(2));
			priceLists[1].Columns.AddRange(priceListColumns.Skip(2));

			foreach (var product in products)
				foreach (var priceList in product.PriceLists)
					foreach (var column in priceList.Columns)
					{
						var columnValue = PriceListColValue.Create(column.PriceListColValType);
						columnValue.PriceListColumn = column;
						columnValue.Product = product;
						column.PriceListColValues.Add(columnValue);
					}

			await _context.PriceLists.AddRangeAsync(priceLists);
			await _context.Products.AddRangeAsync(products);
			await _context.PriceListColumns.AddRangeAsync(priceListColumns);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch
			{
			}
		}
	}
}
