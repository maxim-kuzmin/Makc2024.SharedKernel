namespace Makc2024.Dummy.Writer.DomainUseCases.Customer.Actions.GetFiltered;

public class CustomerGetFilteredActionHandler(ICustomerGetFilteredActionService _service) :
  IQueryHandler<CustomerGetFilteredActionQuery, Result<IEnumerable<CustomerGetFilteredActionDTO>>>
{
  public async Task<Result<IEnumerable<CustomerGetFilteredActionDTO>>> Handle(
    CustomerGetFilteredActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetFilteredAsync(request, cancellationToken);

    return Result.Success(result);
  }
}
