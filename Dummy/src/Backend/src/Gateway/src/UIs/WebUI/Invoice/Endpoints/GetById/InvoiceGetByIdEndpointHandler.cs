namespace Gateway.UIs.WebUI.Invoice.Endpoints.GetById;

public class InvoiceGetByIdEndpointHandler(IMediator _mediator) :
  Endpoint<InvoiceGetByIdEndpointRequest, InvoiceGetByIdActionDTO>
{
  public override void Configure()
  {
    Get(InvoiceGetByIdEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(InvoiceGetByIdEndpointRequest request, CancellationToken cancellationToken)
  {
    var query = new InvoiceGetByIdActionQuery(request.Id);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
    else if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
    }
  }
}
