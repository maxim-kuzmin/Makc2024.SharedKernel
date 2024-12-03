namespace Makc2024.Dummy.Gateway.DomainUseCases.App;

public interface IAppService
{
  Task<Result<AppLoginActionDTO>> Login(AppLoginActionCommand command, CancellationToken cancellationToken);
}
