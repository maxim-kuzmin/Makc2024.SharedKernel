namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Update;

/// <summary>
/// Команда действия по обновлению события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record AppEventUpdateActionCommand(
  long Id,
  string Name) : ICommand<Result<AppEventGetActionDTO>>;
