namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Агрегат полезной нагрузки события приложения.
/// </summary>
/// <param name="entityFromDb">Сущность из базы данных.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppEventPayloadAggregate(
  AppEventPayloadEntity? entityFromDb,
  IAppEventPayloadResources _resources,
  AppEventPayloadSettings _settings) : AggregateBase<AppEventPayloadEntity, long>(entityFromDb)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<EntityChange<AppEventPayloadEntity>> GetResultToUpdate()
  {
    var result = base.GetResultToUpdate();

    if (IsInvalidToUpdate(result))
    {
      return result;
    }

    if (HasChangedProperties())
    {
      bool isOk = false;

      var inserted = result.Data!.Inserted!;

      var entity = GetEntityToUpdate();

      if (HasChangedProperty(nameof(entity.AppEventId)) && inserted.AppEventId != entity.AppEventId)
      {
        inserted.AppEventId = entity.AppEventId;

        isOk = true;
      }

      if (HasChangedProperty(nameof(entity.Data)) && inserted.Data != entity.Data)
      {
        inserted.Data = entity.Data;

        isOk = true;
      }

      if (isOk)
      {
        return result;
      }
    }

    return new AggregateResult<EntityChange<AppEventPayloadEntity>>(new(null, null));
  }

  /// <summary>
  /// Обновить идентификатор события приложения.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateAppEventId(long value)
  {
    if (value == default)
    {
      string errorMessage = _resources.GetAppEventIdIsInvalidErrorMessage();

      var appError = AppEventPayloadError.AppEventIdIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.AppEventId = value;

    MarkPropertyAsChanged(nameof(entity.AppEventId));
  }

  /// <summary>
  /// Обновить данные.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateData(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetDataIsEmptyErrorMessage();

      var appError = AppEventPayloadError.DataIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    if (_settings.MaxLengthForData > 0 && value.Length > _settings.MaxLengthForData)
    {
      string errorMessage = _resources.GetDataIsTooLongErrorMessage(_settings.MaxLengthForData);

      var appError = AppEventPayloadError.DataIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Data = value;

    MarkPropertyAsChanged(nameof(entity.Data));
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToCreate(AppEventPayloadEntity entity)
  {
    entity.ConcurrencyToken = Guid.NewGuid();
  }
  
  /// <inheritdoc/>
  protected sealed override void OnGetResultToUpdate(AppEventPayloadEntity entity)
  {
    entity.ConcurrencyToken = Guid.NewGuid();
  }
}
