using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.DTOs;

namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.Update;

/// <summary>
/// Обработчик конечной точки обновления полезной нагрузки события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventPayloadUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<AppEventPayloadUpdateActionCommand, AppEventPayloadSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Put(AppEventPayloadUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppEventPayloadUpdateActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
