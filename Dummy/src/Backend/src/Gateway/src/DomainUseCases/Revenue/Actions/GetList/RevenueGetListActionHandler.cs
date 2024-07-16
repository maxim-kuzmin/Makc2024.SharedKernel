namespace Makc2024.Dummy.Gateway.DomainUseCases.Revenue.Actions.GetList;

public class RevenueGetListActionHandler(IRevenueGetListActionService _service) :
  IQueryHandler<RevenueGetListActionQuery, Result<IEnumerable<RevenueGetListActionDTO>>>
{
  public async Task<Result<IEnumerable<RevenueGetListActionDTO>>> Handle(
    RevenueGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetListAsync(cancellationToken);

    return Result.Success(result);
  }
}
