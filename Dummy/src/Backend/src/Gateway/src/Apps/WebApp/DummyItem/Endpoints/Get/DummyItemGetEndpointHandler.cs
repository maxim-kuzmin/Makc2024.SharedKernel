namespace Makc2024.Dummy.Gateway.Apps.WebApp.DummyItem.Endpoints.Get;

/// <summary>
/// Обработчик конечной точки получения фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemGetEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetActionQuery, DummyItemSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(DummyItemGetEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(DummyItemGetActionQuery request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
