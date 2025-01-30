namespace Makc2024.Dummy.Writer.Infrastructure.App.Domain;

/// <summary>
/// Настройки домена приложения.
/// </summary>
public class AppDomainSettings(AppDbSettingsEntities entities)
{
  /// <summary>
  /// Событие приложения.
  /// </summary>
  public AppEventSettings AppEvent { get; } = new(entities.AppEvent.MaxLengthForName);

  /// <summary>
  /// Полезная нагрузка события приложения.
  /// </summary>
  public AppEventPayloadSettings AppEventPayload { get; } = new(entities.AppEventPayload.MaxLengthForData);

  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DummyItemSettings DummyItem { get; } = new(entities.DummyItem.MaxLengthForName);
}
