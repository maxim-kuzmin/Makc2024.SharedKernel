using Makc2024.Dummy.Writer.DomainModel.DummyItem;

namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Агрегат события приложения.
/// </summary>
/// <param name="entityFromDb">Сущность из базы данных.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppEventAggregate(
  AppEventEntity? entityFromDb,
  IAppEventResources _resources,
  AppEventSettings _settings) : AggregateBase<AppEventEntity, long>(entityFromDb)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<EntityChange<AppEventEntity>> GetResultToUpdate()
  {
    var result = base.GetResultToUpdate();

    if (IsInvalidToUpdate(result))
    {
      return result;
    }

    if (HasChangedProperties())
    {
      var isOk = false;

      var inserted = result.Data!.Inserted!;

      var entity = GetEntityToUpdate();

      if (HasChangedProperty(nameof(entity.CreatedAt)) && inserted.CreatedAt != entity.CreatedAt)
      {
        inserted.CreatedAt = entity.CreatedAt;

        isOk = true;
      }

      if (HasChangedProperty(nameof(entity.IsPublished)) && inserted.IsPublished != entity.IsPublished)
      {
        inserted.IsPublished = entity.IsPublished;

        isOk = true;
      }

      if (HasChangedProperty(nameof(entity.Name)) && inserted.Name != entity.Name)
      {
        inserted.Name = entity.Name;

        isOk = true;
      }

      if (isOk)
      {
        return result;
      }
    }

    return new AggregateResult<EntityChange<AppEventEntity>>(new(null, null));
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

    var entity = GetEntityToUpdate();

    entity.CreatedAt = value;

    MarkPropertyAsChanged(nameof(entity.CreatedAt));
  }

  /// <summary>
  /// Обновить дату создания.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateIsPublished(bool value)
  {
    var entity = GetEntityToUpdate();

    entity.IsPublished = value;

    MarkPropertyAsChanged(nameof(entity.IsPublished));
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

    var entity = GetEntityToUpdate();

    entity.Name = value;

    MarkPropertyAsChanged(nameof(entity.Name));
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToCreate(AppEventEntity entity)
  {
    RefreshConcurrencyToken(entity);
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToUpdate(AppEventEntity entity)
  {
    RefreshConcurrencyToken(entity);
  }

  private static void RefreshConcurrencyToken(AppEventEntity entity)
  {
    entity.ConcurrencyToken = Guid.NewGuid();
  }
}
