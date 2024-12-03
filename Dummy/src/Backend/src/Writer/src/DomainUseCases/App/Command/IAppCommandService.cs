namespace Makc2024.Dummy.Writer.DomainUseCases.App.Command;

public interface IAppCommandService
{
  Task<Result<AppLoginActionDTO>> Login(AppLoginActionCommand command, CancellationToken cancellationToken);
}
