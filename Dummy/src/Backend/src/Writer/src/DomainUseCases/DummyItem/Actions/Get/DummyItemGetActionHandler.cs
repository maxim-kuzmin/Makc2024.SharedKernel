namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;

public class DummyItemGetActionHandler(IDummyItemQueryService _service) :
  IQueryHandler<DummyItemGetActionQuery, Result<DummyItemGetActionDTO>>
{
  public Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.Get(request, cancellationToken);
  }
}
