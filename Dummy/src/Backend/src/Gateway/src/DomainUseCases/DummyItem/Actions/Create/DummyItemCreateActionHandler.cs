namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Create;

public class DummyItemCreateActionHandler(IDummyActionItemCommandService _service) :
  ICommandHandler<DummyItemCreateActionCommand, Result<DummyItemGetActionDTO>>
{
  public Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Create(request, cancellationToken);
  }
}
