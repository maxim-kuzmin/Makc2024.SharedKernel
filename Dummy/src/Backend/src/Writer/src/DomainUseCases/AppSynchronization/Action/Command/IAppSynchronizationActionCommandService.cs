namespace Makc2024.Dummy.Writer.DomainUseCases.AppSynchronization.Action.Command;

/// <summary>
/// Интерфейс сервиса команд действия с синхронизацией приложения.
/// </summary>
public interface IAppSynchronizationActionCommandService
{
  /// <summary>
  /// Начать.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Start(AppSynchronizationStartActionCommand command, CancellationToken cancellationToken);

  Task<Result> Finish();
}
