namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Delete;

public class DummyItemDeleteActionService(
  IEventDispatcher _eventDispatcher,
  IDummyItemRepository _repository) : IDummyItemDeleteActionService
{
  public async Task<bool> DeleteAsync(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken = default)
  {
    var dummyItemEntity = await _repository.GetByIdAsync(command.Id, cancellationToken);
    
    if (dummyItemEntity == null)
    {
      return false;
    }

    var dummyItemAggregate = new DummyItemAggregate(dummyItemEntity.Id);

    dummyItemEntity = dummyItemAggregate.GetDummyItemEntityToDelete(dummyItemEntity);

    if (dummyItemEntity == null)
    {
      return false;
    }

    await _repository.DeleteAsync(dummyItemEntity, cancellationToken);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate);

    return true;
  }
}
