namespace Makc2024.Dummy.Writer.DomainModel.App.EventPayload;

/// <summary>
/// Агрегат полезной нагрузки события приложения.
/// </summary>
/// <param name="entityId">Идентификатор сущности.</param>
public class AppEventPayloadAggregate(long entityId = default) : AggregateBase<AppEventPayloadEntity, long>(entityId)
{
  /// <inheritdoc/>
  public sealed override AppEventPayloadEntity? GetEntityToUpdate(AppEventPayloadEntity entityFromDb)
  {
    var result = base.GetEntityToUpdate(entityFromDb);

    if (result == null)
    {
      return result;
    }

    bool isOk = false;

    if (HasChangedProperty(nameof(Entity.AppEventId)) && entityFromDb.AppEventId != Entity.AppEventId)
    {
      entityFromDb.AppEventId = Entity.AppEventId;

      isOk = true;
    }

    if (HasChangedProperty(nameof(Entity.Entity)) && entityFromDb.Entity != Entity.Entity)
    {
      entityFromDb.Entity = Entity.Entity;

      isOk = true;
    }

    if (HasChangedProperty(nameof(Entity.EntityId)) && entityFromDb.EntityId != Entity.EntityId)
    {
      entityFromDb.EntityId = Entity.EntityId;

      isOk = true;
    }

    if (HasChangedProperty(nameof(Entity.Name)) && entityFromDb.Name != Entity.Name)
    {
      entityFromDb.Name = Entity.Name;

      isOk = true;
    }

    if (HasChangedProperty(nameof(Entity.NewValue)) && entityFromDb.NewValue != Entity.NewValue)
    {
      entityFromDb.NewValue = Entity.NewValue;

      isOk = true;
    }

    if (HasChangedProperty(nameof(Entity.OldValue)) && entityFromDb.OldValue != Entity.OldValue)
    {
      entityFromDb.OldValue = Entity.OldValue;

      isOk = true;
    }

    return isOk ? entityFromDb : null;
  }

  /// <summary>
  /// Обновить идентификатор события приложения.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateAppEventId(long value)
  {
    string parameterName = nameof(Entity.AppEventId);

    Entity.AppEventId = Guard.Against.Default(value, parameterName: parameterName);

    MarkPropertyAsChanged(parameterName);
  }

  /// <summary>
  /// Обновить сущность.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEntity(string value)
  {
    string parameterName = nameof(Entity.Entity);

    Guard.Against.NullOrWhiteSpace(value, parameterName: parameterName);

    Guard.Against.StringTooLong(value, AppEventPayloadSettings.MaxLengthForEntity, parameterName: parameterName);

    Entity.Entity = value;

    MarkPropertyAsChanged(parameterName);
  }

  /// <summary>
  /// Обновить идентификатор сущности.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEntityId(string value)
  {
    string parameterName = nameof(Entity.EntityId);

    Guard.Against.NullOrWhiteSpace(value, parameterName: parameterName);

    Guard.Against.StringTooLong(value, AppEventPayloadSettings.MaxLengthForEntityId, parameterName: parameterName);

    Entity.EntityId = value;

    MarkPropertyAsChanged(parameterName);
  }

  /// <summary>
  /// Обновить имя.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateName(string value)
  {
    string parameterName = nameof(Entity.Name);

    if (value != null)
    {
      Guard.Against.NullOrWhiteSpace(value, parameterName: parameterName);

      Guard.Against.StringTooLong(value, AppEventPayloadSettings.MaxLengthForName, parameterName: parameterName);
    }

    Entity.Name = value;

    MarkPropertyAsChanged(parameterName);
  }

  /// <summary>
  /// Обновить новое значение.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateNewValue(string value)
  {
    string parameterName = nameof(Entity.NewValue);

    Entity.NewValue = value;

    MarkPropertyAsChanged(parameterName);
  }

  /// <summary>
  /// Обновить старое значение.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateOldValue(string value)
  {
    string parameterName = nameof(Entity.OldValue);

    Entity.OldValue = value;

    MarkPropertyAsChanged(parameterName);
  }
}
