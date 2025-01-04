namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;

/// <summary>
/// Объект передачи данных действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppEventPayloadGetListActionDTO(
  List<AppEventPayloadGetListActionDTOItem> Items,
  long TotalCount) : ListDTO<AppEventPayloadGetListActionDTOItem, long>(Items, TotalCount);
