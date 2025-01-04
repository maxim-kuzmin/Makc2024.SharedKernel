namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.Update;

/// <summary>
/// Обработчик конечной точки обновления события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemUpdateActionCommand, DummyItemGetActionDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Put(AppEventUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(DummyItemUpdateActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
