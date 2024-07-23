namespace Makc2024.Dummy.Gateway.UIs.WebUI.DummyItem.Endpoints.GetById;

public class DummyItemGetByIdEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetByIdActionQuery, DummyItemGetByIdActionDTO>
{
  public override void Configure()
  {
    Get(DummyItemGetByIdEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemGetByIdActionQuery request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
