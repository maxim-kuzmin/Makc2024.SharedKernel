namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Action.Query.Service;

/// <summary>
/// Основа сервиса запросов действия с полезной нагрузкой события приложения.
/// </summary>
/// <param name="_appDbHelperForSQL">Помощник базы данных приложения для SQL.</param>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_appSession">Сессия приложения.</param>
public abstract class AppEventPayloadActionQueryServiceBase(AppSession _appSession) : IAppEventPayloadActionQueryService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadSingleDTO>> Get(
    AppEventPayloadGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var dto = await GetDTO(query, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadListDTO>> GetList(
    AppEventPayloadGetListActionQuery query,
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
  protected abstract Task<AppEventPayloadSingleDTO?> GetDTO(
    AppEventPayloadGetActionQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить объект передачи данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект передачи данных.</returns>
  protected abstract Task<AppEventPayloadListDTO> GetDTO(
    AppEventPayloadGetListActionQuery query,
    CancellationToken cancellationToken);
}
