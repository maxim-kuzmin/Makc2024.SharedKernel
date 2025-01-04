namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList.DTO;

/// <summary>
/// Элемент объекта передачи данных действия по получению списка событий приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record AppEventGetListActionDTOItem(
  long Id,
  string Name);
