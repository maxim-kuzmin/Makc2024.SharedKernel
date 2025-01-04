namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent.Entity;

/// <summary>
/// Настройки базы данных сущности события приложения.
/// </summary>
public abstract class AppEventEntityDbSettings : AppEventSettings
{
  /// <summary>
  /// Столбец для даты создания.
  /// </summary>
  public string ColumnForCreationDate { get; protected set; } = null!;

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; protected set; } = null!;

  /// <summary>
  /// Столбец для признака опубликованности.
  /// </summary>
  public string ColumnForIsPublished { get; protected set; } = null!;

  /// <summary>
  /// Столбец для имени.
  /// </summary>
  public string ColumnForName { get; protected set; } = null!;

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

  /// <summary>
  /// Уникальный индекс для имени.
  /// </summary>
  public string UniqueIndexForName { get; protected set; } = null!;
}
