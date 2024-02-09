using Test.Application.Configuration;

namespace Test.Api.Configuration;

public static class Dependencies
{
    public static void ConfigureDependencies(this IServiceCollection services)
    {
        services.ApplicationLayerConfig();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddControllers();
        services.AddHealthChecks();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
