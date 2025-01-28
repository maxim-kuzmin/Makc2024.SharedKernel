namespace Makc2024.Dummy.Shared.Infrastructure.Db;

/// <summary>
/// Интерфейс исполнителя базы данных.
/// </summary>
public interface IDbExecutor
{
  /// <summary>
  /// Выполнить.
  /// </summary>
  /// <param name="funcToExecute">Функция для выполнения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Execute(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken);

  /// <summary>
  /// Выполнить в транзакции.
  /// </summary>
  /// <param name="funcToExecute">Функция для выполнения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task ExecuteInTransaction(
    Func<IDbContextTransaction?, CancellationToken, Task> funcToExecute,
    CancellationToken cancellationToken);

  /// <summary>
  /// Выполнить в транзакции.
  /// </summary>
  /// <param name="funcToExecute">Функция для выполнения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task ExecuteInTransaction(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken);
}
