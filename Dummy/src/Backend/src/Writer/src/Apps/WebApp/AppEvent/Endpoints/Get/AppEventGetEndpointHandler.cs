using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.DTOs;

namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.Get;

/// <summary>
/// Обработчик конечной точки получения события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventGetEndpointHandler(IMediator _mediator) :
  Endpoint<AppEventGetActionQuery, AppEventSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppEventGetEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppEventGetActionQuery request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
