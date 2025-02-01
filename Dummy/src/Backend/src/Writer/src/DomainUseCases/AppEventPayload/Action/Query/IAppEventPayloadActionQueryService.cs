namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Action.Query;

/// <summary>
/// Интерфейс сервиса запросов действия с полезной нагрузкой события приложения.
/// </summary>
public interface IAppEventPayloadActionQueryService
{
  /// <summary>
  /// Получить.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventPayloadGetActionDTO>> Get(
    AppEventPayloadGetActionQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventPayloadGetListActionDTO>> GetList(
    AppEventPayloadGetListActionQuery query,
    CancellationToken cancellationToken);
}
