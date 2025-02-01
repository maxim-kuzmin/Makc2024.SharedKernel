namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;

/// <summary>
/// Обработчик действия по получению полезной нагрузки события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventPayloadGetActionHandler(IAppEventPayloadActionQueryService _service) :
  IQueryHandler<AppEventPayloadGetActionQuery, Result<AppEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppEventPayloadSingleDTO>> Handle(
    AppEventPayloadGetActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.Get(request, cancellationToken);
  }
}
