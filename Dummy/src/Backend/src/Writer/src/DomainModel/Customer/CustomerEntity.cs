namespace Makc2024.Dummy.Writer.DomainModel.Customer;

public class CustomerEntity : EntityBaseWithId<Guid>, IAggregateRoot
{
  public string Email { get; set; } = null!;
  public string ImageUrl { get; set; } = null!;
  public string Name { get; set; } = null!;
  public ICollection<InvoiceEntity>? Invoices { get; set; }

  public sealed override object DeepCopy()
  {
    var result = (CustomerEntity)base.DeepCopy();

    result.Invoices = Invoices.ToDeepCopyList();

    return result;
  }
}
