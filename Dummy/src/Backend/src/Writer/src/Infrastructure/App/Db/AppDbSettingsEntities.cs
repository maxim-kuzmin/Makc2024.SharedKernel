namespace Makc2024.Dummy.Writer.Infrastructure.App.Db;

/// <summary>
/// Сущности настроек базы данных приложения.
/// </summary>
public class AppDbSettingsEntities
{
  /// <summary>
  /// Событие приложения.
  /// </summary>
  public AppEventEntityDbSettings AppEvent { get; }

  /// <summary>
  /// Полезная нагрузка события приложения.
  /// </summary>
  public AppEventPayloadEntityDbSettings AppEventPayload { get; }

  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DummyItemEntityDbSettings DummyItem { get; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppDbSettingsEntities()
  {
    AppEvent = new();
    AppEventPayload = new(AppEvent.Table);
    DummyItem = new();    
  }
}
