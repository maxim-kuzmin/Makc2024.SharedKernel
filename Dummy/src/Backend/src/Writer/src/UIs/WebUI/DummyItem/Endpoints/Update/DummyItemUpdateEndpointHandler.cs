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

    var commandResult = await _mediator.Send(command, cancellationToken);

    if (!commandResult.IsSuccess)
    {
      await SendResultAsync(commandResult.ToMinimalApiResult());

      return;
    }

    var query = new DummyItemGetByIdActionQuery(request.Id);

    var queryResult = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(queryResult.ToMinimalApiResult());
  }
}
