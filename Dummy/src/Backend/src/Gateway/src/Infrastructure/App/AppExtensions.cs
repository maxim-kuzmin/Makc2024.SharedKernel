namespace Makc2024.Dummy.Gateway.Infrastructure.App;

public static class AppExtensions
{
  public static IServiceCollection AddAppInfrastructureLayer(
    this IServiceCollection services,
    Microsoft.Extensions.Logging.ILogger logger,
    AppConfigOptions appConfigOptions,
    IConfiguration configuration,
    IConfigurationSection appConfigSection)
  {
    Guard.Against.Null(logger, nameof(logger));
    Guard.Against.Null(appConfigOptions, nameof(appConfigOptions));
    Guard.Against.Null(configuration, nameof(configuration));
    Guard.Against.Null(appConfigSection, nameof(appConfigSection));

    services.AddSerilog(config => config.ReadFrom.Configuration(configuration));

    services.Configure<AppConfigOptions>(appConfigSection);

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    services.AddScoped<IEventDispatcher, EventDispatcher>();

    services.AddScoped<AppSession>();

    const string userAgent = "Makc2024.Dummy";

    string writerApiAddress = appConfigOptions.Writer.ApiAddress;

    Guard.Against.Empty(writerApiAddress, nameof(writerApiAddress));

    services.AddHttpClient(
        nameof(AppConfigOptionsWriter),
        client =>
        {
          client.BaseAddress = new Uri(writerApiAddress);

          client.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
        })
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
        {
          ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        });

    logger.LogInformation("Infrastructure layer added");

    return services;
  }

  public static AppConfigOptions CreateAppConfigOptions(this IConfigurationSection appConfigSection)
  {
    var result = new AppConfigOptions();

    appConfigSection.Bind(result);

    return result;
  }
}
