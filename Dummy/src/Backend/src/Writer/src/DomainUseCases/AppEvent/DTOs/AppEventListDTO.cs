namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.DTOs;

/// <summary>
/// Объект передачи данных списка событий приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppEventListDTO(
  List<AppEventSingleDTO> Items,
  long TotalCount) : ListDTO<AppEventSingleDTO, long>(Items, TotalCount);
