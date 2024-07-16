namespace Makc2024.Dummy.Writer.Infrastructure.App.Db;

public class AppDbSettingsEntities
{
  public DummyItemEntityDbSettings DummyItem { get; }

  public AppDbSettingsEntities()
  {
    DummyItem = new();
  }
}
