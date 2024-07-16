namespace Gateway.UIs.WebUI.Invoice.Endpoints.GetFiltered;

public class InvoiceGetFilteredEndpointHandler(IMediator _mediator) :
  Endpoint<InvoiceGetFilteredEndpointRequest, IEnumerable<InvoiceGetFilteredActionDTO>>
{
  public override void Configure()
  {
    Get(InvoiceGetFilteredEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(InvoiceGetFilteredEndpointRequest request, CancellationToken cancellationToken)
  {
    var query = new InvoiceGetFilteredActionQuery(
      new QueryPage(request.CurrentPage, request.ItemsPerPage),
      new InvoiceFilteredQueryFilter(request.Query));

    var result = await _mediator.Send(query, cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
