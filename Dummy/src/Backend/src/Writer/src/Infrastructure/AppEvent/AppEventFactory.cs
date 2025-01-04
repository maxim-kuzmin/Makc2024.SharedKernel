namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent;

/// <summary>
/// Фабрика события приложения.
/// </summary>
/// <param name="_settings">Настройки.</param>
public class AppEventFactory(AppEventSettings _settings) : IAppEventFactory
{
  /// <inheritdoc/>
  public AppEventAggregate CreateAggregate(long entityId = 0)
  {
    return new(entityId, _settings);
  }
}
