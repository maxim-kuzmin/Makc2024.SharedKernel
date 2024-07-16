namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetAmounts;

public interface IInvoiceGetAmountsActionService
{
  Task<InvoiceGetAmountsActionDTO> GetAmountsAsync(
    CancellationToken cancellationToken = default);
}
