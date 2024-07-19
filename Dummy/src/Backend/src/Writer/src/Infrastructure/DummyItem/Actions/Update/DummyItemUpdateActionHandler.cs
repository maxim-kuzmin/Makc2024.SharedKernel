namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Update;

public class DummyItemUpdateActionHandler(
  IEventDispatcher _eventDispatcher,
  IDummyItemRepository _repository) : IDummyItemUpdateActionHandler
{
  public async Task<Result<DummyItemUpdateActionDTO>> Handle(
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    var dummyItemEntity = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    var dummyItemAggregate = new DummyItemAggregate(dummyItemEntity.Id);

    dummyItemAggregate.UpdateName(request.Name);

    dummyItemEntity = dummyItemAggregate.GetDummyItemEntityToUpdate(dummyItemEntity);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    await _repository.UpdateAsync(dummyItemEntity, cancellationToken);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken);

    var data = new DummyItemUpdateActionDTO(
      dummyItemEntity.Id,
      dummyItemEntity.Name);

    return Result.Success(data);
  }
}
