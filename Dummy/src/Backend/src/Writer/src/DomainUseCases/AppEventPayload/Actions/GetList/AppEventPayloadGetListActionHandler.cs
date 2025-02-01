namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventPayloadGetListActionHandler(IAppEventPayloadActionQueryService _service) :
  IQueryHandler<AppEventPayloadGetListActionQuery, Result<AppEventPayloadListDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppEventPayloadListDTO>> Handle(
    AppEventPayloadGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request, cancellationToken);
  }
}
