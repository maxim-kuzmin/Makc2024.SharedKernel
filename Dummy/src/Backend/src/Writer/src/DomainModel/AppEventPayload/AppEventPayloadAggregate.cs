namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Агрегат полезной нагрузки события приложения.
/// </summary>
/// <param name="entityId">Идентификатор сущности.</param>
/// <param name="_settings">Настройки.</param>
public class AppEventPayloadAggregate(
  long entityId,
  AppEventPayloadSettings _settings) : AggregateBase<AppEventPayloadEntity, long>(entityId)
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

    if (HasChangedProperty(nameof(Entity.Data)) && entityFromDb.Data != Entity.Data)
    {
      entityFromDb.Data = Entity.Data;

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
  /// Обновить данные.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateData(string value)
  {
    string parameterName = nameof(Entity.Data);

    Guard.Against.NullOrWhiteSpace(value, parameterName: parameterName);

    if (_settings.MaxLengthForData > 0)
    {
      Guard.Against.StringTooLong(value, _settings.MaxLengthForData, parameterName: parameterName);
    }

    Entity.Data = value;

    MarkPropertyAsChanged(parameterName);
  }
}
