namespace Makc2024.Dummy.Writer.UIs.WebUI.DummyItem.Endpoints.Update;

public class DummyItemUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemUpdateEndpointRequest, DummyItemGetByIdActionDTO>
{
  public override void Configure()
  {
    Put(DummyItemUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemUpdateEndpointRequest request, CancellationToken cancellationToken)
  {
    var command = new DummyItemUpdateActionCommand(
      request.Id,
      request.Name);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);

      return;
    }

    var query = new DummyItemGetByIdActionQuery(request.Id);

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
