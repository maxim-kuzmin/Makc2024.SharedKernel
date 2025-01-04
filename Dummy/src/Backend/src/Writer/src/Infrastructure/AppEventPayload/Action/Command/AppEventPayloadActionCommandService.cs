namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.Action.Command;

/// <summary>
/// Сервис команд действия над полезной нагрузкой события приложения.
/// </summary>
/// <param name="_eventDispatcher">Диспетчер событий.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppEventPayloadActionCommandService(
  IEventDispatcher _eventDispatcher,
  IAppEventPayloadFactory _factory,
  IAppEventPayloadRepository _repository) :
  IAppEventPayloadActionCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadGetActionDTO>> Create(
    AppEventPayloadCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    var appEventPayloadAggregate = _factory.CreateAggregate();

    appEventPayloadAggregate.UpdateName(command.Name);

    var appEventPayloadEntity = appEventPayloadAggregate.GetEntityToCreate();

    if (appEventPayloadEntity == null)
    {
      return Result.Forbidden();
    }

    appEventPayloadEntity = await _repository.AddAsync(appEventPayloadEntity, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(appEventPayloadAggregate, cancellationToken).ConfigureAwait(false);

    var data = new AppEventPayloadGetActionDTO(
      appEventPayloadEntity.Id,
      appEventPayloadEntity.Name);

    return Result.Success(data);
  }

  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppEventPayloadDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    var appEventPayloadEntity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (appEventPayloadEntity == null)
    {
      return Result.NotFound();
    }

    var appEventPayloadAggregate = _factory.CreateAggregate(appEventPayloadEntity.Id);

    appEventPayloadEntity = appEventPayloadAggregate.GetEntityToDelete(appEventPayloadEntity);

    if (appEventPayloadEntity == null)
    {
      return Result.NotFound();
    }

    await _repository.DeleteAsync(appEventPayloadEntity, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(appEventPayloadAggregate, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadGetActionDTO>> Update(
    AppEventPayloadUpdateActionCommand command,
    CancellationToken cancellationToken)
  {
    var appEventPayloadEntity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (appEventPayloadEntity == null)
    {
      return Result.NotFound();
    }

    var appEventPayloadAggregate = _factory.CreateAggregate(appEventPayloadEntity.Id);

    appEventPayloadAggregate.UpdateName(command.Name);

    var appEventPayloadEntityToUpdate = appEventPayloadAggregate.GetEntityToUpdate(appEventPayloadEntity);

    if (appEventPayloadEntityToUpdate != null)
    {
      appEventPayloadEntity = appEventPayloadEntityToUpdate;

      await _repository.UpdateAsync(appEventPayloadEntity, cancellationToken).ConfigureAwait(false);
    }

    await _eventDispatcher.DispatchAndClearEvents(appEventPayloadAggregate, cancellationToken).ConfigureAwait(false);

    var data = new AppEventPayloadGetActionDTO(
      appEventPayloadEntity.Id,
      appEventPayloadEntity.Name);

    return Result.Success(data);
  }
}
