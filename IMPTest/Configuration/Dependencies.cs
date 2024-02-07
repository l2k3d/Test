using IMPTest.Application.Configuration;

namespace IMPTest.Api.Configuration;

public static class Dependencies
{
    public static void ConfigureDependencies(this IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);
        services.ApplicationLayerConfig();
        services.AddControllers();
        services.AddHealthChecks();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
