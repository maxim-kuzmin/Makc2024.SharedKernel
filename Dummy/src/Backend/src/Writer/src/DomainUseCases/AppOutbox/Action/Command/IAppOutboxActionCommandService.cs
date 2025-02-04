namespace Makc2024.Dummy.Writer.DomainUseCases.AppOutbox.Action.Command;

/// <summary>
/// Интерфейс сервиса команд действия с исходящими сообщениями приложения.
/// </summary>
public interface IAppOutboxActionCommandService
{
  /// <summary>
  /// Поставить в очередь сообщения о ещё не опубликованных событиях приложения и пометить их как опубликованные.
  /// </summary>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Produce(CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить в базе данных событие приложения, помеченное как неопубликованное.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Save(AppOutboxSaveActionCommand command, CancellationToken cancellationToken);
}
