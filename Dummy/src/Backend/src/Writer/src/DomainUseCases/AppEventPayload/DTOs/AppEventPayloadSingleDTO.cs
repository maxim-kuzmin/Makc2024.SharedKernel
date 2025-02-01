namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.DTOs;

/// <summary>
/// Объект передачи данных действия по получению полезной нагрузки события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="AppEventId">Идентификатор события приложения.</param>
/// <param name="Data">Данные.</param>
public record AppEventPayloadSingleDTO(long Id, long AppEventId, string Data);
