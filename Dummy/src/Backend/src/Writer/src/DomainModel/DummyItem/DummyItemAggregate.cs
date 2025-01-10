﻿namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Агрегат фиктивного предмета.
/// </summary>
/// <param name="entityId">Идентификатор сущности.</param>
/// <param name="_settings">Настройки.</param>
public class DummyItemAggregate(
  long entityId,
  DummyItemSettings _settings) : AggregateBase<DummyItemEntity, long>(entityId)
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

    if (_settings.MaxLengthForName > 0)
    {
      Guard.Against.StringTooLong(value, _settings.MaxLengthForName, parameterName: parameterName);
    }

    Entity.Name = value;

    MarkPropertyAsChanged(nameof(Entity.Name));
  }
}
