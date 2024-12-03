namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Delete;

public class DummyItemDeleteActionHandler(IDummyItemService _service) :
  ICommandHandler<DummyItemDeleteActionCommand, Result>
{
  public Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Delete(request, cancellationToken);
  }
}
