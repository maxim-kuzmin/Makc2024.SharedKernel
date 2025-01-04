namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Delete;

/// <summary>
/// Команда действия по удалению полезной нагрузки события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppEventPayloadDeleteActionCommand(long Id) : ICommand<Result>;
