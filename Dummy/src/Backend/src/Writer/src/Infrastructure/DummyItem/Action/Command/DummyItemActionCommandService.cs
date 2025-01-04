namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Action.Command;

/// <summary>
/// Сервис команд действия над фиктивным предметом.
/// </summary>
/// <param name="_eventDispatcher">Диспетчер событий.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class DummyItemActionCommandService(
  IEventDispatcher _eventDispatcher,
  IDummyItemFactory _factory,
  IDummyItemRepository _repository) :
  IDummyItemActionCommandService
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemGetActionDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    var dummyItemAggregate = _factory.CreateAggregate();

    dummyItemAggregate.UpdateName(command.Name);

    var dummyItemEntity = dummyItemAggregate.GetEntityToCreate();

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

  /// <inheritdoc/>
  public async Task<Result> Delete(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    var dummyItemEntity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    var dummyItemAggregate = _factory.CreateAggregate(dummyItemEntity.Id);

    dummyItemEntity = dummyItemAggregate.GetEntityToDelete(dummyItemEntity);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    await _repository.DeleteAsync(dummyItemEntity, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemGetActionDTO>> Update(
    DummyItemUpdateActionCommand command,
    CancellationToken cancellationToken)
  {
    var dummyItemEntity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    var dummyItemAggregate = _factory.CreateAggregate(dummyItemEntity.Id);

    dummyItemAggregate.UpdateName(command.Name);

    var dummyItemEntityToUpdate = dummyItemAggregate.GetEntityToUpdate(dummyItemEntity);

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
