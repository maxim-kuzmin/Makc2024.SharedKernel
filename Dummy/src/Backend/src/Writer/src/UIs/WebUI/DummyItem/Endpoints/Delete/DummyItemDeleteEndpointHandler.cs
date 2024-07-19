namespace Makc2024.Dummy.Writer.UIs.WebUI.DummyItem.Endpoints.Delete;

public class DummyItemDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemDeleteEndpointRequest, DummyItemGetByIdActionDTO>
{
  public override void Configure()
  {
    Delete(DummyItemDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemDeleteEndpointRequest request, CancellationToken cancellationToken)
  {
    var command = new DummyItemDeleteActionCommand(request.Id);

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
