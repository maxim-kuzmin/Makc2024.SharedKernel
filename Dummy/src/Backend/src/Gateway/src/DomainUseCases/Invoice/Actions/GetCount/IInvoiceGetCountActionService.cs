namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetCount;

public interface IInvoiceGetCountActionService
{
  Task<int> GetCountAsync(    
    CancellationToken cancellationToken = default);
}
