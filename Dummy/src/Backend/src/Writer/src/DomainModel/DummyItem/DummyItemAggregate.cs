namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Агрегат фиктивного предмета.
/// </summary>
/// <param name="entityId">Идентификатор сущности.</param>
public class DummyItemAggregate(long entityId = default) : AggregateBase<DummyItemEntity, long>(entityId)
{
  /// <inheritdoc/>
  public sealed override DummyItemEntity? GetEntityToUpdate(DummyItemEntity entityFromDb)
  {
    var result = base.GetEntityToUpdate(entityFromDb);

    if (result == null)
    {
      return result;
    }

    bool isOk = false;

    if (HasChangedProperty(nameof(Entity.Name)) && entityFromDb.Name != Entity.Name)
    {
      entityFromDb.Name = Entity.Name;

      isOk = true;
    }

    return isOk ? entityFromDb : null;
  }

  /// <summary>
  /// Обновить имя.
  /// </summary>
  /// <param name="name">Имя.</param>
  public void UpdateName(string name)
  {
    Entity.Name = Guard.Against.NullOrEmpty(name, nameof(name));

    MarkPropertyAsChanged(nameof(Entity.Name));
  }
}
