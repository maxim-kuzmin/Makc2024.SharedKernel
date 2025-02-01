namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Action.Command;

/// <summary>
/// Интерфейс сервиса команд действия с событием приложения.
/// </summary>
public interface IAppEventActionCommandService
{
  /// <summary>
  /// Создать.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventGetActionDTO>> Create(
    AppEventCreateActionCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Delete(
    AppEventDeleteActionCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventGetActionDTO>> Update(
    AppEventUpdateActionCommand command,
    CancellationToken cancellationToken);
}
