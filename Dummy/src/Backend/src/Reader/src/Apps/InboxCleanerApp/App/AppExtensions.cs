namespace Makc2024.Dummy.Reader.Apps.InboxCleanerApp.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить уровень пользовательского интерфейса приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppUILayer(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptions appConfigOptions)
  {
    services.AddHostedService<AppService>();

    logger.LogInformation("UI layer added");

    return services;
  }
}
