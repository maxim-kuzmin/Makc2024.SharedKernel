namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetFiltered;

public interface IInvoiceGetFilteredActionService
{
  Task<IEnumerable<InvoiceGetFilteredActionDTO>> GetFilteredAsync(
    InvoiceGetFilteredActionQuery query,
    CancellationToken cancellationToken = default);
}
