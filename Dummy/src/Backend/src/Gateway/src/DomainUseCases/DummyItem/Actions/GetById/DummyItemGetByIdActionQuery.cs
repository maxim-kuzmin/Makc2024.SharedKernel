namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetById;

public record DummyItemGetByIdActionQuery(long Id) : IQuery<Result<DummyItemGetByIdActionDTO>>;
