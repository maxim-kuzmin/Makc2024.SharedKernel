namespace Gateway.Infrastructure.Invoice.Actions.Delete;

public class InvoiceDeleteActionService(
  IEventDispatcher _eventDispatcher,
  IInvoiceRepository _repository) : IInvoiceDeleteActionService
{
  public async Task<bool> DeleteAsync(
    InvoiceDeleteActionCommand command,
    CancellationToken cancellationToken = default)
  {
    var invoiceEntity = await _repository.GetByIdAsync(command.Id, cancellationToken);
    
    if (invoiceEntity == null)
    {
      return false;
    }

    var invoiceAggregate = new InvoiceAggregate(invoiceEntity.Id);

    invoiceEntity = invoiceAggregate.GetInvoiceEntityToDelete(invoiceEntity);

    if (invoiceEntity == null)
    {
      return false;
    }

    await _repository.DeleteAsync(invoiceEntity, cancellationToken);

    await _eventDispatcher.DispatchAndClearEvents(invoiceAggregate);

    return true;
  }
}
