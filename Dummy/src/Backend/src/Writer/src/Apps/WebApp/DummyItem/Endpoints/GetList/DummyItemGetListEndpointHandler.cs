using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.DTOs;

namespace Makc2024.Dummy.Writer.Apps.WebApp.DummyItem.Endpoints.GetList;

/// <summary>
/// Обработчик конечной точки получения списка фиктивных предметов.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemGetListEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetListEndpointRequest, IEnumerable<DummyItemListDTO>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(DummyItemGetListEndpointSettings.Route);
    //AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(DummyItemGetListEndpointRequest request, CancellationToken cancellationToken)
  {
    DummyItemGetListActionQuery query = new(
      new QueryPage(request.CurrentPage, request.ItemsPerPage),
      new DummyItemGetListActionQueryFilter(request.Query));

    var result = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
