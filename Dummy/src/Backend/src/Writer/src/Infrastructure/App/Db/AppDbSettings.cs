namespace Makc2024.Dummy.Writer.Infrastructure.App.Db;

/// <summary>
/// Настройки базы данных приложения.
/// </summary>
public class AppDbSettings
{
  /// <summary>
  /// Сущности.
  /// </summary>
  public AppDbSettingsEntities Entities { get; } = new AppDbSettingsEntities();
  
  /// <summary>
  /// Схема.
  /// </summary>
  public string Schema { get; } = "writer";
}
