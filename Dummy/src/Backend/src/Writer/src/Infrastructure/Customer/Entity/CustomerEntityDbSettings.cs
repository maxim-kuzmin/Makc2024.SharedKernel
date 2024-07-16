namespace Makc2024.Dummy.Writer.Infrastructure.Customer.Entity;

public class CustomerEntityDbSettings
{
  public string ColumnForEmail { get; }
  public string ColumnForId { get; }
  public string ColumnForImageUrl { get; }
  public string ColumnForName { get; }

  public int MaxLengthForEmail { get; }
  public int MaxLengthForImageUrl { get; }
  public int MaxLengthForName { get; }

  public string PrimaryKey { get; }

  public string Table { get; }

  public CustomerEntityDbSettings()
  {
    Table = "customers";

    PrimaryKey = $"pk_{Table}";

    ColumnForEmail = "email";
    ColumnForId = "id";
    ColumnForImageUrl = "image_url";
    ColumnForName = "name";

    MaxLengthForEmail = 255;
    MaxLengthForImageUrl = 255;
    MaxLengthForName = 255;
  }
}
