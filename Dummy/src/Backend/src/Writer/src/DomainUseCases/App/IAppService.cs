namespace Makc2024.Dummy.Writer.DomainUseCases.App;

public interface IAppService
{
  Task<Result<AppLoginActionDTO>> Login(AppLoginActionCommand command, CancellationToken cancellationToken);
}
