namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.Delete;

/// <summary>
/// Обработчик конечной точки удаления события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemDeleteActionCommand, DummyItemGetActionDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(AppEventDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
