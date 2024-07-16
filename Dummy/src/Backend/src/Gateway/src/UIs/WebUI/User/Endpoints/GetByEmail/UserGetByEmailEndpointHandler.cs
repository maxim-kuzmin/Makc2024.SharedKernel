namespace Gateway.UIs.WebUI.User.Endpoints.GetByEmail;

public class UserGetByEmailEndpointHandler(IMediator _mediator) :
  Endpoint<UserGetByEmailEndpointRequest, UserGetByEmailActionDTO>
{
  public override void Configure()
  {
    Get(UserGetByEmailEndpointSettings.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(UserGetByEmailEndpointRequest request, CancellationToken cancellationToken)
  {
    var query = new UserGetByEmailActionQuery(request.Email);

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
