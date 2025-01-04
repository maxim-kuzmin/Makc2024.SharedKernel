namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.GetList;

/// <summary>
/// Обработчик конечной точки получения списка полезных нагрузок события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventPayloadGetListEndpointHandler(IMediator _mediator) :
  Endpoint<AppEventPayloadGetListEndpointRequest, IEnumerable<AppEventPayloadGetListActionDTO>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppEventPayloadGetListEndpointSettings.Route);
    //AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppEventPayloadGetListEndpointRequest request, CancellationToken cancellationToken)
  {
    AppEventPayloadGetListActionQuery query = new(
      new QueryPage(request.CurrentPage, request.ItemsPerPage),
      new AppEventPayloadGetListActionQueryFilter(request.Query));

    var result = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
