namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.Delete;

public interface IInvoiceDeleteActionService
{
  Task<bool> DeleteAsync(
    InvoiceDeleteActionCommand command,
    CancellationToken cancellationToken = default);
}
