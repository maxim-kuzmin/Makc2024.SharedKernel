using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.DTOs;

namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;

/// <summary>
/// Обработчик действия по получению события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventGetActionHandler(IAppEventActionQueryService _service) :
  IQueryHandler<AppEventGetActionQuery, Result<AppEventSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppEventSingleDTO>> Handle(
    AppEventGetActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.Get(request, cancellationToken);
  }
}
