namespace Gateway.DomainModel.Customer;

public class CustomerAggregate(Guid customerEntityId = default) : AggregateBase
{  
  private readonly CustomerEntity _customerEntity = new() { Id = customerEntityId };

  public string Email => _customerEntity.Email;
  public Guid Id => _customerEntity.Id;
  public string ImageUrl => _customerEntity.ImageUrl;
  public string Name => _customerEntity.Name;
  public IEnumerable<InvoiceEntity>? Invoices => _customerEntity.Invoices;

  public void AddInvoice(InvoiceEntity invoice)
  {
    _customerEntity.Invoices ??= [];

    _customerEntity.Invoices.Add(invoice);

    SetChangedProperty(nameof(Invoices));
  }

  public CustomerEntity? GetCustomerEntityToCreate()
  {
    return (CustomerEntity)_customerEntity.DeepCopy();
  }

  public CustomerEntity? GetCustomerEntityToDelete(CustomerEntity customerEntity)
  {
    if (Id == default || customerEntity.Id != Id)
    {
      return null;
    }

    return customerEntity;
  }

  public CustomerEntity? GetCustomerEntityToUpdate(CustomerEntity customerEntity)
  {
    if (Id == default || customerEntity.Id != Id)
    {
      return null;
    }

    bool isOk = false;

    if (HasChangedProperty(nameof(Email)) && customerEntity.Email != Email)
    {
      customerEntity.Email = Email;

      isOk = true;
    }

    if (HasChangedProperty(nameof(ImageUrl)) && customerEntity.ImageUrl != ImageUrl)
    {
      customerEntity.ImageUrl = ImageUrl;
      
      isOk = true;
    }

    if (HasChangedProperty(nameof(Name)) && customerEntity.Name != Name)
    {
      customerEntity.Name = Name;
      
      isOk = true;
    }

    if (HasChangedProperty(nameof(Invoices)) && Invoices?.Any() == true)
    {
      var invoices = new List<InvoiceEntity>(Invoices);

      if (customerEntity.Invoices?.Count > 0)
      {
        invoices.AddRange(customerEntity.Invoices);
      }

      customerEntity.Invoices = invoices;

      isOk = true;
    }

    return isOk ? customerEntity : null;
  }    

  public void UpdateEmail(string email)
  {
    _customerEntity.Email = Guard.Against.NullOrEmpty(email, nameof(email));

    SetChangedProperty(nameof(Email));
  }

  public void UpdateImageUrl(string imageUrl)
  {
    _customerEntity.ImageUrl = Guard.Against.NullOrEmpty(imageUrl, nameof(imageUrl));

    SetChangedProperty(nameof(ImageUrl));
  }

  public void UpdateName(string name)
  {
    _customerEntity.Name = Guard.Against.NullOrEmpty(name, nameof(name));

    SetChangedProperty(nameof(Name));
  }
}
