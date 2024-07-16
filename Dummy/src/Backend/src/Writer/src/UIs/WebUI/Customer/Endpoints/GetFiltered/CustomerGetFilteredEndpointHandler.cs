namespace Makc2024.Dummy.Writer.UIs.WebUI.Customer.Endpoints.GetFiltered;

public class CustomerGetFilteredEndpointHandler(IMediator _mediator) :
  Endpoint<CustomerGetFilteredEndpointRequest, IEnumerable<CustomerGetFilteredActionDTO>>
{
  public override void Configure()
  {
    Get(CustomerGetFilteredEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CustomerGetFilteredEndpointRequest request, CancellationToken cancellationToken)
  {
    var query = new CustomerGetFilteredActionQuery(
      new CustomerFilteredQueryFilter(request.Query));

    var result = await _mediator.Send(query, cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
