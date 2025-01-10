namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Create;

/// <summary>
/// Команда действия по созданию полезной нагрузки события приложения.
/// </summary>
/// <param name="AppEventId">Идентификатор события приложения.</param>
/// <param name="Data">Данные.</param>
public record AppEventPayloadCreateActionCommand(
  long AppEventId,
  string Data) : ICommand<Result<AppEventPayloadGetActionDTO>>;
