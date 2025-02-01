namespace Makc2024.Dummy.Writer.DomainUseCases.AppSynchronization.Actions.Start;

/// <summary>
/// Команда действия по запуску синхронизации приложения.
/// </summary>
/// <param name="AppEventName">Имя события приложения.</param>
/// <param name="AppEventPayloads">Полезные нагрузки события приложения.</param>
public record AppSynchronizationStartActionCommand(
  string AppEventName,
  List<object> AppEventPayloads) : ICommand<Result>;
