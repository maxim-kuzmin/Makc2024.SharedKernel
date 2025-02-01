using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.DTOs;

namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventUpdateActionHandler(IAppEventActionCommandService _service) :
  ICommandHandler<AppEventUpdateActionCommand, Result<AppEventSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppEventSingleDTO>> Handle(
    AppEventUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Update(request, cancellationToken);
  }
}
