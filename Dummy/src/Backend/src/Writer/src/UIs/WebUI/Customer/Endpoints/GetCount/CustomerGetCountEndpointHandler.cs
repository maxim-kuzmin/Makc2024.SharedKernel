namespace Gateway.UIs.WebUI.Customer.Endpoints.GetCount;

public class CustomerGetCountEndpointHandler(IMediator _mediator) :
  EndpointWithoutRequest<int>
{
  public override void Configure()
  {
    Get(CustomerGetCountEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var query = new CustomerGetCountActionQuery();

    var result = await _mediator.Send(query, cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
