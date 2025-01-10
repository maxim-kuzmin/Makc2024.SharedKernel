namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Агрегат события приложения.
/// </summary>
/// <param name="entityId">Идентификатор сущности.</param>
/// <param name="_settings">Настройки.</param>
public class AppEventAggregate(
  long entityId,
  AppEventSettings _settings) : AggregateBase<AppEventEntity, long>(entityId)
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

    if (HasChangedProperty(nameof(Entity.CreatedAt)) && entityFromDb.CreatedAt != Entity.CreatedAt)
    {
      entityFromDb.CreatedAt = Entity.CreatedAt;

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
    UpdateCreatedAt(DateTimeOffset.Now);
  }

  /// <summary>
  /// Обновить дату создания.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateCreatedAt(DateTimeOffset value)
  {
    var parameterName = nameof(Entity.CreatedAt);

    Entity.CreatedAt = Guard.Against.Default(value, parameterName: parameterName);

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

    if (_settings.MaxLengthForName > 0)
    {
      Guard.Against.StringTooLong(value, _settings.MaxLengthForName, parameterName: parameterName);
    }

    Entity.Name = value;

    MarkPropertyAsChanged(parameterName);
  }
}
