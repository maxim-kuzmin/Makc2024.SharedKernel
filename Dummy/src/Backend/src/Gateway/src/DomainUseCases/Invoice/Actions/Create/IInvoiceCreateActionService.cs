namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.Create;

public interface IInvoiceCreateActionService
{
  Task<Guid?> CreateAsync(
    InvoiceCreateActionCommand command,
    CancellationToken cancellationToken = default);
}
