namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetById;

public interface IDummyItemGetByIdActionHandler :
  IQueryHandler<DummyItemGetByIdActionQuery, Result<DummyItemGetByIdActionDTO>>;
