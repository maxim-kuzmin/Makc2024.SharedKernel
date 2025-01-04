namespace Makc2024.Dummy.Gateway.Infrastructure.App;

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

    services.Configure<AppConfigOptions>(appConfigSection);

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    services.AddScoped<IEventDispatcher, EventDispatcher>();

    services.AddScoped<AppSession>();

    services.AddTransient<IAppActionCommandService>(x =>
    {
      var appConfigOptions = x.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      return appConfigOptions.Value.Writer.Transport switch
      {
        AppTransport.Grpc => new AppActionCommandServiceForGrpc(x.GetRequiredService<WriterAppGrpcClient>()),
        AppTransport.Http => new AppActionCommandServiceForHttp(x.GetRequiredService<IHttpClientFactory>()),
        _ => throw new NotImplementedException()
      };
    });

    services.AddTransient<IDummyActionItemCommandService>(x =>
    {
      var appConfigOptions = x.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      return appConfigOptions.Value.Writer.Transport switch
      {
        AppTransport.Grpc => new DummyItemActionCommandServiceForGrpc(x.GetRequiredService<WriterDummyItemGrpcClient>()),
        AppTransport.Http => new DummyItemActionCommandServiceForHttp(x.GetRequiredService<IHttpClientFactory>()),
        _ => throw new NotImplementedException()
      };
    });

    services.AddTransient<IDummyItemActionQueryService>(x =>
    {
      var appConfigOptions = x.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      return appConfigOptions.Value.Writer.Transport switch
      {
        AppTransport.Grpc => new DummyItemActionQueryServiceForGrpc(
          x.GetRequiredService<AppSession>(),
          x.GetRequiredService<WriterDummyItemGrpcClient>()),
        AppTransport.Http => new DummyItemActionQueryServiceForHttp(
          x.GetRequiredService<AppSession>(),
          x.GetRequiredService<IHttpClientFactory>()),
        _ => throw new NotImplementedException()
      };
    });

    const string userAgent = nameof(Dummy);

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

    services.AddGrpcClient<WriterAppGrpcClient>(
      AppSettings.WriterAppClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(writerGrpcApiAddress);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    services.AddGrpcClient<WriterDummyItemGrpcClient>(
      AppSettings.WriterDummyItemClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(writerGrpcApiAddress);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    logger.LogInformation("Infrastructure layer added");

    return services;
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
