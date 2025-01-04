namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventPayloadDeleteActionHandler(IAppEventPayloadActionCommandService _service) :
  ICommandHandler<AppEventPayloadDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppEventPayloadDeleteActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Delete(request, cancellationToken);
  }
}
