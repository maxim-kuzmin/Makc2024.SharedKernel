﻿namespace Makc2024.Dummy.Writer.Infrastructure.App;

public static class AppExtensions
{
  public static IServiceCollection AddAppInfrastructureLayer(
    this IServiceCollection services,
    Microsoft.Extensions.Logging.ILogger logger,
    AppConfigOptions appConfigOptions,
    IHostBuilder hostBuilder,
    IConfiguration configuration,
    IConfigurationSection appConfigSection)
  {
    services.AddSerilog(config => config.ReadFrom.Configuration(configuration));

    services.Configure<AppConfigOptions>(appConfigSection);

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    services.AddScoped<IEventDispatcher, EventDispatcher>();

    var connectionStringTemplate = configuration.GetConnectionString(
      appConfigOptions.PostgreSQL.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate, nameof(connectionStringTemplate));

    string connectionString = appConfigOptions.PostgreSQL.ToConnectionString(connectionStringTemplate);

    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(AppRepositoryBase<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(AppRepositoryBase<>));

    services.AddScoped<AppSession>();

    services.AddScoped<IDummyItemRepository, DummyItemRepository>();

    logger.LogInformation("Infrastructure layer added");

    return services;
  }

  public static async Task UseAppInfrastructureLayerAsync(
    this IHost app,
    Microsoft.Extensions.Logging.ILogger logger)
  {
    using var scope = app.Services.CreateScope();

    var scopedServices = scope.ServiceProvider;

    try
    {
      var context = scopedServices.GetRequiredService<AppDbContext>();

      //await context.Database.MigrateAsync();
      await context.Database.EnsureCreatedAsync();

      await AppData.InitializeAsync(context);

      logger.LogInformation("Infrastructure layer used");
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
  }

  public static AppConfigOptions CreateAppConfigOptions(this IConfigurationSection appConfigSection)
  {
    var result = new AppConfigOptions();

    appConfigSection.Bind(result);

    return result;
  }
}
