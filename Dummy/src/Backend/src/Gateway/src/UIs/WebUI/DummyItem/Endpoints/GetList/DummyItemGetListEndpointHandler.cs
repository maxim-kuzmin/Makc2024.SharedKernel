namespace Makc2024.Dummy.Gateway.UIs.WebUI.DummyItem.Endpoints.GetList;

public class DummyItemGetListEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetListEndpointRequest, IEnumerable<DummyItemGetListActionDTO>>
{
  public override void Configure()
  {
    Get(DummyItemGetListEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemGetListEndpointRequest request, CancellationToken cancellationToken)
  {
    var query = new DummyItemGetListActionQuery(
      new QueryPage(request.CurrentPage, request.ItemsPerPage),
      new DummyItemListQueryFilter(request.Query));

    var result = await _mediator.Send(query, cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
