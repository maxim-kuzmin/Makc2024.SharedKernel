namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetById;

public interface IDummyItemGetByIdActionHandler :
  IQueryHandler<DummyItemGetByIdActionQuery, Result<DummyItemGetByIdActionDTO>>;
