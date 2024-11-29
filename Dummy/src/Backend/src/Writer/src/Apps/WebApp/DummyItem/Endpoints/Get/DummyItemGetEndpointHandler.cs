namespace Makc2024.Dummy.Writer.Apps.WebApp.DummyItem.Endpoints.Get;

public class DummyItemGetEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetActionQuery, DummyItemGetActionDTO>
{
  public override void Configure()
  {
    Get(DummyItemGetEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemGetActionQuery request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
