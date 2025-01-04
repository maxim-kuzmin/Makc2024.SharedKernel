namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.Create;

/// <summary>
/// Обработчик конечной точки создания события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventCreateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemCreateActionCommand, long>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AppEventCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(DummyItemCreateActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
