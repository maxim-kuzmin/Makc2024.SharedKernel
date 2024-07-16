namespace Makc2024.Dummy.Writer.Infrastructure.Invoice.Entity;

public class InvoiceEntityDbSettings
{
  public string ColumnForAmount { get; }
  public string ColumnForCustomerId { get; }
  public string ColumnForDate { get; }
  public string ColumnForId { get; }
  public string ColumnForStatus { get; }

  public string IndexForCuctomerId { get; }

  public string ForeignKeyToCustomer { get; }

  public int MaxLengthForStatus { get; }

  public string PrimaryKey { get; }

  public string Table { get; }

  public InvoiceEntityDbSettings(CustomerEntityDbSettings customerEntitySettings)
  {
    Table = "invoices";

    PrimaryKey = $"pk_{Table}";

    ColumnForAmount = "amount";
    ColumnForCustomerId = "customer_id";
    ColumnForDate = "date";
    ColumnForId = "id";
    ColumnForStatus = "status";

    IndexForCuctomerId = $"ix_{Table}_{ColumnForCustomerId}";

    MaxLengthForStatus = 255;

    ForeignKeyToCustomer = $"fk_{Table}_{customerEntitySettings.Table}";
  }
}
