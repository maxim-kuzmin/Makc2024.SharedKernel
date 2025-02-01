namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.Get;

/// <summary>
/// Обработчик конечной точки получения полезной нагрузки события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventPayloadGetEndpointHandler(IMediator _mediator) :
  Endpoint<AppEventPayloadGetActionQuery, AppEventPayloadSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppEventPayloadGetEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppEventPayloadGetActionQuery request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
