namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

public record DummyItemGetListActionDTO(
  List<DummyItemGetListActionDTOItem> Items,
  long TotalCount) : ListDTO<DummyItemGetListActionDTOItem, long>(Items, TotalCount);
