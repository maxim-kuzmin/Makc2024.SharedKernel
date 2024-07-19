namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;

public interface IDummyItemGetListActionHandler :
  IQueryHandler<DummyItemGetListActionQuery, Result<List<DummyItemGetListActionDTO>>>;
