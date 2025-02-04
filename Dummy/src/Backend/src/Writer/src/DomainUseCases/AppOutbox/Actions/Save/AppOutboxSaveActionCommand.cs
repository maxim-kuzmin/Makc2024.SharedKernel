namespace Makc2024.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Save;

/// <summary>
/// Команда действия по сохранению в базе данных события приложения, помеченного как неопубликованное.
/// </summary>
/// <param name="AppEventName">Имя события приложения.</param>
/// <param name="AppEventPayloads">Полезные нагрузки события приложения.</param>
public record AppOutboxSaveActionCommand(
  AppEventName AppEventName,
  List<object> AppEventPayloads) : ICommand<Result>;
