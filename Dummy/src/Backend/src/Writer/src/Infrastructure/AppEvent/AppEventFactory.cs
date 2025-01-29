namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent;

/// <summary>
/// Фабрика события приложения.
/// </summary>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppEventFactory(IAppEventResources _resources, AppEventSettings _settings) : IAppEventFactory
{
  /// <inheritdoc/>
  public AppEventAggregate CreateAggregate(AppEventEntity? entityFromDb = null)
  {
    return new(entityFromDb, _resources, _settings);
  }
}
