namespace Gateway.DomainUseCases.Invoice.Actions.Create;

public interface IInvoiceCreateActionService
{
  Task<Guid?> CreateAsync(
    InvoiceCreateActionCommand command,
    CancellationToken cancellationToken = default);
}
