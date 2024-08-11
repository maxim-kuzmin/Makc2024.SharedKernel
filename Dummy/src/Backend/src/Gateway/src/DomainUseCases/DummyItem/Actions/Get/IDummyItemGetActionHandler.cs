namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Get;

public interface IDummyItemGetActionHandler :
  IQueryHandler<DummyItemGetActionQuery, Result<DummyItemGetActionDTO>>;
