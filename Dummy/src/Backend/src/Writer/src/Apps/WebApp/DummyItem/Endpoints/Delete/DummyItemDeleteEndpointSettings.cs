namespace Makc2024.Dummy.Writer.Apps.WebApp.DummyItem.Endpoints.Delete;

/// <summary>
/// Настройки конечной точки удаления фиктивного предмета.
/// </summary>
public class DummyItemDeleteEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{DummyItemEndpointsSettings.Root}/{{id:long}}";
}
