namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Агрегат фиктивного предмета.
/// </summary>
/// <param name="entityId">Идентификатор сущности.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class DummyItemAggregate(
  long entityId,
  IDummyItemResources _resources,
  DummyItemSettings _settings) : AggregateBase<DummyItemEntity, long>(entityId)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<EntityChange<DummyItemEntity>> GetResultToUpdate(DummyItemEntity entityFromDb)
  {
    var result = base.GetResultToUpdate(entityFromDb);

    if (result.IsInvalid)
    {
      return result;
    }

    if (HasChangedProperties())
    {
      bool isOk = false;

      if (HasChangedProperty(nameof(Entity.Name)) && entityFromDb.Name != Entity.Name)
      {
        entityFromDb.Name = Entity.Name;

        isOk = true;
      }

      if (isOk)
      {
        return result;
      }
    }

    return new AggregateResult<EntityChange<DummyItemEntity>>(new(null, null));
  }

  /// <summary>
  /// Обновить имя.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateName(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetNameIsEmptyErrorMessage();

      var appError = DummyItemError.NameIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    if (_settings.MaxLengthForName > 0 && value.Length > _settings.MaxLengthForName)
    {
      string errorMessage = _resources.GetNameIsTooLongErrorMessage(_settings.MaxLengthForName);

      var appError = DummyItemError.NameIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    Entity.Name = value;

    MarkPropertyAsChanged(nameof(Entity.Name));
  }
}
