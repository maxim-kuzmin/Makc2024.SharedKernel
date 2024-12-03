namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Delete;

public class DummyItemDeleteActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemDeleteActionCommand, Result>
{
  public Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Delete(request, cancellationToken);
  }
}
