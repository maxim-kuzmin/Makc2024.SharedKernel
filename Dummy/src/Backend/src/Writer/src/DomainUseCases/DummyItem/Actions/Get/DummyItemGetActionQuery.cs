namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;

public record DummyItemGetActionQuery(long Id) : IQuery<Result<DummyItemGetActionDTO>>;
