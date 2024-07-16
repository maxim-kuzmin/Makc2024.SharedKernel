namespace Makc2024.Dummy.Gateway.UIs.WebUI.Invoice.Endpoints.Update;

public class InvoiceUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<InvoiceUpdateEndpointRequest, InvoiceGetByIdActionDTO>
{
  public override void Configure()
  {
    Put(InvoiceUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(InvoiceUpdateEndpointRequest request, CancellationToken cancellationToken)
  {
    var command = new InvoiceUpdateActionCommand(
      request.Amount,
      request.CustomerId,
      request.Id,
      request.Status);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);

      return;
    }

    var query = new InvoiceGetByIdActionQuery(request.Id);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.IsSuccess)
    {
      Response = queryResult.Value;
    }
    else if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
    }
  }
}
