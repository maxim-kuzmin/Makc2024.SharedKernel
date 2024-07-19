namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

public interface IDummyItemGetListActionHandler :
  IQueryHandler<DummyItemGetListActionQuery, Result<List<DummyItemGetListActionDTO>>>;
