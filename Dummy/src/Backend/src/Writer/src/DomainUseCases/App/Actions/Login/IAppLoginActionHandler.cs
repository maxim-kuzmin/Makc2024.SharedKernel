namespace Makc2024.Dummy.Writer.DomainUseCases.App.Actions.Login;

public interface IAppLoginActionHandler : ICommandHandler<AppLoginActionCommand, Result<AppLoginActionDTO>>;
