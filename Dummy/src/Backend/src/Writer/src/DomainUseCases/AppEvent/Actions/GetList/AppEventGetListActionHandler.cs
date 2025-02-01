namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventGetListActionHandler(IAppEventActionQueryService _service) :
  IQueryHandler<AppEventGetListActionQuery, Result<AppEventListDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppEventListDTO>> Handle(
    AppEventGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request, cancellationToken);
  }
}
