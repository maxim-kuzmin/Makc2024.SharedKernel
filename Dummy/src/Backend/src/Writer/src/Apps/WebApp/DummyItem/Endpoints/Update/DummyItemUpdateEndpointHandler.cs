namespace Makc2024.Dummy.Writer.Apps.WebApp.DummyItem.Endpoints.Update;

/// <summary>
/// Обработчик конечной точки обновления фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemUpdateActionCommand, DummyItemGetActionDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Put(DummyItemUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(DummyItemUpdateActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
