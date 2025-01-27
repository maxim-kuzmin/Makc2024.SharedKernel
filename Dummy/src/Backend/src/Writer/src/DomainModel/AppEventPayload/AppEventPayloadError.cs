namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Ошибка полезной нагрузки события приложения.
/// </summary>
public enum AppEventPayloadError
{
  /// <summary>
  /// Идентификатор события недействителен.
  /// </summary>
  AppEventIdIsInvalid,

  /// <summary>
  /// Данные пустые.
  /// </summary>
  DataIsEmpty,

  /// <summary>
  /// Данные слишком длинные.
  /// </summary>
  DataIsTooLong
}
