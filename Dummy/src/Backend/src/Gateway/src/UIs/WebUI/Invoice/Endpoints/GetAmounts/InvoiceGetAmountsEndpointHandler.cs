namespace Gateway.UIs.WebUI.Invoice.Endpoints.GetAmounts;

public class InvoiceGetAmountsEndpointHandler(IMediator _mediator) :
  EndpointWithoutRequest<InvoiceGetAmountsActionDTO>
{
  public override void Configure()
  {
    Get(InvoiceGetAmountsEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new InvoiceGetAmountsActionQuery(), cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
