namespace Makc2024.Dummy.Gateway.UIs.WebUI.Invoice.Endpoints.Delete;

public class InvoiceDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<InvoiceDeleteEndpointRequest, InvoiceGetByIdActionDTO>
{
  public override void Configure()
  {
    Delete(InvoiceDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(InvoiceDeleteEndpointRequest request, CancellationToken cancellationToken)
  {
    var command = new InvoiceDeleteActionCommand(request.Id);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    }
    else if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
    }
  }
}
