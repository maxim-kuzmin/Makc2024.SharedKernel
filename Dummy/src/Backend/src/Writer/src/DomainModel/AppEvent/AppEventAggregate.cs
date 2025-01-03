namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Агрегат события приложения.
/// </summary>
/// <param name="entityId">Идентификатор сущности.</param>
public class AppEventAggregate(long entityId = default) : AggregateBase<AppEventEntity, long>(entityId)
{
  /// <inheritdoc/>
  public sealed override AppEventEntity? GetEntityToUpdate(AppEventEntity entityFromDb)
  {
    var result = base.GetEntityToUpdate(entityFromDb);

    if (result == null)
    {
      return result;
    }

    var isOk = false;

    if (HasChangedProperty(nameof(Entity.CreationDate)) && entityFromDb.CreationDate != Entity.CreationDate)
    {
      entityFromDb.CreationDate = Entity.CreationDate;

      isOk = true;
    }

    if (HasChangedProperty(nameof(Entity.IsPublished)) && entityFromDb.IsPublished != Entity.IsPublished)
    {
      entityFromDb.IsPublished = Entity.IsPublished;

      isOk = true;
    }

    if (HasChangedProperty(nameof(Entity.Name)) && entityFromDb.Name != Entity.Name)
    {
      entityFromDb.Name = Entity.Name;

      isOk = true;
    }

    return isOk ? entityFromDb : null;
  }

  /// <inheritdoc/>
  protected sealed override void Init()
  {
    UpdateCreationDate(DateTimeOffset.Now);
  }

  /// <summary>
  /// Обновить дату создания.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateCreationDate(DateTimeOffset value)
  {
    var parameterName = nameof(Entity.CreationDate);

    Entity.CreationDate = Guard.Against.Default(value, parameterName: parameterName);

    MarkPropertyAsChanged(parameterName);
  }

  /// <summary>
  /// Обновить дату создания.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateIsPublished(bool value)
  {
    var parameterName = nameof(Entity.IsPublished);

    Entity.IsPublished = value;

    MarkPropertyAsChanged(parameterName);
  }

  /// <summary>
  /// Обновить имя.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateName(string value)
  {
    var parameterName = nameof(Entity.Name);

    Guard.Against.NullOrWhiteSpace(value, parameterName: parameterName);

    Guard.Against.StringTooLong(value, AppEventSettings.MaxLengthForName, parameterName: parameterName);

    Entity.Name = value;

    MarkPropertyAsChanged(parameterName);
  }
}
