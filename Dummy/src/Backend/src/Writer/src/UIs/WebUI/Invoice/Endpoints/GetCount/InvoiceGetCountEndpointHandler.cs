namespace Makc2024.Dummy.Writer.UIs.WebUI.Invoice.Endpoints.GetCount;

public class InvoiceGetCountEndpointHandler(IMediator _mediator) :
  EndpointWithoutRequest<int>
{
  public override void Configure()
  {
    Get(InvoiceGetCountEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var query = new InvoiceGetCountActionQuery();

    var result = await _mediator.Send(query, cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
