namespace Gateway.UIs.WebUI.Invoice.Endpoints.Create;

public class InvoiceCreateEndpointHandler(IMediator _mediator) :
  Endpoint<InvoiceCreateEndpointRequest, Guid>
{
  public override void Configure()
  {
    Post(InvoiceCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(InvoiceCreateEndpointRequest request, CancellationToken cancellationToken)
  {
    var command = new InvoiceCreateActionCommand(
      request.Amount,
      request.CustomerId,
      request.Date,
      request.Status);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
