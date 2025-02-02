namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Action.Query.Service;

/// <summary>
/// Основа сервиса запросов действия с фиктивным предметом.
/// </summary>
/// <param name="_appDbHelperForSQL">Помощник базы данных приложения для SQL.</param>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_appSession">Сессия приложения.</param>
public abstract class DummyItemActionQueryServiceBase(AppSession _appSession) : IDummyItemActionQueryService
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Get(
    DummyItemGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var dto = await GetDTO(query, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemListDTO>> GetList(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    var dto = await GetDTO(query, cancellationToken);

    return Result.Success(dto);
  }

  /// <summary>
  /// Получить объект передачи данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект передачи данных.</returns>
  protected abstract Task<DummyItemSingleDTO?> GetDTO(
    DummyItemGetActionQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить объект передачи данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект передачи данных.</returns>
  protected abstract Task<DummyItemListDTO> GetDTO(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken);
}
