using IMPTest.Data.Interfaces;
using IMPTest.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IMPTest.Data.Configuration;

public static class Dependencies
{
    public static void DataLayerConfig(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("WarehouseDb"));

        services.AddTransient<IProductRecordRepository, ProductRecordRepository>();
        services.AddTransient<ICapacityRecordRepository, CapacityRecordRepository>();
    }
}
