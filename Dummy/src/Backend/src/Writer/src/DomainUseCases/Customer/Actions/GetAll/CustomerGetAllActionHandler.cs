namespace Gateway.DomainUseCases.Customer.Actions.GetAll;

public class CustomerGetAllActionHandler(ICustomerGetAllActionService _service) :
  IQueryHandler<CustomerGetAllActionQuery, Result<IEnumerable<CustomerGetAllActionDTO>>>
{
  public async Task<Result<IEnumerable<CustomerGetAllActionDTO>>> Handle(
    CustomerGetAllActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetAllAsync(cancellationToken);

    return Result.Success(result);
  }
}
