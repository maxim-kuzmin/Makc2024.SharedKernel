namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.DTOs;

/// <summary>
/// Объект передачи данных действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppEventPayloadListDTO(
  List<AppEventPayloadSingleDTO> Items,
  long TotalCount) : ListDTO<AppEventPayloadSingleDTO, long>(Items, TotalCount);
