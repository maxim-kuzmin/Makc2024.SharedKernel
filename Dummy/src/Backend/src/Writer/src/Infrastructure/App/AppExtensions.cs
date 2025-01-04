namespace Makc2024.Dummy.Writer.Infrastructure.App;

public static class AppExtensions
{
  public static IServiceCollection AddAppInfrastructureLayer(
    this IServiceCollection services,
    Microsoft.Extensions.Logging.ILogger logger,
    AppConfigOptions appConfigOptions,    
    IConfiguration configuration,
    IConfigurationSection appConfigSection)
  {
    services.AddSerilog(config => config.ReadFrom.Configuration(configuration));

    services.Configure<AppConfigOptions>(appConfigSection);

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    services.AddScoped<IEventDispatcher, EventDispatcher>();

    var connectionStringTemplate = configuration.GetConnectionString(
      appConfigOptions.PostgreSQL.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate, nameof(connectionStringTemplate));

    string connectionString = appConfigOptions.PostgreSQL.ToConnectionString(connectionStringTemplate);

    AppDbContext.Init(new AppDbSettingsForPostgreSQL());

    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entitiesDbSettings = appDbSettings.Entities;

    services.AddSingleton(entitiesDbSettings.AppEvent);
    services.AddSingleton(entitiesDbSettings.AppEventPayload);
    services.AddSingleton(entitiesDbSettings.DummyItem);

    services.AddSingleton<IAppEventFactory, AppEventFactory>();
    services.AddSingleton<IAppEventPayloadFactory, AppEventPayloadFactory>();
    services.AddSingleton<IDummyItemFactory, DummyItemFactory>();

    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));    

    services.AddScoped(typeof(IRepository<>), typeof(AppRepositoryBase<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(AppRepositoryBase<>));

    services.AddScoped<AppSession>();

    services.AddScoped<IDummyItemRepository, DummyItemRepository>();

    services.AddTransient<IAppActionCommandService, AppCommandService>();
    services.AddTransient<IDummyItemActionCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemActionQueryService, DummyItemQueryService>();

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

      //await context.Database.MigrateAsync().ConfigureAwait(false);
      await context.Database.EnsureCreatedAsync().ConfigureAwait(false);

      await AppData.InitializeAsync(context).ConfigureAwait(false);

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
