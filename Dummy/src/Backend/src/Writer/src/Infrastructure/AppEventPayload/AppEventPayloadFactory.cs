namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload;

/// <summary>
/// Фабрика полезной нагрузки события приложения.
/// </summary>
/// <param name="_settings">Настройки.</param>
public class AppEventPayloadFactory(AppEventPayloadSettings _settings) : IAppEventPayloadFactory
{
  /// <inheritdoc/>
  public AppEventPayloadAggregate CreateAggregate(long entityId = 0)
  {
    return new(entityId, _settings);
  }
}
