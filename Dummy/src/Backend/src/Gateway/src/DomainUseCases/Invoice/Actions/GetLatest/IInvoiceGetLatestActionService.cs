namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetLatest;

public interface IInvoiceGetLatestActionService
{
  Task<IEnumerable<InvoiceGetLatestActionDTO>> GetLatestAsync(
    InvoiceGetLatestActionQuery query,
    CancellationToken cancellationToken = default);
}
