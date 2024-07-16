namespace Makc2024.Dummy.Writer.DomainUseCases.Customer.Actions.GetCount;

public interface ICustomerGetCountActionService
{
  Task<int> GetCountAsync(    
    CancellationToken cancellationToken = default);
}
