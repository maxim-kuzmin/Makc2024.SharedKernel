namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.Update;

/// <summary>
/// Настройки конечной точки обновления события приложения.
/// </summary>
public class AppEventUpdateEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppEventEndpointsSettings.Root}/{{id:long}}";
}
