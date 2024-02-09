using Test.Data.Database;
using Test.Data.Database.Interfaces;
using Test.Data.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Data.Configuration;

public static class Dependencies
{
    public static void DataLayerConfig(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("WarehouseDb"));

        services.AddTransient<IProductRecordRepository, ProductRecordRepository>();
        services.AddTransient<ICapacityRecordRepository, CapacityRecordRepository>();
    }
}
