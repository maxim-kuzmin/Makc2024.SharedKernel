namespace Makc2024.Dummy.Shared.Core.Aggregate;

/// <summary>
/// Основа агрегата.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TEntityId">Тип идентификатора сущности.</typeparam>
/// <remarks>
/// Конструктор.
/// </remarks>
/// <param name="entityFromDb">Сущность из базы данных.</param>
public class AggregateBase<TEntity, TEntityId>(TEntity? _entityFromDb = null)
  where TEntity : class, IEntityBase<TEntityId>, new()
  where TEntityId : struct, IEquatable<TEntityId>
{
  private readonly HashSet<string> _changedProperties = [];

  private TEntity? _entity;

  /// <summary>
  /// Ошибки обновления.
  /// </summary>
  protected HashSet<AppError> UpdateErrors { get; } = [];

  /// <summary>
  /// Получить результат для создания.
  /// </summary>
  /// <returns>Результат для создания.</returns>
  public virtual AggregateResult<EntityChange<TEntity>> GetResultToCreate()
  {
    if (_entity == null)
    {
      return new AggregateResult<EntityChange<TEntity>>(null);
    }

    OnGetResultToCreate(_entity);

    return new AggregateResult<EntityChange<TEntity>>(new(_entity, null), UpdateErrors);
  }

  /// <summary>
  /// Получить результат для удаления.
  /// </summary>
  /// <returns>Результат для удаления.</returns>
  public virtual AggregateResult<EntityChange<TEntity>> GetResultToDelete()
  {
    if (_entityFromDb == null || _entityFromDb.GetId().Equals(default))
    {
      return new AggregateResult<EntityChange<TEntity>>(null);
    }

    OnGetResultToDelete(_entityFromDb);

    return new AggregateResult<EntityChange<TEntity>>(new(null, _entityFromDb));
  }

  /// <summary>
  /// Получить результат для обновления.
  /// </summary>
  /// <returns>Результат для обновления.</returns>
  public virtual AggregateResult<EntityChange<TEntity>> GetResultToUpdate()
  {
    if (_entityFromDb == null || _entityFromDb.GetId().Equals(default))
    {
      return new AggregateResult<EntityChange<TEntity>>(null);
    }

    OnGetResultToUpdate(_entityFromDb);

    var deleted = (TEntity)_entityFromDb.DeepCopy();

    return new AggregateResult<EntityChange<TEntity>>(new(_entityFromDb, deleted), UpdateErrors);
  }

  /// <summary>
  /// Получить сушность для обновления.
  /// </summary>
  /// <returns>Сущность для обновления.</returns>
  protected TEntity GetEntityToUpdate()
  {
    if (_entity == null)
    {
      _entity = new TEntity();
    }

    return _entity;
  }

  /// <summary>
  /// Недействителен ли для обновления?
  /// </summary>
  /// <param name="aggregateResult">Результат агрегата.</param>
  /// <returns>Если недействителен для обновления, то true, иначе - false.</returns>
  protected bool IsInvalidToUpdate(AggregateResult<EntityChange<TEntity>> aggregateResult)
  {
    return aggregateResult.IsInvalid
      ||
      aggregateResult.Data?.Inserted == null
      ||
      aggregateResult.Data?.Deleted == null;
  }

  /// <summary>
  /// Есть ли изменённые свойства?
  /// </summary>
  /// <returns>Если есть изменённые свойства, то true, иначе - false.</returns>
  protected bool HasChangedProperties()
  {
    return _changedProperties.Count > 0;
  }

  /// <summary>
  /// Есть ли изменённое свойство?
  /// </summary>
  /// <param name="propertyName">Имя свойства.</param>
  /// <returns>Если значение свойства изменилось, то true, иначе - false.</returns>
  protected bool HasChangedProperty(string propertyName)
  {
    return _changedProperties.Contains(propertyName);
  }

  /// <summary>
  /// Пометить свойство как изменённое.
  /// </summary>
  /// <param name="propertyName">Имя свойства.</param>
  protected void MarkPropertyAsChanged(string propertyName)
  {
    _changedProperties.Add(propertyName);
  }

  /// <summary>
  /// Обработать событие получения результата для создания.
  /// </summary>
  /// <param name="entity">Обновляемая сущность.</param>
  protected virtual void OnGetResultToCreate(TEntity entity)
  {
  }

  /// <summary>
  /// Обработать событие получения результата для удаления.
  /// </summary>
  /// <param name="entity">Удаляемая сущность.</param>
  protected virtual void OnGetResultToDelete(TEntity entity)
  {
  }

  /// <summary>
  /// Обработать событие получения результата для обновления.
  /// </summary>
  /// <param name="entity">Обновляемая сущность.</param>
  protected virtual void OnGetResultToUpdate(TEntity entity)
  {
  }
}
