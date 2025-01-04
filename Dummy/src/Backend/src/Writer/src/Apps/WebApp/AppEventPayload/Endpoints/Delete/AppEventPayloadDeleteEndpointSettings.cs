namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.Delete;

/// <summary>
/// Настройки конечной точки удаления полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadDeleteEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppEventPayloadEndpointsSettings.Root}/{{id:long}}";
}
