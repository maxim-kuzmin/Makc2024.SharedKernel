namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Action.Command;

/// <summary>
/// Интерфейс сервиса команд действия с фиктивным предметом.
/// </summary>
public interface IDummyItemActionCommandService
{
  /// <summary>
  /// Создать.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<DummyItemSingleDTO>> Create(DummyItemCreateActionCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Delete(DummyItemDeleteActionCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<DummyItemSingleDTO>> Update(DummyItemUpdateActionCommand command, CancellationToken cancellationToken);
}
