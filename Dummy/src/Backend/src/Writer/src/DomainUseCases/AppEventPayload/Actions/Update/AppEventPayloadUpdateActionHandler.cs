﻿namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению полезной нагрузки события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventPayloadUpdateActionHandler(IAppEventPayloadActionCommandService _service) :
  ICommandHandler<AppEventPayloadUpdateActionCommand, Result<AppEventPayloadGetActionDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppEventPayloadGetActionDTO>> Handle(
    AppEventPayloadUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Update(request, cancellationToken);
  }
}
