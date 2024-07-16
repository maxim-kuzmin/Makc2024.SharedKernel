namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Update;

public class DummyItemUpdateActionService(
  IEventDispatcher _eventDispatcher,
  IDummyItemRepository _repository) : IDummyItemUpdateActionService
{
  public async Task<DummyItemUpdateActionDTO?> UpdateAsync(
    DummyItemUpdateActionCommand command,
    CancellationToken cancellationToken = default)
  {
    var dummyItemEntity = await _repository.GetByIdAsync(command.Id, cancellationToken);
    
    if (dummyItemEntity == null)
    {
      return null;
    }

    var dummyItemAggregate = new DummyItemAggregate(dummyItemEntity.Id);

    dummyItemAggregate.UpdateName(command.Name);

    dummyItemEntity = dummyItemAggregate.GetDummyItemEntityToUpdate(dummyItemEntity);

    if (dummyItemEntity == null)
    {
      return null;
    }

    await _repository.UpdateAsync(dummyItemEntity, cancellationToken);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken);

    var result = new DummyItemUpdateActionDTO(
      dummyItemEntity.Id,
      dummyItemEntity.Name);

    return result;
  }
}
