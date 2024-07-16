namespace Gateway.Infrastructure.Invoice.Actions.Create;

public class InvoiceCreateActionService(
  IEventDispatcher _eventDispatcher,
  IInvoiceRepository _repository
  ) : IInvoiceCreateActionService
{
  public async Task<Guid?> CreateAsync(
    InvoiceCreateActionCommand command,
    CancellationToken cancellationToken = default)
  {
    var invoiceAggregate = new InvoiceAggregate();

    invoiceAggregate.UpdateAmount(command.Amount);
    invoiceAggregate.UpdateCustomerId(command.CustomerId);
    invoiceAggregate.UpdateDate(command.Date);
    invoiceAggregate.UpdateStatus(command.Status);

    var invoiceEntity = invoiceAggregate.GetInvoiceEntityToCreate();

    if (invoiceEntity == null)
    {
      return null;
    }

    invoiceEntity = await _repository.AddAsync(invoiceEntity, cancellationToken);

    await _eventDispatcher.DispatchAndClearEvents(invoiceAggregate);

    return invoiceEntity.Id;
  }
}
