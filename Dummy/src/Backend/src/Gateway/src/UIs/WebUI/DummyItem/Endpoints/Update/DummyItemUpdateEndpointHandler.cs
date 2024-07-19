namespace Makc2024.Dummy.Gateway.UIs.WebUI.DummyItem.Endpoints.Update;

public class DummyItemUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemUpdateEndpointRequest, DummyItemGetByIdActionDTO>
{
  public override void Configure()
  {
    Put(DummyItemUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemUpdateEndpointRequest request, CancellationToken cancellationToken)
  {
    var command = new DummyItemUpdateActionCommand(
      request.Id,
      request.Name);

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
