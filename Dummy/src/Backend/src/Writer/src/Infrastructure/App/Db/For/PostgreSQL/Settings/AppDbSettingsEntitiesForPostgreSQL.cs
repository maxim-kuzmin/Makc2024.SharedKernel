namespace Makc2024.Dummy.Writer.Infrastructure.App.Db.For.PostgreSQL.Settings;

/// <summary>
/// Сущности в настройках базы данных приложения для PostgreSQL.
/// </summary>
public class AppDbSettingsEntitiesForPostgreSQL : AppDbSettingsEntities
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  public AppDbSettingsEntitiesForPostgreSQL(string schema)
  {
    AppEvent = new AppEventEntityDbSettingsForPostgreSQL(schema);
    AppEventPayload = new AppEventPayloadEntityDbSettingsForPostgreSQL(schema, AppEvent.Table);
    DummyItem = new DummyItemEntityDbSettingsForPostgreSQL(schema);
  }
}
