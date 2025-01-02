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
  /// Получить сущность для создания.
  /// </summary>
  /// <returns>Сущность для создания.</returns>
  public virtual TEntity? GetEntityToCreate()
  {
    return (TEntity)Entity.DeepCopy();
  }

  /// <summary>
  /// Получить сущность для удаления.
  /// </summary>
  /// <param name="entityFromDb">Сущность из базы данных.</param>
  /// <returns>Сущность для удаления.</returns>
  public virtual TEntity? GetEntityToDelete(TEntity entityFromDb)
  {
    if (IsUnchangeable(entityFromDb))
    {
      return null;
    }

    return entityFromDb;
  }

  /// <summary>
  /// Получить сущность для обновления.
  /// </summary>
  /// <param name="entityFromDb">Сущность из базы данных.</param>
  /// <returns>Сущность для обновления.</returns>
  public virtual TEntity? GetEntityToUpdate(TEntity entityFromDb)
  {
    if (IsUnchangeable(entityFromDb))
    {
      return null;
    }

    return entityFromDb;
  }

  /// <summary>
  /// Есть изменённое свойство.
  /// </summary>
  /// <param name="propertyName">Имя свойства.</param>
  /// <returns>Если значение сойства изменилось, то true, иначе - false.</returns>
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

  private bool IsUnchangeable(TEntity entityFromDb)
  {
    return Entity.GetId().Equals(default) || !entityFromDb.GetId().Equals(Entity.GetId());
  }
}
