using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.DTOs;

namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.Delete;

/// <summary>
/// Обработчик конечной точки удаления события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<AppEventDeleteActionCommand, AppEventSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(AppEventDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppEventDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
