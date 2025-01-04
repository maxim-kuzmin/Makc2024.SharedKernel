namespace Makc2024.Dummy.Writer.DomainUseCases.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить уровень вариантов использования домена приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppDomainUseCasesLayer(
    this IServiceCollection services,
    ILogger logger)
  {
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    logger.LogInformation("DomainUseCases layer added");

    return services;
  }
}
