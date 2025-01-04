namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.Entity;

/// <summary>
/// Настройки базы данных сущности полезной нагрузки события приложения.
/// </summary>
public abstract class AppEventPayloadEntityDbSettings : AppEventPayloadSettings
{
  /// <summary>
  /// Внешний ключ для идентификатора события приложения.
  /// </summary>
  public string ColumnForAppEventId { get; protected set; } = null!;

  /// <summary>
  /// Столбец для сущности.
  /// </summary>
  public string ColumnForEntity { get; protected set; } = null!;

  /// <summary>
  /// Столбец для идентификатора сущности.
  /// </summary>
  public string ColumnForEntityId { get; protected set; } = null!;

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; protected set; } = null!;

  /// <summary>
  /// Столбец для имени.
  /// </summary>
  public string ColumnForName { get; protected set; } = null!;

  /// <summary>
  /// Столбец для нового значения.
  /// </summary>
  public string ColumnForNewValue { get; protected set; } = null!;

  /// <summary>
  /// Столбец для старого значения.
  /// </summary>  
  public string ColumnForOldValue { get; protected set; } = null!;

  /// <summary>
  /// Внешний ключ для идентификатора события приложения.
  /// </summary>
  public string ForeignKeyForAppEventId { get; protected set; } = null!;

  /// <summary>
  /// Первичный ключ.
  /// </summary>
  public string PrimaryKey { get; protected set; } = null!;

  /// <summary>
  /// Схема.
  /// </summary>
  public string Schema { get; protected set; } = null!;

  /// <summary>
  /// Таблица.
  /// </summary>
  public string Table { get; protected set; } = null!;
}
