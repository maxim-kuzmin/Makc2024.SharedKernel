namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetById;

public class DummyItemGetByIdActionHandler(IDummyItemGetByIdActionService _service) :
  IQueryHandler<DummyItemGetByIdActionQuery, Result<DummyItemGetByIdActionDTO>>
{
  public async Task<Result<DummyItemGetByIdActionDTO>> Handle(
    DummyItemGetByIdActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetByIdAsync(request, cancellationToken);

    return result != null ? Result.Success(result) : Result.NotFound();
  }
}
