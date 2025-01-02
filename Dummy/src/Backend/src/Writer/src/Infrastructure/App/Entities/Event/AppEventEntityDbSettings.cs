namespace Makc2024.Dummy.Writer.Infrastructure.App.Entities.Event;

/// <summary>
/// Настройки базы данных сущности события приложения.
/// </summary>
public class AppEventEntityDbSettings
{
  /// <summary>
  /// Столбец для даты создания.
  /// </summary>
  public string ColumnForCreationDate { get; }

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; }

  /// <summary>
  /// Столбец для признака опубликованности.
  /// </summary>
  public string ColumnForIsPublished { get; }

  /// <summary>
  /// Столбец для имени.
  /// </summary>
  public string ColumnForName { get; }

  /// <summary>
  /// Первичный ключ.
  /// </summary>
  public string PrimaryKey { get; }

  /// <summary>
  /// Таблица.
  /// </summary>
  public string Table { get; }

  /// <summary>
  /// Уникальный индекс для имени.
  /// </summary>
  public string UniqueIndexForName { get; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppEventEntityDbSettings()
  {
    Table = "app_event";

    PrimaryKey = $"pk_{Table}";

    ColumnForCreationDate = "creation_date";
    ColumnForId = "id";
    ColumnForIsPublished = "is_published";
    ColumnForName = "name";

    UniqueIndexForName = $"ux_{Table}_{ColumnForName}";
  }
}
