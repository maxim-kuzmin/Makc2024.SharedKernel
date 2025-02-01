namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Create;

/// <summary>
/// Обработчик действия по созданию полезной нагрузки события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventPayloadCreateActionHandler(IAppEventPayloadActionCommandService _service) :
  ICommandHandler<AppEventPayloadCreateActionCommand, Result<AppEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppEventPayloadSingleDTO>> Handle(
    AppEventPayloadCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Create(request, cancellationToken);
  }
}
