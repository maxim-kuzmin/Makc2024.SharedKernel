namespace Makc2024.Dummy.Gateway.DomainUseCases.Customer.Actions.GetFiltered;

public interface ICustomerGetFilteredActionService
{
  Task<IEnumerable<CustomerGetFilteredActionDTO>> GetFilteredAsync(
    CustomerGetFilteredActionQuery query,
    CancellationToken cancellationToken = default);
}
