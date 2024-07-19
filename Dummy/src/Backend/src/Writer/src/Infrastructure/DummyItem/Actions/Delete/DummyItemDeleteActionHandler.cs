using Ardalis.Result;

namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Delete;

public class DummyItemDeleteActionHandler(
  IEventDispatcher _eventDispatcher,
  IDummyItemRepository _repository) : IDummyItemDeleteActionHandler
{
  public async Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var dummyItemEntity = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    var dummyItemAggregate = new DummyItemAggregate(dummyItemEntity.Id);

    dummyItemEntity = dummyItemAggregate.GetDummyItemEntityToDelete(dummyItemEntity);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    await _repository.DeleteAsync(dummyItemEntity, cancellationToken);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken);

    return Result.Success();
  }
}
