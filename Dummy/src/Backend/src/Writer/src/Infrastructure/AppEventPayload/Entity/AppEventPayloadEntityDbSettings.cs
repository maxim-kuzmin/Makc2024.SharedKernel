namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.Entity;

/// <summary>
/// Настройки базы данных сущности полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadEntityDbSettings
{
  /// <summary>
  /// Внешний ключ для идентификатора события приложения.
  /// </summary>
  public string ColumnForAppEventId { get; }

  /// <summary>
  /// Столбец для сущности.
  /// </summary>
  public string ColumnForEntity { get; }

  /// <summary>
  /// Столбец для идентификатора сущности.
  /// </summary>
  public string ColumnForEntityId { get; }

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; }

  /// <summary>
  /// Столбец для имени.
  /// </summary>
  public string ColumnForName { get; }

  /// <summary>
  /// Столбец для нового значения.
  /// </summary>
  public string ColumnForNewValue { get; }

  /// <summary>
  /// Столбец для старого значения.
  /// </summary>  
  public string ColumnForOldValue { get; }

  /// <summary>
  /// Внешний ключ для идентификатора события приложения.
  /// </summary>
  public string ForeignKeyForAppEventId { get; }

  /// <summary>
  /// Первичный ключ.
  /// </summary>
  public string PrimaryKey { get; }

  /// <summary>
  /// Таблица.
  /// </summary>
  public string Table { get; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="tableForAppEventPayload">Таблица для полезной нагрузки события приложения.</param>
  public AppEventPayloadEntityDbSettings(string tableForAppEventPayload)
  {
    Table = "app_event_payload";

    PrimaryKey = $"pk_{Table}";

    ColumnForAppEventId = "app_event_id";
    ColumnForEntity = "entity";
    ColumnForEntityId = "entity_id";
    ColumnForId = "id";
    ColumnForName = "name";
    ColumnForNewValue = "new_value";
    ColumnForOldValue = "old_value";

    ForeignKeyForAppEventId = $"fk_{Table}_{tableForAppEventPayload}";
  }
}
