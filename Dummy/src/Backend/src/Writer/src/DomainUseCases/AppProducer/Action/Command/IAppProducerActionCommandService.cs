namespace Makc2024.Dummy.Writer.DomainUseCases.AppProducer.Action.Command;

/// <summary>
/// Интерфейс сервиса команд действия с поставщиком приложения.
/// </summary>
public interface IAppProducerActionCommandService
{
  /// <summary>
  /// Поставить в очередь сообщения о неопубликованных событиях приложения и пометить их как опубликованные.
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
  Task<Result> Save(AppProducerSaveActionCommand command, CancellationToken cancellationToken);
}
