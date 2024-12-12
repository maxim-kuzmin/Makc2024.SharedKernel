namespace Makc2024.Dummy.Shared.Core.Aggregate;

/// <summary>
/// Основа агрегата.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TEntityId">Тип идентификатора сущности.</typeparam>
/// <param name="entityId">Идентификатор сущности.</param>
public class AggregateBase<TEntity, TEntityId>(TEntityId entityId = default) : EventSource
  where TEntity : class, IEntityBase<TEntityId>, new()
  where TEntityId : struct, IEquatable<TEntityId>
{
  private readonly HashSet<string> _changedProperties = [];

  /// <summary>
  /// Сущность.
  /// </summary>
  protected TEntity Entity { get; } = CreateEntity(entityId);

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
  /// Пометить свойство как изменённое.
  /// </summary>
  /// <param name="propertyName">Имя свойства.</param>
  protected void MarkPropertyAsChanged(string propertyName)
  {
    _changedProperties.Add(propertyName);
  }

  private static TEntity CreateEntity(TEntityId entityId)
  {
    var result = new TEntity();

    result.SetId(entityId);

    return result;
  }

  private bool IsUnchangeable(TEntity entityFromDb)
  {
    return Entity.GetId().Equals(default) || !entityFromDb.GetId().Equals(Entity.GetId());
  }
}
