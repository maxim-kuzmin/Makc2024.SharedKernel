namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Create;

public class DummyItemCreateActionHandler(
  IEventDispatcher _eventDispatcher,
  IDummyItemRepository _repository
  ) : IDummyItemCreateActionHandler
{
  public async Task<Result<DummyItemGetActionDTO>> Handle(DummyItemCreateActionCommand request, CancellationToken cancellationToken)
  {
    var dummyItemAggregate = new DummyItemAggregate();

    dummyItemAggregate.UpdateName(request.Name);

    var dummyItemEntity = dummyItemAggregate.GetDummyItemEntityToCreate();

    if (dummyItemEntity == null)
    {
      return Result.Forbidden();
    }

    dummyItemEntity = await _repository.AddAsync(dummyItemEntity, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken).ConfigureAwait(false);

    var data = new DummyItemGetActionDTO(
      dummyItemEntity.Id,
      dummyItemEntity.Name);

    return Result.Success(data);
  }
}
