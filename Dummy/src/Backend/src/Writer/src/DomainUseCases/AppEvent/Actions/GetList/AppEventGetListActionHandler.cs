namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventGetListActionHandler(IAppEventActionQueryService _service) :
  IQueryHandler<AppEventGetListActionQuery, Result<AppEventGetListActionDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppEventGetListActionDTO>> Handle(
    AppEventGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request, cancellationToken);
  }
}
