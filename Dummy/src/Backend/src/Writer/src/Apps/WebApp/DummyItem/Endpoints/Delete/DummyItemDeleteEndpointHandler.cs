namespace Makc2024.Dummy.Writer.Apps.WebApp.DummyItem.Endpoints.Delete;

public class DummyItemDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemDeleteActionCommand, DummyItemGetActionDTO>
{
  public override void Configure()
  {
    Delete(DummyItemDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
