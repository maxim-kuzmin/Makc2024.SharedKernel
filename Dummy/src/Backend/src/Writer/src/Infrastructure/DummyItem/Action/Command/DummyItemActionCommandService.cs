namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Action.Command;

/// <summary>
/// Сервис команд действия с фиктивным предметом.
/// </summary>
/// <param name="_appDbExecutor">Исполнитель базы данных.</param>
/// <param name="_appSynchronization">Синхронизация приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class DummyItemActionCommandService(
  IAppDbExecutor _appDbExecutor,
  IAppSynchronizationActionCommandService _appSynchronization,
  IDummyItemFactory _factory,
  IDummyItemRepository _repository) : IDummyItemActionCommandService
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    var aggregate = _factory.CreateAggregate();

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

      await OnEntityChanged(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutor.ExecuteInTransaction(SaveToDb, cancellationToken).ConfigureAwait(false);    

    var dto = entity.ToDummyItemSingleDTO();

    return Result.Success(dto);
  }

  /// <inheritdoc/>
  public async Task<Result> Delete(
    DummyItemDeleteActionCommand command,
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

      await OnEntityChanged(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutor.ExecuteInTransaction(SaveToDb, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Update(
    DummyItemUpdateActionCommand command,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity);

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

      await OnEntityChanged(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutor.ExecuteInTransaction(SaveToDb, cancellationToken).ConfigureAwait(false);

    var dto = entity.ToDummyItemSingleDTO();

    return Result.Success(dto);
  }

  private Task<Result> OnEntityChanged(DummyItemEntity entity, CancellationToken cancellationToken)
  {
    return _appSynchronization.Start(new("DummyItem_Changed", [entity]), cancellationToken);
  }
}
