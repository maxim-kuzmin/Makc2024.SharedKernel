﻿namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Entity;

/// <summary>
/// Настройки базы данных сущности фиктивного предмета.
/// </summary>
public class DummyItemEntityDbSettings
{
  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; }

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
  public DummyItemEntityDbSettings()
  {
    Table = "dummy_item";

    PrimaryKey = $"pk_{Table}";

    ColumnForId = "id";
    ColumnForName = "name";

    UniqueIndexForName = $"ux_{Table}_name";
  }
}
