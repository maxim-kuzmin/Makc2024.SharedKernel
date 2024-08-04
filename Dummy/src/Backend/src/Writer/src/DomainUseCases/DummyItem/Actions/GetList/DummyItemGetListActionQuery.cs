namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

public record DummyItemGetListActionQuery(
  QueryPage Page,
  DummyItemListQueryFilter Filter) : IQuery<Result<DummyItemGetListActionDTO>>;
