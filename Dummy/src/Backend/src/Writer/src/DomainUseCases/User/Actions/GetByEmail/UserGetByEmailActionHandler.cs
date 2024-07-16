namespace Gateway.DomainUseCases.User.Actions.GetByEmail;

public class UserGetByEmailActionHandler(IUserGetByEmailActionService _service) :
  IQueryHandler<UserGetByEmailActionQuery, Result<UserGetByEmailActionDTO>>
{
  public async Task<Result<UserGetByEmailActionDTO>> Handle(
    UserGetByEmailActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetByEmailAsync(request, cancellationToken);

    return result != null ? Result.Success(result) : Result.NotFound();
  }
}
