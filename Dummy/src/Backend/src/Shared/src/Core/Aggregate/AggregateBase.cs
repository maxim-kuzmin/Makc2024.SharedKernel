namespace Makc2024.Dummy.Shared.Core.Aggregate;

/// <summary>
/// Основа агрегата.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TEntityId">Тип идентификатора сущности.</typeparam>
public class AggregateBase<TEntity, TEntityId> : EventSource
  where TEntity : class, IEntityBase<TEntityId>, new()
  where TEntityId : struct, IEquatable<TEntityId>
{
  private readonly HashSet<string> _changedProperties = [];

  /// <summary>
  /// Сущность.
  /// </summary>
  protected TEntity Entity { get; }

  /// <summary>
  /// Ошибки обновления.
  /// </summary>
  protected HashSet<AppError> UpdateErrors { get; } = [];

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="entityId">Идентификатор сущности.</param>
  public AggregateBase(TEntityId entityId = default)
  {
    Entity = new TEntity();

    Entity.SetId(entityId);

    Init();
  }

  /// <summary>
  /// Получить результат для создания.
  /// </summary>
  /// <returns>Сущность для создания.</returns>
  public virtual AggregateResult<EntityChange<TEntity>> GetResultToCreate()
  {
    TEntity? inserted = Entity;
    TEntity? deleted = null;

    inserted.RefreshConcurrencyToken();

    return new AggregateResult<EntityChange<TEntity>>(new(inserted, deleted), UpdateErrors);
  }

  /// <summary>
  /// Получить результат для удаления.
  /// </summary>
  /// <param name="entityFromDb">Сущность из базы данных.</param>
  /// <returns>Сущность для удаления.</returns>
  public virtual AggregateResult<EntityChange<TEntity>> GetResultToDelete(TEntity entityFromDb)
  {
    if (IsUnchangeable(entityFromDb))
    {
      return new AggregateResult<EntityChange<TEntity>>(null);
    }

    TEntity? inserted = null;
    TEntity? deleted = entityFromDb;

    return new AggregateResult<EntityChange<TEntity>>(new(inserted, deleted));
  }

  /// <summary>
  /// Получить результат для обновления.
  /// </summary>
  /// <param name="entityFromDb">Сущность из базы данных.</param>
  /// <returns>Сущность для обновления.</returns>
  public virtual AggregateResult<EntityChange<TEntity>> GetResultToUpdate(TEntity entityFromDb)
  {
    if (IsUnchangeable(entityFromDb))
    {
      return new AggregateResult<EntityChange<TEntity>>(null);
    }

    TEntity? inserted = entityFromDb;
    TEntity? deleted = (TEntity)entityFromDb.DeepCopy();

    inserted.RefreshConcurrencyToken();

    return new AggregateResult<EntityChange<TEntity>>(new(inserted, deleted), UpdateErrors);
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
  /// Инициализировать.
  /// </summary>
  protected virtual void Init()
  {
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
  /// Неизменная?
  /// </summary>
  /// <param name="entityFromDb">Сущность из базы данных.</param>
  /// <returns>Если сущность не может быть изменена, то true, иначе - false.</returns>
  protected bool IsUnchangeable(TEntity entityFromDb)
  {
    return Entity.GetId().Equals(default) || !entityFromDb.GetId().Equals(Entity.GetId());
  }
}
