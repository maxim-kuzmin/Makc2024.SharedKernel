namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Агрегат полезной нагрузки события приложения.
/// </summary>
/// <param name="entityId">Идентификатор сущности.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppEventPayloadAggregate(
  long entityId,
  IAppEventPayloadResources _resources,
  AppEventPayloadSettings _settings) : AggregateBase<AppEventPayloadEntity, long>(entityId)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<EntityChange<AppEventPayloadEntity>> GetResultToUpdate(
    AppEventPayloadEntity entityFromDb)
  {
    var result = base.GetResultToUpdate(entityFromDb);

    if (result.IsInvalid)
    {
      return result;
    }

    if (HasChangedProperties())
    {
      bool isOk = false;

      if (HasChangedProperty(nameof(Entity.AppEventId)) && entityFromDb.AppEventId != Entity.AppEventId)
      {
        entityFromDb.AppEventId = Entity.AppEventId;

        isOk = true;
      }

      if (HasChangedProperty(nameof(Entity.Data)) && entityFromDb.Data != Entity.Data)
      {
        entityFromDb.Data = Entity.Data;

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

    Entity.AppEventId = value;

    MarkPropertyAsChanged(nameof(Entity.AppEventId));
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

    Entity.Data = value;

    MarkPropertyAsChanged(nameof(Entity.Data));
  }
}
