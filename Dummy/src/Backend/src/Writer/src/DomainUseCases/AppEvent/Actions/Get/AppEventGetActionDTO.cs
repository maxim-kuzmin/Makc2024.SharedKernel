namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;

/// <summary>
/// Объект передачи данных действия по получению события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="CreatedAt">Когда создано.</param>
/// <param name="IsPublished">Опубликовано ли?</param>
/// <param name="Name">Имя.</param>
public record AppEventGetActionDTO(
  long Id,
  DateTimeOffset CreatedAt,
  bool IsPublished,
  string Name);
