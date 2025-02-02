namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Action.Command;

/// <summary>
/// Сервис команд действия с событием приложения.
/// </summary>
/// <param name="_appDbExecutor">Исполнитель базы данных.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppEventActionCommandService(
  IAppDbExecutor _appDbExecutor,
  IAppEventFactory _factory,
  IAppEventRepository _repository) : IAppEventActionCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventSingleDTO>> Create(
    AppEventCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    var aggregate = _factory.CreateAggregate();

    aggregate.UpdateIsPublished(command.IsPublished);
    aggregate.UpdateName(command.Name);

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

    var dto = entity.ToAppEventSingleDTO();

    return Result.Success(dto);
  }

  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppEventDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity);

    var aggregateResult = aggregate.GetResultToDelete();

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

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventSingleDTO>> Update(
    AppEventUpdateActionCommand command,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateIsPublished(command.IsPublished);
    aggregate.UpdateName(command.Name);

    var aggregateResult = aggregate.GetResultToUpdate();

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

    var dto = entity.ToAppEventSingleDTO();

    return Result.Success(dto);
  }
}
