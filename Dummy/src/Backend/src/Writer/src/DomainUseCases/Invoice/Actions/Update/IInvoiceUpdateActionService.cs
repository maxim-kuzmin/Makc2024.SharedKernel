namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.Update;

public interface IInvoiceUpdateActionService
{
  Task<InvoiceUpdateActionDTO?> UpdateAsync(
    InvoiceUpdateActionCommand command,
    CancellationToken cancellationToken = default);
}
