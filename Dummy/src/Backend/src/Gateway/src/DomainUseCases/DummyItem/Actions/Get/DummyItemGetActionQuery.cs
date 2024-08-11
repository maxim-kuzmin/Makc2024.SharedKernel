namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Get;

public record DummyItemGetActionQuery(long Id) : IQuery<Result<DummyItemGetActionDTO>>;
