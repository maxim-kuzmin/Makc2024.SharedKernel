namespace Makc2024.Dummy.Writer.Infrastructure.App.Db;

public class AppDbSettings
{
  public AppDbSettingsEntities Entities { get; } = new AppDbSettingsEntities();

  public string Schema { get; } = "public";
}
