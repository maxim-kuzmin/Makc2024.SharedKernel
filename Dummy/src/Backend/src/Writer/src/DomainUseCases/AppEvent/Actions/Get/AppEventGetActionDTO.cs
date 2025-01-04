namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;

/// <summary>
/// Объект передачи данных действия по получению события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record AppEventGetActionDTO(
  long Id,
  string Name);
