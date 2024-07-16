namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetById;

public interface IInvoiceGetByIdActionService
{
  Task<InvoiceGetByIdActionDTO?> GetByIdAsync(
    InvoiceGetByIdActionQuery query,
    CancellationToken cancellationToken = default);
}
