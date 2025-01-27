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

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    var entity = aggregateResult.Entity;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    entity = await _repository.AddAsync(entity, cancellationToken).ConfigureAwait(false);

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

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    entity = aggregateResult.Entity;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    await _repository.DeleteAsync(entity, cancellationToken).ConfigureAwait(false);

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

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    entity = aggregateResult.Entity;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    await _repository.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(aggregate, cancellationToken).ConfigureAwait(false);

    var dto = new AppEventPayloadGetActionDTO(
      entity.Id,
      entity.AppEventId,
      entity.Data);

    return Result.Success(dto);
  }
}
