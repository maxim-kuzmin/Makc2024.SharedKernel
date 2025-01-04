namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventUpdateActionHandler(IAppEventActionCommandService _service) :
  ICommandHandler<AppEventUpdateActionCommand, Result<AppEventGetActionDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppEventGetActionDTO>> Handle(
    AppEventUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Update(request, cancellationToken);
  }
}
