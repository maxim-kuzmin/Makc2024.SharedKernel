namespace Makc2024.Dummy.Gateway.Infrastructure.App;

public static class AppExtensions
{
  public static IServiceCollection AddAppInfrastructureLayer(
    this IServiceCollection services,
    Microsoft.Extensions.Logging.ILogger logger,
    IConfiguration configuration,
    IHostBuilder hostBuilder)
  {
    Guard.Against.Null(logger, nameof(logger));
    Guard.Against.Null(configuration, nameof(configuration));
    Guard.Against.Null(hostBuilder, nameof(hostBuilder));

    hostBuilder.UseSerilog((_, config) => config.ReadFrom.Configuration(configuration));

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    services.AddScoped<IEventDispatcher, EventDispatcher>();

    var appConfigSection = configuration.GetSection(AppConfigOptions.SectionKey);

    services.Configure<AppConfigOptions>(appConfigSection);

    var appConfig = new AppConfigOptions();

    appConfigSection.Bind(appConfig);

    const string userAgent = "Makc2024.Dummy";

    string writerApiAddress = appConfig.Writer.ApiAddress;

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

    logger.LogInformation("{Layer} layer added", nameof(Infrastructure));

    return services;
  }
}
