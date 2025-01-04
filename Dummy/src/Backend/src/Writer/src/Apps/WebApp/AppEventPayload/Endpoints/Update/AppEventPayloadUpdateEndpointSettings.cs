namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.Update;

/// <summary>
/// Настройки конечной точки обновления полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadUpdateEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppEventPayloadEndpointsSettings.Root}/{{id:long}}";
}
