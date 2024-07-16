namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;

public class DummyItemCreateActionHandler(IDummyItemCreateActionService _service) :
  ICommandHandler<DummyItemCreateActionCommand, Result<long>>
{
  public async Task<Result<long>> Handle(
    DummyItemCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _service.CreateAsync(request, cancellationToken);

    return result != null ? Result.Success(result.Value) : Result.NotFound();
  }
}
