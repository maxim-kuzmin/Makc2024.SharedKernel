namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;

public interface IDummyItemGetActionHandler :
  IQueryHandler<DummyItemGetActionQuery, Result<DummyItemGetActionDTO>>;
