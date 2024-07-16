namespace Gateway.DomainModel.Invoice;

public class InvoiceAggregate(Guid invoiceEntityId = default) : AggregateBase
{
  private readonly InvoiceEntity _invoiceEntity = new() { Id = invoiceEntityId };

  public int Amount => _invoiceEntity.Amount;
  public Guid CustomerId => _invoiceEntity.CustomerId;
  public DateOnly Date => _invoiceEntity.Date;
  public Guid Id => _invoiceEntity.Id;
  public string Status => _invoiceEntity.Status;
  public CustomerEntity? Customer => _invoiceEntity.Customer;

  public InvoiceEntity? GetInvoiceEntityToCreate()
  {
    return (InvoiceEntity)_invoiceEntity.DeepCopy();
  }

  public InvoiceEntity? GetInvoiceEntityToDelete(InvoiceEntity invoiceEntity)
  {
    if (Id == default || invoiceEntity.Id != Id)
    {
      return null;
    }

    return invoiceEntity;
  }

  public InvoiceEntity? GetInvoiceEntityToUpdate(InvoiceEntity invoiceEntity)
  {
    if (Id == default || invoiceEntity.Id != Id)
    {
      return null;
    }

    bool isOk = false;

    if (HasChangedProperty(nameof(Amount)) && invoiceEntity.Amount != Amount)
    {
      invoiceEntity.Amount = Amount;

      isOk = true;
    }

    if (HasChangedProperty(nameof(Customer)) && invoiceEntity.Customer?.Id != Customer?.Id)
    {
      invoiceEntity.Customer = Customer;

      isOk = true;
    }

    if (HasChangedProperty(nameof(CustomerId)) && invoiceEntity.CustomerId != CustomerId)
    {
      invoiceEntity.CustomerId = CustomerId;

      isOk = true;
    }

    if (HasChangedProperty(nameof(Date)) && invoiceEntity.Date != Date)
    {
      invoiceEntity.Date = Date;

      isOk = true;
    }

    if (HasChangedProperty(nameof(Status)) && invoiceEntity.Status != Status)
    {
      invoiceEntity.Status = Status;

      isOk = true;
    }

    return isOk ? invoiceEntity : null;
  }

  public void UpdateAmount(int amount)
  {
    _invoiceEntity.Amount = amount;

    SetChangedProperty(nameof(Amount));
  }

  public void UpdateCustomer(CustomerEntity customer)
  {
    _invoiceEntity.Customer = customer;

    SetChangedProperty(nameof(Customer));
  }

  public void UpdateCustomerId(Guid customerId)
  {
    _invoiceEntity.CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));

    SetChangedProperty(nameof(CustomerId));
  }

  public void UpdateDate(DateOnly date)
  {
    _invoiceEntity.Date = date;

    SetChangedProperty(nameof(Date));    
  }

  public void UpdateStatus(string status)
  {
    _invoiceEntity.Status = Guard.Against.NullOrEmpty(status, nameof(status));

    SetChangedProperty(nameof(Status));
  }
}
