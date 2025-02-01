namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Update;

/// <summary>
/// Команда действия по обновлению события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="IsPublished">Опубликовано ли?</param>
/// <param name="Name">Имя.</param>
public record AppEventUpdateActionCommand(
  long Id,
  bool IsPublished,
  string Name) : ICommand<Result<AppEventSingleDTO>>;
