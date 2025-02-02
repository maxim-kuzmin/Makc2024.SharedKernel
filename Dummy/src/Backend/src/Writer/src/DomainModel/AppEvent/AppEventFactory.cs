namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Фабрика события приложения.
/// </summary>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppEventFactory(IAppEventResources _resources, AppEventSettings _settings) : IAppEventFactory
{
  /// <inheritdoc/>
  public AppEventAggregate CreateAggregate(AppEventEntity? entityToChange = null)
  {
    return new(entityToChange, _resources, _settings);
  }
}
