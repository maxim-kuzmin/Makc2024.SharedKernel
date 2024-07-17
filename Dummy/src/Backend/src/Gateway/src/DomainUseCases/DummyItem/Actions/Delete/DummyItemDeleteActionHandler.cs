namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Delete;

public class DummyItemDeleteActionHandler(IDummyItemDeleteActionService _service) :
  ICommandHandler<DummyItemDeleteActionCommand, Result>
{
  public async Task<Result> Handle(
    DummyItemDeleteActionCommand request,
    CancellationToken cancellationToken)
  {
    var isOk = await _service.DeleteAsync(request, cancellationToken);

    return isOk ? Result.Success() : Result.NotFound();
  }
}
