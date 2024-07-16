namespace Gateway.DomainUseCases.Invoice.Actions.Update;

public interface IInvoiceUpdateActionService
{
  Task<InvoiceUpdateActionDTO?> UpdateAsync(
    InvoiceUpdateActionCommand command,
    CancellationToken cancellationToken = default);
}
