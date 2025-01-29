namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload;

/// <summary>
/// Фабрика полезной нагрузки события приложения.
/// </summary>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppEventPayloadFactory(
  IAppEventPayloadResources _resources,
  AppEventPayloadSettings _settings) : IAppEventPayloadFactory
{
  /// <inheritdoc/>
  public AppEventPayloadAggregate CreateAggregate(AppEventPayloadEntity? entityFromDb = null)
  {
    return new(entityFromDb, _resources, _settings);
  }
}
