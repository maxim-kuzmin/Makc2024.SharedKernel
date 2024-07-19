﻿namespace Makc2024.Dummy.Gateway.UIs.WebUI.DummyItem.Endpoints.GetById;

public class DummyItemGetByIdEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetByIdEndpointRequest, DummyItemGetByIdActionDTO>
{
  public override void Configure()
  {
    Get(DummyItemGetByIdEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DummyItemGetByIdEndpointRequest request, CancellationToken cancellationToken)
  {
    var query = new DummyItemGetByIdActionQuery(request.Id);

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
