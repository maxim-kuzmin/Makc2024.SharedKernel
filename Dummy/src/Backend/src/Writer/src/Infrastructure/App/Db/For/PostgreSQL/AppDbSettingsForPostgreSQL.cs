namespace Makc2024.Dummy.Writer.Infrastructure.App.Db.For.PostgreSQL;

/// <summary>
/// Настройки базы данных приложения для PostgreSQL.
/// </summary>
public class AppDbSettingsForPostgreSQL : AppDbSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppDbSettingsForPostgreSQL()
  {
    Schema = "writer";
    Entities = new AppDbSettingsEntitiesForPostgreSQL(Schema);    
  }
}
