namespace Gateway.DomainUseCases.Customer.Actions.GetCount;

public interface ICustomerGetCountActionService
{
  Task<int> GetCountAsync(    
    CancellationToken cancellationToken = default);
}
