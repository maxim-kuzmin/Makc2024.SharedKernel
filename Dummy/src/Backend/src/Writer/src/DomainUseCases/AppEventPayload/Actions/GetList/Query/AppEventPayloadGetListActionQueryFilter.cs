namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList.Query;

/// <summary>
/// Фильтр запроса действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record AppEventPayloadGetListActionQueryFilter(string? FullTextSearchQuery);
