namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Action.Query;

/// <summary>
/// Интерфейс сервиса запросов действия с фиктивным предметом.
/// </summary>
public interface IDummyItemActionQueryService
{
  /// <summary>
  /// Получить.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<DummyItemSingleDTO>> Get(DummyItemGetActionQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<DummyItemListDTO>> GetList(DummyItemGetListActionQuery query, CancellationToken cancellationToken);
}
