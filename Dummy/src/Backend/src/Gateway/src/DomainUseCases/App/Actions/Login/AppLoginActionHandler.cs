namespace Makc2024.Dummy.Gateway.DomainUseCases.App.Actions.Login;

/// <summary>
/// Обработчик действия по входу в приложение.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppLoginActionHandler(IAppActionCommandService _service) :
  ICommandHandler<AppLoginActionCommand, Result<AppLoginActionDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppLoginActionDTO>> Handle(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Login(request, cancellationToken);
  }
}
