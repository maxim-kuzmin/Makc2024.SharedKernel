namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Action.Query;

/// <summary>
/// Интерфейс сервиса запросов действия с событием приложения.
/// </summary>
public interface IAppEventActionQueryService
{
  /// <summary>
  /// Получить.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventGetActionDTO>> Get(
    AppEventGetActionQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventGetListActionDTO>> GetList(
    AppEventGetListActionQuery query,
    CancellationToken cancellationToken);
}
