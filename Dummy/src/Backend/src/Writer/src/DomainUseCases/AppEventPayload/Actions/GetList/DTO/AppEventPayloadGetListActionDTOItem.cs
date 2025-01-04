namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList.DTO;

/// <summary>
/// Элемент объекта передачи данных действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record AppEventPayloadGetListActionDTOItem(
  long Id,
  string Name);
