namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Filter">Фильтр.</param>
public record AppEventPayloadGetListActionQuery(
  QueryPage? Page,
  AppEventPayloadGetListActionQueryFilter? Filter) : IQuery<Result<AppEventPayloadListDTO>>;
