namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList.Query;

/// <summary>
/// Фильтр запроса действия по получению списка событий приложения.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record AppEventGetListActionQueryFilter(string? FullTextSearchQuery);
