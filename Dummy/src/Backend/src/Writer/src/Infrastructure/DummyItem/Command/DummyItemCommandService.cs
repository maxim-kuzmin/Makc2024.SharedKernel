namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Command;

public class DummyItemCommandService(IEventDispatcher _eventDispatcher, IDummyItemRepository _repository) :
  IDummyItemCommandService
{
  public async Task<Result<DummyItemGetActionDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    var dummyItemAggregate = new DummyItemAggregate();

    dummyItemAggregate.UpdateName(command.Name);

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

  public async Task<Result> Delete(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    var dummyItemEntity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

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

    await _repository.DeleteAsync(dummyItemEntity, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  public async Task<Result<DummyItemGetActionDTO>> Update(
    DummyItemUpdateActionCommand command,
    CancellationToken cancellationToken)
  {
    var dummyItemEntity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    var dummyItemAggregate = new DummyItemAggregate(dummyItemEntity.Id);

    dummyItemAggregate.UpdateName(command.Name);

    var dummyItemEntityToUpdate = dummyItemAggregate.GetDummyItemEntityToUpdate(dummyItemEntity);

    if (dummyItemEntityToUpdate != null)
    {
      dummyItemEntity = dummyItemEntityToUpdate;

      await _repository.UpdateAsync(dummyItemEntity, cancellationToken).ConfigureAwait(false);
    }

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken).ConfigureAwait(false);

    var data = new DummyItemGetActionDTO(
      dummyItemEntity.Id,
      dummyItemEntity.Name);

    return Result.Success(data);
  }
}
