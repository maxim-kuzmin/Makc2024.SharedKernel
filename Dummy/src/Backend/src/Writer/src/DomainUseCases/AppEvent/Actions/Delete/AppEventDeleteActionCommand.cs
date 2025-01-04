namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Delete;

/// <summary>
/// Команда действия по удалению события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppEventDeleteActionCommand(long Id) : ICommand<Result>;
