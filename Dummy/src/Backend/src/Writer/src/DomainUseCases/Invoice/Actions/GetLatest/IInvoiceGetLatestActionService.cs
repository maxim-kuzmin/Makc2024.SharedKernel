namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetLatest;

public interface IInvoiceGetLatestActionService
{
  Task<IEnumerable<InvoiceGetLatestActionDTO>> GetLatestAsync(
    InvoiceGetLatestActionQuery query,
    CancellationToken cancellationToken = default);
}
