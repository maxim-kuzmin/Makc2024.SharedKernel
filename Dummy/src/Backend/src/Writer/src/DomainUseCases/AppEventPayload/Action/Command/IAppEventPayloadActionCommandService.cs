namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Action.Command;

/// <summary>
/// Интерфейс сервиса команд действия над полезной нагрузкой события приложения.
/// </summary>
public interface IAppEventPayloadActionCommandService
{
  /// <summary>
  /// Создать.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventPayloadGetActionDTO>> Create(
    AppEventPayloadCreateActionCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Delete(
    AppEventPayloadDeleteActionCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventPayloadGetActionDTO>> Update(
    AppEventPayloadUpdateActionCommand command,
    CancellationToken cancellationToken);
}
