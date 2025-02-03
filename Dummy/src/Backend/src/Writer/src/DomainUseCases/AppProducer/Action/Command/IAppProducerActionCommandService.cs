namespace Makc2024.Dummy.Writer.DomainUseCases.AppProducer.Action.Command;

/// <summary>
/// Интерфейс сервиса команд действия с поставщиком приложения.
/// </summary>
public interface IAppProducerActionCommandService
{
  /// <summary>
  /// Опубликовать сообщения о ещё не опубликованных событиях приложения и пометить их как опубликованные.
  /// </summary>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Publish(CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить в базе данных событие приложения, помеченное как неопубликованное.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Save(AppProducerSaveActionCommand command, CancellationToken cancellationToken);
}
