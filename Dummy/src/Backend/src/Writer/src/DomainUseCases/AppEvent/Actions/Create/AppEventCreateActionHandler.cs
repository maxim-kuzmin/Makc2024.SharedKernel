namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Create;

/// <summary>
/// Обработчик действия по созданию события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventCreateActionHandler(IAppEventActionCommandService _service) :
  ICommandHandler<AppEventCreateActionCommand, Result<AppEventGetActionDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppEventGetActionDTO>> Handle(
    AppEventCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Create(request, cancellationToken);
  }
}
