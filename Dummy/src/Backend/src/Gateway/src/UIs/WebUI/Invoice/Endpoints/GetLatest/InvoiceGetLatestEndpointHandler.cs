namespace Makc2024.Dummy.Gateway.UIs.WebUI.Invoice.Endpoints.GetLatest;

public class InvoiceGetLatestEndpointHandler(IMediator _mediator) :
  Endpoint<InvoiceGetLatestEndpointRequest, IEnumerable<InvoiceGetLatestActionDTO>>
{
  public override void Configure()
  {
    Get(InvoiceGetLatestEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(InvoiceGetLatestEndpointRequest request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new InvoiceGetLatestActionQuery(request.Limit), cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
