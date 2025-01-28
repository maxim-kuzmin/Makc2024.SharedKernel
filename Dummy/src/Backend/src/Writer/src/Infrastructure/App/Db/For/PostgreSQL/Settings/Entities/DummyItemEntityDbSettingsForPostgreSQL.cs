namespace Makc2024.Dummy.Writer.Infrastructure.App.Db.For.PostgreSQL.Settings.Entities;

/// <summary>
/// Настройки базы данных сущности фиктивного предмета для PostgreSQL.
/// </summary>
public class DummyItemEntityDbSettingsForPostgreSQL : DummyItemEntityDbSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  public DummyItemEntityDbSettingsForPostgreSQL(string schema)
  {
    Schema = schema;

    Table = "dummy_item";

    PrimaryKey = $"pk_{Table}";

    ColumnForConcurrencyToken = "сoncurrency_token";
    ColumnForId = "id";
    ColumnForName = "name";

    MaxLengthForName = 255;

    UniqueIndexForName = $"ux_{Table}_name";
  }
}
