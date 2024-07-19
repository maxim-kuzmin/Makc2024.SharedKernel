namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Create;

public class DummyItemCreateActionHandler(
  IEventDispatcher _eventDispatcher,
  IDummyItemRepository _repository
  ) : IDummyItemCreateActionHandler
{
  public async Task<Result<long>> Handle(DummyItemCreateActionCommand request, CancellationToken cancellationToken)
  {
    var dummyItemAggregate = new DummyItemAggregate();

    dummyItemAggregate.UpdateName(request.Name);

    var dummyItemEntity = dummyItemAggregate.GetDummyItemEntityToCreate();

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    dummyItemEntity = await _repository.AddAsync(dummyItemEntity, cancellationToken);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken);

    return Result.Success(dummyItemEntity.Id);
  }
}
