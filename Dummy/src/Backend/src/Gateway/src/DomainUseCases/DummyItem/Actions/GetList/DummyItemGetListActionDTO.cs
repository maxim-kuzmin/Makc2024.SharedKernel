namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Объект передачи данных действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record DummyItemGetListActionDTO(
  List<DummyItemGetListActionDTOItem> Items,
  long TotalCount) : ListDTO<DummyItemGetListActionDTOItem, long>(Items, TotalCount);
