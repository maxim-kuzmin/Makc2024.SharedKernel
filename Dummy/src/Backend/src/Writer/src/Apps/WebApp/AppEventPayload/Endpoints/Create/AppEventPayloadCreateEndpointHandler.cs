namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.Create;

/// <summary>
/// Обработчик конечной точки создания полезной нагрузки события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventPayloadCreateEndpointHandler(IMediator _mediator) :
  Endpoint<AppEventPayloadCreateActionCommand, long>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AppEventPayloadCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppEventPayloadCreateActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
