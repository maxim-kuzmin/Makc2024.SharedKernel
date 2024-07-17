namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;

public class DummyItemGetListActionHandler(IDummyItemGetListActionService _service) :
  IQueryHandler<DummyItemGetListActionQuery, Result<IEnumerable<DummyItemGetListActionDTO>>>
{
  public async Task<Result<IEnumerable<DummyItemGetListActionDTO>>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetListAsync(request, cancellationToken);

    return Result.Success(result);
  }
}
