using IMPTest.Application.Interfaces;
using IMPTest.Application.Services;
using IMPTest.Data.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IMPTest.Application.Configuration;

public static class Dependencies
{
    public static void ApplicationLayerConfig(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        services.AddAutoMapper(typeof(AutoMapperConfiguration));

        services.DataLayerConfig();

    }
}
