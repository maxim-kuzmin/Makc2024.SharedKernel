namespace Makc2024.Dummy.Writer.Infrastructure.Revenue.Entity;

public class RevenueEntityDbSettings
{
  public string ColumnForMonth { get; }
  public string ColumnForValue { get; }
  public int MaxLengthForMonth { get; }
  public string PrimaryKey { get; }
  public string Table { get; }

  public RevenueEntityDbSettings()
  {
    Table = "revenue";

    PrimaryKey = $"pk_{Table}";

    ColumnForMonth = "month";
    ColumnForValue = "value";

    MaxLengthForMonth = 4;
  }
}
