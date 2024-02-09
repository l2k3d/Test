using Test.Application.Interfaces;
using Test.Application.Services;
using Test.Data.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Application.Configuration;

public static class Dependencies
{
    public static void ApplicationLayerConfig(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<ICapacityService, CapacityService>();
        services.AddAutoMapper(typeof(AutoMapperConfiguration));

        services.DataLayerConfig();

    }
}
