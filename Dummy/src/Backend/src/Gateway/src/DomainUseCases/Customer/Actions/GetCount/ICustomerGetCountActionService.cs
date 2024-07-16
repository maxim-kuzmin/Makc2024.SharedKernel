namespace Makc2024.Dummy.Gateway.DomainUseCases.Customer.Actions.GetCount;

public interface ICustomerGetCountActionService
{
  Task<int> GetCountAsync(    
    CancellationToken cancellationToken = default);
}
