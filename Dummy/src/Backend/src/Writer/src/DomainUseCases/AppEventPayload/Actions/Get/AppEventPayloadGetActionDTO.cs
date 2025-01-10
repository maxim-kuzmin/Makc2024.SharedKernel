namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;

/// <summary>
/// Объект передачи данных действия по получению полезной нагрузки события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="AppEventId">Идентификатор события приложения.</param>
/// <param name="Data">Данные.</param>
public record AppEventPayloadGetActionDTO(
  long Id,
  long AppEventId,
  string Data);
