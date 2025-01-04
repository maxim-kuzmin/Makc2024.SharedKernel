namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.Get;

/// <summary>
/// Настройки конечной точки получения события приложения.
/// </summary>
public class AppEventGetEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppEventEndpointsSettings.Root}/{{id:long}}";
}
