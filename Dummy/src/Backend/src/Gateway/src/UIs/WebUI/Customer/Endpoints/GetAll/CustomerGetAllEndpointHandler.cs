namespace Makc2024.Dummy.Gateway.UIs.WebUI.Customer.Endpoints.GetAll;

public class CustomerGetAllEndpointHandler(IMediator _mediator) :
  EndpointWithoutRequest<IEnumerable<CustomerGetAllActionDTO>>
{
  public override void Configure()
  {
    Get(CustomerGetAllEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var query = new CustomerGetAllActionQuery();

    var result = await _mediator.Send(query, cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
