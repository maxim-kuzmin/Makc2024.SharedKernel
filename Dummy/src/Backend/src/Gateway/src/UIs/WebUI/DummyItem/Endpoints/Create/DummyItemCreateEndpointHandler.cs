namespace Makc2024.Dummy.Gateway.UIs.WebUI.DummyItem.Endpoints.Create;

public class DummyItemCreateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemCreateEndpointRequest, long>
{
  public override void Configure()
  {
    Post(DummyItemCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemCreateEndpointRequest request, CancellationToken cancellationToken)
  {
    var command = new DummyItemCreateActionCommand(
      request.Name);

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
