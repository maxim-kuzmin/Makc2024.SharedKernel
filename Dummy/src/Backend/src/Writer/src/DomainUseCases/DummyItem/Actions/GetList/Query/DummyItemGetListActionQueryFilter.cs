namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList.Query;

/// <summary>
/// Фильтр запроса действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record DummyItemGetListActionQueryFilter(string? FullTextSearchQuery);
