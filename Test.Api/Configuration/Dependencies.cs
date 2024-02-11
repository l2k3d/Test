using Test.Application.Configuration;

namespace Test.Api.Configuration;

public static class Dependencies
{
    public static void ConfigureDependencies(this IServiceCollection services)
    {
        services.ApplicationLayerConfig();
        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddControllers();
        services.AddHealthChecks();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void ConfigureMiddleware(this WebApplication app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.MapHealthChecks("/health");
    }
}
