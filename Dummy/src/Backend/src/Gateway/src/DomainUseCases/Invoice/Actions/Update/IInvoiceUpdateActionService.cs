namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.Update;

public interface IInvoiceUpdateActionService
{
  Task<InvoiceUpdateActionDTO?> UpdateAsync(
    InvoiceUpdateActionCommand command,
    CancellationToken cancellationToken = default);
}
