namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.Entity;

/// <summary>
/// Настройки базы данных сущности полезной нагрузки события приложения.
/// </summary>
public abstract class AppEventPayloadEntityDbSettings
{
  /// <summary>
  /// Столбец для токена конкуренции.
  /// </summary>
  public string ColumnForConcurrencyToken { get; protected set; } = null!;

  /// <summary>
  /// Внешний ключ для идентификатора события приложения.
  /// </summary>
  public string ColumnForAppEventId { get; protected set; } = null!;

  /// <summary>
  /// Столбец для данных.
  /// </summary>
  public string ColumnForData { get; protected set; } = null!;

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; protected set; } = null!;

  /// <summary>
  /// Внешний ключ для идентификатора события приложения.
  /// </summary>
  public string ForeignKeyForAppEventId { get; protected set; } = null!;

  /// <summary>
  /// Максимальная длина для данных.
  /// </summary>
  public int MaxLengthForData { get; protected set; }

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
