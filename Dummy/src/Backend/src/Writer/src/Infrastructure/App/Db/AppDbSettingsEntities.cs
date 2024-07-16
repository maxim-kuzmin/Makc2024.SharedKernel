namespace Makc2024.Dummy.Writer.Infrastructure.App.Db;

public class AppDbSettingsEntities
{
  public CustomerEntityDbSettings Customer { get; }
  public InvoiceEntityDbSettings Invoice { get; }
  public RevenueEntityDbSettings Revenue { get; }
  public UserEntityDbSettings User { get; }

  public AppDbSettingsEntities()
  {
    Customer = new();
    Invoice = new(Customer);
    Revenue = new();
    User = new();
  }
}
