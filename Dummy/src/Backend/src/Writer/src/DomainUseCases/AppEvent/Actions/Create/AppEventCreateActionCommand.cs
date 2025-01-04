namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Create;

/// <summary>
/// Команда действия по созданию события приложения.
/// </summary>
/// <param name="Name">Имя.</param>
public record AppEventCreateActionCommand(
  string Name) : ICommand<Result<AppEventGetActionDTO>>;
