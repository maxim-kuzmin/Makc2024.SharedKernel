namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetAmounts;

public interface IInvoiceGetAmountsActionService
{
  Task<InvoiceGetAmountsActionDTO> GetAmountsAsync(
    CancellationToken cancellationToken = default);
}
