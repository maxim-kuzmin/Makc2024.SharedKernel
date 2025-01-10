namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Update;

/// <summary>
/// Команда действия по обновлению полезной нагрузки события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="AppEventId">Идентификатор события приложения.</param>
/// <param name="Data">Данные.</param>
public record AppEventPayloadUpdateActionCommand(
  long Id,
  long AppEventId,
  string Data) : ICommand<Result<AppEventPayloadGetActionDTO>>;
