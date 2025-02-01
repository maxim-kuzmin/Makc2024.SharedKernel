namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;

/// <summary>
/// Запрос действия по получению фиктивного предмета.
/// </summary>
/// <param name="Id"></param>
public record DummyItemGetActionQuery(long Id) : IQuery<Result<DummyItemSingleDTO>>;
