namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetFilteredCount;

public interface IInvoiceGetFilteredCountActionService
{
  Task<int> GetFilteredCountAsync(
    InvoiceGetFilteredCountActionQuery query,
    CancellationToken cancellationToken = default);
}
