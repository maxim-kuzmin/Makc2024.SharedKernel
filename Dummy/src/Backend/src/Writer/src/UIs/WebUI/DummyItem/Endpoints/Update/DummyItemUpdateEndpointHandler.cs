namespace Makc2024.Dummy.Writer.UIs.WebUI.DummyItem.Endpoints.Update;

public class DummyItemUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemUpdateActionCommand, DummyItemGetActionDTO>
{
  public override void Configure()
  {
    Put(DummyItemUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemUpdateActionCommand request, CancellationToken cancellationToken)
  {
    var commandResult = await _mediator.Send(request, cancellationToken);

    if (!commandResult.IsSuccess)
    {
      await SendResultAsync(commandResult.ToMinimalApiResult());

      return;
    }

    var query = new DummyItemGetActionQuery(request.Id);

    var queryResult = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(queryResult.ToMinimalApiResult());
  }
}
