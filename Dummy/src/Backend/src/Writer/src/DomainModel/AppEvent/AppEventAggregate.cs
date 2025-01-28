using Makc2024.Dummy.Writer.DomainModel.DummyItem;

namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Агрегат события приложения.
/// </summary>
/// <param name="entityId">Идентификатор сущности.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppEventAggregate(
  long entityId,
  IAppEventResources _resources,
  AppEventSettings _settings) : AggregateBase<AppEventEntity, long>(entityId)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<EntityChange<AppEventEntity>> GetResultToUpdate(AppEventEntity entityFromDb)
  {
    var result = base.GetResultToUpdate(entityFromDb);

    if (result.IsInvalid)
    {
      return result;
    }

    if (HasChangedProperties())
    {
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

      if (isOk)
      {
        return result;
      }
    }

    return new AggregateResult<EntityChange<AppEventEntity>>(new(null, null));
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
    if (value == default)
    {
      string errorMessage = _resources.GetCreatedAtIsInvalidErrorMessage();

      var appError = AppEventError.CreatedAtIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    Entity.CreatedAt = value;

    MarkPropertyAsChanged(nameof(Entity.CreatedAt));
  }

  /// <summary>
  /// Обновить дату создания.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateIsPublished(bool value)
  {
    Entity.IsPublished = value;

    MarkPropertyAsChanged(nameof(Entity.IsPublished));
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

      var appError = AppEventError.NameIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    if (_settings.MaxLengthForName > 0 && value.Length > _settings.MaxLengthForName)
    {
      string errorMessage = _resources.GetNameIsTooLongErrorMessage(_settings.MaxLengthForName);

      var appError = AppEventError.NameIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    Entity.Name = value;

    MarkPropertyAsChanged(nameof(Entity.Name));
  }
}
