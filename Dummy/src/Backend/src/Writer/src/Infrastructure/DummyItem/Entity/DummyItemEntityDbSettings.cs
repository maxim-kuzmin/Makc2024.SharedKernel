namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Entity;

public class DummyItemEntityDbSettings
{
  public string ColumnForId { get; }
  public string ColumnForName { get; }

  public int MaxLengthForName { get; }

  public string PrimaryKey { get; }

  public string Table { get; }

  public string UniqueIndexForName { get; }

  public DummyItemEntityDbSettings()
  {
    Table = "dummy_item";

    PrimaryKey = $"pk_{Table}";

    ColumnForId = "id";
    ColumnForName = "name";

    MaxLengthForName = 255;

    UniqueIndexForName = $"ux_{Table}_name";
  }
}
