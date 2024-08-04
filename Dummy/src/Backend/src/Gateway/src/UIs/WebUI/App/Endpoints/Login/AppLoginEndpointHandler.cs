namespace Makc2024.Dummy.Gateway.UIs.WebUI.App.Endpoints.Login;

public class AppLoginEndpointHandler(IMediator _mediator) :
  Endpoint<AppLoginActionCommand, AppLoginActionDTO>
{
  public override void Configure()
  {
    Post(AppLoginEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
