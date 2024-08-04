namespace Makc2024.Dummy.Gateway.DomainUseCases.App.Actions.Login;

public record AppLoginActionCommand(
  string UserName,
  string Password) : ICommand<Result<AppLoginActionDTO>>;
