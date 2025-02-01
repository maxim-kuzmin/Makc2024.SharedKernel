namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload;

/// <summary>
/// Расширения полезной нагрузки события приложения.
/// </summary>
public static class AppEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных одиночной полезной нагрузки события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных одиночной полезной нагрузки события приложения.</returns>
  public static AppEventPayloadSingleDTO ToAppEventPayloadSingleDTO(this AppEventPayloadEntity entity)
  {
    return new(entity.Id, entity.AppEventId, entity.Data);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных списка полезных нагрузок события приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных списка полезных нагрузок события приложения.</returns>
  public static AppEventPayloadListDTO ToAppEventPayloadListDTO(
    this List<AppEventPayloadSingleDTO> items,
    long totalCount)
  {
    return new(items, totalCount);
  }
}
