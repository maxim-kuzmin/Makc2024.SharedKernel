namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Create;

public class DummyItemCreateActionService(
  IEventDispatcher _eventDispatcher,
  IDummyItemRepository _repository
  ) : IDummyItemCreateActionService
{
  public async Task<long?> CreateAsync(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken = default)
  {
    var dummyItemAggregate = new DummyItemAggregate();

    dummyItemAggregate.UpdateName(command.Name);

    var dummyItemEntity = dummyItemAggregate.GetDummyItemEntityToCreate();

    if (dummyItemEntity == null)
    {
      return null;
    }

    dummyItemEntity = await _repository.AddAsync(dummyItemEntity, cancellationToken);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate);

    return dummyItemEntity.Id;
  }
}
