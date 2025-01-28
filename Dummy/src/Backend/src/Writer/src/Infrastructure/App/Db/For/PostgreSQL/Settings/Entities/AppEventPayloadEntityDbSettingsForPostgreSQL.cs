namespace Makc2024.Dummy.Writer.Infrastructure.App.Db.For.PostgreSQL.Settings.Entities;

/// <summary>
/// Настройки базы данных сущности полезной нагрузки события приложения для PostgreSQL.
/// </summary>
public class AppEventPayloadEntityDbSettingsForPostgreSQL : AppEventPayloadEntityDbSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  /// <param name="tableForAppEventPayload">Таблица для полезной нагрузки события приложения.</param>
  public AppEventPayloadEntityDbSettingsForPostgreSQL(string schema, string tableForAppEventPayload)
  {
    Schema = schema;

    Table = "app_event_payload";

    PrimaryKey = $"pk_{Table}";
    
    ColumnForAppEventId = "app_event_id";
    ColumnForConcurrencyToken = "сoncurrency_token";
    ColumnForData = "data";
    ColumnForId = "id";

    MaxLengthForData = 0;

    ForeignKeyForAppEventId = $"fk_{Table}_{tableForAppEventPayload}";
  }
}
