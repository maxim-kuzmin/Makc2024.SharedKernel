namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Filter">Фильтр.</param>
public record DummyItemGetListActionQuery(
  QueryPage? Page,
  DummyItemGetListActionQueryFilter? Filter) : IQuery<Result<DummyItemGetListActionDTO>>;
