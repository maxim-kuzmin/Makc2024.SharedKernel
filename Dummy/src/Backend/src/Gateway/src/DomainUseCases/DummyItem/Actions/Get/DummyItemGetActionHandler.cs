using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Action.Query;

namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Get;

public class DummyItemGetActionHandler(IDummyItemActionQueryService _service) :
  IQueryHandler<DummyItemGetActionQuery, Result<DummyItemGetActionDTO>>
{
  public Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.Get(request, cancellationToken);
  }
}
