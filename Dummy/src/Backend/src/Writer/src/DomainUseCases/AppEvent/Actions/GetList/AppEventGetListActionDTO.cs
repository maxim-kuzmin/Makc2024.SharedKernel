namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Объект передачи данных действия по получению списка событий приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppEventGetListActionDTO(
  List<AppEventGetListActionDTOItem> Items,
  long TotalCount) : ListDTO<AppEventGetListActionDTOItem, long>(Items, TotalCount);
