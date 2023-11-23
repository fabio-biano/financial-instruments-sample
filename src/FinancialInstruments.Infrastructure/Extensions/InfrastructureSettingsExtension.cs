namespace FinancialInstruments.Infrastructure.Extensions;

public static class InfrastructureSettingsExtension
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) => 
        services.AddDbContext<FinancialInstrumentsContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("FinancialInstruments.DbContext"),
                 x => x.MigrationsAssembly("FinancialInstruments.Migrations")));

    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            // options.InstanceName = "";
        });
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {   // Dependency injection
        services.AddScoped(typeof(IFinancialInstrumentCategoryRepository), typeof(FinancialInsrumentCategoryRepository));
        return services;
    }
}