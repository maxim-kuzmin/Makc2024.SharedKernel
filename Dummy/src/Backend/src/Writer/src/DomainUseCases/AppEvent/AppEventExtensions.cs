namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent;

/// <summary>
/// Расширения события приложения.
/// </summary>
public static class AppEventExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных одиночного события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных одиночного события приложения.</returns>
  public static AppEventSingleDTO ToAppEventSingleDTO(this AppEventEntity entity)
  {
    return new(entity.Id, entity.CreatedAt, entity.IsPublished, entity.Name);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных списка событий приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных списка событий приложения.</returns>
  public static AppEventListDTO ToAppEventListDTO(this List<AppEventSingleDTO> items, long totalCount)
  {
    return new(items, totalCount);
  }
}
