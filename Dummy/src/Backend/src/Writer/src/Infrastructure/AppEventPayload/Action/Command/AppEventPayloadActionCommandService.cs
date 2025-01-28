namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.Action.Command;

/// <summary>
/// Сервис команд действия над полезной нагрузкой события приложения.
/// </summary>
/// <param name="_appDbExecutor">Исполнитель базы данных.</param>
/// <param name="_eventDispatcher">Диспетчер событий.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppEventPayloadActionCommandService(
  IAppDbExecutor _appDbExecutor,
  IEventDispatcher _eventDispatcher,
  IAppEventPayloadFactory _factory,
  IAppEventPayloadRepository _repository) : IAppEventPayloadActionCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadGetActionDTO>> Create(
    AppEventPayloadCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    var aggregate = _factory.CreateAggregate();

    aggregate.UpdateAppEventId(command.AppEventId);
    aggregate.UpdateData(command.Data);

    var aggregateResult = aggregate.GetResultToCreate();

    if (aggregateResult.Data == null)
    {
      return Result.Invalid();
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    var entity = aggregateResult.Data.Inserted;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    async Task SaveToDb(CancellationToken cancellationToken)
    {
      entity = await _repository.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutor.Execute(SaveToDb, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(aggregate, cancellationToken).ConfigureAwait(false);

    var dto = new AppEventPayloadGetActionDTO(
      entity.Id,
      entity.AppEventId,
      entity.Data);

    return Result.Success(dto);
  }

  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppEventPayloadDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity.Id);

    var aggregateResult = aggregate.GetResultToDelete(entity);

    if (aggregateResult.Data == null)
    {
      return Result.Invalid();
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    entity = aggregateResult.Data.Deleted;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    async Task SaveToDb(CancellationToken cancellationToken)
    {
      await _repository.DeleteAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutor.Execute(SaveToDb, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(aggregate, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadGetActionDTO>> Update(
    AppEventPayloadUpdateActionCommand command,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity.Id);

    aggregate.UpdateAppEventId(command.AppEventId);
    aggregate.UpdateData(command.Data);

    var aggregateResult = aggregate.GetResultToUpdate(entity);

    if (aggregateResult.Data == null)
    {
      return Result.Invalid();
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    entity = aggregateResult.Data.Inserted;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    async Task SaveToDb(CancellationToken cancellationToken)
    {
      await _repository.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutor.Execute(SaveToDb, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(aggregate, cancellationToken).ConfigureAwait(false);

    var dto = new AppEventPayloadGetActionDTO(
      entity.Id,
      entity.AppEventId,
      entity.Data);

    return Result.Success(dto);
  }
}
