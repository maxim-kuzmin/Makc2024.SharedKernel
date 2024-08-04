namespace Makc2024.Dummy.Writer.DomainUseCases.App.Actions.Login;

public record AppLoginActionCommand(
  string UserName,
  string Password) : ICommand<Result<AppLoginActionDTO>>;
