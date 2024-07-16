namespace Makc2024.Dummy.Writer.DomainUseCases.Customer.Actions.GetAll;

public interface ICustomerGetAllActionService
{
  Task<IEnumerable<CustomerGetAllActionDTO>> GetAllAsync(    
    CancellationToken cancellationToken = default);
}
