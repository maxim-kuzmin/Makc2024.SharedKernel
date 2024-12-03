namespace Makc2024.Dummy.Writer.DomainUseCases.App.Actions.Login;

public class AppLoginActionHandler(IAppService _service) :
  ICommandHandler<AppLoginActionCommand, Result<AppLoginActionDTO>>
{
  public Task<Result<AppLoginActionDTO>> Handle(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Login(request, cancellationToken);
  }
}
