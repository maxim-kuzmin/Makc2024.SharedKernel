namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Update;

public class DummyItemUpdateActionHandler(IDummyItemUpdateActionService _service) :
  ICommandHandler<DummyItemUpdateActionCommand, Result<DummyItemUpdateActionDTO>>
{
  public async Task<Result<DummyItemUpdateActionDTO>> Handle(
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _service.UpdateAsync(request, cancellationToken);

    return result != null ? Result.Success(result) : Result.NotFound();
  }
}
