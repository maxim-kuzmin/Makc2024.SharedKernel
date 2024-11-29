namespace Makc2024.Dummy.Gateway.Apps.WebApp.DummyItem.Endpoints.Create;

public class DummyItemCreateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemCreateActionCommand, long>
{
  public override void Configure()
  {
    Post(DummyItemCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemCreateActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
