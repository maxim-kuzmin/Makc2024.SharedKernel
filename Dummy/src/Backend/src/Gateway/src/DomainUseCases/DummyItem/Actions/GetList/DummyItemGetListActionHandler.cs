using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Action.Query;

namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;

public class DummyItemGetListActionHandler(IDummyItemActionQueryService _service) :
  IQueryHandler<DummyItemGetListActionQuery, Result<DummyItemGetListActionDTO>>
{
  public Task<Result<DummyItemGetListActionDTO>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request, cancellationToken);
  }
}
