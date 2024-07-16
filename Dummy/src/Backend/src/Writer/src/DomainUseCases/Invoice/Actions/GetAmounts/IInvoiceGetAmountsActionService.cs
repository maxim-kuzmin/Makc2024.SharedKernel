namespace Gateway.DomainUseCases.Invoice.Actions.GetAmounts;

public interface IInvoiceGetAmountsActionService
{
  Task<InvoiceGetAmountsActionDTO> GetAmountsAsync(
    CancellationToken cancellationToken = default);
}
