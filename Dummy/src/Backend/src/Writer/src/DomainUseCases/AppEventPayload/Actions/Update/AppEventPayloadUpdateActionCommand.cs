namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Update;

/// <summary>
/// Команда действия по обновлению полезной нагрузки события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record AppEventPayloadUpdateActionCommand(
  long Id,
  string Name) : ICommand<Result<AppEventPayloadGetActionDTO>>;
