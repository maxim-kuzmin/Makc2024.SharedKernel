namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.Create;

public interface IInvoiceCreateActionService
{
  Task<Guid?> CreateAsync(
    InvoiceCreateActionCommand command,
    CancellationToken cancellationToken = default);
}
