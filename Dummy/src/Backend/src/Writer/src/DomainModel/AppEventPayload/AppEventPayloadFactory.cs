namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

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
  public AppEventPayloadAggregate CreateAggregate(AppEventPayloadEntity? entityToChange = null)
  {
    return new(entityToChange, _resources, _settings);
  }
}
