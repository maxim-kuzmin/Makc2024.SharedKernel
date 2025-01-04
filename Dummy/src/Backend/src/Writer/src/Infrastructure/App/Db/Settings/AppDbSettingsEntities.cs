namespace Makc2024.Dummy.Writer.Infrastructure.App.Db.Settings;

/// <summary>
/// Сущности в настройках базы данных приложения.
/// </summary>
public abstract class AppDbSettingsEntities
{
  /// <summary>
  /// Событие приложения.
  /// </summary>
  public AppEventEntityDbSettings AppEvent { get; protected set; } = null!;

  /// <summary>
  /// Полезная нагрузка события приложения.
  /// </summary>
  public AppEventPayloadEntityDbSettings AppEventPayload { get; protected set; } = null!;

  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DummyItemEntityDbSettings DummyItem { get; protected set; } = null!;
}
