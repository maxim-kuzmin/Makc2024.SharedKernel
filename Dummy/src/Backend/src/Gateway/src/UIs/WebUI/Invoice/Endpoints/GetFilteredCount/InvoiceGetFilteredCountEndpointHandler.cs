namespace Gateway.UIs.WebUI.Invoice.Endpoints.GetFilteredCount;

public class InvoiceGetFilteredCountEndpointHandler(IMediator _mediator) :
  Endpoint<InvoiceGetFilteredCountEndpointRequest, int>
{
  public override void Configure()
  {
    Get(InvoiceGetFilteredCountEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(InvoiceGetFilteredCountEndpointRequest request, CancellationToken cancellationToken)
  {
    var query = new InvoiceGetFilteredCountActionQuery(
      new InvoiceFilteredQueryFilter(request.Query));

    var result = await _mediator.Send(query, cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
