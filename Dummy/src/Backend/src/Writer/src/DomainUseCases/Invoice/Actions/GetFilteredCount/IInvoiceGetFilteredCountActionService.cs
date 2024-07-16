namespace Gateway.DomainUseCases.Invoice.Actions.GetFilteredCount;

public interface IInvoiceGetFilteredCountActionService
{
  Task<int> GetFilteredCountAsync(
    InvoiceGetFilteredCountActionQuery query,
    CancellationToken cancellationToken = default);
}
