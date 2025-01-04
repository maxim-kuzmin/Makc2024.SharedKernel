namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка событий приложения.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Filter">Фильтр.</param>
public record AppEventGetListActionQuery(
  QueryPage? Page,
  AppEventGetListActionQueryFilter? Filter) : IQuery<Result<AppEventGetListActionDTO>>;
