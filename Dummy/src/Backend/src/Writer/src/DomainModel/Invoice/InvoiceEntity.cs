namespace Makc2024.Dummy.Writer.DomainModel.Invoice;

public class InvoiceEntity : EntityBaseWithId<Guid>, IAggregateRoot
{
  public int Amount { get; set; }
  public Guid CustomerId { get; set; }
  public DateOnly Date { get; set; }
  public string Status { get; set; } = null!;
  public CustomerEntity? Customer { get; set; }

  public sealed override object DeepCopy()
  {
    var result = (InvoiceEntity)base.DeepCopy();

    result.Customer = (CustomerEntity?)Customer?.DeepCopy();

    return result;
  }
}
