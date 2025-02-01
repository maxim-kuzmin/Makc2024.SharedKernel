namespace Makc2024.Dummy.Writer.Infrastructure.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить уровень инфраструктуры приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <param name="configuration">Конфигурация.</param>
  /// <param name="appConfigSection">Раздел конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureLayer(
    this IServiceCollection services,
    Microsoft.Extensions.Logging.ILogger logger,
    AppConfigOptions appConfigOptions,    
    IConfiguration configuration,
    IConfigurationSection appConfigSection)
  {
    services.AddSerilog(config => config.ReadFrom.Configuration(configuration));

    services.AddJsonLocalization();

    services.Configure<AppConfigOptions>(appConfigSection);

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    var connectionStringTemplate = configuration.GetConnectionString(
      appConfigOptions.PostgreSQL.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate, nameof(connectionStringTemplate));

    string connectionString = appConfigOptions.PostgreSQL.ToConnectionString(connectionStringTemplate);

    AppDbContext.Init(new AppDbSettingsForPostgreSQL());

    var appDbSettings = AppDbContext.GetAppDbSettings();

    services.AddSingleton(appDbSettings);

    services.AddSingleton(appDbSettings.Entities.AppEvent);
    services.AddSingleton(appDbSettings.Entities.AppEventPayload);
    services.AddSingleton(appDbSettings.Entities.DummyItem);

    var appDomainSettings = new AppDomainSettings(appDbSettings.Entities);

    services.AddSingleton(appDomainSettings.AppEvent);
    services.AddSingleton(appDomainSettings.AppEventPayload);
    services.AddSingleton(appDomainSettings.DummyItem);
        
    services.AddSingleton<IAppEventFactory, AppEventFactory>();
    services.AddSingleton<IAppEventPayloadFactory, AppEventPayloadFactory>();
    services.AddSingleton<IDummyItemFactory, DummyItemFactory>();

    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

    services.AddScoped<IAppDbExecutor, AppDbExecutor>();
    services.AddScoped<IAppDbHelperForSQL, AppDbContext>();

    services.AddScoped(typeof(IRepository<>), typeof(AppRepositoryBase<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(AppRepositoryBase<>));

    services.AddScoped<AppSession>();

    services.AddScoped<IAppEventRepository, AppEventRepository>();
    services.AddScoped<IAppEventPayloadRepository, AppEventPayloadRepository>();
    services.AddScoped<IDummyItemRepository, DummyItemRepository>();

    services.AddTransient<IAppActionCommandService, AppActionCommandService>();
    services.AddTransient<IAppEventActionCommandService, AppEventActionCommandService>();
    services.AddTransient<IAppEventActionQueryService, AppEventActionQueryService>();
    services.AddTransient<IAppEventResources, AppEventResources>();

    services.AddTransient<IAppEventPayloadActionCommandService, AppEventPayloadActionCommandService>();
    services.AddTransient<IAppEventPayloadActionQueryService, AppEventPayloadActionQueryService>();
    services.AddTransient<IAppEventPayloadResources, AppEventPayloadResources>();

    services.AddTransient<IAppSynchronizationActionCommandService, AppSynchronizationActionCommandService>();

    services.AddTransient<IDummyItemActionCommandService, DummyItemActionCommandService>();
    services.AddTransient<IDummyItemActionQueryService, DummyItemActionQueryService>();
    services.AddTransient<IDummyItemResources, DummyItemResources>();

    logger.LogInformation("Infrastructure layer added");

    return services;
  }

  /// <summary>
  /// Использовать уровень инфраструктуры приложения асинхронно.
  /// </summary>
  /// <param name="app">Приложение.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Задача.</returns>
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

  /// <summary>
  /// Создать параметры конфигурации приложения.
  /// </summary>
  /// <param name="appConfigSection">Раздел конфигурации приложения.</param>
  /// <returns>Параметры конфигурации приложения.</returns>
  public static AppConfigOptions CreateAppConfigOptions(this IConfigurationSection appConfigSection)
  {
    var result = new AppConfigOptions();

    appConfigSection.Bind(result);

    return result;
  }
}
