namespace Gateway.Infrastructure.Invoice.Actions.Update;

public class InvoiceUpdateActionService(
  IEventDispatcher _eventDispatcher,
  IInvoiceRepository _repository) : IInvoiceUpdateActionService
{
  public async Task<InvoiceUpdateActionDTO?> UpdateAsync(
    InvoiceUpdateActionCommand command,
    CancellationToken cancellationToken = default)
  {
    var invoiceEntity = await _repository.GetByIdAsync(command.Id, cancellationToken);
    
    if (invoiceEntity == null)
    {
      return null;
    }

    var invoiceAggregate = new InvoiceAggregate(invoiceEntity.Id);

    invoiceAggregate.UpdateAmount(command.Amount);
    invoiceAggregate.UpdateCustomerId(command.CustomerId);    
    invoiceAggregate.UpdateStatus(command.Status);

    invoiceEntity = invoiceAggregate.GetInvoiceEntityToUpdate(invoiceEntity);

    if (invoiceEntity == null)
    {
      return null;
    }

    await _repository.UpdateAsync(invoiceEntity, cancellationToken);

    await _eventDispatcher.DispatchAndClearEvents(invoiceAggregate, cancellationToken);

    var result = new InvoiceUpdateActionDTO(
      invoiceEntity.Amount,
      invoiceEntity.CustomerId,
      invoiceEntity.Id,
      invoiceEntity.Status);

    return result;
  }
}
