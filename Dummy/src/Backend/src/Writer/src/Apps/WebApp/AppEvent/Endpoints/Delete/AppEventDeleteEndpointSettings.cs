namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.Delete;

/// <summary>
/// Настройки конечной точки удаления события приложения.
/// </summary>
public class AppEventDeleteEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppEventEndpointsSettings.Root}/{{id:long}}";
}
