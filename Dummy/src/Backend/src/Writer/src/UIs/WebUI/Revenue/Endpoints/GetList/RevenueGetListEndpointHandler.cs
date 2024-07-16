namespace Gateway.UIs.WebUI.Revenue.Endpoints.GetList;

public class RevenueGetListEndpointHandler(IMediator _mediator) :
  EndpointWithoutRequest<IEnumerable<RevenueGetListActionDTO>>
{
  public override void Configure()
  {
    Get(RevenueGetListEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new RevenueGetListActionQuery(), cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
