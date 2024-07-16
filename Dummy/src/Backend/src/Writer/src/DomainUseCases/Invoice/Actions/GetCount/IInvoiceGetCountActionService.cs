namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetCount;

public interface IInvoiceGetCountActionService
{
  Task<int> GetCountAsync(    
    CancellationToken cancellationToken = default);
}
