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
  /// <param name="value">Значение.</param>
  public void UpdateName(string value)
  {
    string parameterName = nameof(Entity.Name);

    Guard.Against.NullOrWhiteSpace(value, parameterName: parameterName);

    Guard.Against.StringTooLong(value, DummyItemSettings.MaxLengthForName, parameterName: parameterName);

    Entity.Name = value;

    MarkPropertyAsChanged(nameof(Entity.Name));
  }
}
