namespace Gateway.DomainUseCases.Invoice.Actions.GetFiltered;

public interface IInvoiceGetFilteredActionService
{
  Task<IEnumerable<InvoiceGetFilteredActionDTO>> GetFilteredAsync(
    InvoiceGetFilteredActionQuery query,
    CancellationToken cancellationToken = default);
}
