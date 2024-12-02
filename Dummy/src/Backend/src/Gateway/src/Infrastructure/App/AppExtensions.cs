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
    services.AddSerilog(config => config.ReadFrom.Configuration(configuration));

    services.Configure<AppConfigOptions>(appConfigSection);

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    services.AddScoped<IEventDispatcher, EventDispatcher>();

    services.AddScoped<AppSession>();

    const string userAgent = "Makc2024.Dummy";

    string writerRestApiAddress = appConfigOptions.Writer.RestApiAddress;
    
    Guard.Against.Empty(writerRestApiAddress, nameof(writerRestApiAddress));

    services.AddHttpClient(
      AppSettings.WriterDummyItemClientName,
      httpClient =>
      {
        httpClient.BaseAddress = new Uri(writerRestApiAddress);

        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
      })
      .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
      {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
      });

    string writerGrpcApiAddress = appConfigOptions.Writer.GrpcApiAddress;

    services.AddGrpcClient<AppGrpc.AppGrpcClient>(
      AppSettings.WriterAppClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(writerGrpcApiAddress);
      });

    services.AddGrpcClient<DummyItemGrpc.DummyItemGrpcClient>(
      AppSettings.WriterDummyItemClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(writerGrpcApiAddress);
      })
      .AddCallCredentials((context, metadata, serviceProvider) =>
      {
        var appSession = serviceProvider.GetRequiredService<AppSession>();

        if (!string.IsNullOrWhiteSpace(appSession.AccessToken))
        {
          metadata.Add("Authorization", $"Bearer {appSession.AccessToken}");
        }
        
        return Task.CompletedTask;
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
