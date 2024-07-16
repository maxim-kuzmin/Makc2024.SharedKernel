namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetById;

public record DummyItemGetByIdActionQuery(long Id) : IQuery<Result<DummyItemGetByIdActionDTO>>;
