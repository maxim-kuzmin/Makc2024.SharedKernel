namespace Makc2024.Dummy.Gateway.DomainUseCases.Customer.Actions.GetCount;

public class CustomerGetCountActionHandler(ICustomerGetCountActionService _service) :
  IQueryHandler<CustomerGetCountActionQuery, Result<int>>
{
  public async Task<Result<int>> Handle(
    CustomerGetCountActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetCountAsync(cancellationToken);

    return Result.Success(result);
  }
}
