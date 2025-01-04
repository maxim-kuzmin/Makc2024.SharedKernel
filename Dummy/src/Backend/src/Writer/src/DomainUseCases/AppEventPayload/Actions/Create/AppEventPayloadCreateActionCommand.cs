namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Create;

/// <summary>
/// Команда действия по созданию полезной нагрузки события приложения.
/// </summary>
/// <param name="Name">Имя.</param>
public record AppEventPayloadCreateActionCommand(
  string Name) : ICommand<Result<AppEventPayloadGetActionDTO>>;
