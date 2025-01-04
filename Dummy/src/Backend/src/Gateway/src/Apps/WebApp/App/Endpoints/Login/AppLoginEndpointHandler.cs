namespace Makc2024.Dummy.Gateway.Apps.WebApp.App.Endpoints.Login;

/// <summary>
/// Обработчик конечной точки входа в приложение.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppLoginEndpointHandler(IMediator _mediator) :
  Endpoint<AppLoginActionCommand, AppLoginActionDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AppLoginEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
