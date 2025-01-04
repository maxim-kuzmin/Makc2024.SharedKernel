namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent.Action.Command;

/// <summary>
/// Сервис команд действия над событием приложения.
/// </summary>
/// <param name="_eventDispatcher">Диспетчер событий.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppEventActionCommandService(
  IEventDispatcher _eventDispatcher,
  IAppEventFactory _factory,
  IAppEventRepository _repository) :
  IAppEventActionCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventGetActionDTO>> Create(
    AppEventCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    var appEventAggregate = _factory.CreateAggregate();

    appEventAggregate.UpdateName(command.Name);

    var appEventEntity = appEventAggregate.GetEntityToCreate();

    if (appEventEntity == null)
    {
      return Result.Forbidden();
    }

    appEventEntity = await _repository.AddAsync(appEventEntity, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(appEventAggregate, cancellationToken).ConfigureAwait(false);

    var data = new AppEventGetActionDTO(
      appEventEntity.Id,
      appEventEntity.Name);

    return Result.Success(data);
  }

  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppEventDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    var appEventEntity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (appEventEntity == null)
    {
      return Result.NotFound();
    }

    var appEventAggregate = _factory.CreateAggregate(appEventEntity.Id);

    appEventEntity = appEventAggregate.GetEntityToDelete(appEventEntity);

    if (appEventEntity == null)
    {
      return Result.NotFound();
    }

    await _repository.DeleteAsync(appEventEntity, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(appEventAggregate, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventGetActionDTO>> Update(
    AppEventUpdateActionCommand command,
    CancellationToken cancellationToken)
  {
    var appEventEntity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (appEventEntity == null)
    {
      return Result.NotFound();
    }

    var appEventAggregate = _factory.CreateAggregate(appEventEntity.Id);

    appEventAggregate.UpdateName(command.Name);

    var appEventEntityToUpdate = appEventAggregate.GetEntityToUpdate(appEventEntity);

    if (appEventEntityToUpdate != null)
    {
      appEventEntity = appEventEntityToUpdate;

      await _repository.UpdateAsync(appEventEntity, cancellationToken).ConfigureAwait(false);
    }

    await _eventDispatcher.DispatchAndClearEvents(appEventAggregate, cancellationToken).ConfigureAwait(false);

    var data = new AppEventGetActionDTO(
      appEventEntity.Id,
      appEventEntity.Name);

    return Result.Success(data);
  }
}
