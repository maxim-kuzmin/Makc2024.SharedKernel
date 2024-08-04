namespace Makc2024.Dummy.Gateway.DomainUseCases.App.Actions.Login;

public interface IAppLoginActionHandler : ICommandHandler<AppLoginActionCommand, Result<AppLoginActionDTO>>;
