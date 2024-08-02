using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class ServiceCollectionExtensionsDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
            var connectionStr = configuration.GetConnectionString("Warehouse");

            services.AddDbContext<WarehouseDbContext>((sp, options) =>
            {
                options.UseSqlServer(connectionStr);
            });

            services.AddScoped<WarehouseDbContextInitialiser>();

            return services;
        }

    }
}
